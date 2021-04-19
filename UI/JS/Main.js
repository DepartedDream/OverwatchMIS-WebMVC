$(document).ready(function SetVideoVolume() {
    var videoDom = $("#bg_video")[0];
    videoDom.volume = 0.3;
})

$(document).ready(function SetVideoClickToPlay() {
    var videoDom = $("#bg_video")[0];
    $("body").click(function ()
    {
        videoDom.play();
    }
    )
})