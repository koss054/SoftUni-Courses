function vacationCost(peopleCount, peopleGroup, weekday) {
    let ticketPrice = 0;
    let discountPercentage = 0;

    switch (peopleGroup) {
        case "Students":
            if (weekday == "Friday") ticketPrice = 8.45;
            else if (weekday == "Saturday") ticketPrice = 15.60;
            else if (weekday == "Sunday") ticketPrice = 10.46;

            if (peopleCount >= 30) discountPercentage = 15;
            break;

        case "Business":
            if (peopleCount >= 100) peopleCount -= 10;

            if (weekday == "Friday") ticketPrice = 10.90;
            else if (weekday == "Saturday") ticketPrice = 15.60;
            else if (weekday == "Sunday") ticketPrice = 16;

            break;

        case "Regular":
            if (weekday == "Friday") ticketPrice = 15;
            else if (weekday == "Saturday") ticketPrice = 20;
            else if (weekday == "Sunday") ticketPrice = 22.50;

            if (peopleCount >= 10 && peopleCount <= 20) discountPercentage = 5;
            break;
    }

    getTicketTotal(ticketPrice, peopleCount, discountPercentage);

    function getTicketTotal(ticketPrice, peopleCount, discountPercentage) {
        let total = ticketPrice * peopleCount;
        total -= (total * discountPercentage) / 100;
        console.log(`Total price: ${total.toFixed(2)}`);
    }
}