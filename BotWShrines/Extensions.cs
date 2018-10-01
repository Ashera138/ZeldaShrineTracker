using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaShrineTracker
{
    public static class Extensions
    {
        public static void AddItems(this AutoCompleteStringCollection collection, IEnumerable<string> list)
        {
            foreach (string item in list)
            {
                collection.Add(item);
            }
        }

        public static void ShowControl(this Control control)
        {
            control.Enabled = true;
            control.Visible = true;
        }

        public static void HideControl(this Control control)
        {
            control.Enabled = false;
            control.Visible = false;
        }
    }
}
