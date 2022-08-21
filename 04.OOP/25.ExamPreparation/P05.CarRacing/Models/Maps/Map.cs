using System;

using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            bool isRacerOneAvailable = IsRacerAvailable(racerOne);
            bool isRacerTwoAvailable = IsRacerAvailable(racerTwo);

            if (!isRacerOneAvailable && !isRacerTwoAvailable)
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            else if (!isRacerOneAvailable)
            {
                return String.Format(
                    OutputMessages.OneRacerIsNotAvailable, 
                    racerTwo.Username, 
                    racerOne.Username);
            }
            else if (!isRacerTwoAvailable)
            {
                return String.Format(
                    OutputMessages.OneRacerIsNotAvailable,
                    racerOne.Username,
                    racerTwo.Username);
            }

            //racerOne.Race();
            //racerTwo.Race();

            double racerOneBehaviorMultiplier = GetRacingBehaviorMultiplier(racerOne);
            double racerTwoBehaviorMultiplier = GetRacingBehaviorMultiplier(racerTwo);

            double racerOneChance = racerOne.Car.HorsePower
                * racerOne.DrivingExperience
                * racerOneBehaviorMultiplier;

            double racerTwoChance = racerTwo.Car.HorsePower
                    * racerTwo.DrivingExperience
                    * racerTwoBehaviorMultiplier;

            // May need to put the Race() methods above under the last else if check
            // Not sure if the driving experience needs to be updated before or after the winning chance has been calculated
            racerOne.Race();
            racerTwo.Race();

            if (racerOneChance > racerTwoChance)
            {
                return String.Format(
                    OutputMessages.RacerWinsRace,
                    racerOne.Username,
                    racerTwo.Username,
                    racerOne.Username);
            }
            else
            {
                return String.Format(
                    OutputMessages.RacerWinsRace,
                    racerOne.Username,
                    racerTwo.Username,
                    racerTwo.Username);
            }
        }

        private bool IsRacerAvailable(IRacer racer)
        {
            if (racer.IsAvailable())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private double GetRacingBehaviorMultiplier(IRacer racer)
        {
            if (racer.RacingBehavior == "strict")
            {
                return 1.2;
            }
            else
            {
                return 1.1;
            }
        }
    }
}
