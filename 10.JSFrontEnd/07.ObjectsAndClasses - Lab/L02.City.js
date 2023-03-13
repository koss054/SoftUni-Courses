function cityInfo(city) {
  const info = Object.entries(city);

  for (const [key, value] of info) {
    console.log(`${key} -> ${value}`);
  }
}

cityInfo({
  name: "Sofia",
  area: 492,
  population: 1238438,
  country: "Bulgaria",
  postCode: "1000",
});
