function colorize() {
  const rowsToColorize = document.querySelectorAll("table tr:nth-child(even)");
  for (const row of rowsToColorize) {
    row.style.backgroundColor = "teal";
  }
}
