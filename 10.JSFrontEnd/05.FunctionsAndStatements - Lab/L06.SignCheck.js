function isSignPositive(numOne, numTwo, numThree) {
    const numArray = [numOne, numTwo, numThree];
    const negativeNumArray = numArray.filter(num => num < 0);

    return negativeNumArray.length % 2 === 0 ? "Positive" : "Negative";
}

console.log(isSignPositive(5, 12, -15));
console.log(isSignPositive(-6, -12, 14));
console.log(isSignPositive(-1, -2, -3));
console.log(isSignPositive(-5, 1, 1));