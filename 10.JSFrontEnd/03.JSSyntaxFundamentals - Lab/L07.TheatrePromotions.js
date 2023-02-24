function calcTickets(dayType, age) {
    let ageGroup = getAgeGroup(age);

    if (ageGroup == -1) {
        printErrorMsg();
    } else {
        if (dayType == "Weekday") {
            switch (ageGroup) {
                case 1: printTicketPrice(12); break;
                case 2: printTicketPrice(18); break;
                case 3: printTicketPrice(12); break;
            }
        } else if (dayType == "Weekend") {
            switch (ageGroup) {
                case 1: printTicketPrice(15); break;
                case 2: printTicketPrice(20); break;
                case 3: printTicketPrice(15); break;
            }
        } else if (dayType == "Holiday") {
            switch (ageGroup) {
                case 1: printTicketPrice(5); break;
                case 2: printTicketPrice(12); break;
                case 3: printTicketPrice(10); break;
            }
        } else {
            printErrorMsg();
        }
    }


    function getAgeGroup(age) {
        if (age < 0 || age > 122) return -1;
        else if (age >= 0 && age <= 18) return 1;
        else if (age > 18 && age <= 64) return 2;
        else if (age > 64 && age <= 122) return 3;
    }
    
    function printTicketPrice(value) {
        console.log(`${value}$`);
    }
    
    function printErrorMsg() {
        console.log("Error!");
    }
}