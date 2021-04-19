$(document).ready(function playSkillVideo() {
    var skilldoms = $(".skill_logo");
    changeSkill($(skilldoms[0]));
    for (var i = 0; i < skilldoms.length; i++) {
        $(skilldoms[i]).click(function () {
            changeSkill($(this))
        })
    }
})

function changeSkill(skillJQ)
{
    $("#skill_name").text(skillJQ.attr("skill_name"));
    $("#skill_detail").text(skillJQ.attr("skill_detail"));
    $("#show_video").attr("src", `/resource/ShowHero/${skillJQ.attr("hero_id")}/${skillJQ.attr("skill_id")}.mp4`);
}