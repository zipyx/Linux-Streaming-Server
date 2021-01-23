#pragma checksum "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowSeasons.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c309dd7b9e52005ea7dcba7a27e85e49e8870296"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_TVShows_Views_TVShow_TVShowSeasons), @"mvc.1.0.view", @"/Areas/TVShows/Views/TVShow/TVShowSeasons.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c309dd7b9e52005ea7dcba7a27e85e49e8870296", @"/Areas/TVShows/Views/TVShow/TVShowSeasons.cshtml")]
    public class Areas_TVShows_Views_TVShow_TVShowSeasons : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Clam.Areas.TVShows.Models.SectionTVShowSubCategorySeason>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("w-100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("..."), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowSeasons.cshtml"
  
    ViewData["Title"] = "TVShowSeasons";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var Name = ViewBag.Name;
    var Genre = ViewBag.Genre;
    var Gid = ViewBag.Gid;
    var Show = ViewBag.Show;

    var UrlGenre = ViewBag.UrlCategory;
    var UrlSection = ViewBag.UrlSection;

#line default
#line hidden
#nullable disable
            WriteLiteral("<nav aria-label=\"breadcrumb\">\r\n    <ol class=\"breadcrumb\">\r\n        <li class=\"breadcrumb-item\"><a href=\"/tvshows/manage\">Genres</a></li>\r\n        <li class=\"breadcrumb-item\"><a");
            BeginWriteAttribute("href", " href=\"", 558, "\"", 600, 4);
            WriteAttributeValue("", 565, "/tvshows/manage/", 565, 16, true);
#nullable restore
#line 17 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowSeasons.cshtml"
WriteAttributeValue("", 581, UrlGenre, 581, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 590, "/list/", 590, 6, true);
#nullable restore
#line 17 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowSeasons.cshtml"
WriteAttributeValue("", 596, Gid, 596, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 17 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowSeasons.cshtml"
                                                                             Write(Genre);

#line default
#line hidden
#nullable disable
            WriteLiteral(" shows</a></li>\r\n        <li class=\"breadcrumb-item active\" aria-current=\"page\">");
#nullable restore
#line 18 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowSeasons.cshtml"
                                                          Write(Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n    </ol>\r\n</nav>\r\n<div>\r\n    ");
#nullable restore
#line 22 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowSeasons.cshtml"
Write(Html.ActionLink("Add Season", "AddTVShowSeason", "TVShow", new { id = Gid, show = Show, Category = UrlGenre, Section = UrlSection }, new { @class = "btn btn-success rounded" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
#nullable restore
#line 24 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowSeasons.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\r\n        <td>\r\n            <br />\r\n            <div class=\"row no-gutters bg-light position-relative\">\r\n                <div class=\"col-md-6 mb-md-0 p-md-4\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "c309dd7b9e52005ea7dcba7a27e85e49e88702966393", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1148, "~/AfpIData/", 1148, 11, true);
#nullable restore
#line 31 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowSeasons.cshtml"
AddHtmlAttributeValue("", 1159, item.ItemPath, 1159, 14, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col-md-6 position-static p-4 pl-md-0\">\r\n                    <h3 class=\"mt-0\">Season ");
#nullable restore
#line 34 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowSeasons.cshtml"
                                       Write(item.TVShowSeasonNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                    <ul class=\"list-group list-group-flush\">\r\n                        <li class=\"list-group-item\">\r\n                            <b>");
#nullable restore
#line 37 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowSeasons.cshtml"
                          Write(Html.DisplayNameFor(model => model.SubCategorySeasonItemCount));

#line default
#line hidden
#nullable disable
            WriteLiteral(" :</b> ");
#nullable restore
#line 37 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowSeasons.cshtml"
                                                                                                Write(Html.DisplayFor(modelItem => item.SubCategorySeasonItemCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                        </li>\r\n                    </ul>\r\n                    ");
#nullable restore
#line 40 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowSeasons.cshtml"
               Write(Html.ActionLink("Select", "Episode", new { id = item.CategoryId, show = item.TVShowId, season = item.SeasonId, category = item.UrlCategory, section = item.UrlSection, subsection = item.UrlSubSection }, new { @class = "btn btn-primary stretched-link mt-auto" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"card-footer\">\r\n                <button type=\"button\" class=\"btn btn-primary float-right rounded\" data-toggle=\"collapse\" data-target=\"#season-");
#nullable restore
#line 44 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowSeasons.cshtml"
                                                                                                                         Write(item.TVShowSeasonNumber.ToString().Replace(" ",  ""));

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Options</button>\r\n                <div");
            BeginWriteAttribute("id", " id=\"", 2298, "\"", 2363, 2);
            WriteAttributeValue("", 2303, "season-", 2303, 7, true);
#nullable restore
#line 45 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowSeasons.cshtml"
WriteAttributeValue("", 2310, item.TVShowSeasonNumber.ToString().Replace(" ",  ""), 2310, 53, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"collapse\">\r\n                    ");
#nullable restore
#line 46 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowSeasons.cshtml"
               Write(Html.ActionLink("Delete", "DeleteTVShowSeason", new { id = item.CategoryId, show = item.TVShowId, season = item.SeasonId, category = item.UrlCategory, section = item.UrlSection, subsection = item.UrlSubSection }, new { @class = "btn btn-secondary float-right rounded" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 47 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowSeasons.cshtml"
               Write(Html.ActionLink("Edit", "EditTVShowSeason", new { id = item.CategoryId, show = item.TVShowId, season = item.SeasonId, category = item.UrlCategory, section = item.UrlSection, subsection = item.UrlSubSection }, new { @class = "btn btn-secondary float-right rounded" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <footer class=\"blockquote-footer float-left\">Last Modified: <cite>");
#nullable restore
#line 49 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowSeasons.cshtml"
                                                                             Write(item.LastModified);

#line default
#line hidden
#nullable disable
            WriteLiteral("</cite></footer>\r\n                <br />\r\n                <footer class=\"blockquote-footer\">Added: <cite>");
#nullable restore
#line 51 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowSeasons.cshtml"
                                                          Write(item.DateCreated);

#line default
#line hidden
#nullable disable
            WriteLiteral("</cite></footer>\r\n            </div><br />\r\n        </td>\r\n    </tr>\r\n");
#nullable restore
#line 55 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\TVShowSeasons.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Clam.Areas.TVShows.Models.SectionTVShowSubCategorySeason>> Html { get; private set; }
    }
}
#pragma warning restore 1591