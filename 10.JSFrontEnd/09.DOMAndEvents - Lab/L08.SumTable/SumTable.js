function sumTable() {
  const sumElement = document.getElementById("sum");
  const tableElement = document.querySelector("table");
  const tableRowElements = tableElement.querySelectorAll(
    "tbody tr td:last-of-type"
  );

  let sum = 0;
  for (let i = 0; i < tableRowElements.length - 1; i++) {
    sum += Number(tableRowElements[i].textContent);
  }

  sumElement.textContent = sum;
}
