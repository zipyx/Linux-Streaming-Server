#pragma checksum "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "096c00c8443ec90eea7ca1fe21335dfd9f71f3e2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_TVShows_Views_TVShow_TVShowDetails), @"mvc.1.0.view", @"/Areas/TVShows/Views/TVShow/TVShowDetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"096c00c8443ec90eea7ca1fe21335dfd9f71f3e2", @"/Areas/TVShows/Views/TVShow/TVShowDetails.cshtml")]
    public class Areas_TVShows_Views_TVShow_TVShowDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Clam.Areas.TVShows.Models.SectionTVShowSubCategory>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowDetails.cshtml"
  
    ViewData["Title"] = "TVShowDetails";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var Name = ViewBag.Name;
    var Gid = ViewBag.Gid;
    var UrlGenre = ViewBag.UrlGenre;
    var Genre = ViewBag.Genre;

#line default
#line hidden
#nullable disable
            WriteLiteral("<nav aria-label=\"breadcrumb\">\r\n    <ol class=\"breadcrumb\">\r\n        <li class=\"breadcrumb-item\"><a");
            BeginWriteAttribute("href", " href=\"", 383, "\"", 425, 4);
            WriteAttributeValue("", 390, "/tvshows/manage/", 390, 16, true);
#nullable restore
#line 13 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowDetails.cshtml"
WriteAttributeValue("", 406, UrlGenre, 406, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 415, "/list/", 415, 6, true);
#nullable restore
#line 13 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowDetails.cshtml"
WriteAttributeValue("", 421, Gid, 421, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" >");
#nullable restore
#line 13 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowDetails.cshtml"
                                                                              Write(Genre);

#line default
#line hidden
#nullable disable
            WriteLiteral(" shows</a></li>\r\n        <li class=\"breadcrumb-item active\" aria-current=\"page\">");
#nullable restore
#line 14 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowDetails.cshtml"
                                                          Write(Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Show Details</li>\r\n    </ol>\r\n</nav>\r\n<div>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 21 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.TVShowId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 24 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowDetails.cshtml"
       Write(Html.DisplayFor(model => model.TVShowId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 27 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.TVShowTitle));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 30 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowDetails.cshtml"
       Write(Html.DisplayFor(model => model.TVShowTitle));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 33 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.ItemPath));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 36 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowDetails.cshtml"
       Write(Html.DisplayFor(model => model.ItemPath));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 39 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.TVShowSeasonNumberTotal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 42 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowDetails.cshtml"
       Write(Html.DisplayFor(model => model.TVShowSeasonNumberTotal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 45 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.LastModified));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 48 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowDetails.cshtml"
       Write(Html.DisplayFor(model => model.LastModified));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 51 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.DateCreated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 54 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowDetails.cshtml"
       Write(Html.DisplayFor(model => model.DateCreated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 57 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.SubCategorySeasonCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 60 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowDetails.cshtml"
       Write(Html.DisplayFor(model => model.SubCategorySeasonCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 63 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.SubCategorySeasonItemCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 66 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowDetails.cshtml"
       Write(Html.DisplayFor(model => model.SubCategorySeasonItemCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 69 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.CategoryId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 72 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowDetails.cshtml"
       Write(Html.DisplayFor(model => model.CategoryId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Clam.Areas.TVShows.Models.SectionTVShowSubCategory> Html { get; private set; }
    }
}
#pragma warning restore 1591
