window.addEventListener("DOMContentLoaded", () => {

    var commentButtons = document.querySelectorAll(".comment-button");

    function commentButtonClicked(e) {
        var button = e.target;

        var commentContent = $(button).closest(".input-group").find('.comment-content')[0];
        var postId = commentContent.getAttribute("data-post-id");

        var commentsElement = $(button).closest(".dropdown-menu").find(".comments")[0];

        if (commentContent.value) {
            $.ajax({
                type: "POST",
                url: "/friendface/createcomment",
                data: JSON.stringify({ PostId: parseInt(postId), CommentContent: commentContent.value }),
                success: function (data) {
                    var p = document.createElement("p");
                    p.innerText = commentContent.value;
                    commentsElement.appendChild(p);
                    $(".comment-content").val('');
                   
                },
                contentType: "application/json",
                datatype: "json",
            });
        }
    }

    for (var i = 0; i < commentButtons.length; i++) {
        var commentButton = commentButtons[i];
        commentButton.addEventListener("click", commentButtonClicked, false);

    }

});