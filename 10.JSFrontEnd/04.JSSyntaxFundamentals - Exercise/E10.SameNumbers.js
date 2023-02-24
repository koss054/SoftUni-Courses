function areNumsSame(num) {
    let numString = num.toString();
    let firstNum = numString[0];
    let areSame = true;
    let sum = 0;

    for (let i = 0; i < numString.length; i++) {
        if (numString[i] != firstNum) areSame = false;
        sum += parseInt(numString[i]);
    }

    console.log(areSame);
    console.log(sum);
}