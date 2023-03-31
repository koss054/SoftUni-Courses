function attachEvents() {
    const BASE_URL = "http://localhost:3030/jsonstore/messenger";
    const textareaElement = document.getElementById("messages");
    const nameElement = document.getElementsByName("author")[0];
    const contentElement = document.getElementsByName("content")[0];
    const submitBtn = document.getElementById("submit");
    const refreshBtn = document.getElementById("refresh");

    submitBtn.addEventListener("click", () =>{
        const messageObj = {
            author: nameElement.value,
            content: contentElement.value
        };

        fetch(BASE_URL, {
            method: "POST",
            body: JSON.stringify(messageObj),
            headers: {
                "Content-type": "application/json; charset=UTF-8"
            }
        })
        .then(response => response.json())
        .then(json => console.log(json))
    })

    refreshBtn.addEventListener("click", () => {
        fetch(BASE_URL)
            .then(response => response.json())
            .then(info => {
                textareaElement.value = '';
                let count = 0;
                for (const message in info) {
                    const authorName = info[message].author;
                    const content = info[message].content;
                    if (authorName && content) {
                        if (Object.keys(info).length - 1 === count) {
                            textareaElement.value += `${authorName}: ${content}`;    
                        } else {
                            textareaElement.value += `${authorName}: ${content}\n`;
                        }
                    }
                    count++;
                }
            })
    });
}

attachEvents();