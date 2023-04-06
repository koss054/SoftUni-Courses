function shoppingList(input) {
    const initialProducts = input.shift().split("!");
    let productsInList = {};
    let highestOrder = 0;
    const commandParser = {
        Urgent: urgent,
        Unnecessary: unnecessary,
        Correct: correct,
        Rearrange: rearrange,
    };

    for (let i = 0; i < initialProducts.length; i++) {
        const product = initialProducts[i];
        highestOrder = i + 1;
        productsInList[product] = highestOrder;
    }

    for (const inputLine of input) {
        if (inputLine === "Go Shopping!") {
            printSortedProducts();
            return;
        }

        const splitLine = inputLine.split(" ");
        const command = splitLine[0];
        commandParser[command](...splitLine.splice(1));
    }

    function urgent(item) {
        if (!productsInList.hasOwnProperty(item)) {
            productsInList[item] = 1;
            increaseAllProductOrder();
        }
    }

    function unnecessary(item) {
        if (productsInList.hasOwnProperty(item)) {
            delete productsInList[item];
        }
    }

    function correct(oldItem, newItem) {
        if (productsInList.hasOwnProperty(oldItem)) {
            productsInList[newItem] = productsInList[oldItem];
            delete productsInList[oldItem];
        }
    }

    function rearrange(item) {
        if (productsInList.hasOwnProperty(item)) {
            highestOrder++;
            delete productsInList[item];
            productsInList[item] = highestOrder;
        }
    }

    function increaseAllProductOrder() {
        highestOrder++;
        for (const product in productsInList) {
            productsInList[product] += 1;
        }
    }

    function printSortedProducts() {
        let sortable = [];
        let onlyProductsArray = [];
        for (const product in productsInList) {
            sortable.push([product, productsInList[product]]);
        }

        sortable.sort((a, b) => a[1] - b[1]);
        for (const [product, order] of sortable) {
            onlyProductsArray.push(product);
        }

        console.log(onlyProductsArray.join(", "));
    }

    function printFinalProducts(sortedArray) {
        let itemsInList = "";
        for (const [product, order] of sortedArray) {
            itemsInList += `${product} `;
        }
        return itemsInList.trimEnd();
    }
}

shoppingList([
    "Tomatoes!Potatoes!Bread",
    "Unnecessary Milk",
    "Urgent Tomatoes",
    "Go Shopping!",
]);

shoppingList([
    "Milk!Pepper!Salt!Water!Banana",
    "Urgent Salt",
    "Unnecessary Grapes",
    "Correct Pepper Onion",
    "Rearrange Grapes",
    "Correct Tomatoes Potatoes",
    "Go Shopping!",
]);
