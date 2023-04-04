function attachEvents() {
    const BASE_URL = "http://localhost:3030/jsonstore/phonebook/";
    const phoneBookElement = document.getElementById("phonebook");
    const personInputElement = document.getElementById("person");
    const phoneNumberInputElement = document.getElementById("phone");
    const loadBtn = document.getElementById("btnLoad");
    const createBtn = document.getElementById("btnCreate");

    loadBtn.addEventListener("click", loadEntries);
    createBtn.addEventListener("click", createEntry);

    async function loadEntries() {
        try {
            const phoneBookResponse = await fetch(BASE_URL);
            let phoneBookData = await phoneBookResponse.json();

            phoneBookData = Object.values(phoneBookData);
            phoneBookElement.innerHTML = "";

            for (const { phone, person, _id } of phoneBookData) {
                const li = document.createElement("li");
                const button = document.createElement("button");

                button.id = _id;
                button.textContent = "Delete";
                button.addEventListener("click", deleteEntry);

                li.textContent = `${person}: ${phone}`;
                li.appendChild(button);

                phoneBookElement.appendChild(li);
            }
        } catch (error) {
            console.error(error);
        }
    }

    async function createEntry() {
        const person = personInputElement.value;
        const phone = phoneNumberInputElement.value;
        const httpHeaders = {
            method: "POST",
            body: JSON.stringify({ person, phone }),
        };

        fetch(BASE_URL, httpHeaders)
            .then((response) => response.json())
            .then(() => {
                loadEntries();
                personInputElement.value = "";
                phoneNumberInputElement.value = "";
            })
            .catch((error) => {
                console.error(error);
            });
    }

    async function deleteEntry() {
        const id = this.id;
        const httpHeaders = {
            method: "DELETE",
        };

        fetch(`${BASE_URL}${id}`, httpHeaders)
            .then((response) => response.json())
            .then(loadEntries)
            .catch((error) => {
                console.error(error);
            });
    }
}

attachEvents();
