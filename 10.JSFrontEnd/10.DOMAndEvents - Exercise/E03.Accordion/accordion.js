function toggle() {
  const button = document.querySelector(".head .button");
  const extraText = document.getElementById("extra");

  const buttonAction = button.textContent;
  swapButtonText(buttonAction);
  toggleExtraText(buttonAction);

  function swapButtonText(text) {
    const buttonText = text === "More" ? "Less" : "More";
    button.textContent = buttonText;
  }

  function toggleExtraText(action) {
    action === "More"
      ? (extraText.style.display = "block")
      : (extraText.style.display = "none");
  }
}
