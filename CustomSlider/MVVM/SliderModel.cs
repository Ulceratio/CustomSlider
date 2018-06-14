using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CustomSlider.MVVM
{
    class SliderModel
    {
        #region Fields

        private double _HeightForRectangles
        {
            get; set;
        }
        public double HeightForRectangles
        {
            get
            {
                return _HeightForRectangles;
            }
            set
            {
                if (_HeightForRectangles != 0 && value != 0)
                {
                    _HeightForRectangles = value;
                    OnPropertyChanged?.Invoke("HeightForRectangles");
                    RefreshHeights();
                }
                else
                {
                    _HeightForRectangles = value;
                    OnPropertyChanged?.Invoke("HeightForRectangles");
                }
            }
        }

        private double _HeightForRegulator
        {
            get; set;
        }
        public double HeightForRegulator
        {
            get
            {
                return _HeightForRegulator;
            }
            set
            {
                if (_HeightForRegulator != 0 && value != 0)
                {
                    _HeightForRegulator = value;
                    OnPropertyChanged?.Invoke("HeightForRegulator");
                    RefreshHeights();
                }
                else
                {
                    _HeightForRegulator = value;
                    OnPropertyChanged?.Invoke("HeightForRegulator");
                }
            }
        }

        private double _Value
        {
            get;
            set;
        }
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
                LeftPartOfSliderStarWidth = _Value * (LeftPartOfSliderStarWidth + RightPartOfSliderStarWidth);
                RightPartOfSliderStarWidth = (LeftPartOfSliderStarWidth + RightPartOfSliderStarWidth) - (_Value * (LeftPartOfSliderStarWidth + RightPartOfSliderStarWidth));
                OnPropertyChanged("Value");
            }
        }

        private bool _IsMouseDown
        {
            get;
            set;
        }

        private Point PreviousMousePosition
        {
            get;
            set;
        }
        private Point CurrentMousePosition
        {
            get;
            set;
        }

        public event Action<string> Print;

        public event Action ValueChanged;

        #region Widths

        #region ActualWidth

        private double _LeftPartOfSliderActualWidth
        {
            get; set;
        }
        public double LeftPartOfSliderActualWidth
        {
            get
            {
                return _LeftPartOfSliderActualWidth;
            }
            set
            {
                _LeftPartOfSliderActualWidth = value;
                OnPropertyChanged("LeftPartOfSliderActualWidth");
            }
        }

        private double _CenterPartOfSliderActualWidth
        {
            get;
            set;
        }
        public double CenterPartOfSliderActualWidth
        {
            get
            {
                return _CenterPartOfSliderActualWidth;
            }
            set
            {
                _CenterPartOfSliderActualWidth = value;
                OnPropertyChanged("CenterPartOfSliderActualWidth");
            }
        }

        private double _RightPartOfSliderActualWidth
        {
            get;
            set;
        }
        public double RightPartOfSliderActualWidth
        {
            get
            {
                return _RightPartOfSliderActualWidth;
            }
            set
            {
                _RightPartOfSliderActualWidth = value;
                OnPropertyChanged("RightPartOfSliderActualWidth");
            }
        }

        private double MainWidth
        {
            get
            {
                return LeftPartOfSliderActualWidth + CenterPartOfSliderActualWidth + RightPartOfSliderActualWidth;
            }
        }
        #endregion

        #region StarWidth
        private double _LeftPartOfSliderStarWidth
        {
            get;
            set;
        }
        public double LeftPartOfSliderStarWidth
        {
            get
            {
                return _LeftPartOfSliderStarWidth;
            }
            set
            {
                _LeftPartOfSliderStarWidth = value;
                OnPropertyChanged?.Invoke("LeftPartOfSliderStarWidth");
            }
        }

        private double _CenterPartOfSliderStarWidth
        {
            get;
            set;
        }
        public double CenterPartOfSliderStarWidth
        {
            get
            {
                return _CenterPartOfSliderStarWidth;
            }
            set
            {
                _CenterPartOfSliderStarWidth = value;
                OnPropertyChanged?.Invoke("CenterPartOfSliderStarWidth");
            }
        }

        private double _RightPartOfSliderStarWidth
        {
            get;
            set;
        }
        public double RightPartOfSliderStarWidth
        {
            get
            {
                return _RightPartOfSliderStarWidth;
            }
            set
            {
                _RightPartOfSliderStarWidth = value;
                OnPropertyChanged?.Invoke("RightPartOfSliderStarWidth");
            }
        }

        #endregion

        #endregion

        #region Heights
        private double _LeftRectangleActualHeight
        {
            get;
            set;
        }
        public double LeftRectangleActualHeight
        {
            get
            {
                return _LeftRectangleActualHeight;
            }
            set
            {
                _LeftRectangleActualHeight = value;
                OnPropertyChanged?.Invoke("LeftRectangleActualHeight");
            }
        }

        private double _CenterRegulatorActualHight
        {
            get;
            set;
        }
        public double CenterRegulatorActualHight
        {
            get
            {
                return _CenterRegulatorActualHight;
            }
            set
            {
                _CenterRegulatorActualHight = value;
                OnPropertyChanged?.Invoke("CenterRegulatorActualHight");
            }
        }

        private double _RightRectangleActualHeight
        {
            get;
            set;
        }
        public double RightRectangleActualHeight
        {
            get
            {
                return _RightRectangleActualHeight;
            }
            set
            {
                _RightRectangleActualHeight = value;
                OnPropertyChanged?.Invoke("RightRectangleActualHeight");
            }
        }

        public double _MainActualHeight
        {
            get;
            set;
        }
        public double MainActualHeight
        {
            get
            {
                return _MainActualHeight;
            }
            set
            {
                _MainActualHeight = value;
                if (value != 0)
                {
                    RefreshHeights();
                    OnPropertyChanged?.Invoke("MainActualHeight");
                }
            }
        }
        #endregion

        #region Colors

        private SolidColorBrush _LeftRectangleBrush
        {
            get;
            set;
        }
        public SolidColorBrush LeftRectangleBrush
        {
            get
            {
                return _LeftRectangleBrush;
            }
            set
            {
                _LeftRectangleBrush = value;
                OnPropertyChanged?.Invoke("LeftRectangleBrush");
            }
        }

        private SolidColorBrush _RightRectangleBrush
        {
            get;
            set;
        }
        public SolidColorBrush RightRectangleBrush
        {
            get
            {
                return _RightRectangleBrush;
            }
            set
            {
                _RightRectangleBrush = value;
                OnPropertyChanged?.Invoke("RightRectangleBrush");
            }
        }

        private SolidColorBrush _RegulatorBrush
        {
            get;
            set;
        }
        public SolidColorBrush RegulatorBrush
        {
            get
            {
                return _RegulatorBrush;
            }
            set
            {
                _RegulatorBrush = value;
                OnPropertyChanged?.Invoke("RegulatorBrush");
            }
        }
        #endregion

        #endregion

        #region Constructor
        public SliderModel(UserControl userControl, Action<string> action)
        {
            OnPropertyChanged += action;

            LeftPartOfSliderStarWidth = 0.475;
            CenterPartOfSliderStarWidth = 0.05;
            RightPartOfSliderStarWidth = 0.475;

            LeftRectangleBrush = new SolidColorBrush(Color.FromRgb(255, 140, 0));

            RegulatorBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            RightRectangleBrush = new SolidColorBrush(Color.FromRgb(235, 235, 235));

            Init(userControl);

            _IsMouseDown = false;
        }
        #endregion

        #region Events and Funcs

        private void Init(UserControl control)
        {
            control.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));

            control.Arrange(new Rect(0, 0, control.DesiredSize.Width, control.DesiredSize.Height));

            HeightForRectangles = 1.0 / 6.5;

            HeightForRegulator = 1.0 / 2.5;

            RefreshHeights();

            _IsMouseDown = false;

        }

        private void RefreshHeights()
        {
            LeftRectangleActualHeight = (MainActualHeight == 0 ? 1 : MainActualHeight) * HeightForRectangles;

            RightRectangleActualHeight = (MainActualHeight == 0 ? 1 : MainActualHeight) * HeightForRectangles;

            CenterRegulatorActualHight = (MainActualHeight == 0 ? 1 : MainActualHeight) * HeightForRegulator;
        }

        public void RegulatorButtonDown(IInputElement sender, MouseButtonEventArgs e)
        {
            PreviousMousePosition = e.GetPosition(sender);

            _IsMouseDown = true;
        }

        public void RegulatorButtonUp()
        {

            _IsMouseDown = false;

        }

        public void RegulatorMove(IInputElement sender, MouseEventArgs e)
        {
            if (_IsMouseDown)
            {
                CurrentMousePosition = e.GetPosition(sender);

                var Diff = CurrentMousePosition - PreviousMousePosition;

                if (Diff.Length != 0)
                {
                    var percent = Diff.X / MainWidth;

                    var ForLeftPart = LeftPartOfSliderStarWidth + percent;

                    var ForRightPart = RightPartOfSliderStarWidth + percent * -1;

                    var ForCenter = 1 - (LeftPartOfSliderStarWidth + RightPartOfSliderStarWidth);

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
                        LeftPartOfSliderStarWidth = ForLeftPart;

                        RightPartOfSliderStarWidth = ForRightPart;

                        CenterPartOfSliderStarWidth = ForCenter;

                        ValueChanged?.Invoke();
                    }
                    catch
                    { }

                    PreviousMousePosition = CurrentMousePosition;
                }

            }
        }
        #endregion

        #region MVVM
        public event Action<string> OnPropertyChanged;
        #endregion
    }
}
