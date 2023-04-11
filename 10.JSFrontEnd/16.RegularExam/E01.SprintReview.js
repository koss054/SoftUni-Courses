function sprintReview(input) {
    let boardCollection = [];
    let donePoints = 0;
    let otherPoints = 0;
    const initialBoardTasks = input.shift();
    const commandParser = {
        "Add New": addNew,
        "Change Status": changeStatus,
        "Remove Task": removeTask,
    };

    for (let i = 0; i < initialBoardTasks; i++) {
        const [assignee, taskId, title, status, estimatedPoints] = input
            .shift()
            .split(":");

        const currentTask = {
            assignee,
            taskId,
            title,
            status,
            estimatedPoints,
        };

        boardCollection.push(currentTask);
    }

    while (input.length > 0) {
        const currentLine = input.shift().split(":");
        const command = currentLine[0];
        if (
            command === "Add New" ||
            command === "Change Status" ||
            command === "Remove Task"
        ) {
            commandParser[command](...currentLine.slice(1));
        }
    }

    getStatusPoints("ToDo");
    getStatusPoints("In Progress");
    getStatusPoints("Code Review");
    getStatusPoints("Done");
    getSprintResult(donePoints, otherPoints);

    // Functions used for the solution.
    function addNew(assignee, taskId, title, status, estimatedPoints) {
        const assigneeIndex = getAssigneeIndex(assignee);
        if (assigneeIndex >= 0) {
            const currentTask = {
                assignee,
                taskId,
                title,
                status,
                estimatedPoints,
            };

            boardCollection.push(currentTask);
        } else {
            console.log(`Assignee ${assignee} does not exist on the board!`);
        }
    }

    function changeStatus(assignee, taskId, newStatus) {
        const assigneeIndex = getAssigneeIndex(assignee);
        const taskIdIndex = getTaskIdIndex(taskId, assignee);

        if (assigneeIndex === undefined) {
            console.log(`Assignee ${assignee} does not exist on the board!`);
        } else if (taskIdIndex === undefined) {
            console.log(
                `Task with ID ${taskId} does not exist for ${assignee}!`
            );
        } else {
            const currentTask = boardCollection[taskIdIndex];
            if (currentTask) {
                currentTask.status = newStatus;
            } else {
                console.log(
                    `Task with ID ${taskId} does not exist for ${assignee}!`
                );
            }
        }
    }

    function removeTask(assignee, index) {
        const assigneeIndex = getAssigneeIndex(assignee);
        if (assigneeIndex === undefined) {
            console.log(`Assignee ${assignee} does not exist on the board!`);
        } else {
            const assigneeTasks = getAssigneeTasksArray(assignee);
            if (index >= assigneeTasks.length) {
                console.log("Index is out of range!");
            } else {
                const assigneeTaskIndex = getAssigneeTaskId(
                    assigneeTasks,
                    index,
                    assignee
                );

                boardCollection.splice(assigneeTaskIndex, 1);
            }
        }
    }

    function getAssigneeIndex(assigneeName) {
        let index = 0;
        for (const task of boardCollection) {
            if (task.assignee == assigneeName) {
                return index;
            }

            index++;
        }
    }

    function getTaskIdIndex(taskId, assigneeName) {
        let index = 0;
        for (const task of boardCollection) {
            if (task.taskId === taskId && task.assignee === assigneeName) {
                return index;
            }

            index++;
        }
    }

    function getAssigneeTasksArray(assigneeName) {
        let taskArray = [];
        for (const task of boardCollection) {
            if (task.assignee === assigneeName) {
                taskArray.push(task);
            }
        }

        return taskArray;
    }

    function getAssigneeTaskId(assigneeTaskArray, indexToRemove, assigneeName) {
        const taskToRemove = assigneeTaskArray[indexToRemove];

        if (taskToRemove) {
            const taskId = taskToRemove.taskId;
            const taskIndex = getTaskIdIndex(taskId, assigneeName);
            return taskIndex;
        }
    }

    function getStatusPoints(status) {
        let currentPoints = 0;
        for (const task of boardCollection) {
            if (task.status === status) {
                currentPoints += Number(task.estimatedPoints);
            }
        }

        if (status === "Done") {
            donePoints += currentPoints;
        } else {
            otherPoints += currentPoints;
        }

        if (status === "Done") status = "Done Points";
        if (status === "CodeReview") status = "Code Review";
        console.log(`${status}: ${currentPoints}pts`);
    }

    function getSprintResult(donePoints, otherPoints) {
        if (donePoints >= otherPoints) {
            console.log("Sprint was successful!");
        } else {
            console.log("Sprint was unsuccessful...");
        }
    }
}

sprintReview([
    "5",
    "Kiril:BOP-1209:Fix MinorBug:ToDo:3",
    "Mariya:BOP-1210:Fix MajorBug:In Progress:3",
    "Peter:BOP-1211:POC:Code Review:5",
    "Georgi:BOP-1212:Investigation Task:Done:2",
    "Mariya:BOP-1213:NewAccount Page:In Progress:13",
    "Add New:Kiril:BOP-1217:AddInfo Page:In Progress:5",
    "Change Status:Peter:BOP-1290:ToDo",
    "Remove Task:Mariya:1",
    "Remove Task:Joro:1",
]);

sprintReview([
    "4",
    "Kiril:BOP-1213:Fix Typo:Done:1",
    "Peter:BOP-1214:New Products Page:In Progress:2",
    "Mariya:BOP-1215:Setup Routing:ToDo:8",
    "Georgi:BOP-1216:Add Business Card:Code Review:3",
    "Add New:Sam:BOP-1237:Testing Home Page:Done:3",
    "Change Status:Georgi:BOP-1216:Done",
    "Change Status:Will:BOP-1212:In Progress",
    "Remove Task:Georgi:3",
    "Change Status:Mariya:BOP-1215:Done",
]);
