function getGrade(grade) {
    if (grade < 3) {
        console.log("Fail (2)");
    } else if (grade >= 3.00 && grade < 3.50) {
        console.log(`Poor (${formatGrade(grade)})`);
    } else if (grade >= 3.50 && grade < 4.50) {
        console.log(`Good (${formatGrade(grade)})`)
    } else if (grade >= 4.50 && grade < 5.50) {
        console.log(`Very good (${formatGrade(grade)})`);
    } else {
        console.log(`Excellent (${formatGrade(grade)})`);
    }

    function formatGrade(grade) {
        return grade.toFixed(2);
    }
}

getGrade(4.50);