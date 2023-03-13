function getStoreProvisions(stockArray, orderedArray) {
  let provisions = {};

  populateProvisions(stockArray);
  populateProvisions(orderedArray);

  let entries = Object.entries(provisions);

  for (const [key, value] of entries) {
    console.log(`${key} -> ${value}`);
  }

  function populateProvisions(array) {
    for (let i = 0; i < array.length - 1; i += 2) {
      const stockName = array[i];
      const stockQuantity = array[i + 1];

      if (provisions.hasOwnProperty(stockName)) {
        provisions[stockName] += Number(stockQuantity);
      } else {
        provisions[stockName] = Number(stockQuantity);
      }
    }
  }
}

getStoreProvisions(
  ["Chips", "5", "CocaCola", "9", "Bananas", "14", "Pasta", "4", "Beer", "2"],
  ["Flour", "44", "Oil", "12", "Pasta", "7", "Tomatoes", "70", "Bananas", "30"]
);
