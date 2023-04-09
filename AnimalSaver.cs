using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module_18_exercise_3
{
    internal class AnimalSaver
    {
        public IAnimalSave Mode { get; set; }
        public List<IAnimal> Animals { get; set; }
        public AnimalSaver(IAnimalSave Method)
        {
            this.Mode = Method;
        }
        public void Save()
        {
            Mode.SaveAnimals(Animals);
        }
    }
}
