using System.Windows;

namespace GraKK
{
    /// <summary>
    /// Logika interakcji dla klasy Informacja.xaml
    /// </summary>
    public partial class Informacja : Window
    {
        public Informacja()
        {
            InitializeComponent();
        }

        private void Image_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Hide();
        }
    }
}
