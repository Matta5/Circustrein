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
            var animals = CreateAnimals();
            var wagons = DistributeAnimals(animals);
            PrintWagons(wagons);
        }

        private static List<Animal> CreateAnimals()
        {
            var animals = new List<Animal>();
            AddAnimals(animals, "Large Carnivore", Size.Large, FoodType.Carnivore, 0);
            AddAnimals(animals, "Medium Carnivore", Size.Medium, FoodType.Carnivore, 0);
            AddAnimals(animals, "Small Carnivore", Size.Small, FoodType.Carnivore, 3);
            AddAnimals(animals, "Large Herbivore", Size.Large, FoodType.Herbivore, 3);
            AddAnimals(animals, "Medium Herbivore", Size.Medium, FoodType.Herbivore, 2);
            AddAnimals(animals, "Small Herbivore", Size.Small, FoodType.Herbivore, 0);
            return animals;
        }

        private static List<Wagon> DistributeAnimals(List<Animal> animals)
        {
            return Train.DistributeAnimals(animals);
        }

        private static void AddAnimals(List<Animal> animals, string name, Size size, FoodType food, int count)
        {
            for (int i = 0; i < count; i++)
            {
                animals.Add(new Animal { Name = name, Size = size, Food = food });
            }
        }

        private static void PrintWagons(List<Wagon> wagons)
        {
            Train.PrintWagons(wagons);
            Console.WriteLine($"{wagons.Count} wagons needed for trafficking the whole circus.");
        }

    }
}

    