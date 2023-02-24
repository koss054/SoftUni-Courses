function printElement(arr, step) {
    let returnedArr = [];
    let currentStep = step;

    for (let i = 0; i < arr.length; i++) {
        if (currentStep == step) {
            currentStep = 0;
            returnedArr.push(arr[i]);
        }

        currentStep++;
    }

    return returnedArr;
}