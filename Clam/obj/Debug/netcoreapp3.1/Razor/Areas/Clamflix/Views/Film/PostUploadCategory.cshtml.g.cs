#pragma checksum "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Clamflix\Views\Film\PostUploadCategory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7b703788a226069ffe4531f59496b964dbe9163c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Clamflix_Views_Film_PostUploadCategory), @"mvc.1.0.view", @"/Areas/Clamflix/Views/Film/PostUploadCategory.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b703788a226069ffe4531f59496b964dbe9163c", @"/Areas/Clamflix/Views/Film/PostUploadCategory.cshtml")]
    public class Areas_Clamflix_Views_Film_PostUploadCategory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Clam.Areas.Clamflix.Models.AreaFilmflixCategory>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Clamflix\Views\Film\PostUploadCategory.cshtml"
  
    ViewData["Title"] = "PostUploadCategory";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<nav aria-label=""breadcrumb"">
    <ol class=""breadcrumb"">
        <li class=""breadcrumb-item""><a href=""/clamflix/film"">Films</a></li>
        <li class=""breadcrumb-item""><a href=""/clamflix/film/category"">Cateogries</a></li>
        <li class=""breadcrumb-item active"" aria-current=""page"">New Category</li>
    </ol>
</nav>

<hr />
<div class=""row"">
    <div class=""col-md-8"">
");
#nullable restore
#line 18 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Clamflix\Views\Film\PostUploadCategory.cshtml"
         using (Html.BeginForm(actionName: "PostUploadCategory", "Film", method: FormMethod.Post))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div asp-validation-summary=\"ModelOnly\" class=\"text-danger\"></div>\r\n");
#nullable restore
#line 21 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Clamflix\Views\Film\PostUploadCategory.cshtml"
       Write(Html.ValidationSummary(message: "Ensure Field is filled in by specific requirements.", htmlAttributes: new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"form-group row\">\r\n                ");
#nullable restore
#line 23 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Clamflix\Views\Film\PostUploadCategory.cshtml"
           Write(Html.LabelFor(model => model.CategoryName, null, new { @class = "col-md-4 col-form-label control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-md-8\">\r\n                    ");
#nullable restore
#line 25 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Clamflix\Views\Film\PostUploadCategory.cshtml"
               Write(Html.TextBoxFor(model => model.CategoryName, null, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 26 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Clamflix\Views\Film\PostUploadCategory.cshtml"
               Write(Html.ValidationMessageFor(model => model.CategoryName, null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <input type=\"submit\" value=\"Add\" class=\"btn btn-primary\" />\r\n            </div>\r\n");
#nullable restore
#line 32 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Clamflix\Views\Film\PostUploadCategory.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 37 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Clamflix\Views\Film\PostUploadCategory.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Clam.Areas.Clamflix.Models.AreaFilmflixCategory> Html { get; private set; }
    }
}
#pragma warning restore 1591
