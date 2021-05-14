using CommandPattern.Cars;
using CommandPattern.Clients;
using CommandPattern.Commands;
using System.Collections.Generic;

namespace CommandPattern.Commissioner
{
    public interface IMediator
    {
        int Commission { get; } 
        void Mediate(ICommand command, IClient buyer, IClient seller, ICar car);
        List<ICommand> Ledger { get; }
    }
}
