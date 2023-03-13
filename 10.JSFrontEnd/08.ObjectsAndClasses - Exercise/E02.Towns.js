function getTownObjects(townsArray) {
  let towns = [];

  for (const entry of townsArray) {
    const [town, latitude, longitude] = entry.split(" | ");
    const townObject = {
      town,
      latitude: Number(latitude).toFixed(2),
      longitude: Number(longitude).toFixed(2),
    };

    towns.push(townObject);
  }

  for (const town of towns) {
    console.log(town);
  }
}

getTownObjects([
  "Sofia | 42.696552 | 23.32601",
  "Beijing | 39.913818 | 116.363625",
]);
