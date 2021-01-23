#pragma checksum "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7e587fa0cc16180719d42a571c9fc38ed7f33648"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_TVShows_Views_TVShow_DeleteTVShowSeason), @"mvc.1.0.view", @"/Areas/TVShows/Views/TVShow/DeleteTVShowSeason.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7e587fa0cc16180719d42a571c9fc38ed7f33648", @"/Areas/TVShows/Views/TVShow/DeleteTVShowSeason.cshtml")]
    public class Areas_TVShows_Views_TVShow_DeleteTVShowSeason : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Clam.Areas.TVShows.Models.SectionTVShowSubCategorySeason>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
  
    ViewData["Title"] = "DeleteTVShowSeason";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var Show = ViewBag.Show;
    var Genre = ViewBag.Genre;
    var Gid = ViewBag.Gid;
    var TVShowId = ViewBag.TVShowId;
    var SeasonId = ViewBag.SeasonId;
    var SeasonNumber = ViewBag.SeasonNumber;

    var GenreUrl = ViewBag.GenreUrl;
    var ShowUrl = ViewBag.ShowUrl;


#line default
#line hidden
#nullable disable
            WriteLiteral("<nav aria-label=\"breadcrumb\">\r\n    <ol class=\"breadcrumb\">\r\n        <li class=\"breadcrumb-item\"><a");
            BeginWriteAttribute("href", " href=\"", 556, "\"", 620, 8);
            WriteAttributeValue("", 563, "/tvshows/manage/", 563, 16, true);
#nullable restore
#line 19 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
WriteAttributeValue("", 579, GenreUrl, 579, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 588, "/", 588, 1, true);
#nullable restore
#line 19 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
WriteAttributeValue("", 589, ShowUrl, 589, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 597, "/seasons/", 597, 9, true);
#nullable restore
#line 19 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
WriteAttributeValue("", 606, Gid, 606, 4, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 610, "/", 610, 1, true);
#nullable restore
#line 19 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
WriteAttributeValue("", 611, TVShowId, 611, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 19 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
                                                                                                   Write(Show);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Seasons</a></li>\r\n        <li class=\"breadcrumb-item active\" aria-current=\"page\">Remove ");
#nullable restore
#line 20 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
                                                                 Write(Show);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Season ");
#nullable restore
#line 20 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
                                                                              Write(SeasonNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n    </ol>\r\n</nav>\r\n<div>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 27 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
       Write(Html.DisplayNameFor(model => model.SeasonId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 30 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
       Write(Html.DisplayFor(model => model.SeasonId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 33 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
       Write(Html.DisplayNameFor(model => model.TVShowSeasonNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 36 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
       Write(Html.DisplayFor(model => model.TVShowSeasonNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 39 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
       Write(Html.DisplayNameFor(model => model.ItemPath));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 42 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
       Write(Html.DisplayFor(model => model.ItemPath));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 45 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
       Write(Html.DisplayNameFor(model => model.LastModified));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 48 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
       Write(Html.DisplayFor(model => model.LastModified));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 51 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
       Write(Html.DisplayNameFor(model => model.DateCreated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 54 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
       Write(Html.DisplayFor(model => model.DateCreated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 57 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
       Write(Html.DisplayNameFor(model => model.SubCategorySeasonItemCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 60 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
       Write(Html.DisplayFor(model => model.SubCategorySeasonItemCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 63 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
       Write(Html.DisplayNameFor(model => model.CategoryId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 66 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
       Write(Html.DisplayFor(model => model.CategoryId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 69 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
       Write(Html.DisplayNameFor(model => model.TVShowId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 72 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
       Write(Html.DisplayFor(model => model.TVShowId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n");
#nullable restore
#line 75 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
     using (Html.BeginForm(actionName: "DeleteTVShowSeason", controllerName: "TVShow", method: FormMethod.Post, new { enctype = "multipart/form-data", id = Gid, show = TVShowId }))
    {
        

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"form-group row\">\r\n            ");
#nullable restore
#line 79 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
       Write(Html.LabelFor(model => model.CategoryId, null, new { @class = "col-md-4 col-form-label control-label", @hidden = "hidden" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-8\">\r\n                ");
#nullable restore
#line 81 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
           Write(Html.TextBoxFor(model => model.CategoryId, null, new { @class = "form-control", @hidden = "hidden" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 82 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
           Write(Html.ValidationMessageFor(model => model.CategoryId, null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"form-group row\">\r\n            ");
#nullable restore
#line 86 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
       Write(Html.LabelFor(model => model.TVShowId, null, new { @class = "col-md-4 col-form-label control-label", @hidden = "hidden" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-8\">\r\n                ");
#nullable restore
#line 88 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
           Write(Html.TextBoxFor(model => model.TVShowId, null, new { @class = "form-control", @hidden = "hidden" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 89 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
           Write(Html.ValidationMessageFor(model => model.TVShowId, null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"form-group row\">\r\n            ");
#nullable restore
#line 93 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
       Write(Html.LabelFor(model => model.SeasonId, null, new { @class = "col-md-4 col-form-label control-label", @hidden = "hidden" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-8\">\r\n                ");
#nullable restore
#line 95 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
           Write(Html.TextBoxFor(model => model.SeasonId, null, new { @class = "form-control", @hidden = "hidden" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 96 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
           Write(Html.ValidationMessageFor(model => model.SeasonId, null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"form-group\">\r\n            <input type=\"submit\" value=\"Remove\" class=\"btn btn-danger\" />\r\n        </div>\r\n");
#nullable restore
#line 102 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\DeleteTVShowSeason.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Clam.Areas.TVShows.Models.SectionTVShowSubCategorySeason> Html { get; private set; }
    }
}
#pragma warning restore 1591