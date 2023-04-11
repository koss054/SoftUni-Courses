function attachEvents() {
    const BASE_URL = "http://localhost:3030/jsonstore/tasks/";
    const titleInputEl = document.getElementById("title");
    const descriptionInputEl = document.getElementById("description");
    const toDoUlEl = document.querySelector("#todo-section ul");
    const inProgressUlEl = document.querySelector("#in-progress-section ul");
    const codeReviewUlEl = document.querySelector("#code-review-section ul");
    const doneUlEl = document.querySelector("#done-section ul");
    const loadBoardBtn = document.getElementById("load-board-btn");
    const addTaskBtn = document.getElementById("create-task-btn");

    loadBoardBtn.addEventListener("click", loadBoard);
    addTaskBtn.addEventListener("click", addTask);

    async function loadBoard(e) {
        if (e) e.preventDefault();
        const response = await fetch(BASE_URL);
        let data = await response.json();
        data = Object.values(data);

        clearUlElHtml();
        for (const { title, description, status, _id } of data) {
            let parentList;
            if (status === "ToDo") parentList = toDoUlEl;
            else if (status === "In Progress") parentList = inProgressUlEl;
            else if (status === "Code Review") parentList = codeReviewUlEl;
            else if (status === "Done") parentList = doneUlEl;
            createLiEl(title, description, status, _id, parentList);
        }
    }

    async function addTask(e) {
        e.preventDefault();
        const title = titleInputEl.value;
        const description = descriptionInputEl.value;
        const status = "ToDo";

        if (title != "" && description != "") {
            const httpHeaders = {
                method: "POST",
                body: JSON.stringify({ title, description, status }),
            };

            await fetch(BASE_URL, httpHeaders);
            loadBoard();

            titleInputEl.value = "";
            descriptionInputEl.value = "";
        }
    }

    async function moveTask(btnEl, taskId) {
        const btnText = btnEl.textContent;
        const parentEl = btnEl.parentNode;
        let status = "";

        if (btnText === "Move to In Progress") {
            inProgressUlEl.appendChild(parentEl);
            status = "In Progress";
        } else if (btnText === "Move to Code Review") {
            codeReviewUlEl.appendChild(parentEl);
            status = "Code Review";
        } else if (btnText === "Move to Done") {
            doneUlEl.appendChild(parentEl);
            status = "Done";
        }

        let httpHeaders = {
            method: "PATCH",
            body: JSON.stringify({ status }),
        };

        if (btnText === "Close") {
            httpHeaders = { method: "DELETE" };
        }

        await fetch(`${BASE_URL}${taskId}`, httpHeaders);
        loadBoard();
    }

    function createLiEl(title, description, status, _id, parentList) {
        const liEl = document.createElement("li");
        liEl.classList.add("task");
        liEl.id = _id;

        const h3El = document.createElement("h3");
        h3El.textContent = title;

        const pEl = document.createElement("p");
        pEl.textContent = description;

        let btnText = "";
        if (status === "ToDo") btnText = "Move to In Progress";
        else if (status === "In Progress") btnText = "Move to Code Review";
        else if (status === "Code Review") btnText = "Move to Done";
        else if (status === "Done") btnText = "Close";

        const btnEl = document.createElement("button");
        btnEl.textContent = btnText;
        btnEl.addEventListener("click", function () {
            moveTask(this, _id);
        });

        liEl.appendChild(h3El);
        liEl.appendChild(pEl);
        liEl.appendChild(btnEl);
        parentList.appendChild(liEl);
    }

    function clearUlElHtml() {
        toDoUlEl.innerHTML = "";
        inProgressUlEl.innerHTML = "";
        codeReviewUlEl.innerHTML = "";
        doneUlEl.innerHTML = "";
    }
}

attachEvents();
