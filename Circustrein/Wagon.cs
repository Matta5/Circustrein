using System;
using System.Collections.Generic;
using System.Linq;
using Circustrein;

namespace Circustrein
{
    public class Wagon
    {
        public List<Animal> Animals { get; set; } = new List<Animal>();
        public int maxSize { get; set; }

        public void Add(Animal animal)
        {
            Animals.Add(animal);
            maxSize += (int)animal.Size;
        }

        public bool CanAddAnimal(Animal animal)
        {
            return maxSize + (int)animal.Size <= 10 &&
                   Animals.All(a => (a.Food != FoodType.Carnivore || (a.Food == FoodType.Carnivore && a.Size < animal.Size)));
        }
    }

}