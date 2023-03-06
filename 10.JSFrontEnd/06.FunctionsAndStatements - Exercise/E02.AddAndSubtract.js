function addAndSubtract(numOne, numTwo, numThree) {
    console.log(subtract());

    function sum() {
        return numOne + numTwo;
    }

    function subtract() {
        return sum() - numThree;
    }
}

addAndSubtract(23, 6, 10);
addAndSubtract(1, 17, 30);