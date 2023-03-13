function getOddOccuringWords(input) {
  let occuringWords = {};
  let splitInput = input.toLowerCase().split(" ");

  for (const word of splitInput) {
    if (occuringWords[word]) {
      occuringWords[word]++;
    } else {
      occuringWords[word] = 1;
    }
  }

  let oddOccuringWords = [];
  const entries = Object.entries(occuringWords);
  for (const [key, value] of entries) {
    if (value % 2 !== 0) {
      oddOccuringWords.push(key);
    }
  }

  console.log(oddOccuringWords.join(" "));
}

getOddOccuringWords("Java C# Php PHP Java PhP 3 C# 3 1 5 C#");
getOddOccuringWords("Cake IS SWEET is Soft CAKE sweet Food");
