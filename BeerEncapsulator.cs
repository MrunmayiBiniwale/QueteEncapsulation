using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace QueteEncapsulation
{
    public class BeerEncapsulator
    {
        const decimal eachAddBeerVolume = 33;
        const int requiredBottleAndCapsuleEachBeer = 1;
        private decimal _availableBeerVolume;
        private int _availableBottles;
        private int _availableCapsules;
        public int beerBottlesRequiredByUser = 0;
        public int nombreDeBouteillePeutFabriquer = 0;

        //Get user input
        public void GetUserData()
        {
            Console.WriteLine("Please enter the available quantity of beer in litres : ");
            decimal.TryParse(Console.ReadLine(), out _availableBeerVolume);
            Console.WriteLine("Please enter the available number of bottles : ");
            int.TryParse(Console.ReadLine(), out _availableBottles);
            Console.WriteLine("Please enter the available number of capsules : ");
            int.TryParse(Console.ReadLine(), out _availableCapsules);
        }

        //Validate if all elements are available and add beer
        public void AddBeer(int beerBottlesRequiredByUser)
        {           
            if (ValidateElements(beerBottlesRequiredByUser))
            {
                nombreDeBouteillePeutFabriquer = ProduceEncapsulatedBeerBottles(beerBottlesRequiredByUser);
                Console.WriteLine("\n" + nombreDeBouteillePeutFabriquer + " number of bottles can be fabricated.");
                if (nombreDeBouteillePeutFabriquer > beerBottlesRequiredByUser)
                {
                    _availableBeerVolume -= (eachAddBeerVolume * beerBottlesRequiredByUser);
                    _availableBottles -= (requiredBottleAndCapsuleEachBeer * beerBottlesRequiredByUser);
                    _availableCapsules -= (requiredBottleAndCapsuleEachBeer * beerBottlesRequiredByUser);
                    Console.WriteLine("" + beerBottlesRequiredByUser + " are fabricated as requested.");
                }                
            }              
        }

        //Check how many beer bottles can be fabricated
        public int ProduceEncapsulatedBeerBottles(int nombreDeBouteilleDoitFrabiquer = 0)
        {
            if (_availableBeerVolume >= (eachAddBeerVolume * nombreDeBouteilleDoitFrabiquer)
                && _availableBottles >= (requiredBottleAndCapsuleEachBeer * nombreDeBouteilleDoitFrabiquer)
                && _availableBottles >= (requiredBottleAndCapsuleEachBeer * nombreDeBouteilleDoitFrabiquer))
            {
                if((_availableBottles * eachAddBeerVolume) <= _availableBeerVolume)
                {
                    nombreDeBouteillePeutFabriquer =  _availableBottles < _availableCapsules ? _availableBottles : _availableCapsules;
                }
                else
                {
                    for (int i = _availableBottles; i > 0; i--)
                    {
                        if (_availableBeerVolume >= (eachAddBeerVolume * (i))
                            && _availableBottles >= (requiredBottleAndCapsuleEachBeer * (i))
                            && _availableBottles >= (requiredBottleAndCapsuleEachBeer * (i)))
                        {
                            nombreDeBouteillePeutFabriquer = i;
                            break;
                        }
                    }
                }               
            }
            else
            {
                int nombreDeBouteillePeutFabriquer = 0;
                for(int i = nombreDeBouteilleDoitFrabiquer; i > 0; i--)
                {
                    if (_availableBeerVolume >= (eachAddBeerVolume * (i))
                        && _availableBottles >= (requiredBottleAndCapsuleEachBeer * (i))
                        && _availableBottles >= (requiredBottleAndCapsuleEachBeer * (i)))
                    {
                        nombreDeBouteillePeutFabriquer = i;
                        break;
                    }                        
                }  
            }            
            return nombreDeBouteillePeutFabriquer;
        }

        //Validate if all elements are available
        public bool ValidateElements(int beerBottlesRequiredByUser)
        {
            bool isValide;
            if (_availableBeerVolume < (eachAddBeerVolume * beerBottlesRequiredByUser))
            {
                isValide = false;
                decimal requiredBeerVolume = (eachAddBeerVolume * beerBottlesRequiredByUser) - _availableBeerVolume;
                Console.WriteLine("Not enough beer available. Please add " + requiredBeerVolume + " litres of beer.");
            }      
            else if(_availableBottles < (requiredBottleAndCapsuleEachBeer * beerBottlesRequiredByUser))
            {
                isValide = false;
                int requiredBeerBottles = (requiredBottleAndCapsuleEachBeer * beerBottlesRequiredByUser) - _availableBottles;
                Console.WriteLine("Not enough bottles available. Please add " + requiredBeerBottles + " bottles.");
            }
            else if (_availableCapsules < (requiredBottleAndCapsuleEachBeer * beerBottlesRequiredByUser))
            {
                isValide = false;
                int requiredCapsules = (requiredBottleAndCapsuleEachBeer * beerBottlesRequiredByUser) - _availableCapsules;
                Console.WriteLine("Not enough capsules available. Please add " + requiredCapsules + " capsules.");
            }
            else
            {
                isValide = true;
            }

            return isValide;
        }
    }
}
