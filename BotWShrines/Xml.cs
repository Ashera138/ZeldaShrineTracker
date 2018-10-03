using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ZeldaShrineTracker
{
    internal static class Xml
    {
        private const string _filepath = @"D:\git\ZeldaShrineTracker\BotWShrines\ZeldaShrines.xml";

        internal static IEnumerable<Shrine> GetShrines()
        {
            var xDoc = XDocument.Load(_filepath);
            var shrineElements = xDoc.Descendants("Shrine").ToList();

            for (int i = 0; i < shrineElements.Count(); i++)
            {
                var name = shrineElements[i].Attribute("Name")?.Value;
                var region = shrineElements[i].Attribute("Region")?.Value;
                var description = shrineElements[i].Attribute("Description")?.Value;
                var type = shrineElements[i].Attribute("Type")?.Value;
                var completion = shrineElements[i].Attribute("Completion")?.Value;
                var notes = shrineElements[i].Attribute("Notes")?.Value;
                yield return new Shrine(name, region, description, type, completion, notes);
            }
        }

        internal static void SaveChanges(List<Shrine> shrineList)
        {
            var xDoc = XDocument.Load(_filepath);
            foreach (var shrine in shrineList)
            {
                var matchingShrine = xDoc
                    .Descendants("Shrine")
                    .Single(s => s.Attribute("Name")?.Value == shrine.Name);
                matchingShrine.Attribute("Description").Value = shrine.Description;
                matchingShrine.Attribute("Type").Value = shrine.Type;
                matchingShrine.Attribute("Completion").Value = shrine.Completion;
                matchingShrine.Attribute("Notes").Value = shrine.Notes;
            }

            xDoc.Save(_filepath);
        }
    }
}
