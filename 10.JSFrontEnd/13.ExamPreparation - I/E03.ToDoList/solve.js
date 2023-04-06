// TODO
function attachEvents() {
    const BASE_URL = "http://localhost:3030/jsonstore/tasks/";
    const toDoListElement = document.getElementById("todo-list");
    const taskTitleInputElement = document.getElementById("title");
    const addBtn = document.getElementById("add-button");
    const loadAllBtn = document.getElementById("load-button");

    addBtn.addEventListener("click", addTask, true);
    loadAllBtn.addEventListener("click", getAllTasks, true);

    async function addTask(e) {
        e.preventDefault();
        const name = taskTitleInputElement.value;

        if (name != "") {
            const httpHeaders = {
                method: "POST",
                body: JSON.stringify({ name }),
            };

            await fetch(BASE_URL, httpHeaders);
            getAllTasks(e);
        }

        taskTitleInputElement.value = "";
    }

    async function getAllTasks(e) {
        e.preventDefault();
        try {
            const taskResponse = await fetch(BASE_URL);
            let taskData = await taskResponse.json();
            taskData = Object.values(taskData);

            toDoListElement.innerHTML = "";
            for (const { name, _id } of taskData) {
                const li = document.createElement("li");
                li.id = _id;

                const span = document.createElement("span");
                span.textContent = name;

                const removeBtn = document.createElement("button");
                removeBtn.textContent = "Remove";
                removeBtn.addEventListener("click", removeTask);

                const editBtn = document.createElement("button");
                editBtn.textContent = "Edit";
                editBtn.addEventListener("click", editTask);

                li.appendChild(span);
                li.appendChild(removeBtn);
                li.appendChild(editBtn);
                toDoListElement.appendChild(li);
            }
        } catch (error) {
            console.error(error);
        }
    }

    async function removeTask(e) {
        const currentId = this.parentNode.id;

        if (currentId != "") {
            const httpHeaders = {
                method: "DELETE",
            };

            await fetch(`${BASE_URL}${currentId}`, httpHeaders);
            getAllTasks(e);
        }
    }

    async function editTask(e) {
        const currentId = this.parentNode.id;

        if (this.textContent === "Edit") {
            const titleSpanElement = this.parentNode.querySelector("span");
            const titleInputElement = document.createElement("input");
            titleInputElement.value = titleSpanElement.textContent;
            titleSpanElement.replaceWith(titleInputElement);
            this.textContent = "Submit";
        } else if (this.textContent === "Submit") {
            const name = this.parentNode.querySelector("input").value;
            const _id = this.parentNode.id;
            const httpHeaders = {
                method: "PUT",
                body: JSON.stringify({ name, _id }),
            };

            await fetch(`${BASE_URL}${currentId}`, httpHeaders);
            getAllTasks(e);
        }
    }
}

attachEvents();
