
$(document).ready(function showTypeMaps() {
    var mapBtDoms = $(".map_type_bt")
    for (var i = 1; i < mapBtDoms.length; i++) {
        $(mapBtDoms[i]).click(function () {
            var maptype = $($(this).children()[1]).text();
            var mapDoms = $(".map");
            for (var x = 0; x < mapDoms.length; x++) {
                if ($(mapDoms[x]).attr("map_type").match(maptype)!=null) {
                    $(mapDoms[x]).css("display", "block");
                    $($(mapDoms[x]).children()[0]).css("display", "block");
                }
                else {
                    $(mapDoms[x]).css("display", "none");
                    $($(mapDoms[x]).children()[0]).css("display", "none");
                }
            }
        })
    }
})

function showAllMaps() {
    var mapDoms = $(".map");
    for (var x = 0; x < mapDoms.length; x++)
    {
        $(mapDoms[x]).css("display", "block");
        $($(mapDoms[x]).children()[0]).css("display", "block");
    }
    for (var x = 0; x < mapDoms.length; x++) {
        for (var y = x + 1; y <= mapDoms.length; y++) {
            if ($($(mapDoms[x]).children()[0]).text() == $($(mapDoms[y]).children()[0]).text()) {
                $(mapDoms[x]).css("display", "none");
                $($(mapDoms[x]).children()[0]).css("display", "none");
            }
        }
    }
}
$(document).ready(function () {
    showAllMaps()
    $($(".map_type_bt")[0]).click(
        function ()
        {
            showAllMaps()
        }
    )
})