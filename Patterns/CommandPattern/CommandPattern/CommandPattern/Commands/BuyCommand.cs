using CommandPattern.Cars;
using CommandPattern.Clients;
using CommandPattern.Commissioner;

namespace CommandPattern.Commands
{
    public class BuyCommand : ICommand
    {
        private ICar car;
        private IClient buyer, seller;
        private IMediator mediator;

        public BuyCommand(ICar car, IClient buyer, IClient seller, IMediator mediator)
        {
            this.car = car;
            this.buyer = buyer;
            this.seller = seller;
            this.mediator = mediator;
        }

        public void Execute()
        {
            mediator.Mediate(this, buyer, seller, car);
        }

        public void Unexecute()
        {
            mediator.Mediate(this, seller, buyer, car);
        }
    }
}
