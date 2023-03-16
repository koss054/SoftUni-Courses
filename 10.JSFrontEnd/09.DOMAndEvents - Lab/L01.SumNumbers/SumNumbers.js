function calc() {
  const firstNumber = document.getElementById("num1").value;
  const secondNumber = document.getElementById("num2").value;
  const sum = Number(firstNumber) + Number(secondNumber);

  document.getElementById("sum").value = sum;
}
