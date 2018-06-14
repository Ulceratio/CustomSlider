using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace CustomSlider
{
    public partial class SimpleSlider : UserControl
    {
        #region DP properties       

        public Action ValueChanged
        {
            get { return (Action)GetValue(ValueChangedProperty); }
            set { SetValue(ValueChangedProperty, value); }
        }

        public static readonly DependencyProperty ValueChangedProperty =
            DependencyProperty.Register("ValueChanged", typeof(Action), typeof(SimpleSlider));

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(SimpleSlider));



        #region Brushes

        public SolidColorBrush LeftRectangleBrush
        {
            get { return (SolidColorBrush)GetValue(LeftRectangleBrushProperty); }
            set { SetValue(LeftRectangleBrushProperty, value); }
        }

        public static readonly DependencyProperty LeftRectangleBrushProperty =
            DependencyProperty.Register("LeftRectangleBrush", typeof(SolidColorBrush), typeof(SimpleSlider));



        public SolidColorBrush RightRectangleBrush
        {
            get { return (SolidColorBrush)GetValue(RightRectangleBrushProperty); }
            set { SetValue(RightRectangleBrushProperty, value); }
        }

        public static readonly DependencyProperty RightRectangleBrushProperty =
            DependencyProperty.Register("RightRectangleBrush", typeof(SolidColorBrush), typeof(SimpleSlider));


        public SolidColorBrush RegulatorBrush
        {
            get { return (SolidColorBrush)GetValue(RegulatorBrushProperty); }
            set { SetValue(RegulatorBrushProperty, value); }
        }

        public static readonly DependencyProperty RegulatorBrushProperty =
            DependencyProperty.Register("RegulatorBrush", typeof(SolidColorBrush), typeof(SimpleSlider));


        #endregion

        #region Heights

        public double HeightForRectangles
        {
            get { return (double)GetValue(HeightForRectanglesProperty); }
            set { SetValue(HeightForRectanglesProperty, value); }
        }

        public static readonly DependencyProperty HeightForRectanglesProperty =
            DependencyProperty.Register("HeightForRectangles", typeof(double), typeof(SimpleSlider));



        public double HeightForRegulator
        {
            get { return (double)GetValue(HeightForRegulatorProperty); }
            set { SetValue(HeightForRegulatorProperty, value); }
        }

        public static readonly DependencyProperty HeightForRegulatorProperty =
            DependencyProperty.Register("HeightForRegulator", typeof(double), typeof(SimpleSlider));

        public double CenterRegulatorActualHight
        {
            get { return (double)GetValue(CenterRegulatorActualHightProperty); }
            set { SetValue(CenterRegulatorActualHightProperty, value); }
        }

        public static readonly DependencyProperty CenterRegulatorActualHightProperty =
            DependencyProperty.Register("CenterRegulatorActualHight", typeof(double), typeof(SimpleSlider));


        public double LeftRectangleActualHeight
        {
            get { return (double)GetValue(LeftRectangleActualHeightProperty); }
            set { SetValue(LeftRectangleActualHeightProperty, value); }
        }

        public static readonly DependencyProperty LeftRectangleActualHeightProperty =
            DependencyProperty.Register("LeftRectangleActualHeight", typeof(double), typeof(SimpleSlider));


        public double RightRectangleActualHeight
        {
            get { return (double)GetValue(RightRectangleActualHeightProperty); }
            set { SetValue(RightRectangleActualHeightProperty, value); }
        }

        public static readonly DependencyProperty RightRectangleActualHeightProperty =
            DependencyProperty.Register("RightRectangleActualHeight", typeof(double), typeof(SimpleSlider));


        public GridLength MainActualHeight
        {
            get { return (GridLength)GetValue(MainActualHeightProperty); }
            set { SetValue(MainActualHeightProperty, value); }
        }

        public static readonly DependencyProperty MainActualHeightProperty =
            DependencyProperty.Register("MainActualHeight", typeof(GridLength), typeof(SimpleSlider));

        #endregion

        #endregion

        #region Functions
        private void SetBindings()
        {
            this.SetBinding(SimpleSlider.ValueProperty, new Binding("Value") { Mode = BindingMode.TwoWay });
            this.SetBinding(SimpleSlider.ValueChangedProperty, new Binding("ValueChanged") { Mode = BindingMode.TwoWay });

            #region Brushes
            this.SetBinding(SimpleSlider.LeftRectangleBrushProperty, new Binding("LeftRectangleBrush") { Mode = BindingMode.TwoWay });
            this.SetBinding(SimpleSlider.RightRectangleBrushProperty, new Binding("RightRectangleBrush") { Mode = BindingMode.TwoWay });
            this.SetBinding(SimpleSlider.RegulatorBrushProperty, new Binding("RegulatorBrush") { Mode = BindingMode.TwoWay });
            #endregion

            #region Heights
            this.SetBinding(SimpleSlider.HeightForRectanglesProperty, new Binding("HeightForRectangles") { Mode = BindingMode.TwoWay });
            this.SetBinding(SimpleSlider.HeightForRegulatorProperty, new Binding("HeightForRegulator") { Mode = BindingMode.TwoWay });
            this.SetBinding(SimpleSlider.MainActualHeightProperty, new Binding("MainActualHeight") { Mode = BindingMode.TwoWay });
            this.SetBinding(SimpleSlider.CenterRegulatorActualHightProperty, new Binding("CenterRegulatorActualHight") { Mode = BindingMode.TwoWay });
            this.SetBinding(SimpleSlider.LeftRectangleActualHeightProperty, new Binding("LeftRectangleActualHeight") { Mode = BindingMode.TwoWay });
            this.SetBinding(SimpleSlider.RightRectangleActualHeightProperty, new Binding("RightRectangleActualHeight") { Mode = BindingMode.TwoWay });
            #endregion
        }

        #endregion
    }
}
