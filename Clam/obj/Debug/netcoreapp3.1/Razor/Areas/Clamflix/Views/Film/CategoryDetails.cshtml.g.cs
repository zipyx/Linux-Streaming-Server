#pragma checksum "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Clamflix\Views\Film\CategoryDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "92d93d916644d44c88c55cc69fb032bcdf43fd00"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Clamflix_Views_Film_CategoryDetails), @"mvc.1.0.view", @"/Areas/Clamflix/Views/Film/CategoryDetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92d93d916644d44c88c55cc69fb032bcdf43fd00", @"/Areas/Clamflix/Views/Film/CategoryDetails.cshtml")]
    public class Areas_Clamflix_Views_Film_CategoryDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Clam.Areas.Clamflix.Models.FilmCategorySelection>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Clamflix\Views\Film\CategoryDetails.cshtml"
  
    ViewData["Title"] = "CategoryDetails";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var CategoryName = ViewBag.CategoryName;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<nav aria-label=""breadcrumb"">
    <ol class=""breadcrumb"">
        <li class=""breadcrumb-item""><a href=""/clamflix/film"">Films</a></li>
        <li class=""breadcrumb-item""><a href=""/clamflix/film/category"">Cateogries</a></li>
        <li class=""breadcrumb-item active"" aria-current=""page"">");
#nullable restore
#line 12 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Clamflix\Views\Film\CategoryDetails.cshtml"
                                                          Write(CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n    </ol>\r\n</nav>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th class=\"text-center\">\r\n                ");
#nullable restore
#line 19 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Clamflix\Views\Film\CategoryDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.IsSelected));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Clamflix\Views\Film\CategoryDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.FilmTitle));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Clamflix\Views\Film\CategoryDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.Year));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Clamflix\Views\Film\CategoryDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.FilmId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 33 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Clamflix\Views\Film\CategoryDetails.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td class=\"text-center\">\r\n                    ");
#nullable restore
#line 37 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Clamflix\Views\Film\CategoryDetails.cshtml"
               Write(Html.DisplayFor(modelItem => item.IsSelected));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 40 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Clamflix\Views\Film\CategoryDetails.cshtml"
               Write(Html.DisplayFor(modelItem => item.FilmTitle));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 43 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Clamflix\Views\Film\CategoryDetails.cshtml"
               Write(Html.DisplayFor(modelItem => item.Year));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 46 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Clamflix\Views\Film\CategoryDetails.cshtml"
               Write(Html.DisplayFor(modelItem => item.FilmId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 49 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Clamflix\Views\Film\CategoryDetails.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Clam.Areas.Clamflix.Models.FilmCategorySelection>> Html { get; private set; }
    }
}
#pragma warning restore 1591
