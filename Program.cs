namespace QueteEncapsulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int isAvailableQuantityEnoughToContinue = 0;
            BeerEncapsulator beer = new BeerEncapsulator();
            beer.GetUserData();
            while (true)
            {
                Console.WriteLine("Enter the bumber of bottles required : ");
                int.TryParse(Console.ReadLine(), out beer.beerBottlesRequiredByUser);
                beer.AddBeer(beer.beerBottlesRequiredByUser);
                isAvailableQuantityEnoughToContinue = beer.ProduceEncapsulatedBeerBottles();
                if (isAvailableQuantityEnoughToContinue > 0)
                {
                    Console.WriteLine("Do you want to continue fabricating bottles? y/n");
                    if (Console.ReadLine().ToLower() != "y")
                        break;
                }
                else
                    break;
            }            
        }
    }
}
