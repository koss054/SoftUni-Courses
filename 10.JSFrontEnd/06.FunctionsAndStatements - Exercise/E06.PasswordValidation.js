function validatePassword(pass) {
    let errorArray = [];

    validatePasswordLength();
    validatePasswordSymbols();
    validatePasswordDigitCount();

    if (errorArray.length === 0) {
        console.log("Password is valid");
    } else {
        console.log(errorArray.join("\n"));
    }

    function validatePasswordLength() {
        if (pass.length < 6 || pass.length > 10) {
            errorArray.push("Password must be between 6 and 10 characters");
        }
    }

    function validatePasswordSymbols() {
        for (let i = 0; i < pass.length; i++) {
            if (isNaN(parseInt(pass[i])) && pass[i].toLowerCase() == pass[i].toUpperCase()) {
                errorArray.push("Password must consist only of letters and digits");
                break;
            }
        }
    }

    function validatePasswordDigitCount() {
        let digitCount = 0;

        for (let i = 0; i < pass.length; i++) {
            if (pass[i] >= '0' && pass[i] <= '9') {
                digitCount++;
            }
        }

        if (digitCount < 2) {
            errorArray.push("Password must have at least 2 digits");
        }
    }
}

validatePassword("logIn");
validatePassword("MyPass123");
validatePassword("Pa$s$s")