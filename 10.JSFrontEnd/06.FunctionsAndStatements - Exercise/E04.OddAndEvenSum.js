function oddEvenSum(number) {
    const numberString = number.toString();
    let evenSum = 0;
    let oddSum = 0;

    for (let i = 0; i < numberString.length; i++) {
        if (numberString[i] % 2 === 0) {
            evenSum += Number(numberString[i]);
        } else {
            oddSum += Number(numberString[i]);
        }
    }

    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}

oddEvenSum(1000435);