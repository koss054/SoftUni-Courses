function gatos(catArray) {
  class Cat {
    constructor(catName, age) {
      this.catName = catName;
      this.age = age;
    }

    meow() {
      console.log(`${this.catName}, age ${this.age} says Meow`);
    }
  }

  let cats = [];

  for (const cat of catArray) {
    const [name, age] = cat.split(" ");
    cats.push(new Cat(name, age));
  }

  for (const cat of cats) {
    cat.meow();
  }
}

gatos(["Mellow 2", "Tom 5"]);
