#pragma checksum "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Views\Home\About.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "57c0ac99f9735ac7c081b87dda3a38053db0e1d1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_About), @"mvc.1.0.view", @"/Views/Home/About.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57c0ac99f9735ac7c081b87dda3a38053db0e1d1", @"/Views/Home/About.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"70094c4823455c9d12675f0d0711cd4d732d2d76", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_About : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedViewModel<About>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Views\Home\About.cshtml"
  
    ViewData["Title"] = "Otel Haqqında";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""page-title centred""
         style=""background-image: url(/images/background/page-title.jpg)"">
    <div class=""container"">
        <div class=""content-box"">
            <div class=""title"">Otel Haqqında</div>
            <ul class=""bread-crumb"">
                <li><a href=""index.html"">Ana Səhifə</a></li>
                <li>Otel Haqqında</li>
            </ul>
        </div>
    </div>
</section>
");
#nullable restore
#line 18 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Views\Home\About.cshtml"
Write(await Component.InvokeAsync("RadissonHotel"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<!-- fact-counter -->\r\n<section class=\"fact-counter gray-bg sec-pad centred\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 24 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Views\Home\About.cshtml"
             foreach (var item in Model.Items)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""col-lg-3 col-md-6 col-sm-12 column"">
                    <div class=""single-item"">
                        <div class=""content-box"">
                            <div></div>
                            <article class=""column wow fadeIn"" data-wow-duration=""0ms"">
                                <div class=""count-outer"">
                                    <span class=""count-text"" data-speed=""1500"" data-stop=""");
#nullable restore
#line 32 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Views\Home\About.cshtml"
                                                                                     Write(item.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">0</span>\r\n                                </div>\r\n                            </article>\r\n                            <div class=\"text\">");
#nullable restore
#line 35 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Views\Home\About.cshtml"
                                         Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 39 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Views\Home\About.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</section>\r\n\r\n");
#nullable restore
#line 44 "D:\Radisson-AspProject-Hotel\Radisson.Solution\Radisson.WebUI\Views\Home\About.cshtml"
Write(await Component.InvokeAsync("TeamsGrid"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            DefineSection("addcss", async() => {
                WriteLiteral(@"
    <style>
        .fix-img {
            width: 100%;
            height: 205px;
        }

        .r-img {
            width: 335px;
            height: 490px;
        }

        .rm-img {
            width: 370px;
            height: 230px;
        }

        .index-img {
            width: 370px;
            height: 220px;
        }
    </style>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedViewModel<About>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
