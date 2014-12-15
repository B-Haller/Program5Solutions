//javascript goes here

$(document).ready(function () {
    //after the document is loaded
    //run this

    //this binds click to all ajax links on the body
    //even if they have not yet appeared
    //standard procedure with ajax
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

    $('body').on('submit', '.ajax-form', function (event) {
        //preventing default behavior
        event.preventDefault();
        //make the ajax post
        //first param: url to post to
        //second: sends the input field data
        //third: what to do with the response
        $.post($(this).data('posturl'),
        $(this).serialize(), function (data) {
            $('.content').html(data);
        });

    });


});