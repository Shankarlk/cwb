#pragma checksum "D:\projects\working_copy\CWB\CWB.App\Views\Contacts\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "803d624343bdd95909ae653fc0ba089d9bc61ceb30802c462a9f7be8e3ffdfdf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contacts_Index), @"mvc.1.0.view", @"/Views/Contacts/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"803d624343bdd95909ae653fc0ba089d9bc61ceb30802c462a9f7be8e3ffdfdf", @"/Views/Contacts/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"d5ea8e6831a1ee80032874d8c95796e9e8392b4c92855acd058fadc59f67b90e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Contacts_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CWB.App.Models.Contacts.ContactsVM>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-select form-select-sm contact-search"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Select from Drop Down - Customer or Supplier Company or Both"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-plugin", new global::Microsoft.AspNetCore.Html.HtmlString("tippy"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-tippy-placement", new global::Microsoft.AspNetCore.Html.HtmlString("top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-key", new global::Microsoft.AspNetCore.Html.HtmlString("CompanyType"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "../Shared/_ContactsDialog", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/contacts.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/contact-model.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\projects\working_copy\CWB\CWB.App\Views\Contacts\Index.cshtml"
  
    ViewData["Title"] = "Contacts";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            WriteLiteral(@"<input value=""M-C"" type=""hidden"" id=""hdn-nav-menu"" />
<div class=""content"">
    <div class=""card"">
        <div class=""card-body"">
            <div class=""row"">
                <div class=""col-md-11"">
                    <h5>Customer / Supplier Company & Employee List</h5>
                </div>
            </div>
            <!-- -------- -->

            <div class=""row mt-2"">
                <div class=""col-md-3"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "803d624343bdd95909ae653fc0ba089d9bc61ceb30802c462a9f7be8e3ffdfdf7680", async() => {
                WriteLiteral("\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "803d624343bdd95909ae653fc0ba089d9bc61ceb30802c462a9f7be8e3ffdfdf7986", async() => {
                    WriteLiteral("--Select--");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
#nullable restore
#line 21 "D:\projects\working_copy\CWB\CWB.App\Views\Contacts\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = ViewBag.CompanyTypes;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>
                <!-- -------- -->
                <div class=""col-md-3"" title=""Enter the Company Name Partially or Fully to shortlist "" data-plugin=""tippy"" data-tippy-placement=""top"">
                    <input class=""form-control form-control-sm contact-search"" type=""text"" data-key=""CompanyName"" placeholder=""Company Name"">
                </div>
                <!-- -------- -->
                <div class=""col-md-2"" title=""Enter the Company Location if you wish to search by Location"" data-plugin=""tippy"" data-tippy-placement=""top"">
                    <input class=""form-control form-control-sm contact-search"" type=""text"" data-key=""Location"" placeholder=""Location"">
                </div>
                <!-- -------- -->
                <div class=""col-md-3"" title=""Enter any keyword that will enable shortlisting the Companies"" data-plugin=""tippy"" data-tippy-placement=""top"">
                    <input class=""form-control form-control-sm contact-search"" type=""text"" data-key=""DivisionName""");
            WriteLiteral(@" placeholder=""DivisionName"">
                </div>
                <!-- -------- -->
                <!-- -------- -->
            </div>

            <!-- end row -->
            <div class=""table-responsive table-he-250 mt-3"">
                <table class=""table table-sm table-bordered  mb-3 mt-1 tableFixHead"" id=""tbl-contacts"">
                    <thead class=""table-info th-sti text-center"">
                        <tr class=""table-border-bottom"">
                            <th width=""10%""></th>
                            <th width=""50%"">Company Name</th>
                            <th width=""20%"">Division / Branch</th>
                            <th width=""15%"">Location</th>
                            <th width=""5%""></th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 54 "D:\projects\working_copy\CWB\CWB.App\Views\Contacts\Index.cshtml"
                         foreach (var contact in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\n                                <td data-key=\"CompanyType\">");
#nullable restore
#line 57 "D:\projects\working_copy\CWB\CWB.App\Views\Contacts\Index.cshtml"
                                                      Write(contact.CompanyType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td data-key=\"CompanyName\">");
#nullable restore
#line 58 "D:\projects\working_copy\CWB\CWB.App\Views\Contacts\Index.cshtml"
                                                      Write(contact.CompanyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td data-key=\"DivisionName\">");
#nullable restore
#line 59 "D:\projects\working_copy\CWB\CWB.App\Views\Contacts\Index.cshtml"
                                                       Write(contact.DivisionName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td data-key=\"Location\">");
#nullable restore
#line 60 "D:\projects\working_copy\CWB\CWB.App\Views\Contacts\Index.cshtml"
                                                   Write(contact.Location);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                <td>
                                    <div class=""dropdown float-center"">
                                        <a href=""#"" class=""dropdown-toggle arrow-none card-drop"" data-bs-toggle=""dropdown"" aria-expanded=""false""><i class=""mdi mdi-dots-vertical""></i></a>
                                        <div class=""dropdown-menu dropdown-menu-end"">
                                            <!-- item-->
                                            <a href=""javascript:void(0);"" data-bs-toggle=""modal"" data-bs-target=""#dialog-company""
                                               data-id=""");
#nullable restore
#line 67 "D:\projects\working_copy\CWB\CWB.App\Views\Contacts\Index.cshtml"
                                                   Write(contact.CompanyId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-companyname=\"");
#nullable restore
#line 67 "D:\projects\working_copy\CWB\CWB.App\Views\Contacts\Index.cshtml"
                                                                                         Write(contact.CompanyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"\n                                               data-divisionid=\"");
#nullable restore
#line 68 "D:\projects\working_copy\CWB\CWB.App\Views\Contacts\Index.cshtml"
                                                           Write(contact.DivisionId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-companytype=\"");
#nullable restore
#line 68 "D:\projects\working_copy\CWB\CWB.App\Views\Contacts\Index.cshtml"
                                                                                                  Write(contact.CompanyType);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"\n                                               data-divisionname=\"");
#nullable restore
#line 69 "D:\projects\working_copy\CWB\CWB.App\Views\Contacts\Index.cshtml"
                                                             Write(contact.DivisionName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"\n                                               data-notes=\"");
#nullable restore
#line 70 "D:\projects\working_copy\CWB\CWB.App\Views\Contacts\Index.cshtml"
                                                      Write(contact.Notes);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"\n                                               data-location=\"");
#nullable restore
#line 71 "D:\projects\working_copy\CWB\CWB.App\Views\Contacts\Index.cshtml"
                                                         Write(contact.Location);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"\n                                               class=\"dropdown-item\">Company Details</a>\n                                            <!-- item-->\n                                            <a href=\"javascript:void(0);\"");
            BeginWriteAttribute("onclick", " onclick=\"", 4494, "\"", 4538, 3);
            WriteAttributeValue("", 4504, "DeleteCompany(", 4504, 14, true);
#nullable restore
#line 74 "D:\projects\working_copy\CWB\CWB.App\Views\Contacts\Index.cshtml"
WriteAttributeValue("", 4518, contact.CompanyId, 4518, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4536, ");", 4536, 2, true);
            EndWriteAttribute();
            WriteLiteral(" data-bs-toggle=\"modal\" data-bs-target=\"#dialog-company\" data-id=\"");
#nullable restore
#line 74 "D:\projects\working_copy\CWB\CWB.App\Views\Contacts\Index.cshtml"
                                                                                                                                                                                   Write(contact.CompanyId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-divisionid=\"");
#nullable restore
#line 74 "D:\projects\working_copy\CWB\CWB.App\Views\Contacts\Index.cshtml"
                                                                                                                                                                                                                        Write(contact.DivisionId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""" class=""dropdown-item"">Delete Company</a>
                                            <!-- item-->
                                        </div>
                                    </div>
                                </td>
                            </tr>
");
#nullable restore
#line 80 "D:\projects\working_copy\CWB\CWB.App\Views\Contacts\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                </table>
            </div>
            <!-- ------- -->
            <div class=""row"">
                <div class=""col"">
                    <button class=""btn btn-sm btn-info"" data-bs-toggle=""modal"" data-id=""0"" data-divisionId=""0"" data-bs-target=""#dialog-company"" title=""Select to Add details of a Company""
                            data-plugin=""tippy"" data-tippy-placement=""top"">
                        Add Company
                    </button>
                </div>
            </div>
            <!-- ============================== -->
        </div>
        <!-- end card body -->
    </div>
    <!-- ============================== -->
</div>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "803d624343bdd95909ae653fc0ba089d9bc61ceb30802c462a9f7be8e3ffdfdf20046", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
#nullable restore
#line 100 "D:\projects\working_copy\CWB\CWB.App\Views\Contacts\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = new CWB.App.Models.Contacts.CompanyVM{CompanyId=0,DivisionId=0,Location=""};

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "803d624343bdd95909ae653fc0ba089d9bc61ceb30802c462a9f7be8e3ffdfdf21788", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "803d624343bdd95909ae653fc0ba089d9bc61ceb30802c462a9f7be8e3ffdfdf22910", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n");
            }
            );
            WriteLiteral(@"
<!--
     public long CompanyId { get; set; }
        public long DivisionId { get; set; }
        public string CompanyType { get; set; }
        public string CompanyName { get; set; }
        public string DivisionName { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
-->
<!--Company Template-->
<template id=""company-template"">
    <tr>
        <td data-key=""CompanyType"">{companyType}</td>
        <td data-key=""CompanyName"">{companyName}</td>
        <td data-key=""DivisionName"">{divisionName}</td>
        <td data-key=""Location"">{location}</td>
        <td>
            <div class=""dropdown float-center"">
                <a href=""#"" class=""dropdown-toggle arrow-none card-drop"" data-bs-toggle=""dropdown"" aria-expanded=""false""><i class=""mdi mdi-dots-vertical""></i></a>
                <div class=""dropdown-menu dropdown-menu-end"">
                    <!-- item-->
                    <a href=""javascript:void(0);"" data-bs-toggle=""modal"" data-bs-target=""#dialog-co");
            WriteLiteral(@"mpany""
                       data-id=""{companyId}"" data-companyname=""{companyName}""
                       data-divisionid=""{divisionId}"" data-companytype=""{companyType}""
                       data-divisionname=""{divisionName}""
                       data-notes=""{notes}""
                       data-location=""{location}""
                       class=""dropdown-item"">Company Details</a>
                    <!-- item-->
                    <a href=""javascript:void(0);"" 
                       onclick=""DeleteCompany({companyId});"" class=""dropdown-item"">Delete Company</a>
                    <!-- item-->
                </div>
            </div>
        </td>
    </tr>
</template>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CWB.App.Models.Contacts.ContactsVM>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591