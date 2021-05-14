using CommandPattern.Cars;
using CommandPattern.Clients;
using CommandPattern.Commands;
using CommandPattern.Commissioner;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ICommand command;

            IMediator mediator = new Mediator(5000, 5000, "Hitler");

            IClient firstClient = new Client("Ahmet", 90000);
            IClient secondClient = new Client("Mehmet", 100000);
            IClient thirdClient = (IClient) mediator;

            ICar audi = new Car(secondClient, 10000, "Audi");
            secondClient.AddCar(audi, true);

            ICar bmw = new Car(thirdClient, 5000, "BMW");
            thirdClient.AddCar(bmw, true);

            command = new BuyCommand(audi, firstClient, secondClient, mediator);
            command.Execute();
            command.Unexecute();

            System.Console.ReadKey();
        }
    }
}
