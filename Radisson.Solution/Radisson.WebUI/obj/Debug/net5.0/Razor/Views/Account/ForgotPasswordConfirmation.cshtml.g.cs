#pragma checksum "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Views\Account\ForgotPasswordConfirmation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9a357a90f55c513c385da2f2b5c6db04277f461e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_ForgotPasswordConfirmation), @"mvc.1.0.view", @"/Views/Account/ForgotPasswordConfirmation.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a357a90f55c513c385da2f2b5c6db04277f461e", @"/Views/Account/ForgotPasswordConfirmation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"70094c4823455c9d12675f0d0711cd4d732d2d76", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Account_ForgotPasswordConfirmation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/login.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Views\Account\ForgotPasswordConfirmation.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9a357a90f55c513c385da2f2b5c6db04277f461e6494", async() => {
                WriteLiteral("\r\n    <meta charset=\"UTF-8\" />\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n    <title>>Şifrəmi Unutdum</title>\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9a357a90f55c513c385da2f2b5c6db04277f461e6984", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
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
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9a357a90f55c513c385da2f2b5c6db04277f461e8866", async() => {
                WriteLiteral("\r\n    <div class=\"overlay\">\r\n            <div class=\"con\">\r\n                <header class=\"head-form\">\r\n                <p>Şifrənizi yeniləmək üçün maili yoxlayin</p>\r\n                </header>\r\n                <br />\r\n                </div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</html>\r\n");
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
