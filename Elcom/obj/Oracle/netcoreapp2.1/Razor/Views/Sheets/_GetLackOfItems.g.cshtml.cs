#pragma checksum "C:\Users\asadykov\source\repos\foms-smev-service\Elcom\Views\Sheets\_GetLackOfItems.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5836f7ca196da41a4a69f804cfd24e35bcb2d21d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Sheets__GetLackOfItems), @"mvc.1.0.view", @"/Views/Sheets/_GetLackOfItems.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Sheets/_GetLackOfItems.cshtml", typeof(AspNetCore.Views_Sheets__GetLackOfItems))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5836f7ca196da41a4a69f804cfd24e35bcb2d21d", @"/Views/Sheets/_GetLackOfItems.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d596a95d4a3b676f547551363826836a2c5ce762", @"/Views/_ViewImports.cshtml")]
    public class Views_Sheets__GetLackOfItems : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\asadykov\source\repos\foms-smev-service\Elcom\Views\Sheets\_GetLackOfItems.cshtml"
 using (Html.BeginForm("GetLackOfItems", "Sheets", FormMethod.Get))
{
    

#line default
#line hidden
            BeginContext(77, 31, false);
#line 3 "C:\Users\asadykov\source\repos\foms-smev-service\Elcom\Views\Sheets\_GetLackOfItems.cshtml"
Write(Html.Partial("_InventoryInput"));

#line default
#line hidden
            EndContext();
#line 3 "C:\Users\asadykov\source\repos\foms-smev-service\Elcom\Views\Sheets\_GetLackOfItems.cshtml"
                                    ;
    

#line default
#line hidden
            BeginContext(116, 37, false);
#line 4 "C:\Users\asadykov\source\repos\foms-smev-service\Elcom\Views\Sheets\_GetLackOfItems.cshtml"
Write(Html.Partial("_PartialOrExcelSubmit"));

#line default
#line hidden
            EndContext();
#line 4 "C:\Users\asadykov\source\repos\foms-smev-service\Elcom\Views\Sheets\_GetLackOfItems.cshtml"
                                          ;
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
