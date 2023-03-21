function lockedProfile() {
  const buttons = document.querySelectorAll("button");

  for (const button of buttons) {
    button.addEventListener("click", toggleInfo);
  }

  function toggleInfo(e) {
    const button = e.currentTarget;
    const divParent = button.parentNode;
    const divChildren = Array.from(divParent.children);
    const unlockRadio = divChildren[4];
    const extraInformation = divChildren[9];

    if (unlockRadio.checked) {
      if (button.textContent === "Show more") {
        button.textContent = "Hide it";
        extraInformation.style.display = "block";
      } else {
        button.textContent = "Show more";
        extraInformation.style.display = "none";
      }
    }
  }
}
