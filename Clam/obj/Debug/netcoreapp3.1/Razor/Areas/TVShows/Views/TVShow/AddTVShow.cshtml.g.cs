#pragma checksum "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\AddTVShow.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a40502129871311ace5a6a4c833fd3c57b0ec940"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_TVShows_Views_TVShow_AddTVShow), @"mvc.1.0.view", @"/Areas/TVShows/Views/TVShow/AddTVShow.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a40502129871311ace5a6a4c833fd3c57b0ec940", @"/Areas/TVShows/Views/TVShow/AddTVShow.cshtml")]
    public class Areas_TVShows_Views_TVShow_AddTVShow : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Clam.Areas.TVShows.Models.SectionTVShowSubCategory>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\AddTVShow.cshtml"
  
    ViewData["Title"] = "AddTVShow";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var UrlGenre = ViewBag.UrlGenre;
    var Genre = ViewBag.Genre;
    var Gid = ViewBag.Gid;

#line default
#line hidden
#nullable disable
            WriteLiteral("<nav aria-label=\"breadcrumb\">\r\n    <ol class=\"breadcrumb\">\r\n        <li class=\"breadcrumb-item\"><a");
            BeginWriteAttribute("href", " href=\"", 349, "\"", 391, 4);
            WriteAttributeValue("", 356, "/tvshows/manage/", 356, 16, true);
#nullable restore
#line 12 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\AddTVShow.cshtml"
WriteAttributeValue("", 372, UrlGenre, 372, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 381, "/list/", 381, 6, true);
#nullable restore
#line 12 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\AddTVShow.cshtml"
WriteAttributeValue("", 387, Gid, 387, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" >");
#nullable restore
#line 12 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\AddTVShow.cshtml"
                                                                              Write(Genre);

#line default
#line hidden
#nullable disable
            WriteLiteral(" shows</a></li>\r\n        <li class=\"breadcrumb-item active\" aria-current=\"page\">Add ");
#nullable restore
#line 13 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\AddTVShow.cshtml"
                                                              Write(Genre);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Show</li>\r\n    </ol>\r\n</nav>\r\n<hr />\r\n<div class=\"row\">\r\n    <div class=\"col-md-8\">\r\n");
#nullable restore
#line 19 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\AddTVShow.cshtml"
         using (Html.BeginForm(actionName: "AddTVShow", controllerName: "TVShow", method: FormMethod.Post, new { enctype = "multipart/form-data", id = Gid, category = Genre}))
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\AddTVShow.cshtml"
       Write(Html.ValidationSummary(message: "Ensure Field is filled in by specific requirements.", htmlAttributes: new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"form-group row\">\r\n                ");
#nullable restore
#line 23 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\AddTVShow.cshtml"
           Write(Html.LabelFor(model => model.TVShowTitle, null, new { @class = "col-md-4 col-form-label control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-md-8\">\r\n                    ");
#nullable restore
#line 25 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\AddTVShow.cshtml"
               Write(Html.TextBoxFor(model => model.TVShowTitle, null, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 26 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\AddTVShow.cshtml"
               Write(Html.ValidationMessageFor(model => model.TVShowTitle, null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"form-group row\">\r\n                ");
#nullable restore
#line 30 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\AddTVShow.cshtml"
           Write(Html.LabelFor(model => model.FormFile, null, new { @class = "col-md-4 col-form-label control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-md-8\">\r\n                    ");
#nullable restore
#line 32 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\AddTVShow.cshtml"
               Write(Html.TextBoxFor(model => model.FormFile, null, new { @class = "form-control-file border", @type = "file" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 33 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\AddTVShow.cshtml"
               Write(Html.ValidationMessageFor(model => model.FormFile, null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"form-group row\">\r\n                ");
#nullable restore
#line 37 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\AddTVShow.cshtml"
           Write(Html.LabelFor(model => model.CategoryId, null, new { @class = "col-md-4 col-form-label control-label", @hidden = "hidden" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-md-8\">\r\n                    ");
#nullable restore
#line 39 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\AddTVShow.cshtml"
               Write(Html.TextBoxFor(model => model.CategoryId, null, new { @class = "form-control", @hidden = "hidden" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 40 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\AddTVShow.cshtml"
               Write(Html.ValidationMessageFor(model => model.CategoryId, null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <input type=\"submit\" value=\"Save\" class=\"btn btn-primary\" />\r\n            </div>\r\n");
#nullable restore
#line 46 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\AddTVShow.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 51 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\TVShows\Views\TVShow\AddTVShow.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
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
