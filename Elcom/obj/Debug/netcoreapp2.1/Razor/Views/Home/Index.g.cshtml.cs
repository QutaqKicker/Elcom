#pragma checksum "f:\Диплом\NewElcom\Elcom\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cc5ed7f155a9f184b968ce263ab378db3d78d077"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "f:\Диплом\NewElcom\Elcom\Views\_ViewImports.cshtml"
using Elcom;

#line default
#line hidden
#line 2 "f:\Диплом\NewElcom\Elcom\Views\_ViewImports.cshtml"
using Elcom.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc5ed7f155a9f184b968ce263ab378db3d78d077", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d596a95d4a3b676f547551363826836a2c5ce762", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "f:\Диплом\NewElcom\Elcom\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(45, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 6 "f:\Диплом\NewElcom\Elcom\Views\Home\Index.cshtml"
 using (Html.BeginForm("Test", "Home", FormMethod.Get))
{

#line default
#line hidden
            BeginContext(109, 98, true);
            WriteLiteral("    <p>Здесь можно чекнуть выгрузку данных в эксель по запросу</p>\r\n    <p>Текст sql запроса</p>\r\n");
            EndContext();
            BeginContext(212, 23, false);
#line 10 "f:\Диплом\NewElcom\Elcom\Views\Home\Index.cshtml"
Write(Html.TextBox("SQLtext"));

#line default
#line hidden
            EndContext();
            BeginContext(237, 30, true);
            WriteLiteral("    <p>Используемая база</p>\r\n");
            EndContext();
            BeginContext(272, 38, false);
#line 12 "f:\Диплом\NewElcom\Elcom\Views\Home\Index.cshtml"
Write(Html.TextBox("database", "OracleTest"));

#line default
#line hidden
            EndContext();
            BeginContext(314, 54, true);
            WriteLiteral("    <p><input type=\"submit\" value=\"Выгрузить\" /></p>\r\n");
            EndContext();
#line 15 "f:\Диплом\NewElcom\Elcom\Views\Home\Index.cshtml"
}

#line default
#line hidden
            BeginContext(371, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 17 "f:\Диплом\NewElcom\Elcom\Views\Home\Index.cshtml"
 using (Html.BeginForm("Test2", "Home", FormMethod.Get))
{

#line default
#line hidden
            BeginContext(434, 127, true);
            WriteLiteral("    <p>Здесь будет произведен вызов pkg_cmacros.function_FillDatesSheet через вызов функции</p>\r\n    <p>Используемая база</p>\r\n");
            EndContext();
            BeginContext(566, 38, false);
#line 21 "f:\Диплом\NewElcom\Elcom\Views\Home\Index.cshtml"
Write(Html.TextBox("database", "OracleTest"));

#line default
#line hidden
            EndContext();
            BeginContext(606, 52, true);
            WriteLiteral("    <p><input type=\"submit\" value=\"Чекнуть\" /></p>\r\n");
            EndContext();
#line 23 "f:\Диплом\NewElcom\Elcom\Views\Home\Index.cshtml"
}

#line default
#line hidden
            BeginContext(661, 30, true);
            WriteLiteral("\r\n<p>Обработчик шаблонов</p>\r\n");
            EndContext();
#line 26 "f:\Диплом\NewElcom\Elcom\Views\Home\Index.cshtml"
 using (Html.BeginForm("Test3", "Home", FormMethod.Get))
{

#line default
#line hidden
            BeginContext(752, 88, true);
            WriteLiteral("    <p>Здесь будет произведен вызов select * from dbo.\"RefFoms\"</p>\r\n    <p>Шаблон</p>\r\n");
            EndContext();
            BeginContext(845, 36, false);
#line 30 "f:\Диплом\NewElcom\Elcom\Views\Home\Index.cshtml"
Write(Html.TextBox("Template", "Template"));

#line default
#line hidden
            EndContext();
            BeginContext(883, 54, true);
            WriteLiteral("    <p><input type=\"submit\" value=\"Отправить\" /></p>\r\n");
            EndContext();
#line 32 "f:\Диплом\NewElcom\Elcom\Views\Home\Index.cshtml"
}

#line default
#line hidden
            BeginContext(940, 220, true);
            WriteLiteral("<button onclick=\"LoadPartial()\">\r\n    Подгрузка частичного представления\r\n</button>\r\n<script>\r\n    function LoadPartial() {\r\n        $(\"#target\").load(\"/Home/PartialTest\");  \r\n    };\r\n</script>\r\n\r\n<div id=\'target\'></div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
