function simpleCalculator(numOne, numTwo, operator) {
    let operation = {
        multiply: () => numOne * numTwo,
        divide: () => numOne / numTwo,
        add: () => numOne + numTwo,
        subtract: () => numOne - numTwo,
    }

    return operation[operator]();
}

console.log(simpleCalculator(5, 5, "multiply"));
console.log(simpleCalculator(40, 8, "divide"));
console.log(simpleCalculator(50, 5, "add"));
console.log(simpleCalculator(15, 5, "subtract"));