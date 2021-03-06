#pragma checksum "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Tickets\Views\Ticket\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "83739cc3c29439adc3d3cce330b775fa3ee25e70"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Tickets_Views_Ticket_Index), @"mvc.1.0.view", @"/Areas/Tickets/Views/Ticket/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"83739cc3c29439adc3d3cce330b775fa3ee25e70", @"/Areas/Tickets/Views/Ticket/Index.cshtml")]
    public class Areas_Tickets_Views_Ticket_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Clam.Areas.Tickets.Models.TicketHome>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Tickets\Views\Ticket\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<nav aria-label=""breadcrumb"">
    <ol class=""breadcrumb"">
        <li class=""breadcrumb-item active"" aria-current=""page"">Tickets</li>
    </ol>
</nav>
<button type=""button"" class=""btn btn-primary"" data-toggle=""modal"" data-target=""#modalForm"">
    Create Ticket
</button><br />

<!-- Modal -->
<div class=""modal fade"" id=""modalForm"" tabindex=""-1"" role=""dialog"" aria-labelledby=""notify-modal"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""notify-modal"">Log Ticket</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
");
#nullable restore
#line 26 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Tickets\Views\Ticket\Index.cshtml"
                 using (Html.BeginForm(actionName: "Create", controllerName: "Ticket", method: FormMethod.Post))
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Tickets\Views\Ticket\Index.cshtml"
               Write(Html.ValidationSummary(message: "Please be accurate, simple and to the point.", htmlAttributes: new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"form-group row\">\r\n                        ");
#nullable restore
#line 30 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Tickets\Views\Ticket\Index.cshtml"
                   Write(Html.LabelFor(model => model.TicketModel.TicketTitle, null, new { @class = "col-md-4 col-form-label control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <div class=\"col-md-8\">\r\n                            ");
#nullable restore
#line 32 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Tickets\Views\Ticket\Index.cshtml"
                       Write(Html.TextBoxFor(model => model.TicketModel.TicketTitle, null, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            ");
#nullable restore
#line 33 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Tickets\Views\Ticket\Index.cshtml"
                       Write(Html.ValidationMessageFor(model => model.TicketModel.TicketTitle, null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"form-group row\">\r\n                        ");
#nullable restore
#line 37 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Tickets\Views\Ticket\Index.cshtml"
                   Write(Html.LabelFor(model => model.TicketModel.TicketMessage, null, new { @class = "col-md-4 col-form-label control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <div class=\"col-md-8\">\r\n                            ");
#nullable restore
#line 39 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Tickets\Views\Ticket\Index.cshtml"
                       Write(Html.TextAreaFor(model => model.TicketModel.TicketMessage, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            ");
#nullable restore
#line 40 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Tickets\Views\Ticket\Index.cshtml"
                       Write(Html.ValidationMessageFor(model => model.TicketModel.TicketMessage, null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"form-group\">\r\n                        <input type=\"submit\" value=\"Submit\" class=\"btn btn-primary\" />\r\n                    </div>\r\n");
#nullable restore
#line 46 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Tickets\Views\Ticket\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div>\r\n");
            WriteLiteral("    ");
#nullable restore
#line 54 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Tickets\Views\Ticket\Index.cshtml"
Write(await Html.PartialAsync("_IndexPartial"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 58 "C:\Users\Gorilla Rig\source\repos\Clam\Clam\Areas\Tickets\Views\Ticket\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Clam.Areas.Tickets.Models.TicketHome> Html { get; private set; }
    }
}
#pragma warning restore 1591
