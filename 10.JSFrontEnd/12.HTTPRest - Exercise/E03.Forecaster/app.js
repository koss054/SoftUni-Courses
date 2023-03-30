function attachEvents() {
    const BASE_URL = `http://localhost:3030/jsonstore/forecaster/`;
    const submitBtn = document.getElementById("submit");
    const locationElement = document.getElementById("location");
    const forecastElement = document.getElementById("forecast");
    const upcomingElement = document.getElementById("upcoming");

    let locations = {};
    let currentCode = "";

    fetch(`${BASE_URL}locations`)
        .then((response) => response.json())
        .then((locationInfo) => {
            const locationsArray = locationInfo;
            for (const location of locationsArray) {
                locations[location.name] = location.code;
            }
        })
        .catch((error) => {
            console.error(error);
        });

    submitBtn.addEventListener("click", () => {
        forecastElement.style.display = "block";
        const currentElement = document.querySelector("#current");
        const currentLabelElement = document.querySelector("#current .label");

        const upcomingElement = document.querySelector("#upcoming");
        const upcomingLabelElement = document.querySelector("#upcoming .label");

        currentCode = locations[locationElement.value];

        currentElement.innerHTML = "";
        currentElement.appendChild(currentLabelElement);

        upcomingElement.innerHTML = "";
        upcomingElement.appendChild(upcomingLabelElement);

        fetch(`${BASE_URL}today/${currentCode}`)
            .then((response) => response.json())
            .then((todayForecast) => {
                const { name, forecast } = todayForecast;
                const iconCode = getIcon(forecast.condition);

                const forecastsElement = createElement("div", "forecasts");

                const iconElement = createElement(
                    "span",
                    "condition symbol",
                    iconCode
                );

                const parentSpanElement = createElement("span", "condition");

                const locationNameElement = createElement(
                    "span",
                    "forecast-data",
                    name
                );

                const temperaturesElement = createElement(
                    "span",
                    "forecast-data",
                    `${forecast.low}°/${forecast.high}°`
                );

                const conditionElement = createElement(
                    "span",
                    "forecast-data",
                    forecast.condition
                );

                parentSpanElement.appendChild(locationNameElement);
                parentSpanElement.appendChild(temperaturesElement);
                parentSpanElement.appendChild(conditionElement);

                forecastsElement.appendChild(iconElement);
                forecastsElement.appendChild(parentSpanElement);

                currentElement.appendChild(forecastsElement);
            });

        fetch(`${BASE_URL}upcoming/${currentCode}`)
            .then((response) => response.json())
            .then((info) => {
                const forecastInfoElement = createElement(
                    "div",
                    "forecast-info"
                );

                for (const forecast of info.forecast) {
                    const iconCode = getIcon(forecast.condition);
                    const childUpcomingElement = createElement(
                        "span",
                        "upcoming"
                    );

                    const iconElement = createElement(
                        "span",
                        "symbol",
                        iconCode
                    );

                    const temperaturesElement = createElement(
                        "span",
                        "forecast-data",
                        `${forecast.low}°/${forecast.high}°`
                    );

                    const conditionElement = createElement(
                        "span",
                        "forecast-data",
                        forecast.condition
                    );

                    childUpcomingElement.appendChild(iconElement);
                    childUpcomingElement.appendChild(temperaturesElement);
                    childUpcomingElement.appendChild(conditionElement);

                    forecastInfoElement.appendChild(childUpcomingElement);
                }

                upcomingElement.appendChild(forecastInfoElement);
            });
    });

    function getIcon(conditionString) {
        switch (conditionString) {
            case "Sunny":
                return "&#x2600";
            case "Partly sunny":
                return "&#x26C5";
            case "Overcast":
                return "&#x2601";
            case "Rain":
                return "&#x2614";
        }
    }

    function createElement(type, elementClasses, textContent) {
        let element = document.createElement(type);

        if (elementClasses) {
            const splitClasses = elementClasses.split(" ");
            for (const elementClass of splitClasses) {
                element.classList.add(elementClass);
            }
        }

        if (elementClasses.includes("symbol")) {
            element.innerHTML = textContent;
            return element;
        }

        if (textContent) {
            element.textContent = textContent;
        }

        return element;
    }
}

attachEvents();
