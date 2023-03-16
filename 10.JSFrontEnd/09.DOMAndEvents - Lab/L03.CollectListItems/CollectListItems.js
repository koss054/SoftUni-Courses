function extractText() {
  const ulElement = document.getElementById("items").getElementsByTagName("li");
  const resultElement = document.getElementById("result");

  for (let i = 0; i < ulElement.length; i++) {
    resultElement.value += ulElement[i].innerHTML + "\n";
  }
}
