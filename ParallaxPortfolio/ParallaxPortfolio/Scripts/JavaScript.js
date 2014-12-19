
frameRate = 30;
timeInterval = Math.round(1000 / frameRate);
relMouseX = 0;
relMouseY = 0;

$(document).ready(function () {
    // get the stage offset
    offset = $('#stage').offset();

    // start calling animateFollower at the 'timeInterval' we calculated above
    atimer = setInterval("animateFollower()", timeInterval);


    // track and save the position of the mouse
    $(document).mousemove(function (e) {
        mouseX = e.pageX;
        mouseY = e.pageY;
        relMouseX = mouseX - offset.left;
        relMouseY = mouseY - offset.top;

        // display the current mouse positions
        $('#mouse_x-trace').text(mouseX);
        $('#mouse_y-trace').text(mouseY);
    });

    // move the image where the mouse is
    // this function is called by the setInterval command above to run
    // at a rate of 30 frames per second
    function animateFollower() {
        $('#follower').css('left', relMouseX);
        $('#follower').css('top', relMouseY);
    }
});