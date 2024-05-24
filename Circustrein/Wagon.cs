using Circustrein;

public class Wagon
{
    private List<Animal> Animals { get; } = new List<Animal>();
    private int size = 0;
    private int maxSize = 10;
    

    public bool CanAddAnimal(Animal animal)
    {
        return size + (int)animal.Size <= maxSize &&
               Animals.All(a => (a.Food != FoodType.Carnivore || (a.Food == FoodType.Carnivore && a.Size < animal.Size)));
    }

    public void AddAnimal(Animal animal)
    {
        if (CanAddAnimal(animal))
        {
            Animals.Add(animal);
            size += (int)animal.Size;
        }
    }

    public IEnumerable<Animal> GetAnimals()
    {
        return Animals.AsReadOnly();
    }
}