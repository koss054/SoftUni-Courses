function cookNumber(stringNum, action1, action2, action3, action4, action5) {
    let num = parseInt(stringNum);

    num = doAction(num, action1);
    logNumber(num);

    num = doAction(num, action2);
    logNumber(num);

    num = doAction(num, action3);
    logNumber(num);

    num = doAction(num, action4);
    logNumber(num);

    num = doAction(num, action5);
    logNumber(num);

    function doAction(number, action) {
        switch (action) {
            case "chop": return number / 2;
            case "dice": return Math.sqrt(number);
            case "spice": return number + 1;
            case "bake": return number * 3;
            case "fillet": return number - (number * 0.2);
        }
    }

    function logNumber(number) {
        console.log(number);
    }
}