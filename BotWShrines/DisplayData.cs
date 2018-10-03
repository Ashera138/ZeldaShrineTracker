using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ZeldaShrineTracker
{
    internal static class DisplayData
    {
        internal static void ShowShrineInfo(string shrineName, List<Shrine> shrines, TextBox textBoxOnForm)
        {
            foreach (Shrine shrine in shrines)
            {
                if (!string.Equals(shrine.Name, shrineName, StringComparison.CurrentCultureIgnoreCase)) continue;
                textBoxOnForm.Text = shrine.Name + Environment.NewLine;
                textBoxOnForm.Text += shrine.Region + Environment.NewLine;
                textBoxOnForm.Text += "Description: " + shrine.Description + Environment.NewLine;
                textBoxOnForm.Text += $"Type: {shrine.Type}{Environment.NewLine}";
                textBoxOnForm.Text += $"Completed?: {shrine.Completed}{Environment.NewLine}";
                textBoxOnForm.Text += $"Notes: {shrine.Notes}";
            }
        }

        internal static void ShowAllShrinesOfType(string type, List<Shrine> shrines, TextBox textBoxOnForm)
        {
            textBoxOnForm.Clear();
            foreach (Shrine shrine in shrines)
            {
                if (shrine.Type == type)
                {
                    if (shrines.IndexOf(shrine) == shrines.Count - 1)
                        textBoxOnForm.Text += shrine.Name;
                    textBoxOnForm.Text += shrine.Name + Environment.NewLine;
                }
            }
        }

        internal static void ShowShrinesInARegion(string region, List<Shrine> shrines, TextBox textBoxOnForm)
        {
            textBoxOnForm.Clear();
            foreach (Shrine shrine in shrines)
            {
                bool completion = shrine.Completed;
                if (shrine.Region == region)
                {
                    textBoxOnForm.Text += $"{shrine.Name} - Completed? {completion}{Environment.NewLine}";
                }
            }
        }

        internal static void ShowNotes(List<Shrine> shrines, TextBox textBoxOnForm)
        {
            textBoxOnForm.Clear();
            foreach (Shrine shrine in shrines)
            {
                if (!string.IsNullOrEmpty(shrine.Notes))
                    textBoxOnForm.Text += $"{shrine.Name} - {shrine.Notes}{Environment.NewLine}";
            }
        }

        internal static void ShowNotes(string queryInput, List<Shrine> shrines, TextBox textBoxOnForm)
        {
            textBoxOnForm.Clear();
            foreach (Shrine shrine in shrines)
            {
                if (shrine.Notes.Contains(queryInput))
                    textBoxOnForm.Text += $"{shrine.Name} - {shrine.Notes}{Environment.NewLine}";
            }
        }
    }
}
