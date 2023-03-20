function focused() {
  const inputs = document.querySelectorAll("div div input");
  for (const input of inputs) {
    input.addEventListener("focus", inputFocused);
    input.addEventListener("blur", inputUnfocused);
  }

  function inputFocused(e) {
    e.currentTarget.parentNode.classList.add("focused");
  }

  function inputUnfocused(e) {
    e.currentTarget.parentNode.classList.remove("focused");
  }
}
