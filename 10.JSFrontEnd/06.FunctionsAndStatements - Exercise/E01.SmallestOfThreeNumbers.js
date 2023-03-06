function getSmallestNum(numOne, numTwo, numThree) {
    const numArray = [numOne, numTwo, numThree];
    let sortedNumArray = numArray.sort((a, b) => a - b);

    console.log(sortedNumArray[0]);
}

getSmallestNum(2, -3, 4);
getSmallestNum(25, 21, 4);