#pragma checksum "c:\Users\asadykov\source\repos\Elcom\Elcom\Views\Purchaser\_KPIMZ.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a39be0c7d482a0a7ec564551b3f0728063c68439"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Purchaser__KPIMZ), @"mvc.1.0.view", @"/Views/Purchaser/_KPIMZ.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Purchaser/_KPIMZ.cshtml", typeof(AspNetCore.Views_Purchaser__KPIMZ))]
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
#line 1 "c:\Users\asadykov\source\repos\Elcom\Elcom\Views\_ViewImports.cshtml"
using Elcom;

#line default
#line hidden
#line 2 "c:\Users\asadykov\source\repos\Elcom\Elcom\Views\_ViewImports.cshtml"
using Elcom.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a39be0c7d482a0a7ec564551b3f0728063c68439", @"/Views/Purchaser/_KPIMZ.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d596a95d4a3b676f547551363826836a2c5ce762", @"/Views/_ViewImports.cshtml")]
    public class Views_Purchaser__KPIMZ : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "c:\Users\asadykov\source\repos\Elcom\Elcom\Views\Purchaser\_KPIMZ.cshtml"
 using (Html.BeginForm("GetKPIMZ", "Purchaser", FormMethod.Get))
{

#line default
#line hidden
            BeginContext(69, 22, true);
            WriteLiteral("    <p>Период от</p>\r\n");
            EndContext();
            BeginContext(96, 24, false);
#line 4 "c:\Users\asadykov\source\repos\Elcom\Elcom\Views\Purchaser\_KPIMZ.cshtml"
Write(Html.TextBox("fromDate"));

#line default
#line hidden
            EndContext();
            BeginContext(122, 22, true);
            WriteLiteral("    <p>Период по</p>\r\n");
            EndContext();
            BeginContext(149, 22, false);
#line 6 "c:\Users\asadykov\source\repos\Elcom\Elcom\Views\Purchaser\_KPIMZ.cshtml"
Write(Html.TextBox("toDate"));

#line default
#line hidden
            EndContext();
            BeginContext(173, 244, true);
            WriteLiteral("    <p>Тип заказов</p>\r\n    <input type=\"radio\" name=\"orderType\" value=\"Quote\" /><p>Коммерческое предложение</p>\r\n    <input type=\"radio\" name=\"orderType\" value=\"SO\" /><p>Заказ клиента</p>\r\n    <p><input type=\"submit\" value=\"Выгрузить\" /></p>\r\n");
            EndContext();
#line 11 "c:\Users\asadykov\source\repos\Elcom\Elcom\Views\Purchaser\_KPIMZ.cshtml"
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
