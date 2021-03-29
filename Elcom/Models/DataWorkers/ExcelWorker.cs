using Elcom.Models;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Data;
using System.IO;
// ReSharper disable All

namespace Elcom
{
    /// <summary>
    /// Класс для работы с выгруженными данными в xlsx формате
    /// </summary>
    public class ExcelWorker : DataWorker
    {
        List<Param> paramList;

        MemoryStream FilledFile;

        private string[] _ignoreColumns;

        int StartX = 1, StartY = 1;
        public ExcelWorker(string name, string[] ignoreColumns = null)
        {
            Name = name;
            _ignoreColumns = ignoreColumns;
        }

        private string CreateFile(string name)
        {
            // Если такого файла нет, то копируем его шаблон в целевую папку,
            // если есть, то считаем сколько таких файлов есть и копируем его шаблон с крайним порядковым числом.
            // Метод возвращает название созданного файла
            if (!System.IO.File.Exists(TempFilePath + name + ".xlsx"))
            {
                System.IO.File.Copy(TemplatesPath + name + ".xlsx", TempFilePath + name + ".xlsx");
                return name;
            }
            else
            {
                int i = 1;
                while (System.IO.File.Exists(TempFilePath + name + i + ".xlsx"))
                {
                    i++;
                }
                System.IO.File.Copy(TemplatesPath + name + ".xlsx", TempFilePath + name + i + ".xlsx");
                return name + i;
            }
        }
        public string GetName()
        {
            return Name;
        }
        /// <summary>
        /// Изменяет стартовую позицию у выгрузки, включая заголовок(!)
        /// </summary>
        private void SetStartPosition(int x, int y)
        {
            StartX = x;
            StartY = y;
        }

        private void SetParamForView(List<Param> param)
        {
            paramList = param;
            SetStartPosition(param.Count + 1, 1);
        }

        public void SetParamForView(Param[] param)
        {
            paramList = new List<Param>();
            foreach (Param p in param)
            {
                paramList.Add(p);
            }
            SetStartPosition(paramList.Count + 1, 1);
        }

        public override void DoWork(DataSet ds)
        {
            Name = CreateFile(Name);
            FillFile(Name, ds.Tables[0]);
        }
        public MemoryStream GetFile()
        {
            return FilledFile;
        }
        public void FillFile(string name, DataTable dt)
        {
            FilledFile = new MemoryStream();
            // Открываем скопированный шаблон и передаем его обработчику. Если передать сам шаблон, может быть конфликт при одновременном доступе.
            FileStream fs = File.OpenRead(TempFilePath + name + ".xlsx");
            using (var package = new ExcelPackage(fs))
            {
                // Берем первый лист и начинаем работать с ним
                var worksheet = package.Workbook.Worksheets[1];

                int i = 1;
                // Вставляем новые строчки сверху, дабы параметры не налезали на шаблон
                worksheet.InsertRow(1, StartX - 1);
                // Выводим вводимые пользователем параметры
                if (!(paramList is null))
                    foreach (var param in paramList)
                    {
                        worksheet.Cells[i, 1].Value = param.Description;
                        worksheet.Cells[i, 2].Style.Numberformat.Format = "@";
                        worksheet.Cells[i++, 2].Value = param.Value;
                    }

                int x = StartX;
                int y = StartY;
                // Вносим в файл заголовки столбцов. Данные через хелпер приводим к читабельному виду. Из за разности кодировок приходится этим заниматься 
                foreach (DataColumn head in dt.Columns)
                {
                    worksheet.Cells[x, y++].Value = head.ColumnName;
                    //worksheet.Cells[x, y++].Value = Helper.ConvertFromOracle(head.ColumnName);
                }
                x++;
                // Вносим всю оставшуюся информацию в файл согласно данным в DataSet
                foreach (DataRow row in dt.Rows)
                {
                    y = StartY;
                    foreach (var col in row.ItemArray)
                    {
                        worksheet.Cells[x, y++].Value = col is null ? "" : col.ToString();
                        //worksheet.Cells[x, y++].Value = Helper.ConvertFromOracle(col.ToString());
                    }
                    x++;
                }
                // Сохраняем изменения в пакете и сохраняем содержимое пакета в виде потока в классе
                //FilledBytes = package.GetAsByteArray();
                package.SaveAs(FilledFile);
            }
            FilledFile.Position = 0;
            fs.Close();
            // Закрываем читалку и удаляем скопированный шаблон. Выходной файл в виде потока уже сохранен в классе
            File.Delete(TempFilePath + name + ".xlsx");
        }
    }
}