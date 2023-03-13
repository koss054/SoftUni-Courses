function phoneBook(infoArr) {
  let phoneBook = {};

  for (const entry of infoArr) {
    let pair = entry.split(" ");
    let name = pair[0];
    let phoneNum = pair[1];
    phoneBook[name] = phoneNum;
  }

  for (const key in phoneBook) {
    console.log(`${key} -> ${phoneBook[key]}`);
  }
}

phoneBook([
  "Tim 0834212554",
  "Peter 0877547887",
  "Bill 0896543112",
  "Tim 0876566344",
]);
