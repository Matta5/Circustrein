using System;
using System.Collections.Generic;
using System.Linq;
using Circustrein;

namespace Circustrein
{
    public enum FoodType { Herbivore, Carnivore }
    public enum Size { Small = 1, Medium = 3, Large = 5 }

    class Program
    {
        static void Main()
        {
            var animals = new List<Animal>();

            AddAnimals(animals, "Large Carnivore", Size.Large, FoodType.Carnivore, 0);
            AddAnimals(animals, "Medium Carnivore", Size.Medium, FoodType.Carnivore, 0);
            AddAnimals(animals, "Small Carnivore", Size.Small, FoodType.Carnivore, 3);
            AddAnimals(animals, "Large Herbivore", Size.Large, FoodType.Herbivore, 3);
            AddAnimals(animals, "Medium Herbivore", Size.Medium, FoodType.Herbivore, 2);
            AddAnimals(animals, "Small Herbivore", Size.Small, FoodType.Herbivore, 0);




            var wagons = Train.DistributeAnimals(animals);


            Train.PrintWagons(wagons);

            int wagonCount = 0;
            foreach (var wagon in wagons)
            {
                wagonCount++;
            }
            wagonCount.ToString();
			Console.WriteLine($"{wagonCount} wagons needed for trafficing the whole circus.");
		}
        static void AddAnimals(List<Animal> animals, string name, Size size, FoodType food, int count)
        {
            for (int i = 0; i < count; i++)
            {
                animals.Add(new Animal { Name = name, Size = size, Food = food });
            }
        }
        
    }
}

    