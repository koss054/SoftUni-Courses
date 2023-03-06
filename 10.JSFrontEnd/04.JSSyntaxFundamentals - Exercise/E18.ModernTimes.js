function getSpecialWords(str) {
    let isSpecial = false;
    let specialWords = [];
    let currWord = "";

    for (let i = 0; i < str.length; i++) {
        if (isSpecial && !isNaN(parseInt(str[i]))) {
            isSpecial = false;
        }

        if (str[i] === " ") {
            if (currWord.length > 0) {
                specialWords.push(currWord);
                currWord = "";
            }

            isSpecial = false;
        }

        if (isSpecial) {
            currWord += str[i];
        }

        if (str[i] === "#") {
            isSpecial = true;
        }
    }

    if (currWord.length > 0) {
        specialWords.push(currWord);
    }

    console.log(specialWords.join("\n"));
}

getSpecialWords('Nowadays everyone uses # to tag a #special word in #socialMedia')