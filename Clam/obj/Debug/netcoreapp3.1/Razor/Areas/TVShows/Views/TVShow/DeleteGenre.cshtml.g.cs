#pragma checksum "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteGenre.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d8ecb980ba4a17b3a088f324d7bebd41b0c61371"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_TVShows_Views_TVShow_DeleteGenre), @"mvc.1.0.view", @"/Areas/TVShows/Views/TVShow/DeleteGenre.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8ecb980ba4a17b3a088f324d7bebd41b0c61371", @"/Areas/TVShows/Views/TVShow/DeleteGenre.cshtml")]
    public class Areas_TVShows_Views_TVShow_DeleteGenre : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Clam.Areas.TVShows.Models.SectionTVShowCategory>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteGenre.cshtml"
  
    ViewData["Title"] = "DeleteGenre";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var Name = ViewBag.Name;
    var Gid = ViewBag.Gid;
    var Genre = ViewBag.Genre;

#line default
#line hidden
#nullable disable
            WriteLiteral("<nav aria-label=\"breadcrumb\">\r\n    <ol class=\"breadcrumb\">\r\n        <li class=\"breadcrumb-item\"><a href=\"/tvshows/manage\">Genres</a></li>\r\n        <li class=\"breadcrumb-item active\" aria-current=\"page\">Remove ");
#nullable restore
#line 12 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteGenre.cshtml"
                                                                 Write(Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Genre</li>\r\n    </ol>\r\n</nav>\r\n<div>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 19 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteGenre.cshtml"
       Write(Html.DisplayNameFor(model => model.CategoryId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 22 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteGenre.cshtml"
       Write(Html.DisplayFor(model => model.CategoryId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 25 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteGenre.cshtml"
       Write(Html.DisplayNameFor(model => model.Genre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 28 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteGenre.cshtml"
       Write(Html.DisplayFor(model => model.Genre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 31 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteGenre.cshtml"
       Write(Html.DisplayNameFor(model => model.SubCategoryCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 34 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteGenre.cshtml"
       Write(Html.DisplayFor(model => model.SubCategoryCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 37 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteGenre.cshtml"
       Write(Html.DisplayNameFor(model => model.SubCategorySeasonCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 40 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteGenre.cshtml"
       Write(Html.DisplayFor(model => model.SubCategorySeasonCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 43 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteGenre.cshtml"
       Write(Html.DisplayNameFor(model => model.SubCategorySeasonItemCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 46 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteGenre.cshtml"
       Write(Html.DisplayFor(model => model.SubCategorySeasonItemCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 49 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteGenre.cshtml"
       Write(Html.DisplayNameFor(model => model.LastModified));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 52 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteGenre.cshtml"
       Write(Html.DisplayFor(model => model.LastModified));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 55 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteGenre.cshtml"
       Write(Html.DisplayNameFor(model => model.DateCreated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 58 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteGenre.cshtml"
       Write(Html.DisplayFor(model => model.DateCreated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n");
#nullable restore
#line 61 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteGenre.cshtml"
     using (Html.BeginForm(actionName: "DeleteGenre", controllerName: "TVShow", method: FormMethod.Post, new { enctype = "multipart/form-data", id = Gid, category = Name }))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"form-group row\">\r\n            ");
#nullable restore
#line 64 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteGenre.cshtml"
       Write(Html.LabelFor(model => model.CategoryId, null, new { @class = "col-md-4 col-form-label control-label", @hidden = "hidden" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-8\">\r\n                ");
#nullable restore
#line 66 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteGenre.cshtml"
           Write(Html.TextBoxFor(model => model.CategoryId, null, new { @class = "form-control", @hidden = "hidden" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 67 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteGenre.cshtml"
           Write(Html.ValidationMessageFor(model => model.CategoryId, null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"form-group\">\r\n            <input type=\"submit\" value=\"Remove\" class=\"btn btn-danger\" />\r\n        </div>\r\n");
#nullable restore
#line 73 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteGenre.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Clam.Areas.TVShows.Models.SectionTVShowCategory> Html { get; private set; }
    }
}
#pragma warning restore 1591
