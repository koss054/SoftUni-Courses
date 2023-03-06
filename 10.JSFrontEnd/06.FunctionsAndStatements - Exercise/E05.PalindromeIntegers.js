function areIntsPalindrome(array) {
    for (let i = 0; i < array.length; i++) {
        let currNumString = array[i].toString();
        let reversedCurrNumString = currNumString.split('').reverse().join('');

        console.log(currNumString === reversedCurrNumString);
    }
}

areIntsPalindrome([123, 323, 421, 121, 32, 232, 1010]);