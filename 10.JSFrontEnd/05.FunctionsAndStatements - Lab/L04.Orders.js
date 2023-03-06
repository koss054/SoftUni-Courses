function getOrderTotal(item, quantity) {
    let itemPrice = {
        coffee: 1.50,
        water: 1.00,
        coke: 1.40,
        snacks: 2.00,
    };

    return (itemPrice[item] * quantity).toFixed(2);
}

console.log(getOrderTotal("water", 5));
console.log(getOrderTotal("coffee", 2));