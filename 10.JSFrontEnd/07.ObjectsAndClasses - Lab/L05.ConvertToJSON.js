function convertToJson(firstName, lastName, hairColor) {
  let person = {
    name: firstName,
    lastName,
    hairColor,
  };

  console.log(JSON.stringify(person));
}

convertToJson("John", "Smith", "Brown");
