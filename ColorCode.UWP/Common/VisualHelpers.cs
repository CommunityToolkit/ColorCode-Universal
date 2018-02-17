using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace ColorCode.Common
{
    public static class VisualHelpers
    {
        /// <summary>
        /// Commandbars causing crashes at the mo
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent"></param>
        /// <param name="deepscan"></param>
        /// <param name="includeCommandBars"></param>
        /// <returns></returns>
        public static T FirstChildofType<T>(DependencyObject parent, bool deepscan = false, bool includeCommandBars = false)
        {
            if (parent == null) return (T)(object)null;
            if (deepscan)
            {
                if (parent is ContentPresenter presenter)
                {
                    var _Child = presenter.Content as DependencyObject;
                    if (_Child is T)
                    {
                        return (T)(object)_Child;
                    }
                    if (!(_Child is CommandBar) || includeCommandBars)
                    {
                        var next = (FirstChildofType<T>(_Child, deepscan));
                        if (next is T)
                        {
                            return ((T)(object)next);
                        }
                    }
                }
                else if (parent is ContentControl control)
                {
                    var _Child = control.Content as DependencyObject;
                    if (_Child is T)
                    {
                        return (T)(object)_Child;
                    }
                    if (!(_Child is CommandBar) || includeCommandBars)
                    {
                        var next = (FirstChildofType<T>(_Child, deepscan));
                        if (next is T)
                        {
                            return ((T)(object)next);
                        }
                    }
                }
            }
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var _Child = VisualTreeHelper.GetChild(parent, i);
                if (_Child is T)
                {
                    return ((T)(object)_Child);
                }
                if (!(_Child is CommandBar) || includeCommandBars)
                {
                    var next = (FirstChildofType<T>(_Child, deepscan));
                    if (next is T)
                    {
                        return ((T)(object)next);
                    }
                }
            }
            return (T)(object)null;
        }
    }
}