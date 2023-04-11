window.addEventListener("load", solve);

function solve() {
    let currentTask = 1;
    let currentTaskPoints = 0;
    let totalPoints = 0;

    const empty = "";
    const hiddenIdEl = document.getElementById("task-id");
    const titleInputEl = document.getElementById("title");
    const descriptionInputEl = document.getElementById("description");
    const labelInputEl = document.getElementById("label");
    const pointsInputEl = document.getElementById("points");
    const assigneeInputEl = document.getElementById("assignee");
    const tasksSectionEl = document.getElementById("tasks-section");
    const totalPointsEl = document.getElementById("total-sprint-points");
    const createTaskBtn = document.getElementById("create-task-btn");
    const deleteTaskBtn = document.getElementById("delete-task-btn");

    createTaskBtn.addEventListener("click", createTask);
    deleteTaskBtn.addEventListener("click", deleteTask);

    function createTask(e) {
        e.preventDefault();
        if (areInputsInvalid()) return;

        const title = titleInputEl.value;
        const description = descriptionInputEl.value;
        const label = labelInputEl.value;
        const points = pointsInputEl.value;
        const assignee = assigneeInputEl.value;

        generateHtml(title, description, label, points, assignee);
        resetInputValues();
        updateTotalSprintPoints(points, true);
        currentTask++;
    }

    function generateHtml(title, description, label, points, assignee) {
        let icon = "";
        let divClass = "";

        if (label === "Feature") {
            icon = "⊡";
            divClass = "feature";
        } else if (label === "Low Priority Bug") {
            icon = "☉";
            divClass = "low-priority";
        } else if (label === "High Priority Bug") {
            icon = "⚠";
            divClass = "high-priority";
        }

        const pointsContent = `Estimated at ${points} pts`;
        const assigneeContent = `Assigned to: ${assignee}`;
        const parentArticle = createEl(
            "article",
            tasksSectionEl,
            empty,
            "task-card",
            `task-${currentTask}`
        );

        // Div with label
        createEl(
            "div",
            parentArticle,
            `${label} ${icon}`,
            `task-card-label ${divClass}`,
            empty
        );

        createEl("h3", parentArticle, title, "task-card-title");
        createEl("p", parentArticle, description, "task-card-description");
        createEl("div", parentArticle, pointsContent, "task-card-points");
        createEl("div", parentArticle, assigneeContent, "task-card-assignee");

        // Div with button
        const divWithDelete = createEl(
            "div",
            parentArticle,
            "",
            "task-card-actions"
        );

        const deleteBtn = createEl("button", divWithDelete, "Delete");
        deleteBtn.addEventListener("click", loadConfirmDelete);
    }

    function loadConfirmDelete() {
        changeInputDisabledStatus("disable");
        createTaskBtn.disabled = true;
        deleteTaskBtn.disabled = false;

        const article = this.parentNode.parentNode;
        const taskId = article.id;
        const title = article.querySelector(".task-card-title").textContent;
        const description = article.querySelector(
            ".task-card-description"
        ).textContent;

        const labelTextArr = article
            .querySelector(".task-card-label")
            .textContent.split(" ");
        labelTextArr.splice(labelTextArr.length - 1, 1);
        const label = labelTextArr.join(" ");

        const pointsTextArr = article
            .querySelector(".task-card-points")
            .textContent.split(" ");
        const points = Number(pointsTextArr[2]);

        const assigneeTextArr = article
            .querySelector(".task-card-assignee")
            .textContent.split(": ");
        const assignee = assigneeTextArr[1];

        currentTaskPoints = points;
        hiddenIdEl.value = taskId;
        titleInputEl.value = title;
        descriptionInputEl.value = description;
        labelInputEl.value = label;
        pointsInputEl.value = points;
        assigneeInputEl.value = assignee;
    }

    function deleteTask(e) {
        e.preventDefault();
        const taskId = hiddenIdEl.value;
        const elToRemove = document.getElementById(taskId);
        tasksSectionEl.removeChild(elToRemove);

        resetInputValues();
        updateTotalSprintPoints(currentTaskPoints, false);
        changeInputDisabledStatus("enable");
        createTaskBtn.disabled = false;
        deleteTaskBtn.disabled = true;
    }

    function createEl(elType, elParent, elContent, elClass, elId) {
        const htmlEl = document.createElement(elType);

        htmlEl.textContent = elContent;
        if (elId) htmlEl.id = elId;

        if (elClass) {
            const classes = elClass.split(" ");

            for (const item of classes) {
                htmlEl.classList.add(item);
            }
        }

        elParent.appendChild(htmlEl);
        return htmlEl;
    }

    function areInputsInvalid() {
        const isTitleInvalid = titleInputEl.value == "";
        const isDescriptionInvalid = descriptionInputEl.value == "";
        const isLabelInvalid = labelInputEl.value == "";
        const arePointsInvalid = pointsInputEl.value == "";
        const isAssigneeInvalid = assigneeInputEl.value == "";

        return (
            isTitleInvalid ||
            isDescriptionInvalid ||
            isLabelInvalid ||
            arePointsInvalid ||
            isAssigneeInvalid
        );
    }

    function resetInputValues() {
        titleInputEl.value = "";
        descriptionInputEl.value = "";
        pointsInputEl.value = "";
        labelInputEl.value = "Feature";
        assigneeInputEl.value = "";
    }

    function updateTotalSprintPoints(points, shouldIncrease) {
        if (shouldIncrease) totalPoints += Number(points);
        else totalPoints -= Number(points);
        totalPointsEl.textContent = `Total Points ${totalPoints}pts`;
    }

    function changeInputDisabledStatus(changeTo) {
        if (changeTo === "enable") {
            titleInputEl.disabled = false;
            descriptionInputEl.disabled = false;
            labelInputEl.disabled = false;
            pointsInputEl.disabled = false;
            assigneeInputEl.disabled = false;
        } else if (changeTo === "disable") {
            titleInputEl.disabled = true;
            descriptionInputEl.disabled = true;
            labelInputEl.disabled = true;
            pointsInputEl.disabled = true;
            assigneeInputEl.disabled = true;
        }
    }
}
