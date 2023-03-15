function createDictionary(jsonInput) {
  let dictionary = {};

  for (const item of jsonInput) {
    const parsedItem = JSON.parse(item);
    const itemEntries = Object.entries(parsedItem);
    itemEntries.forEach((x) => {
      const term = x[0];
      const definition = x[1];
      dictionary[term] = definition;
    });
  }

  const sortedDictionary = Object.entries(dictionary).sort();
  sortedDictionary.forEach((x) =>
    console.log(`Term: ${x[0]} => Definition: ${x[1]}`)
  );
}

createDictionary([
  '{"Coffee":"A hot drink made from the roasted and ground seeds (coffee beans) of a tropical shrub."}',
  '{"Bus":"A large motor vehicle carrying passengers by road, typically one serving the public on a fixed route and for a fare."}',
  '{"Boiler":"A fuel-burning apparatus or container for heating water."}',
  '{"Tape":"A narrow strip of material, typically used to hold or fasten something."}',
  '{"Microphone":"An instrument for converting sound waves into electrical energy variations which may then be amplified, transmitted, or recorded."}',
]);
