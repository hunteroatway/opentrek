#pragma checksum "C:\Users\ASUS\source\repos\opentrek\Views\Map\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "69388984779d3b8f89476a317691f8452099eae7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Map_Index), @"mvc.1.0.view", @"/Views/Map/Index.cshtml")]
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
#line 1 "C:\Users\ASUS\source\repos\opentrek\Views\_ViewImports.cshtml"
using opentrek;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ASUS\source\repos\opentrek\Views\_ViewImports.cshtml"
using opentrek.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"69388984779d3b8f89476a317691f8452099eae7", @"/Views/Map/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9ebbec0b7422750d3b64528e651c3f037e5351e1", @"/Views/_ViewImports.cshtml")]
    public class Views_Map_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<opentrek.Models.LocationModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\ASUS\source\repos\opentrek\Views\Map\Index.cshtml"
  
    ViewData["Title"] = "Map Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div id=\"map\" style=\"height: 500px\"></div>\r\n<pre id=\"country\" class=\"country\"></pre>\r\n\r\n<h1>");
#nullable restore
#line 9 "C:\Users\ASUS\source\repos\opentrek\Views\Map\Index.cshtml"
Write(Html.DisplayFor(model => model.Country));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n<h1>");
#nullable restore
#line 10 "C:\Users\ASUS\source\repos\opentrek\Views\Map\Index.cshtml"
Write(Html.DisplayFor(model => model.Recommendation));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<opentrek.Models.LocationModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
