using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using Elcom.Models;
using Microsoft.AspNetCore.Mvc;

namespace Elcom.Controllers
{
    public class NextController : Controller
    {
        public ActionResult XlsxOrPartial(Action action, int partial, Param parameter = null)
        {
            if (partial == 0)
                return Helper.GetXlsxFile(action, parameter is null ? null : new Param[] { parameter });
            else
                return PartialView("_TargetTable", Helper.GetDataTable(action, parameter is null ? null : new Param[] { parameter }));
        }
        
        public ActionResult XlsxOrPartial(Action action, int partial, Param[] parameters)
        {
            if (partial == 0)
                return Helper.GetXlsxFile(action, parameters);
            else
                return PartialView("_TargetTable", Helper.GetDataTable(action, parameters));
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

            List<string> availableSheetsName = new List<string>();
            foreach (DataRow row in ((DataTable) caller.GetResult()).Rows)
            {
                availableSheetsName.Add(row[0].ToString());
            }

            List<Sheet> availableSheets =
                (List<Sheet>) Options.Sheets.Where(sheet => availableSheetsName.Contains(sheet.Name));
            return View("Main", availableSheets);
        }
        
        public ActionResult GetCommonSheet(string sheet, int action, int partial = 0)
        {
            var CurrentAction = Options.Sheets[sheet][action];
            List<Param> paramList = new List<Param>();
            foreach (var param in CurrentAction.parameters) //Request.Form
            {
                paramList.Add(new Param(param.Description, Request.Form[param.Name]));
            };
            return XlsxOrPartial(CurrentAction, partial, paramList.ToArray());
        }

        public ActionResult XlsxOrPartial(string sheetName, int partial, Param[] parameters)
        {
            if (partial == 0)
                return Helper.GetXlsxFile(sheetName, parameters);
            else
                return PartialView("_TargetTable", Helper.GetDataTable(sheetName, parameters));

            //return Content(Convert.ToBase64String(Helper.GetBytesArray("Purchaser", sheetName, parameters)));
        }

        [HttpGet]
        public ActionResult ShowPartialForm(string viewName)
        {
            return PartialView(viewName);
        }
    }
}