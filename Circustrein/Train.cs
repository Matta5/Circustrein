using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein
{
	public class Train
	{
		public static List<List<Animal>> DistributeAnimals(List<Animal> animals)
		{
			var wagons = new List<List<Animal>>();
			wagons.Add(new List<Animal>());

			foreach (var animal in animals)
			{
				bool added = false;

				foreach (var wagon in wagons)
				{
					if (wagon.Sum(a => (int)a.Size) + (int)animal.Size <= 10 &&
						wagon.All(a => (a.Food != FoodType.Carnivore || (a.Food == FoodType.Carnivore && a.Size < animal.Size))))
					{
						wagon.Add(animal);
						added = true;
						break;
					}
				}

				if (!added)
				{
					wagons.Add(new List<Animal> { animal });
				}

			}
			return wagons;

		}
		public static void PrintWagons(List<List<Animal>> wagons)
		{
			for (int i = 0; i < wagons.Count; i++)
			{
				Console.WriteLine($"Wagon {i + 1}:");
				foreach (var animal in wagons[i])
				{
					Console.WriteLine($"  {animal.Name} - Size: {animal.Size}, Food: {animal.Food}");
				}
				Console.WriteLine();
			}
		}
	}
}