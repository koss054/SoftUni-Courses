window.addEventListener("load", solve);

function solve() {
    const genreInputElement = document.getElementById("genre");
    const nameInputElement = document.getElementById("name");
    const authorInputElement = document.getElementById("author");
    const dateInputElement = document.getElementById("date");
    const addBtn = document.getElementById("add-btn");
    const allHitsElement = document.querySelector(".all-hits-container");
    const savedSongsElement = document.querySelector(".saved-container");
    const likesParagraphElement = document.querySelector(".likes p");

    addBtn.addEventListener("click", addSong);

    function addSong(e) {
        e.preventDefault();
        if (areInputsInvalid()) {
            return;
        }

        const genreContent = `Genre: ${genreInputElement.value}`;
        const nameContent = `Name: ${nameInputElement.value}`;
        const authorContent = `Author: ${authorInputElement.value}`;
        const dateContent = `Date: ${dateInputElement.value}`;
        const parentDiv = createEl("div", allHitsElement, "", "hits-info");

        createEl("img", parentDiv, "", "", "./static/img/img.png");
        createEl("h2", parentDiv, genreContent);
        createEl("h2", parentDiv, nameContent);
        createEl("h2", parentDiv, authorContent);
        createEl("h3", parentDiv, dateContent);

        const saveBtn = createEl("button", parentDiv, "Save song", "save-btn");
        const likeBtn = createEl("button", parentDiv, "Like song", "like-btn");
        const deleteBtn = createEl("button", parentDiv, "Delete", "delete-btn");

        saveBtn.addEventListener("click", saveSong);
        likeBtn.addEventListener("click", likeSong);
        deleteBtn.addEventListener("click", deleteSong);

        clearInputs();
    }

    function saveSong() {
        const parentDiv = this.parentNode;
        const saveBtn = parentDiv.querySelector(".save-btn");
        const likeBtn = parentDiv.querySelector(".like-btn");

        parentDiv.removeChild(saveBtn);
        parentDiv.removeChild(likeBtn);

        savedSongsElement.appendChild(parentDiv);
    }

    function likeSong() {
        this.disabled = true;
        let [ignore, likeCount] = likesParagraphElement.textContent.split(": ");

        likeCount = Number(likeCount);
        likeCount++;

        likesParagraphElement.textContent = `Total Likes: ${likeCount}`;
    }

    function deleteSong() {
        const parentDiv = this.parentNode;
        const parentOfDivLol = parentDiv.parentNode;
        parentOfDivLol.removeChild(parentDiv);
    }

    function createEl(
        elementType,
        elementParent,
        elementContent,
        elementClass,
        elementSrc
    ) {
        const htmlElement = document.createElement(elementType);
        htmlElement.textContent = elementContent;

        if (elementClass) {
            htmlElement.classList.add(elementClass);
        }

        if (elementSrc) {
            htmlElement.src = elementSrc;
        }

        elementParent.appendChild(htmlElement);
        return htmlElement;
    }

    function areInputsInvalid() {
        const isGenreInvalid = genreInputElement.value === "";
        const isNameInvalid = nameInputElement.value === "";
        const isAuthorInvalid = authorInputElement.value === "";
        const isDateInvalid = dateInputElement.value === "";

        return (
            isGenreInvalid || isNameInvalid || isAuthorInvalid || isDateInvalid
        );
    }

    function clearInputs() {
        genreInputElement.value = "";
        nameInputElement.value = "";
        authorInputElement.value = "";
        dateInputElement.value = "";
    }
}
