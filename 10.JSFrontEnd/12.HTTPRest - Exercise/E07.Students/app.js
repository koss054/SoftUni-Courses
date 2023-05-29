function attachEvents() {
    const BASE_URL = "http://localhost:3030/jsonstore/collections/students";
    const tbodyElement = document.querySelector("#results tbody");
    const submitBtn = document.getElementById("submit");

    fetchStudents();
    submitBtn.addEventListener("click", submitStudent);

    function submitStudent() {
        const firstNameInput = document.getElementsByName("firstName")[0];
        const lastNameInput = document.getElementsByName("lastName")[0];
        const facultyNumInput = document.getElementsByName("facultyNumber")[0];
        const gradeInput = document.getElementsByName("grade")[0];

        let student = {
            firstName: firstNameInput.value,
            lastName: lastNameInput.value,
            facultyNumber: facultyNumInput.value,
            grade: gradeInput.value,
        };

        if (
            student.firstName &&
            student.lastName &&
            student.facultyNumber &&
            student.grade
        ) {
            fetch(BASE_URL, {
                method: "POST",
                body: JSON.stringify(student),
                headers: {
                    "Content-type": "application/json; charset=UTF-8",
                },
            }).then((response) => response.json());
        }

        firstNameInput.value = "";
        lastNameInput.value = "";
        facultyNumInput.value = "";
        gradeInput.value = "";

        fetchStudents();
    }

    function fetchStudents() {
        fetch(BASE_URL)
            .then((response) => response.json())
            .then((info) => {
                tbodyElement.innerHTML = "";
                for (const student in info) {
                    const currStudent = info[student];
                    createTableRow(
                        currStudent.firstName,
                        currStudent.lastName,
                        currStudent.facultyNumber,
                        currStudent.grade
                    );
                }
            });
    }

    function createTableRow(firstName, lastName, facultyNumber, grade) {
        let trElement = document.createElement("tr");
        let firstNameElement = document.createElement("td");
        let lastNameElement = document.createElement("td");
        let facultyNumberElement = document.createElement("td");
        let gradeElement = document.createElement("td");

        firstNameElement.textContent = firstName;
        lastNameElement.textContent = lastName;
        facultyNumberElement.textContent = facultyNumber;
        gradeElement.textContent = grade;

        trElement.appendChild(firstNameElement);
        trElement.appendChild(lastNameElement);
        trElement.appendChild(facultyNumberElement);
        trElement.appendChild(gradeElement);

        tbodyElement.appendChild(trElement);
    }
}

attachEvents();
