using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static DeepWise.BaseLogRecord;

namespace DeepWise
{
    enum Page
    {
        Homepage, ParameterSettings, DeviceSettings, ProductHistory
    }
    public class Parameter
    {
        public int ID { get; set; }
        public string Name { get; set; }

    }
    
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Function
        private void TimerTick(object sender, EventArgs e)
        {
            System_Time.Text = DateTime.Now.ToString();
        }

        private void SystemTime()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += TimerTick;
            timer.Start();
        }
        #endregion

        #region Parameter and Init
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Log.Visibility = Visibility.Hidden;
            SystemTime();
        }
        BaseLogRecord Logger = new BaseLogRecord();
        #region Config
        BaseConfig<Parameter> Config = new BaseConfig<Parameter>();
        //Load Config
        //List<Parameter> Parameter_info = Config.Load();
        //Console.WriteLine(Parameter_info[0].ID);
        //Save Config
        //List<Parameter> Parameter_config = new List<Parameter>()
        //{
        //    new Parameter() { ID = 1, Name = "張飛"}
        //};
        //Config.Save(Parameter_config);
        #endregion
        public DispatcherTimer timer;

        #endregion

        #region Menu RadioButton
        private void Menu_Rbn_Checked(object sender, RoutedEventArgs e)
        {
            switch ((sender as RadioButton).Name)
            {
                case nameof(Home_Page):
                    {
                        Main.SelectedIndex = (int)Page.Homepage;
                        Logger.WriteLog("切換主頁!", LogLevel.General, richTextBoxGeneral);
                        break;
                    }
                case nameof(Parameter_Setting):
                    {
                        Main.SelectedIndex = (int)Page.ParameterSettings;
                        Logger.WriteLog("切換參數設定!", LogLevel.General, richTextBoxGeneral);
                        break;
                    }
                case nameof(Device_Setting):
                    {
                        Main.SelectedIndex = (int)Page.DeviceSettings;
                        Logger.WriteLog("切換設備設定!", LogLevel.General, richTextBoxGeneral);
                        break;
                    }
                case nameof(Product_History):
                    {
                        Main.SelectedIndex = (int)Page.ProductHistory;
                        Logger.WriteLog("切換產品履歷!", LogLevel.General, richTextBoxGeneral);
                        break;
                    }
                case nameof(Window_Closing):
                    {
                        if (MessageBox.Show("確認要關閉程式嗎？", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            this.Close();
                        Window_Closing.IsChecked = false;
                        break;
                    }
            }
        }
        #endregion
    }
}
