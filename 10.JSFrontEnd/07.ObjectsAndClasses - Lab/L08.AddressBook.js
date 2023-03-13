function createAddressBook(entries) {
  let addressBook = {};

  for (const entry of entries) {
    const [name, address] = entry.split(":");
    addressBook[name] = address;
  }

  const sortedAddressBook = Object.entries(addressBook);
  sortedAddressBook.sort((a, b) => a[0].localeCompare(b[0]));

  for (const [key, value] of sortedAddressBook) {
    console.log(`${key} -> ${value}`);
  }
}

createAddressBook([
  "Tim:Doe Crossing",
  "Bill:Nelson Place",
  "Peter:Carlyle Ave",
  "Bill:Ornery Rd",
]);
