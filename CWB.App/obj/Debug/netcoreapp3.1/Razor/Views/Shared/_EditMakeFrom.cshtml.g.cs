#pragma checksum "D:\projects\working_copy\CWB\CWB.App\Views\Shared\_EditMakeFrom.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "e0893f09b76c067808afa26237c9d26e59ab76da519975d4bb505f1c229fe673"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__EditMakeFrom), @"mvc.1.0.view", @"/Views/Shared/_EditMakeFrom.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"e0893f09b76c067808afa26237c9d26e59ab76da519975d4bb505f1c229fe673", @"/Views/Shared/_EditMakeFrom.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"d5ea8e6831a1ee80032874d8c95796e9e8392b4c92855acd058fadc59f67b90e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__EditMakeFrom : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("FormEditMakeFrom"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("FormEditMakeFrom"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("return false;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
            WriteLiteral(@"<div class=""modal fade"" id=""dialog-EditMakeFrom"" data-bs-backdrop=""static"" data-bs-keyboard=""false"" tabindex=""-1"" aria-labelledby=""staticBackdropLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-sm"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""myLargeModalLabel"">Edit MakeFrom Raw Material </h5>
                <button id=""btnEditMakeFromClose"" type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
            </div>
            <div class=""modal-body"">
                <div class=""row"">
                    <div>
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e0893f09b76c067808afa26237c9d26e59ab76da519975d4bb505f1c229fe6735608", async() => {
                WriteLiteral(@"
                    <div class=""row mt-8"">
                            <label class=""form-label col-md-4 mb-2"">Input Weight (Kgs)</label>
                            <div class=""col-md-8 mb-2"" title=""Enter the Input Weight in kjgs"" data-plugin=""tippy"" data-tippy-placement=""top"">
                                <input class=""form-control form-control-sm"" type=""text"" id=""EditInputWeight"" name=""inputWeight"" placeholder=""enter here"" required>
                            </div>
                            <!-- ========================= -->
                            <!-- ========================= -->
                            <label class=""form-label col-md-4 mb-2"">Quantity per Input</label>
                            <div class=""col-md-8 mb-2"" title=""Enter the number of Finished Part Nos that can manufactured from a single Input Material. Example multiple finished Part Nos can be made from a single input Bar or Sheet ..."" data-plugin=""tippy"" data-tippy-placement=""top"">
                                <input ");
                WriteLiteral(@"class=""form-control form-control-sm"" type=""text"" id=""EditQuantityPerInput"" name=""QuantityPerInput"" placeholder=""enter here"" required>
                            </div>

                            <label class=""form-label col-md-4 mb-2"">Scrap Generated</label>
                            <div class=""col-md-8 mb-2"" title=""Scrap Generated..."" data-plugin=""tippy"" data-tippy-placement=""top"">
                                    <input class=""form-control form-control-sm"" type=""text"" id=""EditScrapgenerated"" name=""Scrapgenerated"" value=""0"" />
                            </div>

                            <label class=""form-label col-md-4 mb-2"">Yeild Notes</label>
                            <div class=""col-md-7 mb-2""");
                BeginWriteAttribute("title", " title=\"", 2490, "\"", 2498, 0);
                EndWriteAttribute();
                WriteLiteral(@" data-plugin=""tippy"" data-tippy-placement=""top"">
                                    <textarea id=""EditYieldNotes"" name=""YieldNotes"" class=""form-control form-control-sm""></textarea>
                            </div>
                            <label class=""form-label col-md-4 mb-2"">Preferred Raw Material</label>
                            <div class=""col-md-8 mb-2""");
                BeginWriteAttribute("title", " title=\"", 2869, "\"", 2877, 0);
                EndWriteAttribute();
                WriteLiteral(@" data-plugin=""tippy"" data-tippy-placement=""top"">
                            <input class=""form-check-input mt-1"" id=""PreferedRawMaterial"" name=""PreferedRawMaterial"" type=""checkbox"" title=""If multiple Input Raw Material Options exist, select the Preferred Raw Material Checkbox if this is the preferred RM "" data-plugin=""tippy"" data-tippy-placement=""top"">
                            </div>
                            <!-- ========================= -->
                            <div class=""text-center"">
                                    <input type=""text"" hidden id=""EditPartMadeFrom"" name=""PartMadeFrom"" value=""0"" />
                                    <input type=""text"" hidden id=""EditPreferedRawMaterial"" name=""PreferedRawMaterial"" value=""0"" />
                                    <input type=""text"" hidden id=""EditMFDescription"" name=""MFDescription"" value=""0"" />
                                    <input type=""text"" hidden id=""EditInputPartNo"" name=""InputPartNo"" value=""0"" />
                                  ");
                WriteLiteral(@"  <input type=""text"" hidden id=""EditMPMakeFromId"" name=""MPMakeFromId"" value=""0"" />
                                    <input type=""text"" hidden id=""EditMPPartId"" name=""MPPartId"" value=""0"" />
                                    <input type=""text"" hidden id=""EditManufPartId"" name=""ManufPartId"" value=""0"" />
                                <button type=""button"" id=""EditMakeFrom"" class=""btn btn-sm btn-primary"" title=""Select to Edit another Supplier for the RM"" data-plugin=""tippy"" data-tippy-placement=""top"">Save</button>
                            </div>
                            <!-- ========================= -->
                        </div>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                    </div>\n                </div>\n                </div>\n            </div>\n        </div><!-- /.modal-content -->\n</div><!-- /.modal-dialog -->\n\n\n");
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