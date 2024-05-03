using WebApplication.Models;

namespace WebApplication.Services;

public interface IAnimalService
{
    IEnumerable<Animal> GetAnimals();
    int CreateAnimal(Animal animal);
    Animal? GetAnimal(int idAnimal);
    int UpdateAnimal(Animal animal);
    int DeleteAnimal(int idAnimal);
}