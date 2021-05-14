using CommandPattern.Clients;

namespace CommandPattern.Cars
{
    public abstract class BaseCar : ICar
    {
        public IClient Owner { get => owner; set => owner = value; }
        public string Name => name;
        public int Price => price;

        private IClient owner;
        private int price;
        private string name;

        public BaseCar(IClient owner, int price, string name)
        {
            this.owner = owner;
            this.price = price;
            this.name = name;
        }

        public BaseCar( int price, string name)
        {
            this.price = price;
            this.name = name;
        }
    }
}
