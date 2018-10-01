using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace ZeldaShrineTracker
{
    internal static class Xml
    {
        private const string _filepath = @"D:\git\ZeldaShrineTracker\BotWShrines\ZeldaShrines.xml";

        internal static IEnumerable<Shrine> GetShrines()
        {
            var xDoc = XDocument.Load(_filepath);
            List<XElement> shrineElements = xDoc.Descendants("Shrine").ToList();

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

        // Change to XDoc and refactor as needed
        internal static void SaveChanges(List<Shrine> shrineList)
        {
            // new
            //var xDoc = XDocument.Load(_filepath);
            //foreach (var shrine in shrineList)
            //{
            //    var test = xDoc.Element(shrine.Name)
            //}
            
            // old
            /*
            XmlDocument xdoc = new XmlDocument();
            FileStream rfile = new FileStream(_filepath, FileMode.Open);
            xdoc.Load(rfile);

            for (int i = 0; i < shrineList.Count; i++)
            {
                XmlElement descriptionEle = (XmlElement)xdoc.GetElementsByTagName("Description")[i];
                XmlElement typeEle = (XmlElement)xdoc.GetElementsByTagName("Type")[i];
                XmlElement completionEle = (XmlElement)xdoc.GetElementsByTagName("Completion")[i];
                XmlElement notesEle = (XmlElement)xdoc.GetElementsByTagName("Notes")[i];

                descriptionEle.InnerText = shrineList[i].Description;
                typeEle.InnerText = shrineList[i].Type;
                completionEle.InnerText = shrineList[i].Completion;
                notesEle.InnerText = shrineList[i].Notes;
            }
            rfile.Close();
            xdoc.Save(_filepath);
            rfile.Dispose();
            */
        }
    }
}
