using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module_18_exercise_3
{
    class Amphibians : IAnimal //реализация интерфейса
    {
        public int id { get; set; }
        public string typeAnimal { get; set; }
        public string genus { get; set; }
        public string name { get; set; }
        public string breed { get; set; }
        public string age { get; set; }
        public Amphibians(int ID, string TypeAnimal, string Genus, string Name, string Breed, string Age)
        {
            this.id = ID;
            this.typeAnimal = TypeAnimal;
            this.genus = Genus;
            this.name = Name;
            this.breed = Breed;
            this.age = Age;
        }
        public override string ToString() //перезапись ToString для вывода данных
        {
            return $"{id}#{typeAnimal}#{genus}#{name}#{breed}#{age}";
        }
    }
}
