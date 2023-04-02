#pragma checksum "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Views\BlogPosts\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "775b0dbc27515fcfad9b198a4397787d8ef54b64"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BlogPosts_Index), @"mvc.1.0.view", @"/Views/BlogPosts/Index.cshtml")]
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
#line 2 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Views\_ViewImports.cshtml"
using Radisson.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Views\_ViewImports.cshtml"
using Radisson.WebUI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Views\_ViewImports.cshtml"
using Radisson.Domain.Models.FormData;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Views\_ViewImports.cshtml"
using Radisson.Application.AppCode.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Views\_ViewImports.cshtml"
using Radisson.Application.AppCode.Infrastructure;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Views\_ViewImports.cshtml"
using Radisson.Domain.Models.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Views\_ViewImports.cshtml"
using Radisson.Domain.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Views\_ViewImports.cshtml"
using Radisson.Domain.Business.ContactPostModule;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Views\_ViewImports.cshtml"
using Radisson.Domain.Business.ReservationModule;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Views\_ViewImports.cshtml"
using Radisson.Domain.Business.PaymentModule;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Views\_ViewImports.cshtml"
using Radisson.Domain.Models.Entities.Membership;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"775b0dbc27515fcfad9b198a4397787d8ef54b64", @"/Views/BlogPosts/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"70094c4823455c9d12675f0d0711cd4d732d2d76", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_BlogPosts_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedViewModel<BlogPost>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_PostBody", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Views\BlogPosts\Index.cshtml"
  
    ViewData["Title"] = "Forumlar";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <!-- page-title -->
    <section class=""page-title sec-pad centred"" style=""background-image: url(images/background/page-title.jpg);"">
        <div class=""container"">
            <div class=""content-box"">
            <div class=""title"">Forumlar</div>
                <ul class=""bread-crumb"">
                    <li><a href=""index.html"">Ana Səhifə</a></li>
                <li>Forumlar</li>
                </ul>
            </div>
        </div>
    </section>
    <!-- page-title end -->


    <!-- news-section -->
    <section class=""news-section blog-classic sec-pad-2"">
    <div id=""dynamic-content"" class=""container"">
        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "775b0dbc27515fcfad9b198a4397787d8ef54b646303", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 24 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Views\BlogPosts\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n    </section>\r\n    <!-- news-section -->\r\n\r\n\r\n");
            DefineSection("addjs", async() => {
                WriteLiteral("\r\n\r\n    <script>\r\n        function goPage(pageIndex, pageSize) {\r\n\r\n            $.ajax({\r\n                url: `");
#nullable restore
#line 36 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Views\BlogPosts\Index.cshtml"
                 Write(Url.Action("Index"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"?pageIndex=${pageIndex}&pageSize=${pageSize}`,
                method: 'GET',
                success: function (response) {
                    $('#dynamic-content').html(response);
                    location.hash = '#dynamic-content';
                    location.hash = '';
                },
                error: function (response) {
                    console.log(response)
                }
            });
        }
    </script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedViewModel<BlogPost>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
