#pragma checksum "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\Genre.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a6ba34167a563e31299a1c1ad2549974f1861dfe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_TVShows_Views_TVShow_Genre), @"mvc.1.0.view", @"/Areas/TVShows/Views/TVShow/Genre.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a6ba34167a563e31299a1c1ad2549974f1861dfe", @"/Areas/TVShows/Views/TVShow/Genre.cshtml")]
    public class Areas_TVShows_Views_TVShow_Genre : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Clam.Areas.TVShows.Models.SectionTVShowCategory>>
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
#line 3 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\Genre.cshtml"
  
    ViewData["Title"] = "Genre";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var Content = ViewBag.Content;
    var Path = ViewBag.Path;

#line default
#line hidden
#nullable disable
            WriteLiteral("<nav aria-label=\"breadcrumb\">\r\n    <ol class=\"breadcrumb\">\r\n        <li class=\"breadcrumb-item active\" aria-current=\"page\">Genres</li>\r\n    </ol>\r\n</nav>\r\n<div>\r\n    ");
#nullable restore
#line 15 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\Genre.cshtml"
Write(Html.ActionLink("Create Genre", "CreateGenre", "TVShow", null, new { @class = "btn btn-success rounded" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
#nullable restore
#line 17 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\Genre.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\r\n        <td>\r\n            <br />\r\n            <div class=\"row no-gutters bg-light position-relative\">\r\n                <div class=\"col-md-6 mb-md-0 p-md-4\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a6ba34167a563e31299a1c1ad2549974f1861dfe4656", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 739, "~/AfpIData/", 739, 11, true);
#nullable restore
#line 24 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\Genre.cshtml"
AddHtmlAttributeValue("", 750, item.ItemPath, 750, 14, false);

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
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col-md-6 position-static p-4 pl-md-0\">\r\n                    <h3 class=\"mt-0\">");
#nullable restore
#line 27 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\Genre.cshtml"
                                Write(item.Genre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3><br />\r\n                    <ul class=\"list-group list-group-flush\">\r\n                        <li class=\"list-group-item\">\r\n                            <b>");
#nullable restore
#line 30 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\Genre.cshtml"
                          Write(Html.DisplayNameFor(model => model.SubCategoryCount));

#line default
#line hidden
#nullable disable
            WriteLiteral(" :</b> ");
#nullable restore
#line 30 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\Genre.cshtml"
                                                                                      Write(Html.DisplayFor(modelItem => item.SubCategoryCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                        </li>\r\n                        <li class=\"list-group-item\">\r\n                            <b>");
#nullable restore
#line 33 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\Genre.cshtml"
                          Write(Html.DisplayNameFor(model => model.SubCategorySeasonCount));

#line default
#line hidden
#nullable disable
            WriteLiteral(" :</b> ");
#nullable restore
#line 33 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\Genre.cshtml"
                                                                                            Write(Html.DisplayFor(modelItem => item.SubCategorySeasonCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                        </li>\r\n                        <li class=\"list-group-item\">\r\n                            <b>");
#nullable restore
#line 36 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\Genre.cshtml"
                          Write(Html.DisplayNameFor(model => model.SubCategorySeasonItemCount));

#line default
#line hidden
#nullable disable
            WriteLiteral(" :</b> ");
#nullable restore
#line 36 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\Genre.cshtml"
                                                                                                Write(Html.DisplayFor(modelItem => item.SubCategorySeasonItemCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                        </li>\r\n                    </ul>\r\n                    ");
#nullable restore
#line 39 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\Genre.cshtml"
               Write(Html.ActionLink("Select", "TVShows", new { id = item.CategoryId, category = item.UrlCategory }, new { @class = "btn btn-primary stretched-link mt-auto" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"card-footer\">\r\n                <button type=\"button\" class=\"btn btn-primary float-right\" data-toggle=\"collapse\" data-target=\"#");
#nullable restore
#line 43 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\Genre.cshtml"
                                                                                                          Write(item.Genre.Replace(" ",  ""));

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Options</button>\r\n                <div");
            BeginWriteAttribute("id", " id=\"", 2214, "\"", 2248, 1);
#nullable restore
#line 44 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\Genre.cshtml"
WriteAttributeValue("", 2219, item.Genre.Replace(" ",  ""), 2219, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"collapse\">\r\n                    ");
#nullable restore
#line 45 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\Genre.cshtml"
               Write(Html.ActionLink("Delete", "DeleteGenre", new { id = item.CategoryId, category = item.UrlCategory }, new { @class = "btn btn-secondary float-right" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 46 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\Genre.cshtml"
               Write(Html.ActionLink("Details", "GenreDetails", new { id = item.CategoryId, category = item.UrlCategory }, new { @class = "btn btn-secondary float-right" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 47 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\Genre.cshtml"
               Write(Html.ActionLink("Edit", "EditGenre", new { id = item.CategoryId, category = item.UrlCategory }, new { @class = "btn btn-secondary float-right" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <footer class=\"blockquote-footer float-left\">Last Modified: <cite>");
#nullable restore
#line 49 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\Genre.cshtml"
                                                                             Write(item.LastModified);

#line default
#line hidden
#nullable disable
            WriteLiteral("</cite></footer>\r\n                <br />\r\n                <footer class=\"blockquote-footer\">Added: <cite>");
#nullable restore
#line 51 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\Genre.cshtml"
                                                          Write(item.DateCreated);

#line default
#line hidden
#nullable disable
            WriteLiteral("</cite></footer>\r\n            </div><br />\r\n        </td>\r\n    </tr>\r\n");
#nullable restore
#line 55 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\Genre.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Clam.Areas.TVShows.Models.SectionTVShowCategory>> Html { get; private set; }
    }
}
#pragma warning restore 1591
