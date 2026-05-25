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
using System.Windows.Shapes;
using Obuw11.Modeli;
using System.Data.Entity;

namespace Obuw11
{
    /// <summary>
    /// Логика взаимодействия для OknoZakazi.xaml
    /// </summary>
    public partial class OknoZakazi : Window
    {
        private Polzovatel _pol;
        private ObuwKontext _db;
        public OknoZakazi(Polzovatel pol,ObuwKontext db)
        {
            InitializeComponent();
            _db = db;
            _pol = pol;

            if (_pol.RolId == 2)
            {
                bthDobavit.Visibility = Visibility.Collapsed;
                bthUdalit.Visibility = Visibility.Collapsed;
                bthURedart.Visibility = Visibility.Collapsed;
            }
            Zagruzka();

        }

        void Zagruzka()
        {
            LvElement.ItemsSource = _db.Zakazi
                .Include(z => z.PunktVidachi)
                .Include(z => z.Polzovatel)
                .Include(z => z.StatusZakaza)
                .ToList();
        }

        private void Dobavit(object sender, RoutedEventArgs e)
        {
            new ZakaziRedakt(null,_db).ShowDialog();
            Zagruzka();
        }

        private void Redakt(object sender, RoutedEventArgs e)
        {
            var z = LvElement.SelectedItem as Zakaz;
            if (z == null)
            {
                MessageBox.Show("Выбирите заказ!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            new ZakaziRedakt(z,_db).ShowDialog();
            Zagruzka();
        }

        private void Udalit(object sender, RoutedEventArgs e)
        {
            var z = LvElement.SelectedItem as Zakaz;
            if (z == null)
            {
                MessageBox.Show("Выбирите заказ!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (_db.ZakaziTovarov.Any(zt => zt.ZakazId == z.Id)) { MessageBox.Show("Заказ присутвует в товарах", "Ошимбка", MessageBoxButton.OK, MessageBoxImage.Error); return; }
            if (MessageBox.Show("Удалить заказ?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes) return;
            _db.Zakazi.Remove(z);
            _db.SaveChanges();
            Zagruzka();
        }

        private void Nazad(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ClickElement(object sender, MouseButtonEventArgs e)
        {
            var zakaz = LvElement.SelectedItem as Zakaz;
            if (zakaz == null) return;
            new ZakaziRedakt(zakaz, _db).ShowDialog();
            Zagruzka();
        }
    }
}
