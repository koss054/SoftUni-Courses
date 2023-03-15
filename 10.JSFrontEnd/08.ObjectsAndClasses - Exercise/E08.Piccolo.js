function getCarsInParking(input) {
  let parkedCarNums = [];

  for (const line of input) {
    const [action, carNumber] = line.split(", ");

    if (action === "IN" && !parkedCarNums.includes(carNumber)) {
      parkedCarNums.push(carNumber);
    } else if (action === "OUT" && parkedCarNums.includes(carNumber)) {
      const currIndex = parkedCarNums.indexOf(carNumber);
      parkedCarNums.splice(currIndex, 1);
    }
  }

  if (parkedCarNums.length > 0) {
    parkedCarNums
      .sort((a, b) => a.localeCompare(b))
      .forEach((parkedCarNum) => console.log(parkedCarNum));
  } else {
    console.log("Parking Lot is Empty");
  }
}

getCarsInParking([
  "IN, CA2844AA",
  "IN, CA1234TA",
  "OUT, CA2844AA",
  "IN, CA9999TT",
  "IN, CA2866HI",
  "OUT, CA1234TA",
  "IN, CA2844AA",
  "OUT, CA2866HI",
  "IN, CA9876HH",
  "IN, CA2822UU",
]);

getCarsInParking([
  "IN, CA2844AA",
  "IN, CA1234TA",
  "OUT, CA2844AA",
  "OUT, CA1234TA",
]);
