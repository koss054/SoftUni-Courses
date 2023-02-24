function rotateArray(arr, rotations) {
    let arrString = "";

    for (let j = 0; j < rotations; j++) {
        let firstNum = arr[0];
        for (let i = 0; i < arr.length; i++) {
            if (i == arr.length - 1) arr[i] = firstNum;
            else arr[i] = arr[i + 1];
        }
    }

    for (let i = 0; i < arr.length; i++) {
        arrString += arr[i] + " ";
    }

    console.log(arrString);
}