function charsInRange(charOne, charTwo) {
    const firstAscii = charOne.charCodeAt();
    const secondAscii = charTwo.charCodeAt();
    let asciiArray = [];

    if (firstAscii < secondAscii) {
        getCharsFromAscii(firstAscii, secondAscii);
    } else {
        getCharsFromAscii(secondAscii, firstAscii);
    }

    return asciiArray.join(" ");

    function getCharsFromAscii(asciiStart, asciiEnd) {
        for (let i = asciiStart + 1; i < asciiEnd; i++) {
            asciiArray.push(String.fromCharCode(i));
        }
    }
}

console.log(charsInRange("a", "d"));
console.log(charsInRange("#", ":"));
console.log(charsInRange("C", "#"));