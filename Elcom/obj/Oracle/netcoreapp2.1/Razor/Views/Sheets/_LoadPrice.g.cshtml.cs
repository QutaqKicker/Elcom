#pragma checksum "C:\Users\asadykov\source\repos\foms-smev-service\Elcom\Views\Sheets\_LoadPrice.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e1a8beaaf3350eee7ca150b176be79d8f737dc23"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Sheets__LoadPrice), @"mvc.1.0.view", @"/Views/Sheets/_LoadPrice.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Sheets/_LoadPrice.cshtml", typeof(AspNetCore.Views_Sheets__LoadPrice))]
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
#line 1 "C:\Users\asadykov\source\repos\foms-smev-service\Elcom\Views\_ViewImports.cshtml"
using Elcom;

#line default
#line hidden
#line 2 "C:\Users\asadykov\source\repos\foms-smev-service\Elcom\Views\_ViewImports.cshtml"
using Elcom.Models;

#line default
#line hidden
#line 1 "C:\Users\asadykov\source\repos\foms-smev-service\Elcom\Views\Sheets\_LoadPrice.cshtml"
using System.Data;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e1a8beaaf3350eee7ca150b176be79d8f737dc23", @"/Views/Sheets/_LoadPrice.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d596a95d4a3b676f547551363826836a2c5ce762", @"/Views/_ViewImports.cshtml")]
    public class Views_Sheets__LoadPrice : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DataTable>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("NewPricesToLoadIPO"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(39, 194, true);
            WriteLiteral("\r\n<div>\r\n    <button onclick=\"LoadPriceSubmit()\">Сформировать файл импорта</button>\r\n    <button onclick=\"console.log($(`#Complete0`).innerHTML);\">Отправить</button>\r\n    <table>\r\n        <tr>\r\n");
            EndContext();
#line 9 "C:\Users\asadykov\source\repos\foms-smev-service\Elcom\Views\Sheets\_LoadPrice.cshtml"
             foreach (DataColumn col in @Model.Columns)
            {

#line default
#line hidden
            BeginContext(305, 20, true);
            WriteLiteral("                <td>");
            EndContext();
            BeginContext(326, 14, false);
#line 11 "C:\Users\asadykov\source\repos\foms-smev-service\Elcom\Views\Sheets\_LoadPrice.cshtml"
               Write(col.ColumnName);

#line default
#line hidden
            EndContext();
            BeginContext(340, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 12 "C:\Users\asadykov\source\repos\foms-smev-service\Elcom\Views\Sheets\_LoadPrice.cshtml"
            }

#line default
#line hidden
            BeginContext(362, 48, true);
            WriteLiteral("            <td>Новая цена</td>\r\n        </tr>\r\n");
            EndContext();
#line 15 "C:\Users\asadykov\source\repos\foms-smev-service\Elcom\Views\Sheets\_LoadPrice.cshtml"
           var i = 0; 

#line default
#line hidden
            BeginContext(435, 8, true);
            WriteLiteral("        ");
            EndContext();
#line 16 "C:\Users\asadykov\source\repos\foms-smev-service\Elcom\Views\Sheets\_LoadPrice.cshtml"
         foreach (DataRow row in @Model.Rows)
        {

#line default
#line hidden
            BeginContext(493, 18, true);
            WriteLiteral("            <tr>\r\n");
            EndContext();
#line 19 "C:\Users\asadykov\source\repos\foms-smev-service\Elcom\Views\Sheets\_LoadPrice.cshtml"
                 foreach (var item in row.ItemArray)
                {

#line default
#line hidden
            BeginContext(584, 24, true);
            WriteLiteral("                    <td>");
            EndContext();
            BeginContext(609, 15, false);
#line 21 "C:\Users\asadykov\source\repos\foms-smev-service\Elcom\Views\Sheets\_LoadPrice.cshtml"
                   Write(item.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(624, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 22 "C:\Users\asadykov\source\repos\foms-smev-service\Elcom\Views\Sheets\_LoadPrice.cshtml"
                }

#line default
#line hidden
            BeginContext(650, 42, true);
            WriteLiteral("                <td>\r\n                    ");
            EndContext();
            BeginContext(692, 417, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "367514d0bc5a4023812421f76dcda5a4", async() => {
                BeginContext(725, 63, true);
                WriteLiteral("\r\n                        <input type=\"hidden\" name=\"IPONumber\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 788, "\"", 816, 1);
#line 25 "C:\Users\asadykov\source\repos\foms-smev-service\Elcom\Views\Sheets\_LoadPrice.cshtml"
WriteAttributeValue("", 796, row["Номер_заказа"], 796, 20, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(817, 66, true);
                WriteLiteral("/>\r\n                        <input type=\"hidden\" name=\"LineNumber\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 883, "\"", 911, 1);
#line 26 "C:\Users\asadykov\source\repos\foms-smev-service\Elcom\Views\Sheets\_LoadPrice.cshtml"
WriteAttributeValue("", 891, row["Номер_строки"], 891, 20, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(912, 66, true);
                WriteLiteral("/>\r\n                        <input type=\"hidden\" name=\"ItemNumber\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 978, "\"", 1006, 1);
#line 27 "C:\Users\asadykov\source\repos\foms-smev-service\Elcom\Views\Sheets\_LoadPrice.cshtml"
WriteAttributeValue("", 986, row["Номер_товара"], 986, 20, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1007, 95, true);
                WriteLiteral("/>\r\n                        <input type=\"text\" name=\"NewPrice\" value=\"\"/>\r\n                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1109, 25, true);
            WriteLiteral("\r\n                </td>\r\n");
            EndContext();
#line 31 "C:\Users\asadykov\source\repos\foms-smev-service\Elcom\Views\Sheets\_LoadPrice.cshtml"
                   i++; 

#line default
#line hidden
            BeginContext(1161, 19, true);
            WriteLiteral("            </tr>\r\n");
            EndContext();
#line 33 "C:\Users\asadykov\source\repos\foms-smev-service\Elcom\Views\Sheets\_LoadPrice.cshtml"
        }

#line default
#line hidden
            BeginContext(1191, 24, true);
            WriteLiteral("    </table>\r\n</div>\r\n\r\n");
            EndContext();
            BeginContext(1216, 92, false);
#line 37 "C:\Users\asadykov\source\repos\foms-smev-service\Elcom\Views\Sheets\_LoadPrice.cshtml"
Write(Html.BeginForm("GetImportFileForLoadPrice", "Sheets", FormMethod.Get, new {id="LoadPrices"}));

#line default
#line hidden
            EndContext();
            BeginContext(1308, 274, true);
            WriteLiteral(@"{
<input type=""hidden"" name=""numberIPOs"" id=""numberIPOsLoadPrice""/>
<input type=""hidden"" name=""lineNumbers"" id=""lineNumbersLoadPrice""/>
<input type=""hidden"" name=""itemNumbers"" id=""itemNumbersLoadPrice""/>
<input type=""hidden"" name=""newPrices"" id=""newPricesLoadPrice""/>
}");
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
