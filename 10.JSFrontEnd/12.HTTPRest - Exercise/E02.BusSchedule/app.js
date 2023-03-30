function solve() {
    const BASE_URL = "http://localhost:3030/jsonstore/bus/schedule/";
    const infoElement = document.getElementById("info");
    const departBtn = document.getElementById("depart");
    const arriveBtn = document.getElementById("arrive");

    let currentStationId = "Depot"; // First station id
    let nextStationId = "";
    let currentStationName = "";

    function depart() {
        arriveBtn.disabled = false;
        departBtn.disabled = true;

        fetch(`${BASE_URL}${currentStationId.toLowerCase()}`)
            .then((response) => response.json())
            .then((stopInfo) => {
                const { name, next } = stopInfo;
                infoElement.textContent = `Next stop ${name}`;
                currentStationName = name;
                nextStationId = next;
            })
            .catch(() => {
                infoElement.textContent = `Error`;
                arriveBtn.disabled = true;
                departBtn.disabled = true;
            });
    }

    async function arrive() {
        arriveBtn.disabled = true;
        departBtn.disabled = false;

        infoElement.textContent = `Arriving at ${currentStationName}`;
        currentStationId = nextStationId;
    }

    return {
        depart,
        arrive,
    };
}

let result = solve();
