#pragma checksum "F:\Диплом\NewElcom\Elcom\Views\Sheets\_GetDelayedIPO.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "099fb169a83b1affbfff9eb9b5b563135cc7b202"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Sheets__GetDelayedIPO), @"mvc.1.0.view", @"/Views/Sheets/_GetDelayedIPO.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Sheets/_GetDelayedIPO.cshtml", typeof(AspNetCore.Views_Sheets__GetDelayedIPO))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"099fb169a83b1affbfff9eb9b5b563135cc7b202", @"/Views/Sheets/_GetDelayedIPO.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d596a95d4a3b676f547551363826836a2c5ce762", @"/Views/_ViewImports.cshtml")]
    public class Views_Sheets__GetDelayedIPO : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "F:\Диплом\NewElcom\Elcom\Views\Sheets\_GetDelayedIPO.cshtml"
 using (Html.BeginForm("GetDelayedIPO", "Sheets", FormMethod.Get))
{
    

#line default
#line hidden
            BeginContext(76, 37, false);
#line 3 "F:\Диплом\NewElcom\Elcom\Views\Sheets\_GetDelayedIPO.cshtml"
Write(Html.Partial("_PartialOrExcelSubmit"));

#line default
#line hidden
            EndContext();
#line 3 "F:\Диплом\NewElcom\Elcom\Views\Sheets\_GetDelayedIPO.cshtml"
                                          
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