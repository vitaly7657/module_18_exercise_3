using module_18_exercise_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module_18_exercise_3
{
    internal class AnimalFactory
    {
        public static IAnimal GetAnimal(int ID, string TypeAnimals, string TypeAnimal, string Genus, string Name, string Breed, string Age) //метод добавления животного с проверкой
        {
            switch (TypeAnimals) //проверка типа животного
            {
                case "млекопитающие": return new Mammals(ID, TypeAnimal.ToLower(), Genus, Name, Breed, Age);
                case "земноводные": return new Amphibians(ID, TypeAnimal.ToLower(), Genus, Name, Breed, Age);
                case "птицы": return new Birds(ID, TypeAnimal.ToLower(), Genus, Name, Breed, Age);

                default: return new UnknownAnimal(ID, TypeAnimal.ToLower(), Genus, Name, Breed, Age); //запись неизвестного типа
            }
        }
    }
}
