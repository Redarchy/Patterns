using CommandPattern.Cars;
using System.Collections.Generic;

namespace CommandPattern.Clients
{
    public abstract class BaseClient : IClient
    {
        public List<ICar> OwnedCars => ownedCars;
        public string Name => name;
        public int Budget { get => budget; set => budget = value; }

        private List<ICar> ownedCars = new List<ICar>();
        private string name;
        private int budget;

        public BaseClient(string name, int budget) 
        {
            this.name = name;
            this.budget = budget;
        }

        public void AddCar(ICar car, bool isInitial = false, int commission = 0)
        {
            ownedCars.Add(car);
            budget = isInitial ? budget : budget - car.Price;
            budget -= commission;
        }

        public void RemoveCar(ICar car)
        {
            if(ownedCars.Contains(car))
            {
                ownedCars.Remove(car);
                budget = budget + car.Price;
            }
        }
    }
}
