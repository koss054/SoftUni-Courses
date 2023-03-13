class Vehicle {
  constructor(type, model, parts, fuel) {
    this.type = type;
    this.model = model;
    this.parts = {
      engine: Number(parts.engine),
      power: Number(parts.power),
      quality: Number(parts.engine * parts.power),
    };
    this.fuel = Number(fuel);
  }

  drive(fuelLoss) {
    this.fuel -= fuelLoss;
  }
}

function firstTest() {
  console.log("First Test");
  let parts = { engine: 6, power: 100 };
  let vehicle = new Vehicle("a", "b", parts, 200);
  vehicle.drive(100);
  console.log(vehicle.fuel);
  console.log(vehicle.parts.quality);
  console.log("----------------------");
}

function secondTest() {
  console.log("Second Test");
  let parts = { engine: 9, power: 500 };
  let vehicle = new Vehicle("l", "k", parts, 840);
  vehicle.drive(20);
  console.log(vehicle.fuel);
}

firstTest();
secondTest();
