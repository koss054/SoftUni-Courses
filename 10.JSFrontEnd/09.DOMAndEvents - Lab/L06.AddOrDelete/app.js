function addItem() {
  const ulElement = document.getElementById("items");
  const input = document.getElementById("newItemText").value;

  const newLiElement = document.createElement("li");
  newLiElement.textContent = input;

  const newAnchorElement = document.createElement("a");
  newAnchorElement.href = "#";
  newAnchorElement.textContent = "[Delete]";
  newAnchorElement.addEventListener("click", deleteRow);

  newLiElement.appendChild(newAnchorElement);
  ulElement.appendChild(newLiElement);

  function deleteRow(e) {
    e.currentTarget.parentElement.remove();
  }
}
