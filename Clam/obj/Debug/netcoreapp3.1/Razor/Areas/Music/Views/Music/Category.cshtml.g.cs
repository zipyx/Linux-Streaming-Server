#pragma checksum "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\Category.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8aa950207d31547fd9034c63dcd3427bcc6f9fa9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Music_Views_Music_Category), @"mvc.1.0.view", @"/Areas/Music/Views/Music/Category.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8aa950207d31547fd9034c63dcd3427bcc6f9fa9", @"/Areas/Music/Views/Music/Category.cshtml")]
    public class Areas_Music_Views_Music_Category : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Clam.Areas.Music.Models.AreaUserMusicCategory>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\Category.cshtml"
  
    ViewData["Title"] = "Category";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<nav aria-label=\"breadcrumb\">\r\n    <ol class=\"breadcrumb\">\r\n        <li class=\"breadcrumb-item\"><a href=\"/music/manage\">Music</a></li>\r\n        <li class=\"breadcrumb-item active\" aria-current=\"page\">Genre</li>\r\n    </ol>\r\n</nav>\r\n");
            WriteLiteral("<p>\r\n    ");
#nullable restore
#line 14 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\Category.cshtml"
Write(Html.ActionLink("New Genre", "CreateGenre", "Music", null, new { @class = "btn btn-primary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</p>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th class=\"text-center\">\r\n                ");
#nullable restore
#line 21 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\Category.cshtml"
           Write(Html.DisplayNameFor(model => model.CategoryId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th class=\"text-center\">\r\n                ");
#nullable restore
#line 24 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\Category.cshtml"
           Write(Html.DisplayNameFor(model => model.CategoryName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th class=\"text-center\">\r\n                ");
#nullable restore
#line 27 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\Category.cshtml"
           Write(Html.DisplayNameFor(model => model.LastModified));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th class=\"text-center\">\r\n                ");
#nullable restore
#line 30 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\Category.cshtml"
           Write(Html.DisplayNameFor(model => model.DateCreated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th class=\"text-center\"></th>\r\n            <th class=\"text-center\">\r\n                <code>Delete</code>\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 39 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\Category.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td class=\"text-center\">\r\n                    ");
#nullable restore
#line 43 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\Category.cshtml"
               Write(Html.DisplayFor(modelItem => item.CategoryId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td class=\"text-center\">\r\n                    ");
#nullable restore
#line 46 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\Category.cshtml"
               Write(Html.DisplayFor(modelItem => item.CategoryName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td class=\"text-center\">\r\n                    ");
#nullable restore
#line 49 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\Category.cshtml"
               Write(Html.DisplayFor(modelItem => item.LastModified));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td class=\"text-center\">\r\n                    ");
#nullable restore
#line 52 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\Category.cshtml"
               Write(Html.DisplayFor(modelItem => item.DateCreated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td class=\"text-center\">\r\n                    ");
#nullable restore
#line 55 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\Category.cshtml"
               Write(Html.ActionLink("Update", "GenreSelect", "Music", new { id = item.CategoryId }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                    ");
#nullable restore
#line 56 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\Category.cshtml"
               Write(Html.ActionLink("Details", "GenreDetails", "Music", new { id = item.CategoryId }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                </td>\r\n");
            WriteLiteral("                <td class=\"text-center\">\r\n                    <button type=\"button\" class=\"btn btn-danger\" data-toggle=\"modal\" data-target=\"#modal-");
#nullable restore
#line 60 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\Category.cshtml"
                                                                                                    Write(item.CategoryId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                        Delete\r\n                    </button>\r\n\r\n                    <!-- Modal -->\r\n                    <div class=\"modal fade\"");
            BeginWriteAttribute("id", " id=\"", 2621, "\"", 2648, 2);
            WriteAttributeValue("", 2626, "modal-", 2626, 6, true);
#nullable restore
#line 65 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\Category.cshtml"
WriteAttributeValue("", 2632, item.CategoryId, 2632, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" tabindex=\"-1\" role=\"dialog\"");
            BeginWriteAttribute("aria-labelledby", " aria-labelledby=\"", 2677, "\"", 2718, 2);
            WriteAttributeValue("", 2695, "notify-", 2695, 7, true);
#nullable restore
#line 65 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\Category.cshtml"
WriteAttributeValue("", 2702, item.CategoryId, 2702, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" aria-hidden=""true"">
                        <div class=""modal-dialog modal-dialog-centered"" role=""document"">
                            <div class=""modal-content"">
                                <div class=""modal-header"">
                                    <h5 class=""modal-title""");
            BeginWriteAttribute("id", " id=\"", 3007, "\"", 3035, 2);
            WriteAttributeValue("", 3012, "notify-", 3012, 7, true);
#nullable restore
#line 69 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\Category.cshtml"
WriteAttributeValue("", 3019, item.CategoryId, 3019, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 69 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\Category.cshtml"
                                                                                    Write(item.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
                                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                                        <span aria-hidden=""true"">&times;</span>
                                    </button>
                                </div>
                                <div class=""modal-body"">
                                    Are you sure you want to delete this Genre?
                                </div>
                                <div class=""modal-footer"">
                                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
");
#nullable restore
#line 79 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\Category.cshtml"
                                     using (Html.BeginForm(actionName: "RemoveGenre", controllerName: "Music", new { id = item.CategoryId }, method: FormMethod.Post))
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <button type=\"submit\" class=\"btn btn-danger\">Confirm Delete</button>\r\n");
#nullable restore
#line 82 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\Category.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 89 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Music\Views\Music\Category.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Clam.Areas.Music.Models.AreaUserMusicCategory>> Html { get; private set; }
    }
}
#pragma warning restore 1591
