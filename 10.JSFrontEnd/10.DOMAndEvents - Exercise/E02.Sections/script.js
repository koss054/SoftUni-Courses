function create(words) {
  const contentElement = document.getElementById("content");

  for (const word of words) {
    let divElement = document.createElement("div");
    divElement.addEventListener("click", reveal);

    let paragraphElement = document.createElement("p");
    paragraphElement.textContent = word;
    paragraphElement.style.display = "none";

    divElement.appendChild(paragraphElement);
    contentElement.appendChild(divElement);
  }

  function reveal(e) {
    let paragraph = e.currentTarget.querySelector("p");
    paragraph.style.display = "block";
  }
}
