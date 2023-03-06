function pascalSplit(str) {
    let currWord = "";
    let result = [];

    for (let i = 0; i < str.length; i++) {
        if (str[i] === str[i].toUpperCase() && i > 0) {
            result.push(currWord);
            currWord = "";
        }

        currWord += str[i];
    }

    result.push(currWord);
    console.log(result.join(", "));
}

pascalSplit('SplitMeIfYouCanHaHaYouCantOrYouCan');
pascalSplit('HoldTheDoor');
pascalSplit('ThisIsSoAnnoyingToDo');