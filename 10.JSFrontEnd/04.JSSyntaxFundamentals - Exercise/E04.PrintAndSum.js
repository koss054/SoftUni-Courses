function printAndSum(startNum, endNum) {
    let numString = "";
    let sum = 0;

    for (let i = startNum; i <= endNum; i++) {
        numString += i + " ";
        sum += i;
    }

    console.log(numString);
    console.log(`Sum: ${sum}`);
}