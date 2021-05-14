using CommandPattern.Cars;
using System.Collections.Generic;

namespace CommandPattern.Clients
{
    public interface IClient
    {
        int Budget { get; set; }
        string Name { get; }
        List<ICar> OwnedCars { get; }
        void AddCar(ICar car, bool isInitial = false, int commission = 0);
        void RemoveCar(ICar car);
    }
}
