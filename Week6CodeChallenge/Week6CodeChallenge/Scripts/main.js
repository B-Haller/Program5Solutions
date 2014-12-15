$(document).ready(function () {

    $('body').on('click', '.ajax-link', function () {
        //get the url from the click
        var url = $(this).data('url');
        //do ajax get request
        $.get(url, function (data) {
            //made the request, so do something with response

            //update content with string stored in data parameter
            $('.content').html(data);
        });
    });

     $('body').on('click', '.ajax-linked', function () {
        //get the url from the click
        var url = $(this).data('url');
        //do ajax get request
        $.get(url, function (data) {
            //made the request, so do something with response

            //update content with string stored in data parameter
            $('.about-layout').html(data);
        });
    });
});
