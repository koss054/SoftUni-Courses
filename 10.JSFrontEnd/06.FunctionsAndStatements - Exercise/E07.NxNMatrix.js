function printMatrix(num) {
    for (let i = 0; i < num; i++) {
        let currLine = "";

        for (let j = 0; j < num; j++) {
            currLine += `${num} `;
        }

        console.log(currLine);
    }
}

printMatrix(5);