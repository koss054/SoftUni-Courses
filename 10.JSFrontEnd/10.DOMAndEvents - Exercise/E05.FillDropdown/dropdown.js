function addItem() {
  const selectElement = document.getElementById("menu");
  const textElement = document.getElementById("newItemText");
  const valueElement = document.getElementById("newItemValue");

  let optionElement = document.createElement("option");
  optionElement.textContent = textElement.value;
  optionElement.value = valueElement.value;

  textElement.value = "";
  valueElement.value = "";
  selectElement.appendChild(optionElement);
}
