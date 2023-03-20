function subtract() {
  const firstNumber = Number(document.getElementById("firstNumber").value);
  const secondNumber = Number(document.getElementById("secondNumber").value);
  const sum = firstNumber - secondNumber;

  const resultElement = document.getElementById("result");
  resultElement.textContent = sum;
}
