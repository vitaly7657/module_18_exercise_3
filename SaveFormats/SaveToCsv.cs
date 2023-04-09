using module_18_exercise_3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace module_18_exercise_3.SaveFormats
{
    internal class SaveToCsv : IAnimalSave
    {
        private string fileName;
        public SaveToCsv(string fileName)
        {
            this.fileName = fileName;
        }
        public void SaveAnimals(List<IAnimal> Animal)
        {
            using (StreamWriter sw = new StreamWriter($"{fileName}.csv", false, System.Text.Encoding.GetEncoding("Windows-1251")))
            {
                foreach (IAnimal s in Animal)
                {
                    sw.WriteLine($"ID: {s.id}, тип: {s.typeAnimal}, род: {s.genus}, кличка: {s.name}, порода: {s.breed}, возраст: {s.age} лет");
                }
            }
        }
    }
}
