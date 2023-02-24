function sortNumbers(arr) {
    let sortedArr = [];

    while (arr.length > 0) {
        let currSmallest = arr[0];
        let currLargest = arr[0];

        for (let i = 0; i < arr.length; i++) {
            if (arr[i] < currSmallest) currSmallest = arr[i];
        }

        sortedArr.push(currSmallest);
        arr = removeNum(currSmallest, arr);

        if (arr.length == 0) return sortedArr;

        for (let i = 0; i < arr.length; i++) {
            if (arr[i] > currLargest) currLargest = arr[i];
        }

        sortedArr.push(currLargest);
        arr = removeNum(currLargest, arr);
    }

    return sortedArr;

    function removeNum(numToRemove, fromArr) {
        let index = fromArr.indexOf(numToRemove);
        fromArr.splice(index, 1);
        return fromArr;
    }
}