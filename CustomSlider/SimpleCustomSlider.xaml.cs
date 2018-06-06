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

namespace CustomSlider
{
    public partial class SimpleSlider : UserControl
    {
        #region Fields
        public double HeightForRectangles
        {
            get; set;
        }

        public double HeightForRegulator
        {
            get; set;
        }

        private double _Value { get; set; }
        public double Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
                if (_Value > 1)
                {
                    _Value = 1;
                }
                if (_Value < 0)
                {
                    _Value = 0;
                }
                LeftPartOfSlider.Width = new GridLength(_Value * (LeftPartOfSlider.Width.Value + RightPartOfSlider.Width.Value), GridUnitType.Star);
                RightPartOfSlider.Width = new GridLength((LeftPartOfSlider.Width.Value + RightPartOfSlider.Width.Value) - (_Value * (LeftPartOfSlider.Width.Value + RightPartOfSlider.Width.Value)), GridUnitType.Star);
                ValueChanged?.Invoke();
            }
        }

        private bool _IsMouseDown { get; set; }

        private Point PreviousMousePosition { get; set; }
        private Point CurrentMousePosition { get; set; }

        public event Action<string> Print;

        public event Action ValueChanged;

        private double MainWidth
        {
            get
            {
                return GridForSlider.ColumnDefinitions[0].ActualWidth + GridForSlider.ColumnDefinitions[1].ActualWidth + GridForSlider.ColumnDefinitions[2].ActualWidth;
            }
        }
        #region Colors
        public Color LeftRectangleColor
        {
            get
            {
                return BrushForLeftRectangle.Color;
            }
            set
            {
                BrushForLeftRectangle.Color = value;
            }
        }

        public Color RightRectangleColor
        {
            get
            {
                return ((SolidColorBrush)RightRectangle.Fill).Color;
            }
            set
            {
                ((SolidColorBrush)RightRectangle.Fill).Color = value;
            }
        }

        public Color RegulatorColor
        {
            get
            {
                return ((SolidColorBrush)Regulator.Background).Color;
            }
            set
            {
                ((SolidColorBrush)Regulator.Background).Color = value;
            }
        }
        #endregion

        #endregion

        #region Constructors
        public SimpleSlider()
        {
            InitializeComponent();

            Init();

        }
        #endregion

        #region Functions

        public void Init()
        {
            this.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));

            this.Arrange(new Rect(0, 0, this.DesiredSize.Width, this.DesiredSize.Height));

            HeightForRectangles = 10;

            HeightForRegulator = 30;

            LeftRectangle.Height = MainPartOfSlider.ActualHeight * HeightForRectangles;

            RightRectangle.Height = MainPartOfSlider.ActualHeight * HeightForRectangles;

            Regulator.Height = MainPartOfSlider.ActualHeight * HeightForRegulator;

            _IsMouseDown = false;
        }

        #endregion

        #region Events

        private void Regulator_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PreviousMousePosition = e.GetPosition(this);

            _IsMouseDown = true;
        }

        private void Regulator_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            _IsMouseDown = false;

        }

        private void UserControl_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (_IsMouseDown)
            {
                CurrentMousePosition = e.GetPosition(this);

                var Diff = CurrentMousePosition - PreviousMousePosition;

                var percent = Diff.X / MainWidth;

                var ForLeftPart = LeftPartOfSlider.Width.Value + percent;

                var ForRightPart = RightPartOfSlider.Width.Value + percent * -1;

                var ForCenter = 1 - (LeftPartOfSlider.Width.Value + RightPartOfSlider.Width.Value);

                Value = ForLeftPart * (1 / (ForLeftPart + ForRightPart));

                Print?.Invoke(Value.ToString());

                if (ForLeftPart <= 0)
                {
                    ForLeftPart = 0;
                    ForRightPart = 0.95;
                    ForCenter = 0.05;
                }

                if (ForRightPart <= 0)
                {
                    ForLeftPart = 0.95;
                    ForRightPart = 0;
                    ForCenter = 0.05;
                }

                try
                {
                    LeftPartOfSlider.Width = new GridLength(ForLeftPart, GridUnitType.Star);

                    RightPartOfSlider.Width = new GridLength(ForRightPart, GridUnitType.Star);

                    RegulatorBlock.Width = new GridLength(ForCenter, GridUnitType.Star);
                }
                catch
                { }

                PreviousMousePosition = CurrentMousePosition;
            }
            #endregion

        }
    }
}
