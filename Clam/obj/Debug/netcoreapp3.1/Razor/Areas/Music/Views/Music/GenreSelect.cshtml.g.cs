#pragma checksum "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\GenreSelect.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "132df0dd91cf02b44a194c228bf7c588cd5dc245"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Music_Views_Music_GenreSelect), @"mvc.1.0.view", @"/Areas/Music/Views/Music/GenreSelect.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"132df0dd91cf02b44a194c228bf7c588cd5dc245", @"/Areas/Music/Views/Music/GenreSelect.cshtml")]
    public class Areas_Music_Views_Music_GenreSelect : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Clam.Areas.Music.Models.MusicGenreSelection>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\GenreSelect.cshtml"
  
    ViewData["Title"] = "GenreSelect";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var CategoryName = ViewBag.GenreName;
    var CategoryId = ViewBag.GenreId;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<nav aria-label=""breadcrumb"">
    <ol class=""breadcrumb"">
        <li class=""breadcrumb-item""><a href=""/music/manage"">Music</a></li>
        <li class=""breadcrumb-item""><a href=""/music/manage/genre"">Genre</a></li>
        <li class=""breadcrumb-item active"" aria-current=""page"">Add Track to Genre</li>
    </ol>
</nav>

");
#nullable restore
#line 16 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\GenreSelect.cshtml"
 using (Html.BeginForm(actionName: "GenreSelect", controllerName: "Music", new { id = CategoryId }, method: FormMethod.Post))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"card\">\r\n        <div class=\"card-header\">\r\n            <h3>");
#nullable restore
#line 20 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\GenreSelect.cshtml"
           Write(CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n        </div>\r\n        <div class=\"card-body\">\r\n\r\n");
#nullable restore
#line 24 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\GenreSelect.cshtml"
             for (int i = 0; i < Model.Count; i++)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\GenreSelect.cshtml"
           Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\GenreSelect.cshtml"
           Write(Html.ValidationSummary("", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"form-group row\">\r\n                    <div class=\"form-check col-md-2\">\r\n                        ");
#nullable restore
#line 30 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\GenreSelect.cshtml"
                   Write(Html.CheckBoxFor(model => Model[i].IsSelected, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"form-check col-md-3\">\r\n                        ");
#nullable restore
#line 33 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\GenreSelect.cshtml"
                   Write(Html.TextBoxFor(model => Model[i].SongTitle, new { @class = "form-control", @disabled = "disabled" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 34 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\GenreSelect.cshtml"
                   Write(Html.TextBoxFor(model => Model[i].SongTitle, new { @class = "form-control", @hidden = "hidden" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"form-check col-md-2\">\r\n                        ");
#nullable restore
#line 37 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\GenreSelect.cshtml"
                   Write(Html.TextBoxFor(model => Model[i].SongArtist, new { @class = "form-control", @disabled = "disabled" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 38 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\GenreSelect.cshtml"
                   Write(Html.TextBoxFor(model => Model[i].SongArtist, new { @class = "form-control", @hidden = "hidden" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"form-check col-md-5\">\r\n                        ");
#nullable restore
#line 41 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\GenreSelect.cshtml"
                   Write(Html.TextBoxFor(model => Model[i].SongId, new { @class = "form-control", @disabled = "disabled" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 42 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\GenreSelect.cshtml"
                   Write(Html.TextBoxFor(model => Model[i].SongId, new { @class = "form-control", @hidden = "hidden" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 45 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\GenreSelect.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n        <div class=\"card-footer\">\r\n            <input type=\"submit\" value=\"Update\" class=\"btn btn-primary\" style=\"width:auto\" />\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 51 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\GenreSelect.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 54 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\GenreSelect.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Clam.Areas.Music.Models.MusicGenreSelection>> Html { get; private set; }
    }
}
#pragma warning restore 1591
