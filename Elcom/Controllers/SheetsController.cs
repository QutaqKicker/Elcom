using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Claims;
using System.Threading.Tasks;
using Elcom.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;

namespace Elcom.Controllers
{
    public class SheetsController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("Home/Main");
        }
        
        public FileStreamResult DownloadXlsxFile(MemoryStream result, string name)
        {
            return new FileStreamResult(result, "application/octet-stream")
            {
                FileDownloadName = name + " " + DateTime.Now.ToString() + ".xlsx"
            };
        }
        
        public IActionResult Main()
        {
            ViewData["Title"] = "Главное меню";
            var command = new FunctionCommand("table(pkg_cmacros.getSheets)", new Param[] { new Param("accesslevel", User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value) });
            var caller = new DbCaller(command);
            caller.DoWork();
            if (((DataTable)caller.GetResult()).Rows.Count == 0)
            {
                ViewBag.Message = "Данному пользователю недоступны какие-либо действия!";
                return RedirectToAction("Login", "Home");
            }
            return View("Main", caller.GetResult());
        }

        public ActionResult XlsxOrPartial(string sheetName, int partial, Param[] parameters)
        {
            if (partial == 0)
                return Helper.GetXlsxFile(sheetName, parameters);
            else
                return PartialView("_TargetTable", Helper.GetDataTable(sheetName, parameters));

            //return Content(Convert.ToBase64String(Helper.GetBytesArray("Purchaser", sheetName, parameters)));
        }

        public ActionResult XlsxOrPartial(string sheetName, int partial, Param parameter = null)
        {
            if (partial == 0)
                return Helper.GetXlsxFile(sheetName, parameter is null ? null : new Param[] { parameter });
            else
                return PartialView("_TargetTable", Helper.GetDataTable(sheetName, parameter is null ? null : new Param[] { parameter }));
        }

        public ActionResult GetReadyFile(string name, short key)
        {
            return DownloadXlsxFile(FileHolder.GetFile(key), name);
        }
        
        public ActionResult GetDelayedIPO(int partial)
        {
            return XlsxOrPartial("GetDelayedIPO", partial);
        }

        [HttpGet]
        public ActionResult GetDelayedSO()
        {
            // Вызов осуществляется не через хелпер, так как функционал не так прост. Нужно передать извлеченную информацию в частичное представление. Сам метод работает в аяксе
            var command = new FunctionCommand(Options.Sheets["GetDelayedSO"].Procedure);
            var caller = new DbCaller(command);
            caller.DoWork();
            return PartialView("_DelayedSO", (DataTable) caller.GetResult());

            /*
            var command = new TextCommand(@"select 1 ""OrderNumber"", 1 ""LineNumber"", 1 ""DelayedDays"", 1 ""SupplementaryText5"", rf.* from dbo.""RefFoms"" rf", Returns.Table);
            var caller = new DbCaller(command, null, "PgSQL2");
            caller.DoWork();
            return PartialView("_DelayedSO", (DataTable)caller.GetResult());
            /*
            Sheet currentSheet = Purchaser.GetSheet("Задерживается ЗК");
            var command = new FunctionCommand(currentSheet.Procedure);
            var caller = new DbCaller(command);
            caller.DoWork();
            return PartialView("_DelayedSO", (DataTable)caller.GetResult());
            */
        }

        [HttpGet]
        public ActionResult FillPartialTable(string sheetName, Param[] parameters)
        {
            var command = new FunctionCommand(Options.Sheets[sheetName].Procedure);
            var caller = new DbCaller(command);
            caller.DoWork();
            return PartialView("_GetDelayedSO", (DataTable)caller.GetResult());
        }

        [HttpGet]
        public ActionResult ShowPartialForm(string viewName)
        {
            return PartialView(viewName);
        }

        [HttpGet]
        public ActionResult UpdateDelayedSO(string orderNumber, int lineNumber, string delayedDays, string supplementaryText5, int post = -1)
        {
            if (post != -1)
            {
                Random rnd = new Random();
                int value = rnd.Next(0, 10);
                return Content(value > 5 ? post.ToString() : post.ToString());
            }
            else
                return Content("Ожидание");
            
            // Обновление данных
            Param[] parameters =
            {
                new Param("fDecision", "Отправить запрос МП"), new Param("fYourRequest", "Не отправлен"), new Param("fDelayNumber", delayedDays),
                new Param("fDelay", supplementaryText5), new Param("fOrdernumb", orderNumber), new Param("fLinenumb", lineNumber)
            };
            var command = new ProcedureCommand(Options.Sheets["Обновление задерж. ЗК"].Procedure, parameters, Returns.Nothing);
            var caller = new DbCaller(command);
            try
            {
                caller.DoWork();
            }
            catch
            {
                return Content("Обновить данные не удалось!");
            }
            // Проверка, обновились ли данные. Возвращает простой текст в HTML страничку по итогам проверки
            var checkCommand = new TextCommand(string.Format("select 1 result from OrderLine where OrderNumber = {0} and LineNumber = {1} SupplementaryText5 like '%LETTER%'", orderNumber, lineNumber));
            var checkCaller = new DbCaller(checkCommand);
            try
            {
                checkCaller.DoWork();
                return Content(checkCaller.GetResult().ToString().Equals("1") ? "Успешно" : "Неуспешно");
            }
            catch (Exception e)
            {
                return Content("Проверка неуспешна");
            }
        }

        //TODO Не реализовано. Жду реализации функции от коллег
        public ActionResult GetUpdateDeliveryDates(string vendorNumbers, string dates, string numberPOs, string numberIPOs, Inventory inventory)
        {
            // Пилим список столбцов файла импорта
            List<ImportColumn> listOfColumns = new List<ImportColumn>();
            
            // Класс колонки сам распарсит строку
            // Если в строке всего один ряд, он возмет строку как значение по умолчанию
            var IPOColumn = new ImportColumn("ItemPurchaseOrderNumber", vendorNumbers);
            listOfColumns.Add(IPOColumn);
            var LinesColumn = new ImportColumn("LineNumber", "1");
            listOfColumns.Add(LinesColumn);
            var ItemsColumn = new ImportColumn("ItemNumber", "itemnumber");
            listOfColumns.Add(ItemsColumn);
            var Date2Column = new ImportColumn("Date2", dates);
            listOfColumns.Add(Date2Column);
            
            // Подгружаем из базы необходимые данные
            
            listOfColumns.Add(new ImportColumn("ExpectedCommitmentDate", numberPOs));
            listOfColumns.Add(new ImportColumn("Date1", numberIPOs));
            listOfColumns.Add(new ImportColumn("Date4", numberIPOs));
            // Создаем секцию файла импорта, передав ему название таблицы, режим и список столбцов и их значений
            var importSection = new ImportSection("ITEMPURCHASELINE", ImportMode.CreateChange, listOfColumns);
            // Создаем класс-создатель файла импорта
            var importWorker = new ImportWorker("GetUpdateDeliveryDates");
            // Передаем ему секцию и заставляем работать.
            importWorker.DoWork(importSection);
            return DownloadTxt(importWorker.GetResult(), "test");
        }

        public ActionResult GetReception(int inventory, int partial = 0)
        {
            return XlsxOrPartial("GetReception", partial, new Param("№ Склада", inventory.ToString()));
        }

        public ActionResult GetLoadPrice(int numberIPO)
        {
            var command = new FunctionCommand("table(pkg_cmacros.LoadPriceToIPO)");
            var caller = new DbCaller(command);
            caller.DoWork();
            return PartialView("_LoadPrice", (DataTable) caller.GetResult());
            //return Helper.GetXlsxFile("Purchaser", "LoadPrice", new Param("№ ЗП", numberIPO));
        }
        
        public ActionResult GetImportFileForLoadPrice(string numberIPOs, string lineNumbers, string itemNumbers, string newPrices)
        {
            List<ImportColumn> listOfColumns = new List<ImportColumn>();
            
            listOfColumns.Add(new ImportColumn("ItemPurchaseOrderNumber", numberIPOs));
            listOfColumns.Add(new ImportColumn("LineNumber", lineNumbers));
            listOfColumns.Add(new ImportColumn("ItemNumber", itemNumbers));
            listOfColumns.Add(new ImportColumn("UnitPriceCurrency", newPrices));
                
            var importSection = new ImportSection("ITEMPURCHASELINE", ImportMode.Change, listOfColumns);
            
            var worker = new ImportWorker("LoadPricesToIPO");
            
            worker.DoWork(importSection);
            return DownloadTxt(worker.GetResult(), "test");
        }

        public ActionResult GetLackOfItems(object inventory, int partial = 0)
        {
            return XlsxOrPartial("GetLackOfItems", partial, new Param("№ Склада", inventory.ToString()));
        }

        public ActionResult GetGTD(string itemNumber, int inventory, DateTime fromDate, DateTime toDate, int partial = 0)
        {
            return XlsxOrPartial("GetGTD", partial, new Param[] { new Param("№ товара", itemNumber), new Param("№ Склада", inventory), new Param("Период от", Helper.DateToOracle(fromDate)), new Param("Период до", Helper.DateToOracle(toDate))}
                );
        }

        public ActionResult GetLackOfItemsForSO(int partial = 0)
        {
            return XlsxOrPartial("GetLackOfItemsForSO", partial);
        }

        public ActionResult GetRejectedSO(int partial = 0)
        {
            return XlsxOrPartial("GetRejectedSO", partial);
        }

        public ActionResult GetAddToIPO(string vendorNumber, int monthPeriod /*Период 1/3/6 месяцев*/, int partial = 0)
        {
            return XlsxOrPartial("GetAddToIPO", partial, new Param[] {new Param("№ поставщика", vendorNumber), new Param("Период (Месяцев)", monthPeriod)
            });
        }

        public ActionResult GetKPIMZ(DateTime fromDate, DateTime toDate, string orderType/*, выбор Выгрузка по КП или выгрузка по ЗК*/, int partial = 0)
        {
            if (orderType.Equals("KP"))
                return XlsxOrPartial("KPI МЗ КП", partial, new Param[] {new Param("Период с", fromDate), new Param("Период по", toDate)});
            else 
                return XlsxOrPartial("KPI МЗ ЗК", partial, new Param[] {new Param("Период с", fromDate), new Param("Период по", toDate)});
        }
         
        public ActionResult GetLoadPurchasePriceToQuote(string orderNumbers, string date1, string lineNumbers, string amount4s)
        {
            List<ImportColumn> listOfColumns = new List<ImportColumn>();
            
            var orderNumberColumn = new ImportColumn("OrderNumber", orderNumbers);
            
            listOfColumns.Add(new ImportColumn("OrderNumber", orderNumberColumn[0]));
            listOfColumns.Add(new ImportColumn("OrderType", "Комм. предложение"));
            listOfColumns.Add(new ImportColumn("Date1", date1));
                
            var importSection = new ImportSection("ORDERHEADER", ImportMode.Change, listOfColumns);
            
            List<ImportColumn> secondListOfColumns = new List<ImportColumn>();

            secondListOfColumns.Add(orderNumberColumn);
            secondListOfColumns.Add(new ImportColumn("OrderType", "Комм. предложение"));
            secondListOfColumns.Add(new ImportColumn("LineNumber", lineNumbers));
            secondListOfColumns.Add(new ImportColumn("Amount4", amount4s));
                
            var secondImportSection = new ImportSection("ORDERLINE", ImportMode.Change, listOfColumns);
            
            var worker = new ImportWorker("LoadPricesToIPO");

            worker.DoWork(ImportWorker.CreateDataSet(new ImportSection[] {importSection, secondImportSection}));
            return DownloadTxt(worker.GetResult(), "test");
        }
        
        public ActionResult GetShipmentFromVendor(string vendorNumber, string shipmentDate, bool checkSO, int partial = 0)
        {
            return XlsxOrPartial("GetShipmentFromVendor", partial, new[]{new Param("Номер поставщика", vendorNumber)
                        , new Param("Дата", shipmentDate)
                        , new Param("Только заказы", checkSO ? 1 : 0) });
        }
        // Метод для отдачи на скачку готового документа 
        FileContentResult DownloadXlsx(object result, string name)
        {
            return File(
                fileContents: (byte[])result,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: name + " " + DateTime.Now.ToString() + ".xlsx"
            );
        }
        FileContentResult DownloadTxt(object result, string name)
        {
            return File((byte[])result, "text/plain", name + " " + DateTime.Now.ToString() + ".txt");
        }
    }
}