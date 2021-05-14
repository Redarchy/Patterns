using CommandPattern.Clients;

namespace CommandPattern.Cars
{
    public class Car : BaseCar
    {
        public Car(IClient owner, int price, string name) : base(owner, price, name) { }
        public Car(int price, string name) : base(price, name) { }
        
    }
}
