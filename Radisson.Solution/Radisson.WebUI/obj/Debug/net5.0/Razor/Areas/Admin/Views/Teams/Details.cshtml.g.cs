#pragma checksum "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\Teams\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "938c17db8c8d0ba0381a890203551491d81917b4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Teams_Details), @"mvc.1.0.view", @"/Areas/Admin/Views/Teams/Details.cshtml")]
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
#nullable restore
#line 2 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Radisson.Domain.Models.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Radisson.Application.AppCode.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Radisson.Domain.AppCode.Infrastructure;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Radisson.Application.AppCode.Infrastructure;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Radisson.Domain.Models.FormData;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Radisson.Domain.Business.RoomModule;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Radisson.Domain.Business.RoomTypeModule;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Radisson.Domain.Business.PeopleModule;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Radisson.Domain.Business.ReservationModule;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Radisson.Domain.Business.BlogPostModule;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Radisson.Domain.Business.AboutModule.RadissonHotels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Radisson.Domain.Business.AboutModule.Abouts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Radisson.Domain.Business.AboutModule.ServicesHeaders;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Radisson.Domain.Business.AboutModule.ServicesBodies;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Radisson.Domain.Business.AboutModule.Teams;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Radisson.Domain.Models.Entities.Membership;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Radisson.Domain.Business.RadissonRoleModule;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"938c17db8c8d0ba0381a890203551491d81917b4", @"/Areas/Admin/Views/Teams/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0489d3baf6c8ba5363b9988453b8d986ab6fc77d", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Teams_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Team>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Dashboard", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("col-sm-2 col-form-label"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning mr-2 fix-btn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\Teams\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h2>Detallı</h2>

<h4>Komanda</h4>
<hr />
<div class=""page-wrapper"">
    <div class=""page-header"">
        <div class=""row align-items-end"">
            <div class=""col-lg-8"">
                <div class=""page-header-title"">
                    <div class=""d-inline"">
                        <h4>Bootstrap Border Sizes</h4>
                        <span>
                            lorem ipsum dolor sit amet, consectetur adipisicing
                            elit
                        </span>
                    </div>
                </div>
            </div>
            <div class=""col-lg-4"">
                <div class=""page-header-breadcrumb"">
                    <ul class=""breadcrumb-title"">
                        <li class=""breadcrumb-item"" style=""float: left;"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "938c17db8c8d0ba0381a890203551491d81917b410539", async() => {
                WriteLiteral(" <i class=\"feather icon-home\"></i> ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </li>\r\n");
#nullable restore
#line 31 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\Teams\Details.cshtml"
                         if (User.HasAccess("admin.teams.index"))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li class=\"breadcrumb-item\" style=\"float: left;\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "938c17db8c8d0ba0381a890203551491d81917b412389", async() => {
                WriteLiteral("Komanda");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </li>\r\n");
#nullable restore
#line 36 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\Teams\Details.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <li class=""breadcrumb-item"" style=""float: left;"">
                            <span>Detallı</span>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <div class=""page-body"">
        <div class=""row"">
            <div class=""col-sm-12"">
                <div class=""card"">
                    <div class=""card-header"">
                        <h5>Basic Form Inputs</h5>
                        <span>
                            Add class of <code>.form-control</code> with
                            <code>&lt;input&gt;</code> tag
                        </span>


                        <div class=""card-header-right"">
                            <i class=""icofont icofont-spinner-alt-5""></i>
                        </div>

                    </div>
                    <div class=""card-block"">
                        <h4 class=""sub-title"">Basic Inputs</h4>

                        <div>
");
            WriteLiteral(@"                            <div class=""form-group row"">
                                <label class=""col-sm-2 col-form-label"">Image</label>
                                <div class=""col-sm-10"">
                                    <label class=""image-viewer""");
            BeginWriteAttribute("style", " style=\"", 2601, "\"", 2663, 3);
            WriteAttributeValue("", 2609, "background-image:url(/uploads/images/", 2609, 37, true);
#nullable restore
#line 69 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\Teams\Details.cshtml"
WriteAttributeValue("", 2646, Model.ImagePath, 2646, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2662, ")", 2662, 1, true);
            EndWriteAttribute();
            WriteLiteral("></label>\r\n                                </div>\r\n                            </div>\r\n                            <div class=\"form-group row\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "938c17db8c8d0ba0381a890203551491d81917b415916", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 73 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\Teams\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Name);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                <p class=\"fix-row\">\r\n                                    ");
#nullable restore
#line 75 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\Teams\Details.cshtml"
                               Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </p>\r\n                            </div>\r\n                            <div class=\"form-group row\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "938c17db8c8d0ba0381a890203551491d81917b417987", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 79 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\Teams\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Surname);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                <div class=\"fix-row\">\r\n                                    ");
#nullable restore
#line 81 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\Teams\Details.cshtml"
                               Write(Html.Raw(Model.Surname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n                            <div class=\"form-group row\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "938c17db8c8d0ba0381a890203551491d81917b420078", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 85 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\Teams\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Text);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                <div class=\"fix-row\">\r\n                                    ");
#nullable restore
#line 87 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\Teams\Details.cshtml"
                               Write(Html.Raw(Model.Text));

#line default
#line hidden
#nullable disable
            WriteLiteral("<span style=\"margin-left: 4px\"></span>\r\n                                </div>\r\n                            </div>\r\n                            <div class=\"form-group row\">\r\n                                <div class=\"col-12 d-flex justify-content-end\">\r\n");
#nullable restore
#line 92 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\Teams\Details.cshtml"
                                     if (User.HasAccess("admin.teams.edit"))
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "938c17db8c8d0ba0381a890203551491d81917b422626", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 94 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\Teams\Details.cshtml"
                                                                      WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 95 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\Teams\Details.cshtml"
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 96 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\Teams\Details.cshtml"
                                     if (User.HasAccess("admin.teams.index"))
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "938c17db8c8d0ba0381a890203551491d81917b425585", async() => {
                WriteLiteral("Cancel");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 99 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\Teams\Details.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Team> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
