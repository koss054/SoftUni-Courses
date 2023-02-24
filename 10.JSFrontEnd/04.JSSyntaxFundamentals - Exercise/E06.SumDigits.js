function sumDigits(num) {
    let numString = num.toString();
    let sum = 0;

    for (let i = 0; i < numString.length; i++) {
        sum += parseInt(numString[i]);
    }

    console.log(sum);
}