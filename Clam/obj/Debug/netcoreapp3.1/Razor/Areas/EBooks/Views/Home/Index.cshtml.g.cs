#pragma checksum "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\EBooks\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0c60d41f1d7327c7b61de15ba2cfe99350ec0c2f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_EBooks_Views_Home_Index), @"mvc.1.0.view", @"/Areas/EBooks/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c60d41f1d7327c7b61de15ba2cfe99350ec0c2f", @"/Areas/EBooks/Views/Home/Index.cshtml")]
    public class Areas_EBooks_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Clam.Areas.EBooks.Models.BooksHome>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/books/books.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\EBooks\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0c60d41f1d7327c7b61de15ba2cfe99350ec0c2f3691", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("<a href=\"/ebooks\">\r\n    <h1 style=\"color:#e50914;\">EBooks</h1>\r\n</a>\r\n\r\n<!-- Search Bar -->\r\n<div class=\"container\">\r\n    <div class=\"display-tv-section\">\r\n        <br />\r\n        <h2 style=\"color:whitesmoke\">Search</h2>\r\n");
#nullable restore
#line 19 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\EBooks\Views\Home\Index.cshtml"
         using (Html.BeginForm("Index", "Home", FormMethod.Get))
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\EBooks\Views\Home\Index.cshtml"
       Write(Html.TextBox("search", null, null, new { @class = "form-control", @placeholder = "Book name, genre", @id = "myMovie" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n            <input type=\"submit\" value=\"Search\" id=\"myMovie\" class=\"btn btn-success\" />\r\n");
#nullable restore
#line 23 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\EBooks\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n<br />\r\n\r\n<div id=\"page-content\">\r\n");
            WriteLiteral("    ");
#nullable restore
#line 30 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\EBooks\Views\Home\Index.cshtml"
Write(await Html.PartialAsync("_IndexPartial"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
</div>

<!-- Initialize Swiper -->
<script>
    var swiper = new Swiper('.swiper-container-book', {
        effect: 'coverflow',
        grabCursor: true,
        spaceBetween: 40,
        slidesPerView: 'auto',

        breakpoints: {
            320: {
                slidesPerView: 2
            },
            480: {
                slidesPerView: 2
            },
            640: {
                slidesPerView: 2
            },
            768: {
                slidesPerView: 3,
                slidesPerGroup: 3
            },
            850: {
                slidesPerView: 4,
                slidesPerGroup: 4
            },
            1024: {
                slidesPerView: 5,
                slidesPerGroup: 5
            }
        },

        coverflowEffect: {
            rotate: 0,
            stretch: 0,
            depth: 0,
            modifier: 1,
            slideShadows: false,
        },

        navigation: {
            nextEl: '.swiper-button-");
            WriteLiteral(@"next',
            prevEl: '.swiper-button-prev'
        },

        pagination: {
            el: '.page-book-zero',
            clickable: true,
        }
    });

    var swiper = new Swiper('.swiper-container-book-genre', {
        spaceBetween: 5,
        slidesPerView: 3,
        breakpoints: {
            320: {
                slidesPerView: 2
            },
            480: {
                slidesPerView: 2
            },
            640: {
                slidesPerView: 2
            },
            640: {
                slidesPerView: 3,
                spacebetween: 5
            },
            768: {
                slidesPerView: 3,
                spacebetween: 5
            },
            850: {
                slidesPerView: 4,
                slidesPerGroup: 4
            },
            1024: {
                slidesPerView: 5,
                spacebetween: 5
            }
        },
        pagination: {
            el: '.page-book-one',
          ");
            WriteLiteral("  clickable: true,\r\n        },\r\n        navigation: {\r\n            nextEl: \'.swiper-button-next\',\r\n            prevEl: \'.swiper-button-prev\',\r\n        },\r\n    });\r\n\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Clam.Areas.EBooks.Models.BooksHome> Html { get; private set; }
    }
}
#pragma warning restore 1591
