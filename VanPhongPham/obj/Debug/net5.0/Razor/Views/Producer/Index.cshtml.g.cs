#pragma checksum "C:\Users\tranp\OneDrive\Tài liệu\DoAnNet\VanPhongPham\Views\Producer\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bb112101e4ea62bfa7721455bff1d458c2752ca4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Producer_Index), @"mvc.1.0.view", @"/Views/Producer/Index.cshtml")]
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
#line 1 "C:\Users\tranp\OneDrive\Tài liệu\DoAnNet\VanPhongPham\Views\_ViewImports.cshtml"
using VanPhongPham;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\tranp\OneDrive\Tài liệu\DoAnNet\VanPhongPham\Views\_ViewImports.cshtml"
using VanPhongPham.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bb112101e4ea62bfa7721455bff1d458c2752ca4", @"/Views/Producer/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3be38da4f166896812bcfd9e5a8f1300823c9a22", @"/Views/_ViewImports.cshtml")]
    public class Views_Producer_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<VanPhongPhamDTO.Entities.Producer>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onclick", new global::Microsoft.AspNetCore.Html.HtmlString("confirm(\"Bạn có chắc chắn muốn xóa không?\");"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\tranp\OneDrive\Tài liệu\DoAnNet\VanPhongPham\Views\Producer\Index.cshtml"
  
    ViewData["Title"] = "Quản lý danh mục nhà sản xuất";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<h5 class=""ml-3 mb-2"">Quản lý danh mục nhà sản xuất</h5>
<div class=""container-fluid"">
    <div class=""row"">
        <div class=""col-12"">
            <div class=""card"">
                <div class=""card-header"">
                    <h3 class=""card-title"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb112101e4ea62bfa7721455bff1d458c2752ca44973", async() => {
                WriteLiteral("<i class=\"fas fa-plus-circle mr-2\"></i>Thêm mới");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</h3>
                </div>
                <!-- /.card-header -->
                <div class=""card-body"">
                    <table id=""example2"" class=""table table-bordered table-hover"">
                        <thead>
                            <tr>
                                <th>Mã nhà sản xuất</th>
                                <th>Tên nhà sản xuất</th>
                                <th>Ảnh đại diện</th>
                                <th>Mô tả</th>
                                <th>Quốc gia</th>
                                <th>Chức năng</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 28 "C:\Users\tranp\OneDrive\Tài liệu\DoAnNet\VanPhongPham\Views\Producer\Index.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 31 "C:\Users\tranp\OneDrive\Tài liệu\DoAnNet\VanPhongPham\Views\Producer\Index.cshtml"
                               Write(item.Producer_Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 32 "C:\Users\tranp\OneDrive\Tài liệu\DoAnNet\VanPhongPham\Views\Producer\Index.cshtml"
                               Write(item.Producer_Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>\r\n                                    <img");
            BeginWriteAttribute("src", " src=\"", 1522, "\"", 1562, 1);
#nullable restore
#line 34 "C:\Users\tranp\OneDrive\Tài liệu\DoAnNet\VanPhongPham\Views\Producer\Index.cshtml"
WriteAttributeValue("", 1528, "/images/"+item.Producer_Images, 1528, 34, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Alternate Text\" height=\"100\" />\r\n                                </td>\r\n                                <td>");
#nullable restore
#line 36 "C:\Users\tranp\OneDrive\Tài liệu\DoAnNet\VanPhongPham\Views\Producer\Index.cshtml"
                               Write(Html.Raw(item.Producer_Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 37 "C:\Users\tranp\OneDrive\Tài liệu\DoAnNet\VanPhongPham\Views\Producer\Index.cshtml"
                               Write(item.Origin);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb112101e4ea62bfa7721455bff1d458c2752ca49018", async() => {
                WriteLiteral("<i class=\"fas fa-edit\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 39 "C:\Users\tranp\OneDrive\Tài liệu\DoAnNet\VanPhongPham\Views\Producer\Index.cshtml"
                                                           WriteLiteral(item.Producer_Id);

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
            WriteLiteral("\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb112101e4ea62bfa7721455bff1d458c2752ca411259", async() => {
                WriteLiteral("<i class=\"far fa-trash-alt\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 40 "C:\Users\tranp\OneDrive\Tài liệu\DoAnNet\VanPhongPham\Views\Producer\Index.cshtml"
                                                             WriteLiteral(item.Producer_Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 43 "C:\Users\tranp\OneDrive\Tài liệu\DoAnNet\VanPhongPham\Views\Producer\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                        </tbody>

                    </table>
                </div>
                <!-- /.card-body -->
            </div>
            <!-- /.card -->
        </div>
        <!-- /.col -->
    </div>
    <!-- /.row -->
</div>
<!--<div class=""modal"" id=""myModal"">
    <div class=""modal-dialog modal-lg"">
        <div class=""modal-content"">
            <!--Modal header-->
            <!--<div class=""modal-header"">
                <h4>Cập nhật nhà cung cấp</h4>
                <button class=""close"" data-dismiss=""modal"">&times;</button>
            </div>-->
");
            WriteLiteral(@"        <!--<div class=""modal-body"">
            <form asp-action=""Create"" method=""post"" enctype=""multipart/form-data"">
                <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
                <div class=""form-group"">
                    <label asp-for=""Producer_Name"" class=""control-label""></label>
                    <input asp-for=""Producer_Name"" class=""form-control"" />
                    <span asp-validation-for=""Producer_Name"" class=""text-danger""></span>
                </div>
                <div class=""form-group"">
                    <label asp-for=""Producer_Images"" class=""control-label""></label>
                    <div class=""mt-2 mb-2"">
                        <img id=""blah"" src=""#"" alt=""your image"" height=""200"" class=""d-block mx-auto"" />
                    </div>
                    <div class=""custom-file"">
                        <input type=""file"" class=""custom-file-input"" id=""customFile"" asp-for=""ImageFile"" accept=""image/*"" onchange=""document.getElement");
            WriteLiteral(@"ById('blah').src = window.URL.createObjectURL(this.files[0])"">
                        <label class=""custom-file-label"" for=""customFile"" id=""blah"">Chọn ảnh</label>
                    </div>
                    <span asp-validation-for=""ImageFile"" class=""text-danger""></span>
                </div>
                <div class=""form-group"">
                    <label asp-for=""Producer_Description"" class=""control-label""></label>-->
");
            WriteLiteral(@"                    <!--<textarea class=""summernote"" asp-for=""Producer_Description""></textarea>
                    <span asp-validation-for=""Producer_Description"" class=""text-danger""></span>
                </div>
                <div class=""form-group"">
                    <label asp-for=""Origin"" class=""control-label""></label>
                    <input asp-for=""Origin"" class=""form-control"" />
                    <span asp-validation-for=""Origin"" class=""text-danger""></span>
                </div>
                <div class=""form-group"">
                    <input type=""submit"" value=""Save"" class=""btn btn-primary"" />
                </div>
            </form>
        </div>-->
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<VanPhongPhamDTO.Entities.Producer>> Html { get; private set; }
    }
}
#pragma warning restore 1591