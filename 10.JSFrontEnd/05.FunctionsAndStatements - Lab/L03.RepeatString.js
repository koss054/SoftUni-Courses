function repeatString(str, repeatCount) {
    let strToReturn = "";

    for (let i = 0; i < repeatCount; i++) {
        strToReturn += str;
    }

    console.log(strToReturn);
}

repeatString("abc", 3);
repeatString("String", 2);