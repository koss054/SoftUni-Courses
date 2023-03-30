function getInfo() {
    const BASE_URL = "http://localhost:3030/jsonstore/bus/businfo/";

    const stopIdElement = document.getElementById("stopId");
    const stopNameElement = document.getElementById("stopName");
    const busesElement = document.getElementById("buses");
    const stopId = stopIdElement.value;

    busesElement.innerHTML = "";
    fetch(`${BASE_URL}${stopId}`)
        .then((response) => response.json())
        .then((busInfo) => {
            const { name, buses } = busInfo;
            stopNameElement.textContent = name;
            for (const busNum in buses) {
                const li = document.createElement("li");
                li.textContent = `Bus ${busNum} arrives in ${buses[busNum]} minutes`;
                busesElement.appendChild(li);
            }
        })
        .catch((error) => {
            stopNameElement.textContent = "Error";
        });
}
