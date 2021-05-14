using CommandPattern.Cars;
using CommandPattern.Clients;
using CommandPattern.Commands;
using System;
using System.Collections.Generic;

namespace CommandPattern.Commissioner
{
    public class Mediator : Client, IMediator
    {
        public int Commission => commission;
        public List<ICommand> Ledger => ledger;

        private int commission;
        private List<ICommand> ledger = new List<ICommand>();

        public Mediator(int budget, int commission, string name) : base(name, budget)
        {
            this.commission = commission;
        }

        public void Mediate(ICommand command, IClient buyer, IClient seller, ICar car)
        {
            if (!CheckForValidity(buyer, seller, car)) return;

            seller.RemoveCar(car);
            car.Owner = buyer;
            buyer.AddCar(car, commission: commission);
            Budget += commission;
            ledger.Add(command);

            Console.WriteLine($"\n-------- COMMAND IN PROGRESS --------");
            Console.WriteLine($"The selling of the car {car.Name} come true, successfully!");
            Console.WriteLine($"By the mediator with commission of {commission} and budget {Budget}, \n" +
                $"Seller {seller.Name} with remaining budget of {seller.Budget}. \n" +
                $"Buyer {buyer.Name} with remaining budget of {buyer.Budget}. \n\n" +
                $"Updated cars of the seller {seller.Name} : ");

            seller.OwnedCars.ForEach(x => Console.WriteLine(x.Name));

            Console.WriteLine($"Updated cars of the buyer {buyer.Name}: ");

            buyer.OwnedCars.ForEach(x => Console.WriteLine(x.Name));

            Console.WriteLine($"Updated cars of the mediator {Name} : ");
            
            buyer.OwnedCars.ForEach(x => Console.WriteLine(x.Name));
            Console.WriteLine($"-------- COMMAND PROGRESS DONE--------\n");
        }

        private bool CheckForValidity(IClient buyer, IClient seller, ICar car)
        {
            if (buyer == this || seller == this)
            {
                Console.WriteLine($"Seller/Buyer cannot be the same person whom the mediator {Name} of any sale is.");
                return false;
            }
            else if (buyer == seller)
            {
                Console.WriteLine($"Seller/Buyer cannot be the same person.");
                return false;
            }
            else if (seller != car.Owner)
            {
                Console.WriteLine($"{seller.Name} is not the owner of the related car {car.Name}.");
                return false;
            }
            else if (!(buyer.Budget >= (car.Price + commission)))
            {
                Console.WriteLine($"{buyer.Name} cannot afford the car {car.Name}.");
                return false;
            }

            return true;
        }
    }
}
