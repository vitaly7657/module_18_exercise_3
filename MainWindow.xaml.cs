using LogicLib;
using module_18_exercise_3.SaveFormats;
using System;
using System.Windows;
using System.Linq;

namespace module_18_exercise_3
{
    public partial class MainWindow : Window, IView
    {
        Repository zoo; //объявление репозитория zoo
        Presenter presenter; //объявление презентера
        string animalToParse; //объявление переменной строки добавляемого животного

        public MainWindow()
        {
            InitializeComponent();
            zoo = Repository.CreateRepository(); //созание списка животных
            dg_animals.ItemsSource = zoo.animalList; //заполнение datagrid животными

            presenter = new Presenter(this); //создание нового презентера
        }

        //присовение данных из полей в переменные
        public string _TypeAnimal { get => this.tb_typeAnimal.Text; }
        public string _Genus { get => this.tb_genus.Text; }
        public string _AnimalName { get => this.tb_name.Text; }
        public string _Breed { get => this.tb_breed.Text; }
        public string _Age { get => this.tb_age.Text; }

        //вывод результата
        public string Result { set => animalToParse = value; }


        private void add_button_Click(object sender, RoutedEventArgs e) //кнопка добавление животного
        {
            if (tb_typeAnimal.Text != "" && tb_genus.Text != "" && tb_name.Text != "" && tb_breed.Text != "" && tb_age.Text != "") //проверка заполнения полей
            {
                presenter.Result(); //результатом будет строка с разделителями
                string[] result = animalToParse.Split('#').ToArray(); //расделяем строку
                int animalMaxID = zoo.animalList.Max(s => s.id); //ищем в списке животных максимальный id
                zoo.Add(AnimalFactory.GetAnimal(animalMaxID + 1, result[0], result[0], result[1], result[2], result[3], result[4])); //добавляем новое животное через проверку
                dg_animals.Items.Refresh(); //обновление datagrid
            }
            else
            {
                MessageBox.Show("Не все поля заполнены!");
            }
        }

        private void save_csv_button_Click(object sender, RoutedEventArgs e) //кнопка сохранения в csv
        {
            var saveToCsv = new SaveToCsv("Animals_CSV_format");
            AnimalSaver anSave = new AnimalSaver(saveToCsv);
            anSave.Animals = zoo.animalList;
            anSave.Mode = saveToCsv;
            anSave.Save();
        }

        private void save_txt_button_Click(object sender, RoutedEventArgs e) //кнопка сохранения в txt
        {
            var saveToTxt = new SaveToTxt("Animals_TXT_format");
            AnimalSaver anSave = new AnimalSaver(saveToTxt);
            anSave.Animals = zoo.animalList;
            anSave.Mode = saveToTxt;
            anSave.Save();
        }

        private void delete_button_Click(object sender, RoutedEventArgs e) //кнопка удаления животного
        {
            if (dg_animals.SelectedItems.Count > 0) //проверка выделения DataGrid
            {
                var deleteAnimalIDArray = dg_animals.SelectedItem.ToString().Split('#'); //разделение строки выделенного животного
                var deleteAnimal = zoo.animalList.FirstOrDefault(p => p.id == Convert.ToInt32(deleteAnimalIDArray[0])); //поиск в списке животного
                zoo.animalList.Remove(deleteAnimal); //удаление животного из списка
            }
            else
            {
                MessageBox.Show("Выберите животное из списка");
            }

            dg_animals.Items.Refresh(); //обновление datagrid
        }
    }
}
