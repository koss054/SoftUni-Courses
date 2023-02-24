function reverseArray(count, array) {
    let shortArray = [];
    let reversedArray = "";

    for (let i = 0; i < count; i++) shortArray.push(array[i]);
    for (let i = shortArray.length - 1; i >= 0; i--) reversedArray += shortArray[i] + " ";

    console.log(reversedArray);
}

reverseArray(3, [10, 20, 30, 40, 50]);