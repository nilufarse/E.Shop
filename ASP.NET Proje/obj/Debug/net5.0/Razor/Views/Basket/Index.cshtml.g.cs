#pragma checksum "C:\Users\macbook\Desktop\ASP.NET Proje -New\ASP.NET Proje\Views\Basket\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8075280896c0fdd173bef9fa1241c4e5191d44bd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Basket_Index), @"mvc.1.0.view", @"/Views/Basket/Index.cshtml")]
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
#line 1 "C:\Users\macbook\Desktop\ASP.NET Proje -New\ASP.NET Proje\Views\_ViewImports.cshtml"
using ASP.NET_Proje;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\macbook\Desktop\ASP.NET Proje -New\ASP.NET Proje\Views\_ViewImports.cshtml"
using ASP.NET_Proje.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\macbook\Desktop\ASP.NET Proje -New\ASP.NET Proje\Views\_ViewImports.cshtml"
using ASP.NET_Proje.Models.ViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\macbook\Desktop\ASP.NET Proje -New\ASP.NET Proje\Views\_ViewImports.cshtml"
using ASP.NET_Proje.Models.FormModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\macbook\Desktop\ASP.NET Proje -New\ASP.NET Proje\Views\_ViewImports.cshtml"
using ASP.NET_Proje.Models.Entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\macbook\Desktop\ASP.NET Proje -New\ASP.NET Proje\Views\_ViewImports.cshtml"
using ASP.NET_Proje.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8075280896c0fdd173bef9fa1241c4e5191d44bd", @"/Views/Basket/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b28825ff65c89cd918aa011436da5b8923bb5c91", @"/Views/_ViewImports.cshtml")]
    public class Views_Basket_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\macbook\Desktop\ASP.NET Proje -New\ASP.NET Proje\Views\Basket\Index.cshtml"
Write(await Component.InvokeAsync("Product", new { userId = ViewData["User"] }));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
