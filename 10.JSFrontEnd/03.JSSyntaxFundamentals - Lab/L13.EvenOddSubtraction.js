function calculate(arr) {
    let evenSum = 0;
    let oddSum = 0;
    let result = 0;

    for (let i = 0; i < arr.length; i++) {
        if (arr[i] % 2 == 0) {
            evenSum += parseInt(arr[i]);
        } else {
            oddSum += parseInt(arr[i]);
        }
    }

    result = evenSum - oddSum;
    console.log(result);
}

calculate([1, 2, 3, 4, 5, 6]);
calculate([3, 5, 7, 9]);