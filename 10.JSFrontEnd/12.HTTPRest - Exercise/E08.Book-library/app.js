function attachEvents() {
    const BASE_URL = "http://localhost:3030/jsonstore/collections/books/";
    const loadBtn = document.getElementById("loadBooks");
    const createBtn = document.querySelector("#form > button");
    const tbodyElement = document.querySelector("table tbody");
    const h3FormElement = document.querySelector("#form > h3");
    const [titleInputElement, authorInputElement] =
        document.querySelectorAll("#form > input");

    let editBookId = null;

    loadBtn.addEventListener("click", loadAllBooks);
    createBtn.addEventListener("click", createBook);

    async function loadAllBooks() {
        const response = await fetch(BASE_URL);
        let bookData = await response.json();
        tbodyElement.innerHTML = "";

        for (const bookId in bookData) {
            const { author, title } = bookData[bookId];
            createTableRow(title, author, bookId);
        }
    }

    async function createBook() {
        let url = BASE_URL;
        const isEditMode = h3FormElement.textContent == "Edit FORM";
        const title = titleInputElement.value;
        const author = authorInputElement.value;
        const httpHeaders = {
            method: "POST",
            body: JSON.stringify({ author, title }),
        };

        if (isEditMode) {
            httpHeaders.method = "PUT";
            url += editBookId;
        }

        await fetch(url, httpHeaders);
        loadAllBooks();

        if (isEditMode) {
            h3FormElement.textContent = "FORM";
            createBtn.textContent = "Submit";
        }

        titleInputElement.value = "";
        authorInputElement.value = "";
    }

    async function editBook() {
        editBookId = this.id;
        h3FormElement.textContent = "Edit FORM";
        createBtn.textContent = "Save";

        const response = await fetch(`${BASE_URL}${this.id}`);
        let bookData = await response.json();

        titleInputElement.value = bookData.title;
        authorInputElement.value = bookData.author;
    }

    async function deleteBook() {
        let httpHeaders = {
            method: "DELETE",
        };

        await fetch(`${BASE_URL}${this.id}`, httpHeaders);
        loadAllBooks();
    }

    function createTableRow(title, author, id) {
        let tr = document.createElement("tr");
        let titleTd = document.createElement("td");
        let authorTd = document.createElement("td");
        let actionTd = document.createElement("td");
        let editBtn = document.createElement("button");
        let deleteBtn = document.createElement("button");

        titleTd.textContent = title;
        authorTd.textContent = author;
        editBtn.textContent = "Edit";
        deleteBtn.textContent = "Delete";

        editBtn.id = id;
        deleteBtn.id = id;
        editBtn.addEventListener("click", editBook);
        deleteBtn.addEventListener("click", deleteBook);

        actionTd.appendChild(editBtn);
        actionTd.appendChild(deleteBtn);
        tr.appendChild(titleTd);
        tr.appendChild(authorTd);
        tr.appendChild(actionTd);
        tbodyElement.appendChild(tr);
    }
}

attachEvents();
