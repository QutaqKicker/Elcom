#pragma checksum "F:\Диплом\NewElcom\Elcom\Views\Sheets\_DelayedSO.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bda9d66fd92eb074103dcdcfc625639610521cd4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Sheets__DelayedSO), @"mvc.1.0.view", @"/Views/Sheets/_DelayedSO.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Sheets/_DelayedSO.cshtml", typeof(AspNetCore.Views_Sheets__DelayedSO))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "F:\Диплом\NewElcom\Elcom\Views\_ViewImports.cshtml"
using Elcom;

#line default
#line hidden
#line 2 "F:\Диплом\NewElcom\Elcom\Views\_ViewImports.cshtml"
using Elcom.Models;

#line default
#line hidden
#line 1 "F:\Диплом\NewElcom\Elcom\Views\Sheets\_DelayedSO.cshtml"
using System.Data;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bda9d66fd92eb074103dcdcfc625639610521cd4", @"/Views/Sheets/_DelayedSO.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d596a95d4a3b676f547551363826836a2c5ce762", @"/Views/_ViewImports.cshtml")]
    public class Views_Sheets__DelayedSO : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DataTable>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(39, 347, true);
            WriteLiteral(@"
<div class=""row"">
    <div class=""col"">
        <button type=""button"" class=""btn btn-outline-primary btn-sm btn-block workingButton"" onclick=""UpdateSalesOrders();"">Отправить</button>
    </div>
</div>
<table class=""contentTable"" style=""display: block;"">
    <thead>
    <tr>
        <th>Успех</th>
        <th>Отправить запрос МП</th>
");
            EndContext();
#line 14 "F:\Диплом\NewElcom\Elcom\Views\Sheets\_DelayedSO.cshtml"
         foreach (DataColumn col in @Model.Columns)
        {

#line default
#line hidden
            BeginContext(450, 16, true);
            WriteLiteral("            <th>");
            EndContext();
            BeginContext(467, 14, false);
#line 16 "F:\Диплом\NewElcom\Elcom\Views\Sheets\_DelayedSO.cshtml"
           Write(col.ColumnName);

#line default
#line hidden
            EndContext();
            BeginContext(481, 7, true);
            WriteLiteral("</th>\r\n");
            EndContext();
#line 17 "F:\Диплом\NewElcom\Elcom\Views\Sheets\_DelayedSO.cshtml"
        }

#line default
#line hidden
            BeginContext(499, 38, true);
            WriteLiteral("    </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 21 "F:\Диплом\NewElcom\Elcom\Views\Sheets\_DelayedSO.cshtml"
       var i = 0; 

#line default
#line hidden
            BeginContext(558, 4, true);
            WriteLiteral("    ");
            EndContext();
#line 22 "F:\Диплом\NewElcom\Elcom\Views\Sheets\_DelayedSO.cshtml"
     foreach (DataRow row in @Model.Rows)
    {

#line default
#line hidden
            BeginContext(608, 52, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                <div");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 660, "\"", 677, 2);
            WriteAttributeValue("", 665, "Complete", 665, 8, true);
#line 26 "F:\Диплом\NewElcom\Elcom\Views\Sheets\_DelayedSO.cshtml"
WriteAttributeValue("", 673, i, 673, 4, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(678, 40, true);
            WriteLiteral(">Ожидание</div></td>\r\n            <td>\r\n");
            EndContext();
#line 28 "F:\Диплом\NewElcom\Elcom\Views\Sheets\_DelayedSO.cshtml"
                 using (Html.BeginForm("UpdateDelayedSO", "Sheets", FormMethod.Post, new {@class = "UpdateSO"}))
                {

#line default
#line hidden
            BeginContext(851, 50, true);
            WriteLiteral("                <input type=\"checkbox\" name=\"post\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 901, "\"", 913, 1);
#line 30 "F:\Диплом\NewElcom\Elcom\Views\Sheets\_DelayedSO.cshtml"
WriteAttributeValue("", 909, i, 909, 4, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(914, 60, true);
            WriteLiteral(" />\r\n                <input type=\"hidden\" name=\"orderNumber\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 974, "\"", 1007, 1);
#line 31 "F:\Диплом\NewElcom\Elcom\Views\Sheets\_DelayedSO.cshtml"
WriteAttributeValue("", 982, row["Заказа_клиента_Но"], 982, 25, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1008, 59, true);
            WriteLiteral(" />\r\n                <input type=\"hidden\" name=\"lineNumber\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1067, "\"", 1092, 1);
#line 32 "F:\Диплом\NewElcom\Elcom\Views\Sheets\_DelayedSO.cshtml"
WriteAttributeValue("", 1075, row["Строка_Но"], 1075, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1093, 60, true);
            WriteLiteral(" />\r\n                <input type=\"hidden\" name=\"delayedDays\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1153, "\"", 1188, 1);
#line 33 "F:\Диплом\NewElcom\Elcom\Views\Sheets\_DelayedSO.cshtml"
WriteAttributeValue("", 1161, row["Дни_задержки_кол_во"], 1161, 27, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1189, 67, true);
            WriteLiteral(" />\r\n                <input type=\"hidden\" name=\"supplementaryText5\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1256, "\"", 1284, 1);
#line 34 "F:\Диплом\NewElcom\Elcom\Views\Sheets\_DelayedSO.cshtml"
WriteAttributeValue("", 1264, row["Дни_задержки"], 1264, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1285, 5, true);
            WriteLiteral(" />\r\n");
            EndContext();
#line 35 "F:\Диплом\NewElcom\Elcom\Views\Sheets\_DelayedSO.cshtml"
                }

#line default
#line hidden
            BeginContext(1309, 16, true);
            WriteLiteral("                ");
            EndContext();
#line 36 "F:\Диплом\NewElcom\Elcom\Views\Sheets\_DelayedSO.cshtml"
                   i++; 

#line default
#line hidden
            BeginContext(1336, 19, true);
            WriteLiteral("            </td>\r\n");
            EndContext();
#line 38 "F:\Диплом\NewElcom\Elcom\Views\Sheets\_DelayedSO.cshtml"
             foreach (var item in row.ItemArray)
            {

#line default
#line hidden
            BeginContext(1420, 20, true);
            WriteLiteral("                <td>");
            EndContext();
            BeginContext(1441, 15, false);
#line 40 "F:\Диплом\NewElcom\Elcom\Views\Sheets\_DelayedSO.cshtml"
               Write(item.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(1456, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 41 "F:\Диплом\NewElcom\Elcom\Views\Sheets\_DelayedSO.cshtml"
            }

#line default
#line hidden
            BeginContext(1478, 15, true);
            WriteLiteral("        </tr>\r\n");
            EndContext();
#line 43 "F:\Диплом\NewElcom\Elcom\Views\Sheets\_DelayedSO.cshtml"
    }

#line default
#line hidden
            BeginContext(1500, 22, true);
            WriteLiteral("    </tbody>\r\n</table>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DataTable> Html { get; private set; }
    }
}
#pragma warning restore 1591
