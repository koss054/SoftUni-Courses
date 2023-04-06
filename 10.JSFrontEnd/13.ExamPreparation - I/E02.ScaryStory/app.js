window.addEventListener("load", solve);

function solve() {
    const previewListElement = document.getElementById("preview-list");
    const firstNameInputElement = document.getElementById("first-name");
    const lastNameInputElement = document.getElementById("last-name");
    const ageInputElement = document.getElementById("age");
    const storyTitleInputElement = document.getElementById("story-title");
    const genreSelectElement = document.getElementById("genre");
    const storyTextareaElement = document.getElementById("story");
    const publishBtn = document.getElementById("form-btn");

    let saveBtn, editBtn, deleteBtn;

    publishBtn.addEventListener("click", generateStory);

    function generateStory() {
        if (!areInputsInvalid()) {
            clearPreviewList();

            const liElement = createElement(
                "li",
                previewListElement,
                "story-info"
            );
            const articleElement = createElement("article", liElement);
            const saveButton = createElement(
                "button",
                liElement,
                "save-btn",
                "Save Story"
            );
            const editButton = createElement(
                "button",
                liElement,
                "edit-btn",
                "Edit Story"
            );
            const deleteButton = createElement(
                "button",
                liElement,
                "delete-btn",
                "Delete Story"
            );

            publishBtn.disabled = true;
            saveButton.disabled = false;
            editButton.disabled = false;
            deleteButton.disabled = false;

            const h4Content = `Name: ${firstNameInputElement.value} ${lastNameInputElement.value}`;
            const ageContent = `Age: ${ageInputElement.value}`;
            const titleContent = `Title: ${storyTitleInputElement.value}`;
            const genreContent = `Genre: ${genreSelectElement.value}`;
            const storyContent = storyTextareaElement.value;

            createElement("h4", articleElement, "", h4Content);
            createElement("p", articleElement, "", ageContent);
            createElement("p", articleElement, "", titleContent);
            createElement("p", articleElement, "", genreContent);
            createElement("p", articleElement, "", storyContent);

            saveButton.addEventListener("click", saveStory);
            editButton.addEventListener("click", editStory);
            deleteButton.addEventListener("click", deleteStory);

            saveBtn = saveButton;
            editBtn = editButton;
            deleteBtn = deleteButton;

            clearInputFields();
        }
    }

    function createElement(
        elementType,
        elementParent,
        elementClass,
        elementContent
    ) {
        const htmlElement = document.createElement(elementType);
        if (elementType === "input") {
            htmlElement.value = elementContent;
        } else {
            htmlElement.textContent = elementContent;
        }

        if (elementParent) {
            elementParent.appendChild(htmlElement);
        }

        if (elementClass) {
            htmlElement.classList.add(elementClass);
        }

        return htmlElement;
    }

    function clearPreviewList() {
        previewListElement.innerHTML = "";
        createElement("h3", previewListElement, "", "Preview");
    }

    function clearInputFields() {
        firstNameInputElement.value = "";
        lastNameInputElement.value = "";
        ageInputElement.value = "";
        storyTitleInputElement.value = "";
        storyTextareaElement.value = "";
    }

    function populateInputFields() {
        const articleElement = document.querySelector(
            "#preview-list > li > article"
        );

        const h4Element = articleElement.querySelector("h4");
        const [ignore, firstName, lastName] = h4Element.textContent.split(" ");
        firstNameInputElement.value = firstName;
        lastNameInputElement.value = lastName;

        // Not using the genreElement as the value isn't cleared.
        // Taking it here since it's between two needed elements.
        const [ageElement, titleElement, genreElement, storyElement] =
            articleElement.querySelectorAll("p");

        ageInputElement.value = Number(ageElement.textContent.split(" ")[1]);
        storyTitleInputElement.value = titleElement.textContent.split(" ")[1];
        storyTextareaElement.value = storyElement.textContent;
    }

    function areInputsInvalid() {
        const isFirstNameInvalid = validateField(firstNameInputElement);
        const isLastNameInvalid = validateField(lastNameInputElement);
        const isAgeInvalid = validateField(ageInputElement);
        const isStoryTitleInvalid = validateField(storyTitleInputElement);
        const isStoryInvalid = validateField(storyTextareaElement);

        // Returns true if any of the fields are invalid.
        return (
            isFirstNameInvalid ||
            isLastNameInvalid ||
            isAgeInvalid ||
            isStoryTitleInvalid ||
            isStoryInvalid
        );

        function validateField(field) {
            return field.value == "";
        }
    }

    function saveStory() {
        const mainElement = document.getElementById("main");
        const h1Content = "Your scary story is saved!";

        mainElement.innerHTML = "";
        createElement("h1", mainElement, "", h1Content);
    }

    function editStory() {
        publishBtn.disabled = false;
        saveBtn.disabled = true;
        editBtn.disabled = true;
        deleteBtn.disabled = true;

        populateInputFields();
        clearPreviewList();
    }

    function deleteStory() {
        clearPreviewList();
        publishBtn.disabled = false;
    }
}
