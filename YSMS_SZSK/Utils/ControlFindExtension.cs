using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace YSMS_SZSK.Utils
{
    public static class ControlFindExtension
    {
        public static IEnumerable<T> FindWindows<T>(this Window parentControl, string name)
        {
            if (parentControl is T)
            {
                if (string.IsNullOrEmpty(name))
                    yield return (T)(object)parentControl;
                else if (parentControl.Name.Contains(name))
                {
                    yield return (T)(object)parentControl;
                    yield break;
                }
            }
            var filteredControlList = from controlList in parentControl.OwnedWindows.OfType<Window>()
                                      where controlList is T || controlList.OwnedWindows.Count > 0
                                      select controlList;
            foreach (Window childControl in filteredControlList)
            {
                foreach (T foundControl in FindWindows<T>(childControl, name))
                {
                    yield return foundControl;
                    if (!string.IsNullOrEmpty(name))
                        yield break;
                }
            }
        }



        public static IEnumerable<T> FindControls<T>(this UserControl parentControl, string name)
        {
            if (parentControl is T)
            {
                if (string.IsNullOrEmpty(name))
                    yield return (T)(object)parentControl;
                else if (parentControl.Name.Contains(name))
                {
                    yield return (T)(object)parentControl;
                    yield break;
                }
            }
            var filteredControlList = from controlList in parentControl.Controls.OfType<UserControl>()
                                      where controlList is T || controlList.Controls.Count > 0
                                      select controlList;
            foreach (UserControl childControl in filteredControlList)
            {
                foreach (T foundControl in FindControls<T>(childControl, name))
                {
                    yield return foundControl;
                    if (!string.IsNullOrEmpty(name))
                        yield break;
                }
            }
        }

    }
}
