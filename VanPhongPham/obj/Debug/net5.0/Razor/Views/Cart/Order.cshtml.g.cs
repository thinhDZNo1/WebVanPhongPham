#pragma checksum "C:\Users\tranp\OneDrive\Tài liệu\DoAnNet\VanPhongPham\Views\Cart\Order.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "10aaf55282b6b643b0a3970f519d3b4dcc8ff311"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_Order), @"mvc.1.0.view", @"/Views/Cart/Order.cshtml")]
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
#nullable restore
#line 1 "C:\Users\tranp\OneDrive\Tài liệu\DoAnNet\VanPhongPham\Views\Cart\Order.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\tranp\OneDrive\Tài liệu\DoAnNet\VanPhongPham\Views\Cart\Order.cshtml"
using VanPhongPhamDTO.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10aaf55282b6b643b0a3970f519d3b4dcc8ff311", @"/Views/Cart/Order.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3be38da4f166896812bcfd9e5a8f1300823c9a22", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_Order : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tuple<List<Products>, List<Producer>>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery-3.5.1.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 4 "C:\Users\tranp\OneDrive\Tài liệu\DoAnNet\VanPhongPham\Views\Cart\Order.cshtml"
  
    ViewData["Title"] = "Thanh toán";
    Layout = "~/Views/Shared/_MainLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<nav aria-label=\"breadcrumb\">\r\n    <ol class=\"breadcrumb\">\r\n        <li class=\"breadcrumb-item\"><a href=\"/Home/Index\">Trang chủ</a></li>\r\n        <li class=\"breadcrumb-item\"><a");
            BeginWriteAttribute("href", " href=\"", 388, "\"", 395, 0);
            EndWriteAttribute();
            WriteLiteral(@">Thanh toán</a></li>
    </ol>
</nav>
<section>
    <div class=""container"">
        <div class=""row"">
            <div class=""col-xs-12 col-sm-12 col-md-8 col-lg-8"">
                <h4 class=""text-center mt-4 pt-2 pb-1""> Sản phẩm bạn chọn</h4>
                <hr>
                <div class=""content-cart"" style="" border-radius: 15px;"">

                </div>
            </div>
            <div class=""col-xs-12 col-sm-12 col-md-4 col-lg-4"">
                <h4 class=""mt-4 pt-2 pb-1"">Thông tin đơn hàng</h4>
                <hr>

                <div class=""row"">
                    <div class=""col-10 address"">
                        <p>
                            <i class=""fas fa-map-marker-alt""></i>
                            <span id=""addr"">");
#nullable restore
#line 33 "C:\Users\tranp\OneDrive\Tài liệu\DoAnNet\VanPhongPham\Views\Cart\Order.cshtml"
                                       Write(Context.Session.GetString("address"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                        </p>
                    </div>
                    <div class=""col-2 nut"">
                        <button class=""btn-sm btn-info ml-0"" onclick=""return changeaddress();""><i class=""fas fa-pen""></i></button>
                    </div>
                </div>
                <p>
                    Phí giao hàng
                    <span>20,000 VND</span>
                </p>
                <p>
                    Tạm tính (<span id=""count""></span> sản phẩm)
                    <span id=""total""></span>
                </p>
                <p>
                    <span>0</span> mã giảm giá được chọn
                </p>
                
                <p class=""mt-2"">
                    Tổng cộng:
                    <span id=""sum""></span>
                <p>Đã bao gồm vat (nếu có)</p>
                <hr />
                <p>Hình thức thanh toán: </p>
                <div class=""pl-3 pb-3"">
                    <div class=""form-check"">
               ");
            WriteLiteral(@"         <input class=""form-check-input"" name=""chon"" id=""chuyenk"" type=""radio"" value=""Thanh toán qua chuyển khoản"" checked />
                        <label class=""form-check-label"" for=""chuyenk"">Thanh toán qua chuyển khoản</label>
                    </div>
                    <div class=""form-check"">
                        <input class=""form-check-input"" name=""chon"" id=""tainha"" type=""radio"" value=""Thanh toán khi nhận hàng"" />
                        <label class=""form-check-label"" for=""tainha"">Thanh toán khi nhận hàng</label>
                    </div>
                </div>
                <p>Ghi chú khách hàng: </p>
                <div class=""md-form amber-textarea active-amber-textarea-2 mb-3"">
                    <textarea id=""form16"" class=""md-textarea form-control"" rows=""4"" cols=""42""></textarea>
                </div>
                <button class=""btn btn-block btn-primary"" onclick=""return thanhtoan();"">Thanh toán</button>
            </div>
        </div>
    </div>
</section>
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "10aaf55282b6b643b0a3970f519d3b4dcc8ff3117677", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script type=""text/javascript"">
    var n = 0;
    $(document).ready(function () {
        loadData();
       
    })
    function loadData() {
        $.ajax({
            url: ""/Cart/ListCarts"",
            type: ""GET"",
            contentType: ""application/json;charset=utf-8"",
            dataType: ""json"",
            success: function (result) {
                var data = '';
                var total = 0;
                var i = 0;
                var sum = 0;
                $.each(result, function (key, item) {
                    data += '<div class=""row pl-3"" style=""height: 125px;"">';
                    data += '<div class=""col-2"">';
                    data += '<img src=""/images/' + item.products.product_Images + '"" width=""120"" height=""120"" alt="""">';
                    data += '</div >';
                    data += '<div class=""col-5"">';
                    data += ' <p class=""product-name pl-4 pt-3"" style=""font-size: 20px; width: 100%; color: #1561d3;"">' + item.products.p");
            WriteLiteral(@"roduct_Name + '</p>';
                    data += '</div>';
                    data += '<div class=""col-3"">';
                    if (item.products.newPrice == 0) {
                        data += '<p class=""product-price mb-1"" style=""color: deeppink; font-size: 18px;"">' + item.products.price.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }) + '</p>';
                        total += item.products.price * item.quantity;
                    } else {
                        data += '<p class=""product-price mb-1"" style=""color: deeppink; font-size: 18px;"">' + item.products.newPrice.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }) + '</p>';
                        data += '<p style = ""font-size: 18px; text-decoration: line-through;"" >' + item.products.price.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }) + '</p>';
                        total += item.products.newPrice * item.quantity;
                    }
                    data += '</div>';
            ");
            WriteLiteral(@"        data += '<div class=""col-2"">';
                    data += '<p class=""pt-4 mb-1"" style=""font-size: 18px; width: 100%;"">' + item.quantity + ' ' + item.products.unit +'</p>';
                    data += '</div>';
                    data += '</div>';
                    //$.each(result.vouchers, function (key, vou) {
                    //    if (vou.product_Id == item.product_Id) {
                    //        $.each(result.promotions, function (key, promo) {
                    //            data += '<div class=""form-check"" style=""margin-left:123px;"">';
                    //            data += '<input class=""form-check-input"" name=""chon"" id=""voucher' + promo.promotion_Id + '"" type=""checkbox"" value=""' + promo.promotion_Id + '"" checked />';
                    //            data += '<label class=""form-check-label"" for=""chuyenk"">'+promo.promotion_Name+'</label>';
                    //            data += '</div>';
                    //        })
                    //    }
               ");
            WriteLiteral(@"     //});
                    data += '<hr>';
                    i += item.quantity;
                });
                $("".content-cart"").html(data);
                $(""#total"").html(total.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }));
                $(""#count"").text(i);
                sum = (total + 20000).toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
                n = total + 20000;
                $(""#sum"").text(sum);
            },
            error: function (errorMessage) {
                alert(errorMessage.responseText);
            }
        });
    }
    function changeaddress() {
        $("".address"").html('<div class=""form-group""><input type=""text"" class=""form-control diac"" id=""diachi"" value=""' + $(""#addr"").text() + '"" ><span class=""error"" style=""color:red;""></span></div >');
        $("".nut"").html('<button class=""btn-sm btn-success ml-0"" onclick=""return saveaddress();""><i class=""fas fa-save""></i></button>');
        $('input').blur(");
            WriteLiteral(@"function () {

            if ($(this).hasClass('diac')) {
                if ($(this).val().length < 15) {
                    $(this).siblings('span.error').text('Vui lòng nhập đúng địa chỉ của bạn').fadeIn().parent('.form-group').addClass('hasError');
                } else {
                    $(this).siblings('.error').text('').fadeOut().parent('.form-group').removeClass('hasError');
                }
            }

        });
    }
    function saveaddress() {
        var address = $(""#diachi"").val();
        $.ajax({
            url: ""/Cart/ChangeAddress"",
            type: ""POST"",
            data: { address: address },
            success: function (result) {
                $("".address"").html('<p><i class=""fas fa-map-marker-alt""></i><span id=""addr""> '+result.address+'</span></p>');
                $("".nut"").html('<button class=""btn-sm btn-info ml-0"" onclick=""return changeaddress();""><i class=""fas fa-pen""></i></button>');
            }
        })
    }
    function thanhtoan");
            WriteLiteral(@"() {
        var note = $(""#form16"").text();
        let payment = '';
        //if ($(""#Chuyenck"").prop('checked', true)) {
        //    payment = $(""#chuyenck"").val();
        //} else if ($(""#tainha"").prop('checked', true)) {
        //    payment = $(""#tainha"").val();
        //}
        const rbs = document.querySelectorAll('input[name=""chon""]');
        for (const rb of rbs) {
            if (rb.checked) {
                payment = rb.value;
                break;
            }
        }
        $.ajax({
            url: ""/Cart/ThanhToan"",
            type: ""POST"",
            data: { note: note, payment: payment, n: n },
            success: function (result) {
                window.location.href = result.url;
            }
        })
    }
    //function price() {
    //    var str, so, total = """";
    //    for (let i = 0; i < 100; i++) {

    //        for (let j = 0; j < 100; j++) {
    //            if ($("".check-product-"" + String(i) + String(j)).is(':checked')) {
");
            WriteLiteral(@"    //                str = $(""#gia-"" + String(i) + String(j)).text().subString(1, $(""#gia-"" + String(i) + String(j)).text().indexOf("" ""));
    //                for (var l = 0; l < str.length; l++) {
    //                    if (str[l] != "","") {
    //                        so += str[l];
    //                    }
    //                }
    //                total += so;
    //            }
    //        }
    //    }
    //    $(""#total-price"").text(total);
    //}
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tuple<List<Products>, List<Producer>>> Html { get; private set; }
    }
}
#pragma warning restore 1591