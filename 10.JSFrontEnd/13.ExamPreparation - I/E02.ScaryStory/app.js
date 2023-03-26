window.addEventListener("load", solve);

function solve() {
    const firstNameElement = document.getElementById("first-name");
    const lastNameElement = document.getElementById("last-name");
    const ageElement = document.getElementById("age");
    const storyTitleElement = document.getElementById("story-title");
    const storyElement = document.getElementById("story");
    const previewElement = document.querySelector("#preview-list h3");

    let genre = "Disturbing";
    const genreSelection = document.getElementById("genre");
    genreSelection.addEventListener("change", () => {
        genre = genreSelection.selectedOptions[0].text;
    });

    const publishButton = document.getElementById("form-btn");
    publishButton.addEventListener("click", publish);

    function publish() {
        const firstName = firstNameElement.value;
        const lastName = lastNameElement.value;
        const age = Number(ageElement.value);
        const storyTitle = storyTitleElement.value;
        const story = storyElement.value;

        if (firstName && lastName && age && storyTitle && genre && story) {
            publishButton.disabled = true;
            generateStoryHtml(
                firstName,
                lastName,
                age,
                storyTitle,
                genre,
                story
            );
        }
    }

    function generateStoryHtml(
        firstName,
        lastName,
        age,
        storyTitle,
        genre,
        story
    ) {
        const liElement = document.createElement("li");
        liElement.classList.add("story-info");

        // Article
        const articleElement = document.createElement("article");

        const headerElement = document.createElement("h4");
        headerElement.textContent = `Name: ${firstName} ${lastName}`;

        const ageParagraphElement = document.createElement("p");
        ageParagraphElement.textContent = `Age: ${age}`;

        const titleParagraphElement = document.createElement("p");
        titleParagraphElement.textContent = `Title: ${storyTitle}`;

        const genreParagraphElement = document.createElement("p");
        genreParagraphElement.textContent = `Genre: ${genre}`;

        const storyParagraphElement = document.createElement("p");
        storyParagraphElement.textContent = story;

        clearInputs();

        articleElement.appendChild(headerElement);
        articleElement.appendChild(ageParagraphElement);
        articleElement.appendChild(titleParagraphElement);
        articleElement.appendChild(genreParagraphElement);
        articleElement.appendChild(storyParagraphElement);

        // Buttons
        const saveButtonElement = document.createElement("button");
        const editButtonElement = document.createElement("button");
        const deleteButtonElement = document.createElement("button");

        saveButtonElement.classList.add("save-btn");
        editButtonElement.classList.add("edit-btn");
        deleteButtonElement.classList.add("delete-btn");

        saveButtonElement.textContent = "Save Story";
        editButtonElement.textContent = "Edit Story";
        deleteButtonElement.textContent = "Delete Story";

        saveButtonElement.addEventListener("click", saveStory);
        editButtonElement.addEventListener("click", editStory);
        deleteButtonElement.addEventListener("click", deleteStory);

        // Append all elements to parent li element
        liElement.appendChild(articleElement);
        liElement.appendChild(saveButtonElement);
        liElement.appendChild(editButtonElement);
        liElement.appendChild(deleteButtonElement);

        previewElement.insertAdjacentElement("afterend", liElement);
    }

    function clearInputs() {
        firstNameElement.value = "";
        lastNameElement.value = "";
        ageElement.value = "";
        storyTitleElement.value = "";
        storyElement.value = "";
    }

    function saveStory() {
        const mainDivElement = document.getElementById("main");
        mainDivElement.innerHTML = ``;

        const h1Element = document.createElement("h1");
        h1Element.textContent = "Your scary story is saved!";

        mainDivElement.appendChild(h1Element);
    }

    function editStory() {
        publishButton.disabled = false;
        const liElement = document.querySelector("li.story-info");
        const headerElement = liElement.querySelector("h4");
        const ageParagraphElement = liElement.querySelector("p:nth-of-type(1)");
        const titleParagraphElement =
            liElement.querySelector("p:nth-of-type(2)");
        const storyParagraphElement =
            liElement.querySelector("p:nth-of-type(4)");

        const fullName = headerElement.textContent.split(": ");
        const splitFullName = fullName[1].split(" ");
        const currentFirstName = splitFullName[0];
        const currentLastName = splitFullName[1];
        firstNameElement.value = currentFirstName;
        lastNameElement.value = currentLastName;

        const currentAge = ageParagraphElement.textContent.split(": ");
        ageElement.value = Number(currentAge[1]);

        const currentTitle = titleParagraphElement.textContent.split(": ");
        storyTitleElement.value = currentTitle[1];

        const currentStory = storyParagraphElement.textContent;
        storyElement.value = currentStory;

        liElement.remove();
    }

    function deleteStory() {
        publishButton.disabled = false;
        const liElement = document.querySelector("li.story-info");
        liElement.remove();
    }
}
