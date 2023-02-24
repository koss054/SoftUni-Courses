function listNamesAsc(nameArr) {
    let sortedNameArr = nameArr.sort();

    for (let i = 0; i < sortedNameArr.length; i++) {
        console.log(`${i + 1}.${sortedNameArr[i]}`);
    }
}