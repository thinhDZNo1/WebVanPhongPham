#pragma checksum "C:\Users\tranp\OneDrive\Tài liệu\DoAnNet\VanPhongPham\Views\Cart\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3f9f7456f850e376a60f0ee19a2e23a5a2bbb401"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_List), @"mvc.1.0.view", @"/Views/Cart/List.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f9f7456f850e376a60f0ee19a2e23a5a2bbb401", @"/Views/Cart/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3be38da4f166896812bcfd9e5a8f1300823c9a22", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\tranp\OneDrive\Tài liệu\DoAnNet\VanPhongPham\Views\Cart\List.cshtml"
  
    ViewData["Title"] = "List";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-fluid"">
    <div class=""row"">
        <div class=""col-12"">
            <div class=""card"">
                <div class=""card-header"">
                    <h3 class=""card-title""><button class=""btn btn-primary"" data-toggle=""modal"" data-target=""#myModal""> Thêm mới</button></h3>
                </div>
                <!-- /.card-header -->
                <div class=""card-body"">
                    <table id=""example2"" class=""table table-bordered table-hover"">
                        <thead>
                            <tr>
                                <th>Mã cart</th>
                                <th>Mã user</th>
                                <th>Mã sản phẩm</th>
                                <th>Ngày</th>
                                <th>Số lượng</th>
                                <th>Chức năng</th>
                            </tr>
                        </thead>
                        <tbody class=""tbody"">
                        </tbody>
          ");
            WriteLiteral(@"          </table>
                </div>
                <!-- /.card-body -->
            </div>
            <!-- /.card -->
        </div>
        <!-- /.col -->
    </div>
    <!-- /.row -->
</div>
<div class=""modal"" id=""myModal"">
    <div class=""modal-dialog modal-lg"">
        <div class=""modal-content"">
            <!--Modal header-->
            <div class=""modal-header"">
                <h4>Cập nhật nhà cung cấp</h4>
                <button class=""close"" data-dismiss=""modal"">&times;</button>
            </div>
            <!--Modal body-->
            <div class=""modal-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f9f7456f850e376a60f0ee19a2e23a5a2bbb4015232", async() => {
                WriteLiteral(@"
                    <div class=""form-group"">
                        <label>Mã user</label>
                        <input type=""text"" id=""User_Id"" name=""User_Id"" class=""form-control"" />
                    </div>
                    <div class=""form-group"">
                        <label>Mã sản phẩm</label>
                        <input type=""text"" id=""Product_Id"" name=""Product_Id"" class=""form-control"" />
                    </div>
                    <div class=""form-group"">
                        <label>ngày</label>
                        <input type=""text"" id=""Invoice_Date"" name=""Invoice_Date"" class=""form-control"" />
                    </div>
                    <div class=""form-group"">
                        <label>số lượng</label>
                        <input type=""text"" id=""Amount"" name=""Amount"" class=""form-control"" />
                    </div>

                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
            <!--Modal footer-->
            <div class=""modal-footer"">
                <button class=""btn btn-primary"" id=""btnAdd"" onclick=""return Add();"">Thêm</button>
                <button class=""btn btn-success"" style=""display:none;"">Cập nhật</button>
                <button class=""btn btn-danger"" data-dismiss=""modal"">Đóng</button>
            </div>
        </div>
    </div>
</div>
<script>
    function loadData() {
        $.ajax({
            url: ""/Cart/ListCart"",//""/Admin/Supplier/List"" để này ko cũng đc
            type: ""GET"",
            contentType: ""application/json;charset=utf-8"",
            dataType: ""json"",
            success: function (result) {
                var data = '';
                $.each(result, function (key, item) {
                    data += '<tr>';
                    data += '<td>' + item.cart_Id + '</td>';
                    data += '<td>' + item.user_Id + '</td>';
                    data += '<td>' + item.product_Id + '</td>'");
            WriteLiteral(@";
                    data += '<td>' + item.invoice_Date + '</td>';
                    data += '<td>' + item.amount + '</td>';
                    data += '<td><a href=""#"" onclick = ""return GetById(' + item.cart_Id + ')"">sửa </a> | <a href=""#"" onclick = ""return Delete(' + item.cart_Id + ')"">Xóa </a></td>';
                    data += '</tr>'
                });
                $("".tbody"").html(data);
            },
            error: function (errorMessage) {
                alert(errorMessage.responseText);
            }
        });
    }
    function Add() {
        //Lấy giá trị trong textbox
        //var today = new Date();
        //var date = today.getDate() + ""/"" +  (today.getMonth() + 1) + '/'+ today.getFullYear() ;
        var objSup = {
            User_Id: parseInt($(""#User_Id"").val()),
            Product_Id: parseInt($(""#Product_Id"").val()),
            Invoice_Date: $('#Invoice_Date').val(),
            Amount: parseInt($(""#Amount"").val())
        };
        $.ajax({
  ");
            WriteLiteral(@"          url: ""/Cart/Create"",
            data: JSON.stringify(objSup),
            contentType: ""application/json;charset=utf-8"",
            dataType: ""json"",
            type: ""POST"",
            success: function (result) {
                loadData();
                //Ẩn modal
                $(""#myModal"").modal(""hide"");
            },
            error: function (errorMessage) {
                alert(errorMessage.responseText);
            }
        });
    }
</script>

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591