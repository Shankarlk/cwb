#pragma checksum "D:\projects\working_copy\CWB\CWB.App\Views\Shared\_RouteSubCons.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6b75597fb780ee3c6d7251d4ea975b4818037ac6a8c5fba14992a13a8e6eb67f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__RouteSubCons), @"mvc.1.0.view", @"/Views/Shared/_RouteSubCons.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"6b75597fb780ee3c6d7251d4ea975b4818037ac6a8c5fba14992a13a8e6eb67f", @"/Views/Shared/_RouteSubCons.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"d5ea8e6831a1ee80032874d8c95796e9e8392b4c92855acd058fadc59f67b90e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__RouteSubCons : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div id=""Div_RouteSubCons"" class=""col-md-12"">
    <div class=""table-responsive mt-2 table-he-180 w-100"">
        <table class=""table table-sm table-bordered  mb-3 text-center mt-1 tableFixHead"" id=""SubConsTable"">
            <thead class=""  table-info th-sti"">
                <tr class=""table-border-bottom"">
                    <th width=""55%"">SubCon</th>
                    <th width=""20%"">No Of operations</th>
                    <th width=""20%"">Preferred SubCon</th>
                    <th width=""5%""></th>
                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
    </div>
    <div class=""col-md-12 text-end"">
        <button data-addedit=""Add""
        class=""btn btn-sm btn-primary mt-2"" data-bs-toggle=""modal"" data-bs-target=""#add-subcon"">Add Sub Con</button>
    </div>
</div>

<template id=""RouteSubConsTemplate"">
    <tr>
        <td data-key=""supplier"">{company}</td>
        <td data-key=""noofoperations"">{noOfOperations}</td>
        <td");
            WriteLiteral(@" data-key=""preferredSubCon"">{strPreferredSubCon}</td>
        <td>
            <div class=""dropdown float-center"">
                <a href=""#"" class=""dropdown-toggle arrow-none card-drop"" data-bs-toggle=""dropdown"" aria-expanded=""false""><i class=""mdi mdi-dots-vertical""></i></a>
                <div class=""dropdown-menu dropdown-menu-end"">
                    <!-- item-->
                    <a href=""javascript:void(0);"" onclick=""SetPreferredSubCon({subConDetailsId});"" class=""dropdown-item"">Set Preferred SubCon</a>
                    <a href=""javascript:void(0);"" data-addedit=""Edit"" 
                        data-workdone =""{workDone}""
                        data-transporttime=""{transportTime}""
                       data-costperpart=""{costPerPart}""
                       data-preferredsubcon=""{preferredSubcon}""
                       data-subconsupplierid=""{supplierId}""
                       data-subcondetailsid=""{subConDetailsId}""
                       data-subconroutingstepid=""{routingStepId");
            WriteLiteral(@"}""
                       data-company=""{company}""
                       data-deleted=""{deleted}""
                    data-bs-toggle=""modal"" data-bs-target=""#add-subcon"" class=""dropdown-item"">Edit</a>
                    <!-- item-->
                    <a href=""javascript:void(0);"" data-subcondetailsid=""{subConDetailsId}"" data-stepid=""{routingStepId}"" data-company=""{company}"" data-bs-toggle=""modal"" data-bs-target=""#delete-subcon"" class=""dropdown-item"">Delete</a>
                </div>
            </div>
        </td>
    </tr>
</template>");
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
