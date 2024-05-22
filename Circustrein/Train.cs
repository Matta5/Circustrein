using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Circustrein;

namespace Circustrein
{
    public class Train
    {
        public static List<Wagon> DistributeAnimals(List<Animal> animals)
        {
            var wagons = new List<Wagon>();
            wagons.Add(new Wagon());

            List<Animal> carnivores = animals.FindAll(a => a.Food.Equals(FoodType.Carnivore)).ToList().OrderByDescending (a => a.Size).ToList();
            List<Animal> herbivores = animals.FindAll(a => a.Food.Equals(FoodType.Herbivore)).ToList().OrderBy(a => a.Size).ToList();
            List<Animal> allAnimals = carnivores.Concat(herbivores).ToList();

            foreach(Animal animal in allAnimals)
            {
                bool added = false;

                foreach (var wagon in wagons)
                {
                    if (wagon.CanAddAnimal(animal))
                    {
                        wagon.Add(animal);
                        added = true;
                        break;
                    }
                    
                }

                if (!added)
                {
                    var newWagon = new Wagon();
                    newWagon.Add(animal);
                    wagons.Add(newWagon);
                }
            }

            // Group animals by type and count
            //var groupedAnimals = animals.GroupBy(a => new { a.Food, a.Size })
            //                            .Select(g => new { Type = g.Key, Count = g.Count() })
            //                            .ToList();

            //// Sort groups by food type, size, and count
            //var sortedGroups = groupedAnimals.OrderByDescending(g => g.Type.Food)
            //                                 .ThenByDescending(g => g.Type.Size)
            //                                 .ThenBy(g => g.Count)
            //                                 .ToList();

            //foreach (var group in sortedGroups)
            //{
            //    for (int i = 0; i < group.Count; i++)
            //    {
            //        var animal = new Animal { Food = group.Type.Food, Size = group.Type.Size };

            //        bool added = false;

            //        foreach (var wagon in wagons)
            //        {
            //            if (wagon.CanAddAnimal(animal))
            //            {
            //                wagon.Add(animal);
            //                added = true;
            //                break;
            //            }
            //        }

            //        if (!added)
            //        {
            //            var newWagon = new Wagon();
            //            newWagon.Add(animal);
            //            wagons.Add(newWagon);
            //        }
            //    }
            //}

            return wagons;
        }


        public static void PrintWagons(List<Wagon> wagons)
        {
            for (int i = 0; i < wagons.Count; i++)
            {
                Console.WriteLine($"Wagon {i + 1}:");
                foreach (var animal in wagons[i].Animals)
                {
                    Console.WriteLine($"  {animal.Name} - Size: {animal.Size}, Food: {animal.Food}");
                }
                Console.WriteLine();
            }
        }

    }

    //wagon.Size + (int) animal.Size <= 10 &&
    //                    wagon.Animals.All(a => (a.Food != FoodType.Carnivore || (a.Food == FoodType.Carnivore && a.Size < animal.Size)))
}