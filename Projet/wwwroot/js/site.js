// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    var book = $('#book');
    $('#view-cover').click(function () {
        $(this).addClass('cur').siblings().removeClass('cur');
        book.removeClass().addClass('view-cover');
    });
    $('#view-back').click(function () {
        $(this).addClass('cur').siblings().removeClass('cur');
        book.removeClass().addClass('view-back');
    });
    $('#open-book').click(function () {
        if (book.attr('class') != 'open-book') {
            $(this).addClass('cur').siblings().removeClass('cur');
            book.removeClass().addClass('open-book');
        } else {
            $(this).removeClass('cur');
            $('#view-cover').addClass('cur');
            book.removeClass().addClass('view-cover');
        }
    });
    $('#view-rotate').click(function () {
        $(this).addClass('cur').siblings().removeClass('cur');
        book.removeClass().addClass('view-rotate');
    });
});

let menu = document.getElementById("dropdown-menu");
menu.addEventListener("click", function (event) {
    let target = event.target;
    if (target.tagName === "A") {
        event.preventDefault();
        event.stopPropagation();
        let href = target.getAttribute("href");
        window.location.href = href;
    }
});