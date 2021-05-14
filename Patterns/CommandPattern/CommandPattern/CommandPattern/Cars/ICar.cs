using CommandPattern.Clients;

namespace CommandPattern.Cars
{
    public interface ICar
    {
        IClient Owner { get; set; }
        string Name { get; }
        int Price { get; }
    }
}
