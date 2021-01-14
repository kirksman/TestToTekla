using System.Windows;
using System.Windows.Media;
using Tekla.Structures.Model;

namespace TestToTekla
{
    public partial class MainWindow : Window
    {
        Model model;

        public MainWindow()
        {
            InitializeComponent();

            btn_Creater.IsEnabled = false;
            this.Title = "Test to TS";

            btn_ConnectToTekla.Click += (s, e) => { model = new Model(); IsConnect(); };
            btn_Creater.Click += (s,e) => 
            {
                if (IsCreate()){MessageBox.Show(
                    "Create ok",
                    "IsCreate",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);}
                else { MessageBox.Show(
                    "Not creating",
                    "IsCreate",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error); ; }
            };
            
        }

        /// <summary>
        /// Попотка создания балки в TS
        /// </summary>
        /// <returns>true - операция выполнена успешна. false - инверсия true</returns>
        private bool IsCreate()
        {
            Beam beam = new Beam(Beam.BeamTypeEnum.BEAM);
            beam.Name = "My beam";
            beam.Profile.ProfileString = "380*380";
            beam.Material.MaterialString = "09Г2";
            beam.Class = "20";
            beam.StartPoint = new Tekla.Structures.Geometry3d.Point(0, 0, 0);
            beam.EndPoint = new Tekla.Structures.Geometry3d.Point(3000, 0, 0);

            return beam.Insert();
        }

        /// <summary>
        /// Проверка присоединения к TS
        /// </summary>
        private void IsConnect()
        {
            if (model.GetConnectionStatus()) 
            {
                msg_IsConnect.Foreground = Brushes.GreenYellow;
                msg_IsConnect.Content = "Connect";
                btn_Creater.IsEnabled = true;
                 
            }
            else 
            {
                msg_IsConnect.Foreground = Brushes.Red;
                msg_IsConnect.Content = "Not connect";
                btn_Creater.IsEnabled = false;
               
            }
        }
    }
}
