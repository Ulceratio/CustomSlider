using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CustomSlider.MVVM
{
    public class ColumnDefinitionObserver
    {
        public static readonly DependencyProperty ObserveColumnsProperty = DependencyProperty.RegisterAttached(
             "ObserveColumns",
             typeof(bool),
             typeof(ColumnDefinitionObserver),
             new FrameworkPropertyMetadata(OnObserveChanged));

        public static readonly DependencyProperty ObservedFirstColumnWidthProperty = DependencyProperty.RegisterAttached(
            "ObservedFirstColumnWidth",
            typeof(double),
            typeof(ColumnDefinitionObserver));

        public static readonly DependencyProperty ObservedSecondColumnWidthProperty = DependencyProperty.RegisterAttached(
            "ObservedSecondColumnWidth",
            typeof(double),
            typeof(ColumnDefinitionObserver));

        public static readonly DependencyProperty ObservedThirdColumnWidthProperty = DependencyProperty.RegisterAttached(
            "ObservedThirdColumnWidth",
            typeof(double),
            typeof(ColumnDefinitionObserver));

        public static bool GetObserveColumns(FrameworkElement frameworkElement)
        {
            return (bool)frameworkElement.GetValue(ObserveColumnsProperty);
        }

        public static void SetObserveRow(FrameworkElement frameworkElement, bool observe)
        {
            frameworkElement.SetValue(ObserveColumnsProperty, observe);
        }

        #region Gets and Sets for columns

        public static double GetObservedFirstColumnWidth(FrameworkElement frameworkElement)
        {
            return (double)frameworkElement.GetValue(ObservedFirstColumnWidthProperty);
        }

        public static void SetObservedFirstColumnWidth(FrameworkElement frameworkElement, double observedWidth)
        {
            frameworkElement.SetValue(ObservedFirstColumnWidthProperty, observedWidth);
        }


        public static double GetObservedSecondColumnWidth(FrameworkElement frameworkElement)
        {
            return (double)frameworkElement.GetValue(ObservedSecondColumnWidthProperty);
        }

        public static void SetObservedSecondColumnWidth(FrameworkElement frameworkElement, double observedWidth)
        {
            frameworkElement.SetValue(ObservedSecondColumnWidthProperty, observedWidth);
        }


        public static double GetObservedThirdColumnWidth(FrameworkElement frameworkElement)
        {
            return (double)frameworkElement.GetValue(ObservedThirdColumnWidthProperty);
        }

        public static void SetObservedThirdColumnWidth(FrameworkElement frameworkElement, double observedWidth)
        {
            frameworkElement.SetValue(ObservedThirdColumnWidthProperty, observedWidth);
        }

        #endregion

        private static void OnObserveChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var frameworkElement = (FrameworkElement)dependencyObject;

            if ((bool)e.NewValue)
            {
                frameworkElement.SizeChanged += OnFrameworkElementSizeChanged;
                UpdateObservedSizesForFrameworkElement(frameworkElement);
            }
            else
            {
                frameworkElement.SizeChanged -= OnFrameworkElementSizeChanged;
            }
        }

        private static void OnFrameworkElementSizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateObservedSizesForFrameworkElement((FrameworkElement)sender);
        }

        private static void UpdateObservedSizesForFrameworkElement(FrameworkElement frameworkElement)
        {
            Grid g = frameworkElement as Grid;
            if (g != null)
            {
                if (g.ColumnDefinitions.Count > 1)
                {
                    SetObservedFirstColumnWidth(g, g.ColumnDefinitions[0].ActualWidth);
                    SetObservedSecondColumnWidth(g, g.ColumnDefinitions[1].ActualWidth);
                    SetObservedThirdColumnWidth(g, g.ColumnDefinitions[2].ActualWidth);
                }
            }
        }

    }
}
