//Login
function isEmail(inputEmail) {
    var regex = /^([a-zA-Z0-9_.+-])+@(([a-zA-Z0-9_])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(inputEmail);
}

function validatePassword(inputPassword) {
    return inputPassword.length > 5;
}
$(document).ready(function() {
    $("input[type='number']").inputSpinner();
    $("#email").change(function() {
        var email = $(this).val().trim();
        if (!isEmail(email)) {
            //error?
            $(".emailError").html("Dữ liệu mới nhập không phải là email!");
        } else {
            $(".emailError").html("")
        }
    });
    $("#password").change(function() {
        var password = $(this).val();
        if (!validatePassword(password)) {
            $(".passwordError").html("Mật khẩu nhập vào phải từ 6 kí tự trở lên!");
        } else {
            $(".passwordError").html("");
        }
    });
});