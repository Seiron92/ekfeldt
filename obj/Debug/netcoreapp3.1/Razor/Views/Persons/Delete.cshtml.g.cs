#pragma checksum "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5ab06136df256cf3160d2c2f0b9399866ca87e7b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Persons_Delete), @"mvc.1.0.view", @"/Views/Persons/Delete.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\_ViewImports.cshtml"
using project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\_ViewImports.cshtml"
using project.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ab06136df256cf3160d2c2f0b9399866ca87e7b", @"/Views/Persons/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"229d22977632e367b33876458aad14c78337e6d5", @"/Views/_ViewImports.cshtml")]
    public class Views_Persons_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<project.Models.Persons>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/man.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("En man"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "BidderIndex", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/menu.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
  
    ViewData["Title"] = "Avboka person";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""section"">
    <div id=""header"">
        <div class=""container-fluid"">
            <div class=""row"">
                <div class=""col-sm-2 high social"">
                    <ul>
                        <li>
                            <i class=""fab fa-instagram""></i>
                        </li>
                        <li><i class=""fab fa-facebook""></i></li>
                    </ul>
                </div>
                <div class=""col high main"">
");
#nullable restore
#line 20 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
                     if (@Model.Viewer == true)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <h1>Avboka person</h1>\n");
#nullable restore
#line 23 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
                     if (@Model.Bidder == true)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <h1>Ta bort bud</h1>\n");
#nullable restore
#line 27 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </div>\n                <div class=\"col-sm-5 high\">\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5ab06136df256cf3160d2c2f0b9399866ca87e7b8121", async() => {
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
            WriteLiteral("\n\n\n                </div>\n            </div>\n        </div>\n    </div>\n</div>\n\n");
#nullable restore
#line 40 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
   
    var firstPart = "";
    var secondPart = "";
    if (@Model.Bidder == true)
    {
        firstPart = "ta bort ";
        secondPart = "s bud?";
    }
    if (@Model.Viewer == true)
    {
        firstPart = "avboka ";
        secondPart = "s visning?";
    }


#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"container marginTop\">\n   \n\n    <h3>Är du säker på att du vill ");
#nullable restore
#line 59 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
                              Write(firstPart);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 59 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
                                         Write(Model.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 59 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
                                                          Write(Model.LastName);

#line default
#line hidden
#nullable disable
#nullable restore
#line 59 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
                                                                         Write(secondPart);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\n    <div>\n\n        <hr />\n        <dl class=\"row\">\n");
#nullable restore
#line 64 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
               if (Model.Bidder == true) {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <dt class=\"col-sm-2\">\n\n                ");
#nullable restore
#line 68 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
           Write(Html.DisplayNameFor(model => model.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </dt>\n            <dd class=\"col-sm-10\">\n                ");
#nullable restore
#line 71 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
           Write(Html.DisplayFor(model => model.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </dd>\n");
#nullable restore
#line 73 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
                } 

#line default
#line hidden
#nullable disable
            WriteLiteral("            <dt class=\"col-sm-2\">\n                ");
#nullable restore
#line 75 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
           Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </dt>\n            <dd class=\"col-sm-10\">\n                ");
#nullable restore
#line 78 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
           Write(Html.DisplayFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </dd>\n            <dt class=\"col-sm-2\">\n                ");
#nullable restore
#line 81 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
           Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </dt>\n            <dd class=\"col-sm-10\">\n                ");
#nullable restore
#line 84 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
           Write(Html.DisplayFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </dd>\n            <dt class=\"col-sm-2\">\n                ");
#nullable restore
#line 87 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
           Write(Html.DisplayNameFor(model => model.Street));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </dt>\n            <dd class=\"col-sm-10\">\n                ");
#nullable restore
#line 90 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
           Write(Html.DisplayFor(model => model.Street));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </dd>\n            <dt class=\"col-sm-2\">\n                ");
#nullable restore
#line 93 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
           Write(Html.DisplayNameFor(model => model.City));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </dt>\n            <dd class=\"col-sm-10\">\n                ");
#nullable restore
#line 96 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
           Write(Html.DisplayFor(model => model.City));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </dd>\n            <dt class=\"col-sm-2\">\n                ");
#nullable restore
#line 99 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
           Write(Html.DisplayNameFor(model => model.PostalCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </dt>\n            <dd class=\"col-sm-10\">\n                ");
#nullable restore
#line 102 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
           Write(Html.DisplayFor(model => model.PostalCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </dd>\n\n            <dt class=\"col-sm-2\">\n                ");
#nullable restore
#line 106 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
           Write(Html.DisplayNameFor(model => model.PhoneNUmber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </dt>\n            <dd class=\"col-sm-10\">\n                ");
#nullable restore
#line 109 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
           Write(Html.DisplayFor(model => model.PhoneNUmber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </dd>\n            <dt class=\"col-sm-2\">\n                ");
#nullable restore
#line 112 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
           Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </dt>\n            <dd class=\"col-sm-10\">\n                ");
#nullable restore
#line 115 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
           Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </dd>\n\n        </dl>\n\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ab06136df256cf3160d2c2f0b9399866ca87e7b17849", async() => {
                WriteLiteral("\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5ab06136df256cf3160d2c2f0b9399866ca87e7b18118", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#nullable restore
#line 121 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.PersonId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n            <input type=\"hidden\" homeId=\"homeId\" />\n");
#nullable restore
#line 123 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
               if (Model.Bidder == true)
                {


#line default
#line hidden
#nullable disable
                WriteLiteral("                    <input type=\"submit\" value=\"Ta bort bud\" class=\"btn btn-danger\" />\n");
#nullable restore
#line 127 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
                } 

#line default
#line hidden
#nullable disable
#nullable restore
#line 128 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
               if (Model.Viewer == true)
                {


#line default
#line hidden
#nullable disable
                WriteLiteral("                    <input type=\"submit\" value=\"Avboka\" class=\"btn btn-danger\" />\n");
#nullable restore
#line 132 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
                }
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 134 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
               if (Model.Bidder == true)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ab06136df256cf3160d2c2f0b9399866ca87e7b21527", async() => {
                    WriteLiteral("Gå tillbaka");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-homeId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 136 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
                                                      WriteLiteral(Model.HomeId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["homeId"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-homeId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["homeId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n");
#nullable restore
#line 137 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
                } 

#line default
#line hidden
#nullable disable
#nullable restore
#line 138 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
               if (Model.Viewer == true)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ab06136df256cf3160d2c2f0b9399866ca87e7b24421", async() => {
                    WriteLiteral("Gå tillbaka");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-homeId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 140 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
                                                WriteLiteral(Model.HomeId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["homeId"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-homeId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["homeId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n");
#nullable restore
#line 141 "C:\Users\Rebecca Lap\Desktop\Mittuniversitetet\ÅR 2\DT102G c# i ASP.net\projekt\dt102g_projekt-master\Views\Persons\Delete.cshtml"
                } 

#line default
#line hidden
#nullable disable
                WriteLiteral("        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n    </div>\n\n    </div>\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ab06136df256cf3160d2c2f0b9399866ca87e7b28227", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<project.Models.Persons> Html { get; private set; }
    }
}
#pragma warning restore 1591
