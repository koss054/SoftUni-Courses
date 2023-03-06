function wordInString(word, str) {
    const isWordIncluded = 
        str.toLowerCase().split(" ").includes(word.toLowerCase());

    if (isWordIncluded) {
        console.log(word);
    } else {
        console.log(`${word} not found!`);
    }
}

wordInString(
    'javascript',
    'JavaScript is the best programming language'
)

wordInString(
    'python',
    'JavaScript is the best programming language'
)