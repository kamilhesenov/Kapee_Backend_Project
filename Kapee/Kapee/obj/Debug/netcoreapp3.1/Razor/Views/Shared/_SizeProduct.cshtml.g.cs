#pragma checksum "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a067027528cde5c43855a7c8a46664bf4677d7f8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__SizeProduct), @"mvc.1.0.view", @"/Views/Shared/_SizeProduct.cshtml")]
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
#line 1 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\_ViewImports.cshtml"
using Kapee;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\_ViewImports.cshtml"
using Kapee.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\_ViewImports.cshtml"
using Kapee.Models.Product;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\_ViewImports.cshtml"
using Kapee.Models.ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a067027528cde5c43855a7c8a46664bf4677d7f8", @"/Views/Shared/_SizeProduct.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94aef39934adeb311d0c82f2d4539b225796fe17", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__SizeProduct : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Product>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("hide-img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("hover-image hide-img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Men-Hooded-Blue-Grey-T-Shirt"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-xl-4 col-lg-4 col-md-6 col-sm-6 col-6\">\r\n        <div class=\"item\">\r\n            <div class=\"product-group\">\r\n                <div class=\"product-item\">\r\n                    <div class=\"product-img\">\r\n");
#nullable restore
#line 10 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                         if (item.IsFeatured == true)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"product-featured\">\r\n                                <span>Featured</span>\r\n                            </div>\r\n");
#nullable restore
#line 15 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"product-featured d-none\">\r\n                                <span>Featured</span>\r\n                            </div>\r\n");
#nullable restore
#line 21 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <div class=""product-button"">
                            <a href=""#"" data-toggle=""tooltip"" data-placement=""left"" title=""Add to Wishlist"">
                                <i class=""far fa-heart""></i>
                            </a>
                        </div>
                        <a href=""#"">
");
#nullable restore
#line 28 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                               var imgCount = 1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                             foreach (var img in item.ProductGalleries)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                                 if (imgCount == 1)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a067027528cde5c43855a7c8a46664bf4677d7f88473", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 33 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                                            Write(imgCount);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-id", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1417, "~/assets/img/", 1417, 13, true);
#nullable restore
#line 33 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
AddHtmlAttributeValue("", 1430, img.Photo, 1430, 10, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 34 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a067027528cde5c43855a7c8a46664bf4677d7f810942", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 37 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                                            Write(imgCount);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-id", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1640, "~/assets/img/", 1640, 13, true);
#nullable restore
#line 37 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
AddHtmlAttributeValue("", 1653, img.Photo, 1653, 10, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 38 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                                 
                                imgCount++;
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a067027528cde5c43855a7c8a46664bf4677d7f813696", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1852, "~/assets/img/", 1852, 13, true);
#nullable restore
#line 41 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
AddHtmlAttributeValue("", 1865, item.HoverPhoto, 1865, 16, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </a>\r\n                    </div>\r\n                    <div class=\"product-text\">\r\n                        <div class=\"product-title\">\r\n                            <div class=\"product-category\">\r\n");
#nullable restore
#line 47 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                                 foreach (var categoryName in item.SubCategories)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a href=\"#\">");
#nullable restore
#line 49 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                                           Write(categoryName.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 50 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n                            <h3 class=\"product-content\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a067027528cde5c43855a7c8a46664bf4677d7f816617", async() => {
#nullable restore
#line 53 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                                                                                                  Write(item.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 53 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                                                                                 WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </h3>\r\n                            <div class=\"product-start\">\r\n                                <div");
            BeginWriteAttribute("class", " class=\"", 2705, "\"", 2728, 1);
#nullable restore
#line 56 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
WriteAttributeValue("", 2713, item.StarColor, 2713, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    <span>");
#nullable restore
#line 57 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                                     Write(item.StarCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ★</span>\r\n                                </div>\r\n                                <div class=\"rating-counts\">\r\n                                    <a href=\"#\"><span> (");
#nullable restore
#line 60 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                                                   Write(item.RatingCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@") </span></a>
                                </div>
                            </div>
                        </div>
                        <div class=""product-price"">
                            <span class=""price"">
                                <span>$");
#nullable restore
#line 66 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                                  Write(item.Price.ToString("#.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                            </span>\r\n                            <span class=\"on-sale\">\r\n                                <span>");
#nullable restore
#line 69 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                                 Write(item.OnSale);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                            </span>
                        </div>
                        <div class=""product-buttons"">
                            <div class=""cart-button"">
                                <a href=""#"">Select options</a>
                            </div>
                            <div class=""compare-button"">
                                <a href=""#"" data-toggle=""tooltip"" data-placement=""top"" title=""Compare""><i class=""fas fa-random""></i></a>
                            </div>
                            <div class=""search-button"">
                                <a href=""#"" data-toggle=""tooltip"" data-placement=""top"" title=""Quick View""><i class=""fas fa-search-plus""></i></a>
                            </div>
                        </div>
                        <div class=""product-variations"">
                            <div class=""product-colors"">
");
#nullable restore
#line 85 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                                   int colorsCount = 1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 86 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                                 foreach (var color in item.ProductColors)
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 88 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                                     if (colorsCount == 1)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <span data-id=");
#nullable restore
#line 90 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                                                 Write(colorsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" class=\"product-color active\">\r\n                                            <span data-toggle=\"tooltip\" data-placement=\"top\"");
            BeginWriteAttribute("title", " title=\"", 4780, "\"", 4804, 1);
#nullable restore
#line 91 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
WriteAttributeValue("", 4788, color.Color.Key, 4788, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 4805, "\"", 4831, 1);
#nullable restore
#line 91 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
WriteAttributeValue("", 4813, color.Color.Value, 4813, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></span>\r\n                                        </span>\r\n");
#nullable restore
#line 93 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <span data-id=");
#nullable restore
#line 96 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                                                 Write(colorsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" class=\"product-color\">\r\n                                            <span data-toggle=\"tooltip\" data-placement=\"top\"");
            BeginWriteAttribute("title", " title=\"", 5194, "\"", 5218, 1);
#nullable restore
#line 97 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
WriteAttributeValue("", 5202, color.Color.Key, 5202, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 5219, "\"", 5245, 1);
#nullable restore
#line 97 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
WriteAttributeValue("", 5227, color.Color.Value, 5227, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></span>\r\n                                        </span>\r\n");
#nullable restore
#line 99 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 99 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                                     
                                    colorsCount++;
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n                            <div class=\"product-sizes\">\r\n");
#nullable restore
#line 104 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                                   string actives = "active";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 106 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                                 foreach (var sizes in item.ProductSizes)
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 108 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                                     if (actives == "active")
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <span class=\"product-size active\">\r\n                                            <span>");
#nullable restore
#line 111 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                                             Write(sizes.Size.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                        </span>\r\n");
#nullable restore
#line 113 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <span class=\"product-size\">\r\n                                            <span>");
#nullable restore
#line 117 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                                             Write(sizes.Size.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                        </span>\r\n");
#nullable restore
#line 119 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 119 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
                                     
                                    { actives = "deactive"; }
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 129 "C:\Users\Kamil\Desktop\Kapee_Backend_Project\Kapee\Kapee\Views\Shared\_SizeProduct.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591