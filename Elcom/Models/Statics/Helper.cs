using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Elcom.Models
{
    /// <summary>
    /// Универсальный класс для быстрого выполнения обычных задач
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Класс для создания xlsx файла и последующего его сохранения в FileHolder
        /// </summary>
        /// <param name="sheet">Название листа</param>
        /// <param name="parameters">Параметр</param>
        /// <returns>Ключ файла для FileHolder</returns>
        public static short CreateXlsxFile(string sheet, Param[] parameters = null)
        {
            // Получаем лист
            Sheet currentSheet = Options.Sheets[sheet];
            // Заполняем команду названием процедуры из листа и параметрами
            var command = new FunctionCommand(currentSheet.Procedure, parameters);
            // Создаем воркер, даем ему имя из листа
            var worker = new ExcelWorker(currentSheet.Description);
            // Передаем все в каллер и результат работы возвращаем
            var caller = new DbCaller(command, worker);
            caller.DoWork();
            return FileHolder.AddFile((MemoryStream)caller.GetResult());
        }

        public static short CreateXlsxFile(Action action, Param[] parameters = null)
        {
            // Заполняем команду названием процедуры из листа и параметрами
            var command = new FunctionCommand(action.FunctionName, parameters);
            // Создаем воркер, даем ему имя из листа
            var worker = new ExcelWorker(action.NameRus);
            // Передаем все в каллер и результат работы возвращаем
            var caller = new DbCaller(command, worker);
            caller.DoWork();
            return FileHolder.AddFile((MemoryStream)caller.GetResult());
        }
        
        /// <summary>
        /// Производит действия по извлечению данных из БД и размещению их в Excel. Далее автоматически отдает на загрузку, если помещен после return
        /// </summary>
        /// <param name="sheet">Название листа</param>
        /// <param name="parameters">Параметр(ы)</param>
        public static FileStreamResult GetXlsxFile(string sheet, Param[] parameters = null)
        {
            // Получаем лист
            Sheet currentSheet = Options.Sheets[sheet];
            // Заполняем команду названием процедуры из листа и параметрами
            var command = new FunctionCommand(currentSheet.Procedure, parameters);
            // Создаем воркер, даем ему имя из листа
            var worker = new ExcelWorker(currentSheet.Description);
            // Передаем все в каллер и результат работы возвращаем
            var caller = new DbCaller(command, worker);
            caller.DoWork();
            return DownloadXlsxFile((MemoryStream)caller.GetResult(), currentSheet.Description);
        }
        
        public static FileStreamResult GetXlsxFile(Action action, Param[] parameters = null)
        {
            // Заполняем команду названием процедуры из листа и параметрами
            var command = new FunctionCommand(action.FunctionName, parameters);
            // Создаем воркер, даем ему имя из листа
            var worker = new ExcelWorker(action.NameRus);
            // Передаем все в каллер и результат работы возвращаем
            var caller = new DbCaller(command, worker);
            caller.DoWork();
            return DownloadXlsxFile((MemoryStream)caller.GetResult(), action.NameRus);
        }

        /// <summary>
        /// Перегрузка, принимающая один параметр функции вместо массива параметров функции
        /// </summary>
        public static FileStreamResult GetXlsxFile(string sheet, Param parameter)
        {
            return GetXlsxFile(sheet, new Param[] { parameter });
        }

        public static DataTable GetDataTable(string sheet, Param[] parameters = null)
        {
            // Получаем лист
            Sheet currentSheet = Options.Sheets[sheet];
            // Заполняем команду названием процедуры из листа и параметрами
            var command = new FunctionCommand(currentSheet.Procedure, parameters);
            // Передаем все в каллер и результат работы возвращаем
            var caller = new DbCaller(command);
            caller.DoWork();
            return (DataTable)caller.GetResult();
        }
        
        public static DataTable GetDataTable(Action action, Param[] parameters = null)
        {
            // Заполняем команду названием процедуры из листа и параметрами
            var command = new FunctionCommand(action.FunctionName, parameters);
            // Передаем все в каллер и результат работы возвращаем
            var caller = new DbCaller(command);
            caller.DoWork();
            return (DataTable)caller.GetResult();
        }

        /// <summary>
        /// Перегрузка, принимающая один параметр функции вместо массива параметров функции
        /// </summary>
        public static DataTable GetDataTable(string sheet, Param parameter)
        {
            return GetDataTable(sheet, new Param[] { parameter });
        }

        /// <summary>
        /// Возвращает файл для дальнейшей скачки
        /// </summary>
        /// <param name="result">Результат работы DbCaller. Обязательно в виде потока памяти, иначе файл будет поврежден</param>
        /// <param name="name">Влияет на название скачиваемого файла</param>
        static FileStreamResult DownloadXlsxFile(MemoryStream result, string name)
        {
            return new FileStreamResult(result, "application/octet-stream")
            {
                FileDownloadName = name + " " + DateTime.Now + ".xlsx"
            };
        }
        
        /// <summary>
        /// Переводит русские символы в читабельный формат и возвращает готовую строку. Аналог ConvertFromOracle из VBA
        /// </summary>
        public static string ConvertFromOracle(string text)
        {
            string readyText = "";
            // Проходим по каждому символу и меняем его код. Алгоритм взят из VBA
            foreach (var part in text)
            {
                int b = Strings.AscW(part);
                readyText += Strings.ChrW((b == 191 ? 1103 : b >= 192 & b <= 255 ? b + 848 : b));
            }
            return readyText;
        }
        
        /// <summary>
        /// Находит в запросе все строки с русскими словами и конвертирует их в набор соединенных CHR, далее возвращает обработанную строку. Аналог ConvertRussianStr из VBA
        /// </summary>
        public static string ConvertRusWordsToCHR(string text)
        {
            string readyString = text;
            // Через регулярное выражение ищем все строки, содержащие русские символы или пробелы, формируем массив из уникальных строк средствами Linq
            var russianWords = Regex.Matches(text, @"'[А-Я|\s]*'", RegexOptions.IgnoreCase).Select(x => x.Value).Distinct();
            foreach (var word in russianWords)
            {
                // Удаляем кавычки
                string unquotedWord = word.Replace("'", "");
                string readyWord = "";
                // Проходим по каждому символу и заменяем его на CHR(), цифры взяты из конвертации из оракла, но в обратном порядке
                foreach (char letter in unquotedWord)
                {
                    int chr = Strings.AscW(letter);
                    if (letter != ' ')
                    {
                        readyWord += "CHR(" + (chr == 1103 ? 191 : chr >= 1040 & chr <= 1103 ? chr - 848 : chr) + ")";
                        //ReadyWord += "CHR(" + ASCII.GetBytes(letter.ToString())[0] + ")";
                    }
                    else
                        readyWord += "CHR(32)";
                }
                // Разделяем CHR конкатенацией
                readyString = readyString.Replace(word, readyWord.Replace(")CHR(", ")||CHR("));
            }
            return readyString;
        }
        
/// <summary>
/// Все значения в таблице конвертирует из оракла. Может принимать датасет(Редактирует первую таблицу)
/// </summary>
        public static DataTable ConvertTableFromOracle(DataTable table)
        {
            foreach (DataColumn col in table.Columns)
            {
                col.ColumnName = ConvertFromOracle(col.ColumnName);
            }
            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    if (row[i].ToString() != "")
                        row[i] = ConvertFromOracle(row.ItemArray[i].ToString());
                }
            }

            return table;
        }
        public static DataSet ConvertTableFromOracle(DataSet ds)
        {
            ConvertTableFromOracle(ds.Tables[0]);
            return ds;
        }

        public static string DateToMaconomy(DateTime date)
        {
            return date.ToString("dd.mm.yyyy");
        }
        public static string DateToOracle(DateTime date)
        {
            return date.ToString("yyyy.mm.dd");
        }
        public static string DateToMaconomy(string date)
        {
            return DateTime.Parse(date).ToString("dd.mm.yyyy");
        }
        public static string DateToOracle(string date)
        {
            return DateTime.Parse(date).ToString("yyyy.mm.dd");
        }
    }
}
