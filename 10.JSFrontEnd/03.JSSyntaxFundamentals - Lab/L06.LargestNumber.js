function getLargestNum(firstNum, secondNum, thirdNum) {
    let array = [firstNum, secondNum, thirdNum];
    let largestNum = firstNum;

    for (let i = 1; i < array.length; i++) {
        if (largestNum < array[i]) largestNum = array[i];
    }

    console.log(`The largest number is ${largestNum}.`);
}