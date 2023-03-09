function checkForPerfectNumber(number) {
  let sum = 0;

  for (let i = 1; i < number; i++) {
    if (number % i === 0) {
      sum += i;
    }
  }

  return sum === number ? "We have a perfect number!" : "It's not so perfect.";
}

console.log(checkForPerfectNumber(6));
console.log(checkForPerfectNumber(28));
console.log(checkForPerfectNumber(1236498));
