window.addEventListener("DOMContentLoaded", () => {

    var commentButton = document.getElementById("comment-button");

    function commentButtonClicked() {
        var commentContent = document.getElementById("comment-content");
        var postId = commentContent.getAttribute("data-post-id");

        if (commentContent.value) {
            $.ajax({
                type: "POST",
                url: "/friendface/createcomment",
                data: JSON.stringify({ PostId: parseInt(postId), CommentContent: commentContent.value }),
                success: function (data) {
                    var commentsElement = document.getElementById("comments");
                    var p = document.createElement("p");
                    p.innerText = commentContent.value;
                    commentsElement.appendChild(p);
                    
                },
                contentType: "application/json",
                datatype: "json",
            });
        }
    }

    if (commentButton)
        commentButton.addEventListener("click", commentButtonClicked, false);

});