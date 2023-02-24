function calculate(firstNum, secondNum, operator) {
    // Avoid using eval, as it poses a security risk.
    var array = [firstNum, operator, secondNum];
    var result = eval(array.join(' '));
    return result;
}