function trackWords(input) {
  let splitInput = input.toString().split(",");
  let wordsToTrack = splitInput.shift().split(" ");
  let wordOccurrence = {};

  for (const word of wordsToTrack) {
    wordOccurrence[word] = 0;
  }

  for (const word of splitInput) {
    if (wordOccurrence.hasOwnProperty(word)) {
      wordOccurrence[word]++;
    }
  }

  let sortable = [];
  for (const word in wordOccurrence) {
    sortable.push([word, wordOccurrence[word]]);
  }

  sortable.sort((a, b) => b[1] - a[1]);
  for (const [key, value] of sortable) {
    console.log(`${key} - ${value}`);
  }
}

trackWords([
  "this sentence",
  "In",
  "this",
  "sentence",
  "you",
  "have",
  "to",
  "count",
  "the",
  "occurrences",
  "of",
  "the",
  "words",
  "this",
  "and",
  "sentence",
  "because",
  "this",
  "is",
  "your",
  "task",
]);

trackWords([
  "is the",
  "first",
  "sentence",
  "Here",
  "is",
  "another",
  "the",
  "And",
  "finally",
  "the",
  "the",
  "sentence",
]);
