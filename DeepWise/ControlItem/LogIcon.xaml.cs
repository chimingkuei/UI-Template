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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DeepWise.ControlItem
{
    /// <summary>
    /// LogIcon.xaml 的互動邏輯
    /// </summary>
    public partial class LogIcon : UserControl
    {
        public LogIcon()
        {
            InitializeComponent();
        }

        #region Information TextBlock
        public static readonly DependencyProperty InformationTextProperty =
        DependencyProperty.Register(nameof(Information), typeof(string), typeof(LogIcon), new FrameworkPropertyMetadata("0", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string Information
        {
            get { return (string)GetValue(InformationTextProperty); }
            set { SetValue(InformationTextProperty, value); }
        }
        #endregion

        #region Warning TextBlock
        public static readonly DependencyProperty WarningTextProperty =
        DependencyProperty.Register(nameof(Warning), typeof(string), typeof(LogIcon), new FrameworkPropertyMetadata("0", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string Warning
        {
            get { return (string)GetValue(WarningTextProperty); }
            set { SetValue(WarningTextProperty, value); }
        }
        #endregion

        #region Error TextBlock
        public static readonly DependencyProperty ErrorTextProperty =
        DependencyProperty.Register(nameof(Error), typeof(string), typeof(LogIcon), new FrameworkPropertyMetadata("0", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string Error
        {
            get { return (string)GetValue(ErrorTextProperty); }
            set { SetValue(ErrorTextProperty, value); }
        }
        #endregion
    }
}
