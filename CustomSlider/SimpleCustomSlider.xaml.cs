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
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class SimpleSlider : UserControl
    {
        #region Fields
        public double HeightForRectangles
        {
            get
            {
                return (Resources["halfConverter1"] as HalfConverter).Multiplier;
            }
            set
            {
                var ConverterForRectangles = (Resources["halfConverter1"] as HalfConverter);
                ConverterForRectangles.Multiplier = value;                
            }
        }

        public double HeightForRegulator
        {
            get
            {
                return (Resources["halfConverter2"] as HalfConverter).Multiplier;
            }
            set
            {
                var ConverterForRectangles = (Resources["halfConverter2"] as HalfConverter);
                ConverterForRectangles.Multiplier = value;
            }
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
            }
        }

        private bool _IsMouseDown { get; set; }

        private Point PreviousMousePosition { get; set; }
        private Point CurrentMousePosition { get; set; }

        //public event Action<string> Print;

        private double MainWidth
        {
            get
            {
                return GridForSlider.ColumnDefinitions[0].ActualWidth + GridForSlider.ColumnDefinitions[1].ActualWidth + GridForSlider.ColumnDefinitions[2].ActualWidth;
            }
        }


        #endregion

        #region Constructors
        public SimpleSlider()
        {
            InitializeComponent();

            var converter1 = Resources["halfConverter1"] as HalfConverter;

            _IsMouseDown = false;
           
        }
        #endregion

        #region Functions
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
