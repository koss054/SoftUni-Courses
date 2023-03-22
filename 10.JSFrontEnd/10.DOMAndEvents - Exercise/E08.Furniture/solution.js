function solve() {
  const [generateTextArea, buyTextArea] = Array.from(
    document.getElementsByTagName("textarea")
  );

  const [generateBtn, buyBtn] = Array.from(
    document.getElementsByTagName("button")
  );

  const tbody = document.querySelector(".table > tbody");

  generateBtn.addEventListener("click", generate);
  buyBtn.addEventListener("click", buy);

  function generate() {
    const data = JSON.parse(generateTextArea.value);

    for (const { img, name, price, decFactor } of data) {
      const tr = createElement("tr", tbody);

      const firstTd = createElement("td", tr);
      const imgTd = createElement("img", firstTd, "", { src: img });

      const secondTd = createElement("td", tr);
      const nameTd = createElement("span", secondTd, name);

      const thirdTd = createElement("td", tr);
      const priceTd = createElement("span", thirdTd, price);

      const fourthTd = createElement("td", tr);
      const decFactorTd = createElement("span", fourthTd, decFactor);

      const fifthTd = createElement("td", tr);
      const markTd = createElement("input", fifthTd, "", { type: "checkbox" });

      tbody.appendChild(tr);
    }
  }

  function buy(e) {
    const tableRows = Array.from(tbody.querySelectorAll("tr"));
    let furnitureNames = [];
    let totalPrice = 0;
    let totalDecFactor = 0;

    for (const tableRow of tableRows) {
      const tableData = Array.from(tableRow.children);
      const checkbox = tableData[4].firstChild;

      if (checkbox.checked) {
        const furnitureName = tableData[1].firstChild.textContent;
        const furniturePrice = Number(tableData[2].firstChild.textContent);
        const furnitureDecFactor = Number(tableData[3].firstChild.textContent);

        furnitureNames.push(furnitureName);
        totalPrice += furniturePrice;
        totalDecFactor += furnitureDecFactor;
      }
    }

    const averageDecFactor = totalDecFactor / furnitureNames.length;

    buyTextArea.value = `Bought furniture: ${furnitureNames.join(", ")}\n`;
    buyTextArea.value += `Total price: ${totalPrice.toFixed(2)}\n`;
    buyTextArea.value += `Average decoration factor: ${averageDecFactor}`;
  }

  function createElement(type, parentNode, content, attributes) {
    const htmlElement = document.createElement(type);

    if (content && type !== "input") {
      htmlElement.textContent = content;
    } else if (content && type === "input") {
      htmlElement.value = content;
    }

    if (parentNode) {
      parentNode.appendChild(htmlElement);
    }

    if (attributes) {
      for (const key in attributes) {
        htmlElement.setAttribute(key, attributes[key]);
      }
    }

    return htmlElement;
  }
}
