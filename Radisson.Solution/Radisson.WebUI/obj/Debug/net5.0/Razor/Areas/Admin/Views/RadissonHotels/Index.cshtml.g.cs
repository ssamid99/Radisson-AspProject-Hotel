#pragma checksum "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\RadissonHotels\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "303ca889eab4f756d89c89a8ce91198c7342f87b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_RadissonHotels_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/RadissonHotels/Index.cshtml")]
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
using Radisson.Domain.Models.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Radisson.Domain.AppCode.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Radisson.Domain.AppCode.Infrastructure;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Radisson.Domain.Models.FormData;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Radisson.Domain.Business.RoomModule;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Radisson.Domain.Business.RoomTypeModule;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Radisson.Domain.Business.PeopleModule;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Radisson.Domain.Business.ReservationModule;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Radisson.Domain.Business.BlogPostModule;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Radisson.Domain.Business.AboutModule.RadissonHotels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"303ca889eab4f756d89c89a8ce91198c7342f87b", @"/Areas/Admin/Views/RadissonHotels/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f6b641d57284df36123bea91b6ea7e459b47718d", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_RadissonHotels_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RadissonHotel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/aboutcss.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\RadissonHotels\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Otel Haqqında</h2>\r\n");
#nullable restore
#line 8 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\RadissonHotels\Index.cshtml"
 if (ViewBag.IsTableEmpty){

#line default
#line hidden
#nullable disable
            WriteLiteral("<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "303ca889eab4f756d89c89a8ce91198c7342f87b7518", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n");
#nullable restore
#line 12 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\RadissonHotels\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<div>\r\n<section class=\"about-section\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 17 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\RadissonHotels\Index.cshtml"
             foreach (var item in Model)
           {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-lg-6 col-md-12 col-sm-12\">\r\n                <div class=\"about-content\">\r\n                    <div class=\"sec-title left\">");
#nullable restore
#line 21 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\RadissonHotels\Index.cshtml"
                                           Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    <div class=\"text\">");
#nullable restore
#line 22 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\RadissonHotels\Index.cshtml"
                                 Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 25 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\RadissonHotels\Index.cshtml"
             foreach(var img in item.Images){
                var imagePath = item.Images.FirstOrDefault(p => p.DeletedDate == null)?.Name;

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-lg-6 col-md-12 col-sm-12 clearfix\">\r\n                <div class=\"img-box\">\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 871, "\"", 897, 2);
            WriteAttributeValue("", 877, "/uploads/images/", 877, 16, true);
#nullable restore
#line 29 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\RadissonHotels\Index.cshtml"
WriteAttributeValue("", 893, img, 893, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 32 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\RadissonHotels\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("             ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "303ca889eab4f756d89c89a8ce91198c7342f87b11373", async() => {
                WriteLiteral("<i class=\"fa-solid fa-pencil\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 33 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\RadissonHotels\Index.cshtml"
                                    WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 34 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Areas\Admin\Views\RadissonHotels\Index.cshtml"
           }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</section>\r\n</div>\r\n");
            DefineSection("addcss", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "303ca889eab4f756d89c89a8ce91198c7342f87b14048", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RadissonHotel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
