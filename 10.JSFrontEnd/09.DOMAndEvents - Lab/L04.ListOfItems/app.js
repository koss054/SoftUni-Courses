function addItem() {
  const ulElement = document.getElementById("items");
  const itemToAdd = document.getElementById("newItemText").value;

  let li = document.createElement("li");
  li.appendChild(document.createTextNode(itemToAdd));
  ulElement.appendChild(li);
}
