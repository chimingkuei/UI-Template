﻿using System;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DeepWise.ControlItem
{
    /// <summary>
    /// IndicatorLight.xaml 的互動邏輯
    /// </summary>
    public partial class IndicatorLight : UserControl
    {
        public IndicatorLight()
        {
            InitializeComponent();
        }

        ColorAnimation Animation { get; } = new ColorAnimation() { Duration = new Duration(TimeSpan.FromSeconds(0.1)) };
        DoubleAnimation Animation2 { get; } = new DoubleAnimation() { Duration = new Duration(TimeSpan.FromSeconds(0.1)) };

        public static readonly DependencyProperty LightColorProperty = DependencyProperty.Register(nameof(LightColor), typeof(Color), typeof(IndicatorLight), new PropertyMetadata(Colors.Gray, OnLightColorChanged));

        public Color LightColor
        {
            get => (Color)GetValue(LightColorProperty);
            set => SetValue(LightColorProperty, value);
        }

        private static void OnLightColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var s = sender as IndicatorLight;
            s.Animation.From = (s.Light.Fill as SolidColorBrush).Color;
            var color = (Color)e.NewValue;
            s.Animation.To = color;
            s.Light.Fill.BeginAnimation(SolidColorBrush.ColorProperty, s.Animation);
            //s.Animation2.From = s.Blur.Radius;
            //s.Animation2.To = color.> 0.5f ? 10 : 1;
            //s.Blur.BeginAnimation(BlurEffect.RadiusProperty, s.Animation2);
        }

        #region DeviceName TextBox
        public static readonly DependencyProperty DeviceNameProperty =
        DependencyProperty.Register(nameof(DeviceName), typeof(string), typeof(IndicatorLight), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string DeviceName
        {
            get { return (string)GetValue(DeviceNameProperty); }
            set { SetValue(DeviceNameProperty, value); }
        }
        #endregion

    }
}
