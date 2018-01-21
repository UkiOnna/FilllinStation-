using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FillingStation
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double sum = 0;
        private List<Item> items;

        public MainWindow()
        {
            InitializeComponent();
            items = new List<Item>();

            Random random = new Random();
            int nameFuel = 92;

            for (int i = 0; i < 3; i++)
            {
                Item item = new Item();
                item.Type = TypeItem.Petrol;
                item.Price = random.Next(150, 200);
                item.Name = nameFuel.ToString();
                items.Add(item);
                nameFuel += 3;
            }

            Item chocolate = new Item();
            chocolate.Type = TypeItem.Food;
            chocolate.Price = 300;
            chocolate.Name = "Шоколад";
            items.Add(chocolate);

            Item burger = new Item();
            burger.Type = TypeItem.Food;
            burger.Price = 500;
            burger.Name = "Гамбургер";
            items.Add(burger);

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Type == TypeItem.Petrol)
                {
                    fuelBox.Items.Add(items[i].Name);
                }

                else
                {
                    foodBox.Items.Add(items[i].Name);
                }
            }


        }

        private void orderButtonClick(object sender, RoutedEventArgs e)
        {
            int countItemFuel;
            int countItemFood;

            if (int.TryParse(countFood.Text, out countItemFood) && int.TryParse(countLiter.Text, out countItemFuel) && foodBox.SelectedItem != null && fuelBox.SelectedItem != null)
            {

                for (int i = 0; i < items.Count; i++)
                {
                    if (foodBox.SelectedItem == items[i].Name)
                    {
                        sum += items[i].Price * countItemFood;
                    }
                    else if (fuelBox.SelectedItem == items[i].Name)
                    {
                        sum += items[i].Price * countItemFuel;
                    }
                }

                MessageBox.Show(string.Format("Общая сумма заказа - {0} тенге", sum));
                sum = 0;
            }

            else
            {
                MessageBox.Show("Вы неправильно заполнили форму заказа");
            }
        }
    }
}
