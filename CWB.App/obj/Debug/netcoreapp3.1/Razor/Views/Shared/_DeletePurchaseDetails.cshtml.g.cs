#pragma checksum "D:\projects\working_copy\CWB\CWB.App\Views\Shared\_DeletePurchaseDetails.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "549fb61480b6c5ea6d19d126f5793573f498eb557d9f998d16e2aceaaac46058"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__DeletePurchaseDetails), @"mvc.1.0.view", @"/Views/Shared/_DeletePurchaseDetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"549fb61480b6c5ea6d19d126f5793573f498eb557d9f998d16e2aceaaac46058", @"/Views/Shared/_DeletePurchaseDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"d5ea8e6831a1ee80032874d8c95796e9e8392b4c92855acd058fadc59f67b90e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__DeletePurchaseDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CWB.App.Models.ItemMaster.PartPurchaseDetailsVM>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("DelMasterPartType"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("FormDelPurchaseDetails"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("FormDelPurchaseDetails"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("return false;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""modal fade"" id=""dialog-DeletePurchaseDetail"" data-bs-backdrop=""static"" data-bs-keyboard=""false"" tabindex=""-1"" aria-labelledby=""staticBackdropLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-sm"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""myLargeModalLabel"">Delete Purchase Detail </h5>
                <button id=""btnDeletePDClose"" type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
            </div>
            <div class=""modal-body"">
                <div class=""row"">
                    <div>
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "549fb61480b6c5ea6d19d126f5793573f498eb557d9f998d16e2aceaaac460586777", async() => {
                WriteLiteral(@"
                            <div class=""row"">
                                <!--<label class=""form-label col-md-4 mb-2""> Company <span class=""text-danger""> *</span> </label>
                                <div class=""col-md-8 mb-2"">
                                    <div class=""input-group"">
                                        <div class=""col-md-9 mb-2"">
                                        </div>
                                    </div>
                                </div>
                                <label class=""form-label col-md-4 mb-2"">Lead Time (Days) </label>
                                <div class=""col-md-8 mb-2"">
                                    
                                </div>
                                <label class=""form-label col-md-4 mb-2"">Minimum Order Quantity</label>
                                <div class=""col-md-8 mb-2"">
                                    
                                </div>
                                <label class=""form-labe");
                WriteLiteral(@"l col-md-4 mb-2"">Price</label>
                                <div class=""col-md-8 mb-2"">
                                </div>
                                -->
                                <!-- ========================= -->
                                <!-- ========================= -->
                                <input type=""text"" hidden id=""DelPSupplier""");
                BeginWriteAttribute("value", " value=\"", 2215, "\"", 2223, 0);
                EndWriteAttribute();
                WriteLiteral(" name=\"PSupplier\" readonly />\n                                <input id=\"DelLeadTimeInDays\" hidden name=\"LeadTimeInDays\" type=\"text\"");
                BeginWriteAttribute("value", " value=\"", 2356, "\"", 2364, 0);
                EndWriteAttribute();
                WriteLiteral(" readonly />\n                                <input id=\"DelMinimumOrderQuantity\" hidden type=\"text\"");
                BeginWriteAttribute("value", " value=\"", 2464, "\"", 2472, 0);
                EndWriteAttribute();
                WriteLiteral(" name=\"MinimumOrderQuantity\" readonly />\n                                <input id=\"DelPrice\" hidden type=\"text\" name=\"Price\"");
                BeginWriteAttribute("value", " value=\"", 2598, "\"", 2606, 0);
                EndWriteAttribute();
                WriteLiteral(" readonly />\n                                <input type=\"text\" hidden id=\"DelShareOfBusiness\" name=\"ShareOfBusiness\"");
                BeginWriteAttribute("value", " value=\"", 2724, "\"", 2732, 0);
                EndWriteAttribute();
                WriteLiteral(" />\n                                <input type=\"text\" hidden id=\"DelSupplierPartNo\" name=\"PSupplierPartNo\"");
                BeginWriteAttribute("value", " value=\"", 2840, "\"", 2848, 0);
                EndWriteAttribute();
                WriteLiteral(@" />
                                <input type=""text"" hidden id=""DelPartId"" value=""0"" name=""PPartId"" />
                                <input type=""text"" hidden id=""DelPartPurchaseId"" value=""0"" name=""PartPurchaseId"" />
                                <input type=""text"" hidden id=""DelPPDSupplierId""");
                BeginWriteAttribute("value", " value=\"", 3149, "\"", 3157, 0);
                EndWriteAttribute();
                WriteLiteral(" name=\"PSupplierId\"/>\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "549fb61480b6c5ea6d19d126f5793573f498eb557d9f998d16e2aceaaac4605810592", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#nullable restore
#line 44 "D:\projects\working_copy\CWB\CWB.App\Views\Shared\_DeletePurchaseDetails.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.PMasterPartType);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                <textarea hidden id=""DelAdditionalInfo"" name=""AdditionalInfo""></textarea>
                                <input type=""text"" hidden id=""DelRMId"" value=""-1"" name=""RMId"" />
                                <input type=""text"" hidden id=""DelBOFId"" value=""-1"" name=""BOFId"" />

                                <!-- ========================= -->
                                <div>
                                    <label class=""form-label col-md-8 mb-2""> Are you sure you want to delete this entry?</label>
                                </div>
                                <div class=""text-center"">
                                    <button type=""button"" id=""DelSupplier"" class=""btn btn-sm btn-primary"" title=""Select to Delete Supplier for the RM"" data-plugin=""tippy"" data-tippy-placement=""top"">Delete</button>
                                    <button type=""button"" id=""CancelDelSupplier"" class=""btn btn-sm btn-primary"" title=""Select to Cancel"" data-plugin=""tippy"" data-tippy-placeme");
                WriteLiteral("nt=\"top\">Cancel</button>\n                                </div>\n                                <!-- ========================= -->\n                            </div>\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                    </div>\n                </div>\n            </div>\n        </div><!-- /.modal-content -->\n    </div><!-- /.modal-dialog -->\n</div>\n\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CWB.App.Models.ItemMaster.PartPurchaseDetailsVM> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
