/*global $, document, window, setTimeout, navigator, console, location*/
$(document).ready(function () {

    'use strict';

    var firstnameError = true,
        birthdayError = true,
        lastnameError = true,
        addressError = true,
        usernameError = true,
        phoneError = true,
        emailError = true,
        passwordError = true,
        passConfirm = true;

    // Detect browser for css purpose
    if (navigator.userAgent.toLowerCase().indexOf('firefox') > -1) {
        $('.form form label').addClass('fontSwitch');
    }

    // Label effect
    $('input').focus(function () {

        $(this).siblings('label').addClass('active');
    });

    // Form validation
    $('input').blur(function () {

        // User Name
        //if ($(this).hasClass('name')) {
        //    if ($(this).val().length === 0) {
        //        $(this).siblings('span.error').text('Please type your full name').fadeIn().parent('.form-group').addClass('hasError');
        //        usernameError = true;
        //    } else if ($(this).val().length > 1 && $(this).val().length <= 6) {
        //        $(this).siblings('span.error').text('Please type at least 6 characters').fadeIn().parent('.form-group').addClass('hasError');
        //        usernameError = true;
        //    } else {
        //        $(this).siblings('.error').text('').fadeOut().parent('.form-group').removeClass('hasError');
        //        usernameError = false;
        //    }
        //}
        if ($(this).hasClass('firstname')) {
            if ($(this).val().length === 0) {
                $(this).siblings('span.error').text('vui lòng nhập họ').fadeIn().parent('.form-group').addClass('hasError');
                firstnameError = true;
            } else {
                $(this).siblings('.error').text('').fadeOut().parent('.form-group').removeClass('hasError');
                firstnameError = false;
            }
        }
        if ($(this).hasClass('lastname')) {
            if ($(this).val().length === 0) {
                $(this).siblings('span.error').text('vui lòng nhập tên').fadeIn().parent('.form-group').addClass('hasError');
                lastnameError = true;
            } else {
                $(this).siblings('.error').text('').fadeOut().parent('.form-group').removeClass('hasError');
                lastnameError = false;
            }
        }
        if ($(this).hasClass('birthday')) {
            if ($(this).val().length === 0) {
                $(this).siblings('span.error').text('vui lòng nhập ngày sinh của bạn').fadeIn().parent('.form-group').addClass('hasError');
               birthdayError = true;
            } else {
                $(this).siblings('.error').text('').fadeOut().parent('.form-group').removeClass('hasError');
                birthdayError = false;
            }
        }
        if ($(this).hasClass('username')) {
            if ($(this).val().length == '') {
                $(this).siblings('span.error').text('vui lòng nhập tên tài khoản').fadeIn().parent('.form-group').addClass('hasError');
                usernameError = true;
            } else if ($(this).val().length > 1 && $(this).val().length <= 6) {
                $(this).siblings('span.error').text('Vui lòng nhập ít nhất 6 ký tự').fadeIn().parent('.form-group').addClass('hasError');
                usernameError = true;
            } else {
                $(this).siblings('.error').text('').fadeOut().parent('.form-group').removeClass('hasError');
                usernameError = false;
            }
        }
        // Address
        if ($(this).hasClass('address')) {
            if ($(this).val().length == '') {
                $(this).siblings('span.error').text('vui lòng nhập địa chỉ của bạn').fadeIn().parent('.form-group').addClass('hasError');
                addressError = true;
            } else {
                $(this).siblings('.error').text('').fadeOut().parent('.form-group').removeClass('hasError');
                addressError = false;
            }
        }
        if ($(this).hasClass('phone')) {
            if ($(this).val().length == '') {
                $(this).siblings('span.error').text('vui lòng nhập số điện thoại của bạn').fadeIn().parent('.form-group').addClass('hasError');
                phoneError = true;
            } else {
                $(this).siblings('.error').text('').fadeOut().parent('.form-group').removeClass('hasError');
                phoneError = false;
            }
        }
        // PassWord
        if ($(this).hasClass('pass')) {
            if ($(this).val().length < 8) {
                $(this).siblings('span.error').text('Vui lòng đặt mật khẩu ít nhất 8 kí tự').fadeIn().parent('.form-group').addClass('hasError');
                passwordError = true;
            } else {
                $(this).siblings('.error').text('').fadeOut().parent('.form-group').removeClass('hasError');
                passwordError = false;
            }
        }

        // PassWord confirmation
        if ($('.pass').val() !== $('.passConfirm').val()) {
            $('.passConfirm').siblings('.error').text('Mật khẩu nhập lại không đúng').fadeIn().parent('.form-group').addClass('hasError');
            passConfirm = false;
        } else {
            $('.passConfirm').siblings('.error').text('').fadeOut().parent('.form-group').removeClass('hasError');
            passConfirm = false;
        }

        // label effect
        if ($(this).val().length > 0) {
            $(this).siblings('label').addClass('active');
        } else {
            $(this).siblings('label').removeClass('active');
        }
    });


    // form switch
    $('a.switch').click(function (e) {
        $(this).toggleClass('active');
        e.preventDefault();

        if ($('a.switch').hasClass('active')) {
            $(this).parents('.form-peice').addClass('switched').siblings('.form-peice').removeClass('switched');
        } else {
            $(this).parents('.form-peice').removeClass('switched').siblings('.form-peice').addClass('switched');
        }
    });


    // Form submit
    $('form.signup-form').submit(function (event) {
        event.preventDefault();

        if (firstnameError == true || phoneError == true || birthdayError == true || lastnameError == true || addressError == true || usernameError == true || emailError == true || passwordError == true || passConfirm == true){
            $('.firstname, .lastname, .address, .username, .brithday, .phone, .pass, .passConfirm').blur();
        } else {
            $('.signup, .login').addClass('switched');

            setTimeout(function () { $('.signup, .login').hide(); }, 700);
            setTimeout(function () { $('.brand').addClass('active'); }, 300);
            setTimeout(function () { $('.heading').addClass('active'); }, 600);
            setTimeout(function () { $('.success-msg p').addClass('active'); }, 900);
            setTimeout(function () { $('.success-msg a').addClass('active'); }, 1050);
            setTimeout(function () { $('.form').hide(); }, 700);
        }
    });

    // Reload page
    $('a.profile').on('click', function () {
        location.reload(true);
    });


});
