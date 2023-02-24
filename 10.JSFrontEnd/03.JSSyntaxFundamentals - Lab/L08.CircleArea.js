function getCircleArea(arg) {
    let argType = typeof(arg);

    if (argType == "number") {
        let result = arg * arg * Math.PI;
        console.log(`${result.toFixed(2)}`);
    } else {
        console.log(`We can not calculate the circle area, because we receive a ${argType}.`);
    }
}

getCircleArea(5);
getCircleArea('name');