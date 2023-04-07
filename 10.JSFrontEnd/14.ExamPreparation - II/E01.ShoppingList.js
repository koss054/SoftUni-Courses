function shoppingList(input) {
    class Product {
        constructor(name, order) {
            this.name = name;
            this.order = order;
        }

        getName() {
            return this.name;
        }

        changeName(newName) {
            this.name = newName;
        }

        changeOrder(newOrder) {
            this.order = newOrder;
        }

        increaseOrder() {
            this.order++;
        }

        reduceOrder() {
            this.order--;
        }

        getNameWithMatchingOrder(order) {
            if (this.order === order) {
                return this.name;
            } else {
                return "";
            }
        }
    }

    const commandParser = {
        Urgent: urgent,
        Unnecessary: unnecessary,
        Correct: correct,
        Rearrange: rearrange,
    };

    const increaseCommandKeyword = "increase";
    const reduceCommandKeyword = "reduce";
    const startIndex = 0;
    let highestOrder = startIndex;
    let productCollection = [];
    const initialProducts = input.shift().split("!");
    for (const product of initialProducts) {
        productCollection.push(new Product(product, highestOrder));
        highestOrder++;
    }

    for (const line of input) {
        if (line === "Go Shopping!") {
            printCollection();
            return;
        }

        const tokens = line.split(" ");
        const command = tokens[0];
        commandParser[command](...tokens.slice(1));
    }

    // Functions used throughout the task.
    function urgent(productName) {
        const isItemInList = isProductAlreadyInList(productName);
        if (!isItemInList) {
            loopCollectionWithCommand(increaseCommandKeyword, 0);
            productCollection.unshift(new Product(productName, startIndex));
            highestOrder++;
        }
    }

    function unnecessary(productName) {
        const isItemInList = isProductAlreadyInList(productName);
        if (isItemInList) {
            const productIndex = getProductIndex(productName);
            loopCollectionWithCommand(reduceCommandKeyword, productIndex);
            productCollection.splice(productIndex, 1);
            highestOrder--;
        }
    }

    function correct(oldProductName, newProductName) {
        const isItemInList = isProductAlreadyInList(oldProductName);
        if (isItemInList) {
            const productIndex = getProductIndex(oldProductName);
            productCollection[productIndex].changeName(newProductName);
        }
    }

    function rearrange(productName) {
        const isItemInList = isProductAlreadyInList(productName);
        if (isItemInList) {
            const productIndex = getProductIndex(productName);
            loopCollectionWithCommand(reduceCommandKeyword, productIndex);
            productCollection.splice(productIndex, 1);
            productCollection.push(new Product(productName, highestOrder));
        }
    }

    function isProductAlreadyInList(productName) {
        for (const product of productCollection) {
            if (productName === product.getName()) {
                return true;
            }
        }

        return false;
    }

    function getProductIndex(productName) {
        for (let i = 0; i < productCollection.length; i++) {
            if (productCollection[i].getName() === productName) {
                return i;
            }
        }
    }

    function loopCollectionWithCommand(command, startIndex) {
        switch (command) {
            case increaseCommandKeyword:
                for (let i = startIndex; i < productCollection.length; i++) {
                    productCollection[i].increaseOrder();
                }
                break;
            case reduceCommandKeyword:
                for (let i = startIndex; i < productCollection.length; i++) {
                    productCollection[i].reduceOrder();
                }
                break;
        }
    }

    function printCollection() {
        let productNameArray = [];
        let currentIndex = 0;

        while (productCollection.length > 0) {
            const currentProduct = productCollection[currentIndex];
            const productName =
                currentProduct.getNameWithMatchingOrder(currentIndex);

            if (productName !== "") {
                productCollection.splice(currentIndex, 1);
                loopCollectionWithCommand(reduceCommandKeyword, startIndex);
                productNameArray.push(productName);
                currentIndex = 0;
            } else {
                currentIndex++;
            }
        }

        console.log(productNameArray.join(", "));
    }
}

// shoppingList([
//     "Tomatoes!Potatoes!Bread",
//     "Unnecessary Milk",
//     "Urgent Tomatoes",
//     "Go Shopping!",
// ]);

shoppingList([
    "Pepper!Water!Milk!Banana",
    "Urgent Salt",
    "Unnecessary Grapes",
    "Correct Pepper Onion",
    "Rearrange Grapes",
    "Correct Tomatoes Potatoes",
    "Go Shopping!",
]);

// function testPrint(collectionToPrint) {
//     const isCollectionArray =
//         Object.prototype.toString.call(collectionToPrint) == "[object Array]";

//     if (isCollectionArray) {
//         console.log("is array");
//         for (const item of collectionToPrint) {
//             console.log(item);
//         }
//     } else {
//         console.log("is object");
//         for (const item in collectionToPrint) {
//             console.log(collectionToPrint[item]);
//         }
//     }
// }
