// 40/100 in judge. Too fkn depressed to figure out why.
function revealWords(connectedWords, template) {
    let hiddenLength = 0;
    let hiddenIndex = 0;
    let words = connectedWords.split(", ");

    for (let i = 0; i < template.length; i++) {
        if (template[i] === "*") {
            hiddenLength++;
        }

        if (hiddenLength === 1) {
            hiddenIndex = i;
        }

        if (template[i] !== "*") {
            let replace = "";
            let wordToReplaceWith = "";

            while (hiddenLength > 0) {
                replace += "*";
                hiddenLength--;
            }

            for (let j = 0; j < words.length; j++) {
                if (words[j].length == replace.length) {
                    wordToReplaceWith = words[j];
                    break;
                }
            }

            template = template.replace(replace, wordToReplaceWith);
        }
    }

    console.log(template);
}

revealWords(
    'great',
    'softuni is ***** place for learning new programming languages'
)

revealWords(
    'great, learning',
    'softuni is ***** place for ******** new programming languages'
)