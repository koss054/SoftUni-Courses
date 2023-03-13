function getHeroInformation(heroesArray) {
  class Hero {
    constructor(name, level, items) {
      this.name = name;
      this.level = level;
      this.items = items;
    }

    getName() {
      return `Hero: ${this.name}`;
    }

    getLevel() {
      return `level => ${this.level}`;
    }

    getItems() {
      return `items => ${this.items.join(",")}`;
    }

    getInfo() {
      console.log(this.getName());
      console.log(this.getLevel());
      console.log(this.getItems());
    }
  }

  let heroes = [];

  for (const entry of heroesArray) {
    const [name, level, items] = entry.split(" / ");
    const itemArray = items.split(",");
    heroes.push(new Hero(name, level, itemArray));
  }

  const sortedHeroes = heroes.sort((a, b) => a.level - b.level);

  for (const hero of sortedHeroes) {
    hero.getInfo();
  }
}

getHeroInformation([
  "Isacc / 25 / Apple, GravityGun",
  "Derek / 12 / BarrelVest, DestructionSword",
  "Hes / 1 / Desolator, Sentinel, Antara",
]);

getHeroInformation([
  "Batman / 2 / Banana, Gun",
  "Superman / 18 / Sword",
  "Poppy / 28 / Sentinel, Antara",
]);
