#pragma checksum "D:\projects\working_copy\CWB\CWB.App\Views\Shared\_ExistingPart.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "701570d75fe420eeec0bc418e5e01e31d06780b2bd25efe02a70763618ef28c6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ExistingPart), @"mvc.1.0.view", @"/Views/Shared/_ExistingPart.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"701570d75fe420eeec0bc418e5e01e31d06780b2bd25efe02a70763618ef28c6", @"/Views/Shared/_ExistingPart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"d5ea8e6831a1ee80032874d8c95796e9e8392b4c92855acd058fadc59f67b90e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__ExistingPart : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""modal fade"" id=""existing-part"" data-bs-backdrop=""static"" data-bs-keyboard=""false"" tabindex=""-1"" aria-labelledby=""staticBackdropLabel"" aria-hidden=""true"">
    <div class=""modal-dialog bxs-modal"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 class=""modal-title"" id=""standard-modalLabel"">Select Part</h4>
                <button type=""button"" class=""btn-close"" id=""btn-close-ExistingParts"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
            </div>
            <div class=""modal-body"">
                <!-- ---------------- -->
                <div class=""row mt-1"">
                    <label class=""form-label col-md-4 mb-2""> Company  </label>
                    <div class=""col-md-8 mb-2"">
                        <input class=""form-control form-control-sm"" type=""text"" placeholder=""Enter here""");
            BeginWriteAttribute("value", " value=\"", 882, "\"", 890, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""epco"" name=""epco"" disabled />
                    </div>
                    <!-- -------------------------------------  -->
                    <!-- ========================= -->
                    <label class=""form-label col-md-4 mb-2"">Part Number </label>
                    <div class=""col-md-8 mb-2"">
                        <input class=""form-control form-control-sm"" type=""text"" placeholder=""Enter here""");
            BeginWriteAttribute("value", " value=\"", 1315, "\"", 1323, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""eppn"" name=""eppn"" />
                    </div>
                    <!-- ========================= -->
                    <label class=""form-label col-md-4 mb-2"">Part Description </label>
                    <div class=""col-md-8 mb-2"">
                        <input class=""form-control form-control-sm"" type=""text"" placeholder=""Enter here""");
            BeginWriteAttribute("value", " value=\"", 1675, "\"", 1683, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""eppd"" name=""eppd"" />
                    </div>
                </div>
                <!-- ============================== -->
                <div class=""table-responsive table-he-250 mt-3"">
                    <table class=""table table-sm table-bordered  mb-3 mt-1 tableFixHead"" id=""tbl-existingparts"">
                        <thead class=""table-info th-sti text-center"">
                            <tr class=""table-border-bottom"">
                                <th width=""10%""></th>
                                <th width=""30%"">Part No.</th>
                                <th width=""40%"">Description</th>
                                <th width=""15%"">Child/Assy</th>
                                <th width=""5%""></th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table>
                </div>
                <!-- =============================== -->
            </div>
    ");
            WriteLiteral(@"        <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-primary btn-sm"" onclick=""copyData()"">Select</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>");
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