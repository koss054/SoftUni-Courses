function attachEvents() {
    const BASE_URL = "http://localhost:3030/jsonstore/phonebook";
    const phonebookElement = document.getElementById("phonebook");
    const personInputElement = document.getElementById("person");
    const phoneNumberInputElement = document.getElementById("phone");
    const loadBtn = document.getElementById("btnLoad");
    const createBtn = document.getElementById("btnCreate");

    loadBtn.addEventListener("click", () => {
        fetch(BASE_URL)
            .then((response) => response.json())
            .then((info) => {
                phonebookElement.innerHTML = "";
                for (const row in info) {
                    createPhonebookEntryElement(
                        info[row].person,
                        info[row].phone
                    );
                }
            });
    });

    createBtn.addEventListener("click", () => {
        const entryObj = {
            person: personInputElement.value,
            phone: phoneNumberInputElement.value,
        };

        fetch(BASE_URL, {
            method: "POST",
            body: JSON.stringify(entryObj),
            headers: {
                "Content-type": "application/json; charset=UTF-8",
            },
        }).then((response) => response.json());

        personInputElement.value = "";
        phoneNumberInputElement.value = "";
    });

    async function createPhonebookEntryElement(personName, phoneNumber) {
        const entryId = await getEntryId(phoneNumber);
        let li = document.createElement("li");
        let deleteBtn = document.createElement("button");

        li.textContent = `${personName} ${phoneNumber}`;
        deleteBtn.textContent = "Delete";

        deleteBtn.addEventListener("click", () => {
            phonebookElement.removeChild(li);
            fetch(`${BASE_URL}/${entryId}`, {
                method: "DELETE",
                headers: {
                    "Content-type": "application/json; charset=UTF-8",
                },
            })
                .then((response) => response.json())
                .then((info) => console.log(info));
        });

        li.appendChild(deleteBtn);

        phonebookElement.appendChild(li);
    }

    async function getEntryId(phoneNumber) {
        let entryId = await fetch(BASE_URL)
            .then((response) => response.json())
            .then((info) => {
                for (const row in info) {
                    if (info[row].phone === phoneNumber) {
                        return info[row]._id;
                    }
                }
            });

        return entryId;
    }
}

attachEvents();
