$(document).ready(function () {
    var canvases = document.getElementsByClassName("canvas");
    // run on each canvas and draw on it
    for (var i = 1; i < canvases.length; i++){
        var ctx = canvases[i].getContext("2d");
        ctx.font = "18px Arial";
        ctx.fillText("no image", 10, 50);
    }
}
);
