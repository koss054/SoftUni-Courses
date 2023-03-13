function convertToObject(jsonString) {
  let person = JSON.parse(jsonString);
  let personInfo = Object.entries(person);

  for (const [key, value] of personInfo) {
    console.log(`${key}: ${value}`);
  }
}

convertToObject('{"name": "George", "age": 40, "town": "Sofia"}');
