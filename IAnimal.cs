using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module_18_exercise_3
{
    interface IAnimal
    {
        int id { get; set; }
        string typeAnimal { get; set; } //тип       
        string genus { get; set; } //род
        string name { get; set; } //кличка
        string breed { get; set; } //порода
        string age { get; set; } //возраст
    }
}
