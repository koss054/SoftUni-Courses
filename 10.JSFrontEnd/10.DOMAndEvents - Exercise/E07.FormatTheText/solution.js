function solve() {
  const textField = document.getElementById("input");
  const output = document.getElementById("output");
  const sentances = textField.value.split(".");

  let count = 0;
  let pElement;

  for (const sentance of sentances) {
    if (sentance.length > 0) {
      let currentSentence = sentance.trim() + ".";

      if (count === 0) {
        pElement = document.createElement("p");
      }

      pElement.textContent += currentSentence;
      count++;

      if (count === 3) {
        count = 0;
        output.appendChild(pElement);
      }
    }
  }

  if (count > 0) {
    output.appendChild(pElement);
  }
}
