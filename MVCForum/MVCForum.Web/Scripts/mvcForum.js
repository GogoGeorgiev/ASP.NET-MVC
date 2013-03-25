$("#Menu").kendoMenu();

$(function () {
    
    $(".up-vote").click(function () {
        var id = $(this).attr("data-id");
        $("#rating_" + id).load("/ForumPosts/VoteUp/" + id);
        return false;
    });

    $(".down-vote").click(function (e) {
        var id = $(this).attr("data-id");
        $("#rating_" + id).load("/ForumPosts/VoteDown/" + id);
        return false;
    });
    
    var ajaxFormSubmit = function () {
        var form = $(this);

        var options = {
            url: form.attr("action"),
            type: form.attr("method"),
            data: form.serialize()
        };

        $.ajax(options).done(function (data) {
            var target = $(form.attr("data-mvcForum-target"));
            $(target).replaceWith(data);
        });

        return false;
    };

    $("form[data-mvcForum-ajax='true']").submit(ajaxFormSubmit);

});









