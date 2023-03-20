function deleteByEmail() {
  const emailToDelete = document.querySelector("input").value;
  const resultDiv = document.getElementById("result");
  const emailsInTable = Array.from(
    document.querySelectorAll("td:nth-child(even)")
  );

  const foundElement = emailsInTable.find(
    (x) => x.textContent === emailToDelete
  );

  if (foundElement) {
    foundElement.parentElement.remove();
    resultDiv.textContent = "Deleted";
  } else {
    resultDiv.textContent = "Not found.";
  }
}
