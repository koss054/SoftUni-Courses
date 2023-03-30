function attachEvents() {
    const BASE_URL = "http://localhost:3030/jsonstore/blog/";
    const selectPostsElement = document.getElementById("posts");
    const postTitleElement = document.getElementById("post-title");
    const postBodyElement = document.getElementById("post-body");
    const postCommentsElement = document.getElementById("post-comments");

    let posts = {};

    const loadPostsBtn = document.getElementById("btnLoadPosts");
    loadPostsBtn.addEventListener("click", () => {
        selectPostsElement.innerHTML = "";
        fetch(`${BASE_URL}posts`)
            .then((response) => response.json())
            .then((info) => {
                posts = info;
                for (const post in info) {
                    const currentPost = info[post];
                    selectPostsElement.appendChild(
                        createOptionsElement(
                            currentPost.id,
                            currentPost.title.toUpperCase()
                        )
                    );
                }

                sortList(selectPostsElement);
            });
    });

    const viewPostBtn = document.getElementById("btnViewPost");
    viewPostBtn.addEventListener("click", () => {
        const selectedPost = selectPostsElement.value;
        postTitleElement.textContent = posts[selectedPost].title.toUpperCase();
        postBodyElement.textContent = posts[selectedPost].body;

        postCommentsElement.innerHTML = "";
        fetch(`${BASE_URL}comments`)
            .then((response) => response.json())
            .then((info) => {
                for (const comment in info) {
                    if (info[comment].postId === selectedPost) {
                        postCommentsElement.appendChild(
                            createListElement(
                                info[comment].id,
                                info[comment].text
                            )
                        );
                    }
                }
            });
    });

    function createOptionsElement(value, text) {
        let element = document.createElement("option");
        element.value = value;
        element.textContent = text;
        return element;
    }

    function createListElement(id, text) {
        let element = document.createElement("li");
        element.setAttribute("id", id);
        element.textContent = text;
        return element;
    }

    function sortList(list) {
        arrTexts = new Array();
        arrValues = new Array();

        let pair = {};

        for (i = 0; i < list.length; i++) {
            arrTexts[i] = list.options[i].text;
            arrValues[i] = list.options[i].value;
            pair[list.options[i].text] = list.options[i].value;
        }

        arrTexts.sort();

        for (i = 0; i < list.length; i++) {
            list.options[i].text = arrTexts[i];
            list.options[i].value = pair[arrTexts[i]];
        }
    }
}

attachEvents();
