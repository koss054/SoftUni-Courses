function factorialDivision(numOne, numTwo) {
  const numOneFactorial = getFactorial(numOne);
  const numTwoFactorial = getFactorial(numTwo);

  function getFactorial(number) {
    if (number === 1) {
      return number;
    }

    return number * getFactorial(number - 1);
  }

  return (numOneFactorial / numTwoFactorial).toFixed(2);
}

console.log(factorialDivision(5, 2));
