#pragma checksum "D:\projects\working_copy\CWB\CWB.App\Views\Shared\_TabRoutingDetails.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "557be8df68ba0892b57f60b31eb3a039987f9c9f6bd452127bbbbbf2cdce774c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__TabRoutingDetails), @"mvc.1.0.view", @"/Views/Shared/_TabRoutingDetails.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\projects\working_copy\CWB\CWB.App\Views\_ViewImports.cshtml"
using CWB.App;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\projects\working_copy\CWB\CWB.App\Views\_ViewImports.cshtml"
using CWB.App.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\projects\working_copy\CWB\CWB.App\Views\_ViewImports.cshtml"
using CWB.Constants.UserIdentity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"557be8df68ba0892b57f60b31eb3a039987f9c9f6bd452127bbbbbf2cdce774c", @"/Views/Shared/_TabRoutingDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"d5ea8e6831a1ee80032874d8c95796e9e8392b4c92855acd058fadc59f67b90e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__TabRoutingDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!-- ===================== -->
<div class=""row"">
    <div class=""table-responsive"">
        <table class=""table table-sm"">
            <tbody>
                <tr>
                    <td>
                        <div id=""DivRoutingName""></div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div class=""col-md-7"">
        <div class=""table-responsive mt-1 table-he-250"">
            <table id=""StepTable"" class=""table table-sm table-bordered  mb-3 text-center mt-1 tableFixHead w-100"">
                <thead class=""table-info th-sti"">
                    <tr class=""table-border-bottom"">
                        <th width=""10%"">Step No</th>
                        <th>Step Description</th>
                        <th>Doc Avl</th>
                        <th>Status</th>
                        <th width=""5%""></th>
                    </tr>
                </thead>
                <tbody>
                </tbody>
            </table>
  ");
            WriteLiteral(@"      </div>
        <button id=""BtnAddNextStep"" class=""btn btn-sm btn-primary"" title=""Use to add a Routing Step"" data-plugin=""tippy"" data-tippy-placement=""top"">Add Next Step</button>
     </div>
</div>

<template id=""RoutingStepTemplate"">
    <tr>
        <td>{stepNumber}</td>
        <td>{stepDescription}</td>
        <td>---</td>
        <td>{status}</td>
        <td>
            <div class=""dropdown float-center"">
                <a href=""#"" class=""dropdown-toggle arrow-none card-drop"" data-bs-toggle=""dropdown"" aria-expanded=""false""><i class=""mdi mdi-dots-vertical""></i></a>
                <div class=""dropdown-menu dropdown-menu-end"">
                    <!-- item-->
                    <a href=""javascript:void(0);"" data-stepid=""{stepId}"" data-stepNumber=""{stepNumber}"" data-toggle=""modal"" data-target=""#delete-step"" class=""dropdown-item"">delete</a>
                    <a href=""javascript:getAndShowStep({stepId},'{stepNumber}')"" class=""dropdown-item"">Edit</a>
                </div>
      ");
            WriteLiteral("      </div>\r\n        </td>\r\n    </tr>\r\n</template>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591