#pragma checksum "F:\Диплом\NewElcom\Elcom\Views\Sheets\_GetKPIMZ.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9524e2feda952adbadd415aaa879bdc52eda0833"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Sheets__GetKPIMZ), @"mvc.1.0.view", @"/Views/Sheets/_GetKPIMZ.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Sheets/_GetKPIMZ.cshtml", typeof(AspNetCore.Views_Sheets__GetKPIMZ))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9524e2feda952adbadd415aaa879bdc52eda0833", @"/Views/Sheets/_GetKPIMZ.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d596a95d4a3b676f547551363826836a2c5ce762", @"/Views/_ViewImports.cshtml")]
    public class Views_Sheets__GetKPIMZ : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "F:\Диплом\NewElcom\Elcom\Views\Sheets\_GetKPIMZ.cshtml"
 using (Html.BeginForm("GetKPIMZ", "Sheets", FormMethod.Get))
{

#line default
#line hidden
            BeginContext(66, 1231, true);
            WriteLiteral(@"    <div class=""row"">
        <div class=""col"">
            <input type=""date"" class=""btn btn-outline-primary btn-sm btn-block workingButton"" data-toggle=""tooltip"" title=""Введите период с дд.мм.гг"" placeholder=""Дата"" name=""fromDate"" required>
        </div>	
    </div>
    <div class=""row"">
        <div class=""col"">
            <input type=""date"" class=""btn btn-outline-primary btn-sm btn-block workingButton"" data-toggle=""tooltip"" title=""Введите период по дд.мм.гг"" placeholder=""Дата"" name=""toDate"" required>
        </div>	
    </div>
    <div class=""row"">
        <div class=""col"">									
            <input type=""radio"" id=""onlyZK"" class=""workingButton"" data-toggle=""tooltip"" title=""Выберите, если нужна выгрузка по КП"" placeholder=""Только под КП"" name=""orderType"" value=""KP"">
            <label for=""onlyZK""><p>Выгрузка по КП</p></label>
        </div>	
    </div>
    <div class=""row"">
        <div class=""col"">									
            <input type=""radio"" id=""onlyZK"" class=""workingButton"" data-togg");
            WriteLiteral("le=\"tooltip\" title=\"Выберите, если нужна выгрузка по ЗК\" placeholder=\"Только под ЗК\" name=\"orderType\" value=\"SO\">\r\n            <label for=\"onlyKP\"><p>Выгрузка по ЗК</p></label>\r\n        </div>\t\r\n    </div>\r\n");
            EndContext();
            BeginContext(1302, 37, false);
#line 25 "F:\Диплом\NewElcom\Elcom\Views\Sheets\_GetKPIMZ.cshtml"
Write(Html.Partial("_PartialOrExcelSubmit"));

#line default
#line hidden
            EndContext();
#line 25 "F:\Диплом\NewElcom\Elcom\Views\Sheets\_GetKPIMZ.cshtml"
                                          
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
