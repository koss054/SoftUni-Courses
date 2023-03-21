function solve() {
  const searchedField = document.getElementById("searchField");
  document.querySelector("#searchBtn").addEventListener("click", onClick);

  function onClick() {
    let searchedWord = searchedField.value;
    const tableRows = Array.from(document.querySelectorAll("tbody tr"));

    for (const row of tableRows) {
      const trimmedText = row.textContent.trim();
      console.log(trimmedText);
      row.classList.remove("select");

      if (trimmedText.includes(searchedWord)) {
        row.classList.add("select");
      }
    }

    searchedField.value = "";
  }
}
