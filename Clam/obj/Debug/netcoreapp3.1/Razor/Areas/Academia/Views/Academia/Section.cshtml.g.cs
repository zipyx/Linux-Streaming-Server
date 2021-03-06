#pragma checksum "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Academia\Views\Academia\Section.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74a5bf6c1c6553ab8a63a3b6f1b521922f78a49e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Academia_Views_Academia_Section), @"mvc.1.0.view", @"/Areas/Academia/Views/Academia/Section.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74a5bf6c1c6553ab8a63a3b6f1b521922f78a49e", @"/Areas/Academia/Views/Academia/Section.cshtml")]
    public class Areas_Academia_Views_Academia_Section : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Clam.Areas.Academia.Models.SectionRegister>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Academia\Views\Academia\Section.cshtml"
   var Aid = ViewBag.Aid;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Academia\Views\Academia\Section.cshtml"
   var Name = ViewBag.Category;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Academia\Views\Academia\Section.cshtml"
  
    ViewData["Title"] = "Section";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var UrlCategory = ViewBag.UrlCategory;
    var CategoryName = ViewBag.CategoryName;

#line default
#line hidden
#nullable disable
            WriteLiteral("<nav aria-label=\"breadcrumb\">\r\n    <ol class=\"breadcrumb\">\r\n        <li class=\"breadcrumb-item\"><a href=\"/academia/manage\">Academic Categories</a></li>\r\n        <li class=\"breadcrumb-item active\" aria-current=\"page\">");
#nullable restore
#line 13 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Academia\Views\Academia\Section.cshtml"
                                                          Write(CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n    </ol>\r\n</nav>\r\n");
#nullable restore
#line 16 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Academia\Views\Academia\Section.cshtml"
 if ((User.Identity.IsAuthenticated) && ((User.IsInRole("Contributor"))
|| (User.IsInRole("Engineer")) || (User.IsInRole("Developer")) || (User.IsInRole("Admin")) || (User.IsInRole("Owner"))))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>\r\n        ");
#nullable restore
#line 20 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Academia\Views\Academia\Section.cshtml"
   Write(Html.ActionLink("Create Section", "CreateSection", "Academia", new { id = Aid, category = UrlCategory }, new { @class = "btn btn-success" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </p>\r\n");
#nullable restore
#line 22 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Academia\Views\Academia\Section.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Academia\Views\Academia\Section.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\r\n        <td>\r\n            <div class=\"card\">\r\n                <div class=\"card-header\">\r\n                    <div class=\"float-sm-left\">\r\n                        <h3>");
#nullable restore
#line 30 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Academia\Views\Academia\Section.cshtml"
                       Write(item.SubCategoryTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                    </div>\r\n                    <div class=\"float-sm-right\">\r\n                        <b>Total Videos:</b> ");
#nullable restore
#line 33 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Academia\Views\Academia\Section.cshtml"
                                        Write(item.VideoCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"card-body\">\r\n                    <h5>Description</h5>\r\n                    <p class=\"card-text\">");
#nullable restore
#line 38 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Academia\Views\Academia\Section.cshtml"
                                    Write(item.SubCategoryDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n                <div class=\"card-footer text-muted\">\r\n                    <footer class=\"blockquote-footer float-left\">Last Modified: <cite>");
#nullable restore
#line 41 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Academia\Views\Academia\Section.cshtml"
                                                                                 Write(item.LastModified);

#line default
#line hidden
#nullable disable
            WriteLiteral("</cite></footer>\r\n                    <br />\r\n                    <footer class=\"blockquote-footer float-left\">Added: <cite>");
#nullable restore
#line 43 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Academia\Views\Academia\Section.cshtml"
                                                                         Write(item.DateAdded);

#line default
#line hidden
#nullable disable
            WriteLiteral("</cite></footer>\r\n                    ");
#nullable restore
#line 44 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Academia\Views\Academia\Section.cshtml"
               Write(Html.ActionLink("Select", "Episode", new { id = @item.AcademicId, said = @item.SubCategoryId, category = item.UrlCategory, section = item.UrlSection }, new { @class = "btn btn-primary float-right" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 45 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Academia\Views\Academia\Section.cshtml"
                     if ((User.Identity.IsAuthenticated) && ((User.IsInRole("Contributor")) 
                        || (User.IsInRole("Engineer")) || (User.IsInRole("Developer")) || (User.IsInRole("Admin")) || (User.IsInRole("Owner"))))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <button type=\"button\" data-toggle=\"collapse\" data-target=\"#");
#nullable restore
#line 48 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Academia\Views\Academia\Section.cshtml"
                                                                              Write(item.SubCategoryTitle.Replace(" ", ""));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"btn btn-primary float-right\">Options</button>\r\n                        <div");
            BeginWriteAttribute("id", " id=\"", 2551, "\"", 2596, 1);
#nullable restore
#line 49 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Academia\Views\Academia\Section.cshtml"
WriteAttributeValue("", 2556, item.SubCategoryTitle.Replace(" ",  ""), 2556, 40, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"collapse\">\r\n                            ");
#nullable restore
#line 50 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Academia\Views\Academia\Section.cshtml"
                       Write(Html.ActionLink("Details", "SectionDetails", new { id = @item.SubCategoryId, category = item.UrlCategory, section = item.UrlSection }, new { @class = "btn btn-primary float-right" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            ");
#nullable restore
#line 51 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Academia\Views\Academia\Section.cshtml"
                       Write(Html.ActionLink("Edit", "EditSection", new { id = @item.SubCategoryId, category = item.UrlCategory, section = item.UrlSection }, new { @class = "btn btn-primary float-right" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            ");
#nullable restore
#line 52 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Academia\Views\Academia\Section.cshtml"
                       Write(Html.ActionLink("Delete", "DeleteSection", new { id = @item.SubCategoryId, category = item.UrlCategory, section = item.UrlSection }, new { @class = "btn btn-danger float-right" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n");
#nullable restore
#line 54 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Academia\Views\Academia\Section.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n            <br />\r\n        </td>\r\n    </tr>\r\n");
#nullable restore
#line 60 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Academia\Views\Academia\Section.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Clam.Areas.Academia.Models.SectionRegister>> Html { get; private set; }
    }
}
#pragma warning restore 1591
