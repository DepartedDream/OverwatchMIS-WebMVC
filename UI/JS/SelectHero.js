var heroId= 0;
setInterval(function () {
    var heros = $(".hero");
    $(heros[heroId]).css("opacity", "1");
    heroId = heroId + 1;
}, 200)
