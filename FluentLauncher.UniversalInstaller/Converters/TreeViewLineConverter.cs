﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Shapes;

namespace FluentLauncher.UniversalInstaller.Converters;

class TreeViewLineConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        double height = (double)values[0];

        TreeViewItem item = values[2] as TreeViewItem;
        ItemsControl ic = ItemsControl.ItemsControlFromItemContainer(item);
        bool isLastOne = ic.ItemContainerGenerator.IndexFromContainer(item) == ic.Items.Count - 1;

        Rectangle rectangle = values[3] as Rectangle;
        if (isLastOne)
        {
            rectangle.VerticalAlignment = VerticalAlignment.Top;
            return 9.0;
        }
        else
        {
            rectangle.VerticalAlignment = VerticalAlignment.Stretch;
            return double.NaN;
        }
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

