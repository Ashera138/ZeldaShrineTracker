using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotWShrines
{
    static class DisplayData
    {
        internal static void ShowShrineInfo(string shrineName, List<Shrine> shrineList, TextBox textBoxOnForm)
        {
            foreach (Shrine shrine in shrineList)
            {
                if (shrine.Name.ToUpper() == shrineName.ToUpper())
                {
                    textBoxOnForm.Text = shrine.Name + Environment.NewLine;
                    textBoxOnForm.Text += shrine.Region + Environment.NewLine;
                    textBoxOnForm.Text += "Description: " + shrine.Description + Environment.NewLine;
                    textBoxOnForm.Text += "Type: " + shrine.Type + Environment.NewLine;
                    textBoxOnForm.Text += "Completed?: " + shrine.Completion + Environment.NewLine;
                    textBoxOnForm.Text += "Notes: " + shrine.Notes;
                }
            }
        }

        internal static void ShowAllShrinesOfType(string type, List<Shrine> shrineList, TextBox textBoxOnForm)
        {
            textBoxOnForm.Clear();
            foreach (Shrine shrine in shrineList)
            {
                if (shrine.Type == type)
                {
                    if (shrineList.IndexOf(shrine) == shrineList.Count - 1)
                        textBoxOnForm.Text += shrine.Name;
                    textBoxOnForm.Text += shrine.Name + Environment.NewLine;
                }
            }
        }

        internal static void ShowShrinesInARegion(string region, List<Shrine> shrineList, TextBox textBoxOnForm)
        {
            textBoxOnForm.Clear();
            foreach (Shrine shrine in shrineList)
            {
                string completion = (shrine.Completion == "Yes") ? "Yes" : "No";
                if (shrine.Region == region)
                {
                    textBoxOnForm.Text += shrine.Name+ " - Completed? " + completion + Environment.NewLine;
                }
            }
        }

        internal static void ShowNotes(List<Shrine> shrineList, TextBox textBoxOnForm)
        {
            textBoxOnForm.Clear();
            foreach (Shrine shrine in shrineList)
            {
                if (!string.IsNullOrEmpty(shrine.Notes))
                    textBoxOnForm.Text += shrine.Name + " - " + shrine.Notes + Environment.NewLine;
            }
        }

        internal static void ShowNotes(string queryInput, List<Shrine> shrineList, TextBox textBoxOnForm)
        {
            textBoxOnForm.Clear();
            foreach (Shrine shrine in shrineList)
            {
                if (shrine.Notes.Contains(queryInput))
                    textBoxOnForm.Text += shrine.Name + " - " + shrine.Notes + Environment.NewLine;
            }
        }
    }
}
