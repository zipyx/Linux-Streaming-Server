#pragma checksum "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\EBooks\Views\EBooks\CreateGenre.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "641ab375d5050722e7067f9b86e91c25abd3b305"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_EBooks_Views_EBooks_CreateGenre), @"mvc.1.0.view", @"/Areas/EBooks/Views/EBooks/CreateGenre.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"641ab375d5050722e7067f9b86e91c25abd3b305", @"/Areas/EBooks/Views/EBooks/CreateGenre.cshtml")]
    public class Areas_EBooks_Views_EBooks_CreateGenre : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Clam.Areas.EBooks.Models.AreaUserBooksCategory>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\EBooks\Views\EBooks\CreateGenre.cshtml"
  
    ViewData["Title"] = "CreateGenre";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<nav aria-label=""breadcrumb"">
    <ol class=""breadcrumb"">
        <li class=""breadcrumb-item""><a href=""/ebooks/manage"">Books</a></li>
        <li class=""breadcrumb-item""><a href=""/ebooks/manage/genre"">Genre</a></li>
        <li class=""breadcrumb-item active"" aria-current=""page"">New Genre</li>
    </ol>
</nav>

<hr />
<div class=""row"">
    <div class=""col-md-8"">
");
#nullable restore
#line 18 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\EBooks\Views\EBooks\CreateGenre.cshtml"
         using (Html.BeginForm(actionName: "CreateGenre", "EBooks", method: FormMethod.Post))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div asp-validation-summary=\"ModelOnly\" class=\"text-danger\"></div>\r\n");
#nullable restore
#line 21 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\EBooks\Views\EBooks\CreateGenre.cshtml"
       Write(Html.ValidationSummary(message: "Ensure Field is filled in by specific requirements.", htmlAttributes: new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"form-group row\">\r\n                ");
#nullable restore
#line 23 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\EBooks\Views\EBooks\CreateGenre.cshtml"
           Write(Html.LabelFor(model => model.CategoryName, null, new { @class = "col-md-4 col-form-label control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-md-8\">\r\n                    ");
#nullable restore
#line 25 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\EBooks\Views\EBooks\CreateGenre.cshtml"
               Write(Html.TextBoxFor(model => model.CategoryName, null, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 26 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\EBooks\Views\EBooks\CreateGenre.cshtml"
               Write(Html.ValidationMessageFor(model => model.CategoryName, null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <input type=\"submit\" value=\"Add\" class=\"btn btn-primary\" />\r\n            </div>\r\n");
#nullable restore
#line 32 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\EBooks\Views\EBooks\CreateGenre.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 37 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\EBooks\Views\EBooks\CreateGenre.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Clam.Areas.EBooks.Models.AreaUserBooksCategory> Html { get; private set; }
    }
}
#pragma warning restore 1591
