using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace NetworkService.Helper
{
    public static class VisualHelper
    {
        public static T GetParentOfType<T>(this DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            while (parentObject != null)
            {
                if (parentObject is T parent)
                {
                    return parent;
                }

                parentObject = VisualTreeHelper.GetParent(parentObject);
            }

            return null;
        }
    }
}
