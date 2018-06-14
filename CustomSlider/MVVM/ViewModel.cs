using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CustomSlider.MVVM
{
    class ViewModel : INotifyPropertyChanged
    {
        #region Fields

        private UserControl userControl { get; set; }

        #region Commands
        private DelegateCommand<MouseButtonEventArgs> _RegulatorButtonDown;
        public DelegateCommand<MouseButtonEventArgs> RegulatorButtonDown
        {
            get
            {
                return _RegulatorButtonDown ?? (_RegulatorButtonDown = new DelegateCommand<MouseButtonEventArgs>(
                new Action<MouseButtonEventArgs>((param) =>
                {
                    model.RegulatorButtonDown(userControl, param);
                })));
            }
        }

        private DelegateCommand<MouseEventArgs> _RegulatorButtonUp;
        public DelegateCommand<MouseEventArgs> RegulatorButtonUp
        {
            get
            {
                return _RegulatorButtonUp ?? (_RegulatorButtonUp = new DelegateCommand<MouseEventArgs>(
                new Action<MouseEventArgs>((param) =>
                {
                    model.RegulatorButtonUp();
                })));
            }
        }

        private DelegateCommand<MouseEventArgs> _RegulatorMove;
        public DelegateCommand<MouseEventArgs> RegulatorMove
        {
            get
            {
                return _RegulatorMove ?? (_RegulatorMove = new DelegateCommand<MouseEventArgs>(
                new Action<MouseEventArgs>((param) =>
                {
                    model.RegulatorMove(userControl, param);
                })));
            }
        }

        #endregion

        private SliderModel model;

        #region Model Fields      

        public double HeightForRectangles
        {
            get
            {
                return model.HeightForRectangles;
            }
            set
            {
                model.HeightForRectangles = value;
            }
        }

        public double HeightForRegulator
        {
            get
            {
                return model.HeightForRegulator;
            }
            set
            {
                model.HeightForRegulator = value;
            }
        }

        #region Heights

        public double CenterRegulatorActualHight
        {
            get
            {
                return model.CenterRegulatorActualHight;
            }
            set
            {
                model.CenterRegulatorActualHight = value;
            }
        }

        public double LeftRectangleActualHeight
        {
            get
            {
                return model.LeftRectangleActualHeight;
            }
            set
            {
                model.LeftRectangleActualHeight = value;
            }
        }

        public double MainActualHeight
        {
            get
            {
                return model.MainActualHeight;
            }
            set
            {
                model.MainActualHeight = value;
            }
        }

        public double RightRectangleActualHeight
        {
            get
            {
                return model.RightRectangleActualHeight;
            }
            set
            {
                model.RightRectangleActualHeight = value;
            }
        }


        #endregion

        #region Widths

        #region Star

        public GridLength RightPartOfSliderStarWidth
        {
            get
            {
                return new GridLength(model.RightPartOfSliderStarWidth, GridUnitType.Star);
            }
            set
            {
                model.RightPartOfSliderStarWidth = value.Value;
            }
        }

        public GridLength LeftPartOfSliderStarWidth
        {
            get
            {
                return new GridLength(model.LeftPartOfSliderStarWidth, GridUnitType.Star);
            }
            set
            {
                model.LeftPartOfSliderStarWidth = value.Value;
            }
        }

        public GridLength CenterPartOfSliderStarWidth
        {
            get
            {
                return new GridLength(model.CenterPartOfSliderStarWidth, GridUnitType.Star);
            }
            set
            {
                model.CenterPartOfSliderActualWidth = value.Value;
            }
        }

        #endregion

        #region Actual

        public double LeftPartOfSliderActualWidth
        {
            get
            {
                return model.LeftPartOfSliderActualWidth;
            }
            set
            {
                model.LeftPartOfSliderActualWidth = value;
            }
        }

        public double RightPartOfSliderActualWidth
        {
            get
            {
                return model.RightPartOfSliderActualWidth;
            }
            set
            {
                model.RightPartOfSliderActualWidth = value;
            }
        }

        public double CenterPartOfSliderActualWidth
        {
            get
            {
                return model.CenterPartOfSliderActualWidth;
            }
            set
            {
                model.CenterPartOfSliderActualWidth = value;
            }
        }

        #endregion

        #endregion

        #region Brushes

        public SolidColorBrush RegulatorBrush
        {
            get
            {
                return model.RegulatorBrush;
            }
            set
            {
                model.RegulatorBrush = value;
            }
        }

        public SolidColorBrush LeftRectangleBrush
        {
            get
            {
                return model.LeftRectangleBrush;
            }
            set
            {
                model.LeftRectangleBrush = value;
            }
        }

        public SolidColorBrush RightRectangleBrush
        {
            get
            {
                return model.RightRectangleBrush;
            }
            set
            {
                model.RightRectangleBrush = value;
            }
        }

        #endregion

        public double Value
        {
            get
            {
                return model.Value;
            }
            set
            {
                model.Value = value;
                //OnPropertyChanged("Value");
            }
        }

        public Action ValueChanged
        {
            set
            {
                model.ValueChanged += value;
            }
        }

        #endregion

        #endregion

        #region Constructors
        public ViewModel(UserControl userControl)
        {
            this.userControl = userControl;
            model = new SliderModel(userControl, OnPropertyChanged);
        }
        #endregion

        #region MVVM
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}
