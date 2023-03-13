function getEmployeesPersonalNumbers(employeesArray) {
  let employees = {};

  for (const entry of employeesArray) {
    const employeeName = entry.toString();
    const personalNumber = employeeName.length;
    employees[employeeName] = personalNumber;
  }

  for (const key in employees) {
    console.log(`Name: ${key} -- Personal Number: ${employees[key]}`);
  }
}

getEmployeesPersonalNumbers([
  "Silas Butler",
  "Adnaan Buckley",
  "Juan Peterson",
  "Brendan Villarreal",
]);
