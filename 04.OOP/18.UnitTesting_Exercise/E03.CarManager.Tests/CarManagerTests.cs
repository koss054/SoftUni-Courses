namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class CarManagerTests
    {
        [TestCaseSource("TestCaseConstructorWithValidData")]
        public void Constructor_WithValidData_ShouldBeCreated(
            string make,
            string model,
            double fuelConsumption,
            double fuelCapacity,
            Car expectedCar)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(expectedCar.Make, car.Make);
        }

        [TestCaseSource("TestCaseConstructorWithInvalidData")]
        public void Constructor_WithInvalidData_ShouldThrow(
            string make,
            string model,
            double fuelConsumption,
            double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
        }

        [TestCaseSource("TestCaseRefuelWithValidData")]
        public void Refuel_WithValidData_ShouldFuelCar(
            string make,
            string model,
            double fuelConsumption,
            double fuelCapacity,
            double fuelToRefuel,
            double expectedFuelAmount)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(fuelToRefuel);

            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [TestCaseSource("TestCaseRefuelAboveFuelCapacityWithValidData")]
        public void Refuel_AboveFuelCapacity_WithValidData_ShouldFuelCar(
            string make,
            string model,
            double fuelConsumption,
            double fuelCapacity,
            double fuelToRefuel)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(fuelToRefuel);

            Assert.AreEqual(car.FuelCapacity, car.FuelAmount);
        }

        [TestCaseSource("TestCaseRefuelWithInvalidData")]
        public void Refuel_WithInvalidData_ShouldThrow(
            string make,
            string model,
            double fuelConsumption,
            double fuelCapacity,
            double fuelToRefuel)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(fuelToRefuel);
            });
        }

        [TestCaseSource("TestCaseDriveWithValidData")]
        public void Drive_WithValidData_ShouldReduceFuelAmount(
            string make,
            string model,
            double fuelConsumption,
            double fuelCapacity,
            double fuelToRefuel,
            double distance,
            double expectedFuelLeft)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(fuelToRefuel);
            car.Drive(distance);

            Assert.AreEqual(expectedFuelLeft, car.FuelAmount);
        }

        [TestCaseSource("TestCaseDriveWithNotEnoughFuelData")]
        public void Drive_WithNotEnoughFuel_ShouldThrow(
            string make,
            string model,
            double fuelConsumption,
            double fuelCapacity,
            double fuelToRefuel,
            double distance)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(fuelToRefuel);

            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(distance);
            });
        }

        public static IEnumerable<TestCaseData> TestCaseDriveWithNotEnoughFuelData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    "BMW",
                    "M3",
                    5,
                    50,
                    5,
                    1000
                    ),
                new TestCaseData(
                    "Mitsubishi",
                    "Lancer Evo 5",
                    5,
                    500,
                    100,
                    10000
                    ),
                new TestCaseData(
                    "Mitsubishi",
                    "Eclipse",
                    5,
                    10,
                    6,
                    2500
                    ),
                new TestCaseData(
                    "Subaru",
                    "Impreza",
                    10,
                    100,
                    1,
                    100
                    )
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseDriveWithValidData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    "BMW",
                    "M3",
                    5,
                    50,
                    5,
                    100,
                    0
                    ),
                new TestCaseData(
                    "Mitsubishi",
                    "Lancer Evo 5",
                    5,
                    500,
                    100,
                    1000,
                    50
                    ),
                new TestCaseData(
                    "Mitsubishi",
                    "Eclipse",
                    5,
                    10,
                    6,
                    0,
                    6
                    ),
                new TestCaseData(
                    "Subaru",
                    "Impreza",
                    10,
                    100,
                    100,
                    100,
                    90
                    )
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseRefuelWithInvalidData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    "BMW",
                    "M3",
                    5.6,
                    5,
                    0
                    ),
                new TestCaseData(
                    "Mitsubishi",
                    "Lancer Evo 5",
                    10.2,
                    4,
                    -1
                    ),
                new TestCaseData(
                    "Mitsubishi",
                    "Eclipse",
                    55,
                    22.5,
                    -6
                    ),
                new TestCaseData(
                    "Subaru",
                    "Impreza",
                    10,
                    15.6,
                    -55
                    )
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseRefuelAboveFuelCapacityWithValidData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    "BMW",
                    "M3",
                    5.6,
                    5,
                    10
                    ),
                new TestCaseData(
                    "Mitsubishi",
                    "Lancer Evo 5",
                    10.2,
                    4,
                    20
                    ),
                new TestCaseData(
                    "Mitsubishi",
                    "Eclipse",
                    55,
                    22.5,
                    87
                    ),
                new TestCaseData(
                    "Subaru",
                    "Impreza",
                    10,
                    15.6,
                    80
                    )
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseRefuelWithValidData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    "BMW",
                    "M3",
                    5.6,
                    100.2,
                    10,
                    10
                    ),
                new TestCaseData(
                    "Mitsubishi",
                    "Lancer Evo 5",
                    10.2,
                    100.2,
                    20,
                    20
                    ),
                new TestCaseData(
                    "Mitsubishi",
                    "Eclipse",
                    55,
                    100.2,
                    40,
                    40
                    ),
                new TestCaseData(
                    "Subaru",
                    "Impreza",
                    10,
                    100.2,
                    80,
                    80
                    )
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseConstructorWithInvalidData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                //Invalid make
                new TestCaseData(
                    "",
                    "M3",
                    5.6,
                    100.2
                    ),
                //Invalid model
                new TestCaseData(
                    "Mitsubishi",
                    "",
                    10.2,
                    100.2
                    ),
                //Invalid fuel consumption
                new TestCaseData(
                    "Mitsubishi",
                    "Eclipse",
                    -55,
                    100.2
                    ),
                //Invalid fuel capacity
                new TestCaseData(
                    "Subaru",
                    "Impreza",
                    10,
                    -100.2
                    )
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseConstructorWithValidData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    "BMW",
                    "M3",
                    5.6,
                    100.2,
                    new Car("BMW", "M3", 5.6, 100.2)
                    ),
                new TestCaseData(
                    "Mitsubishi",
                    "Lancer Evo 5",
                    10.2,
                    100.2,
                    new Car("Mitsubishi", "Lancer Evo 5", 10.2, 100.2)
                    )
            };

            foreach (var testCase in testCases)
            {
                yield return testCase;
            }
        }


    }
}