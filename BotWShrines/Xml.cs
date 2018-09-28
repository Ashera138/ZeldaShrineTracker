using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BotWShrines
{
    static class Xml
    {
        public static List<Shrine> CreateShrineList()
        {
            List<Shrine> shrineList = new List<Shrine>();

            string filepath = @"D:\My Documents\ZeldaShrines.xml";

            XmlDocument xdoc = new XmlDocument();
            FileStream rfile = new FileStream(filepath, FileMode.Open);
            xdoc.Load(rfile);
            XmlNodeList shrineNameNodes = xdoc.GetElementsByTagName("ShrineName");

            for (int i = 0; i < shrineNameNodes.Count; i++)
            {
                XmlElement shrineNameEle = (XmlElement)xdoc.GetElementsByTagName("ShrineName")[i];
                XmlElement regionEle = (XmlElement)xdoc.GetElementsByTagName("Region")[i];
                XmlElement descriptionEle = (XmlElement)xdoc.GetElementsByTagName("Description")[i];
                XmlElement typeEle = (XmlElement)xdoc.GetElementsByTagName("Type")[i];
                XmlElement completionEle = (XmlElement)xdoc.GetElementsByTagName("Completion")[i];
                XmlElement notesEle = (XmlElement)xdoc.GetElementsByTagName("Notes")[i];

                string name = shrineNameEle.Attributes[0].InnerText;
                string region = regionEle.InnerText;
                string description;
                string type;
                string completion;
                string notes;

                if (!String.IsNullOrEmpty(descriptionEle.InnerText))
                    description = descriptionEle.InnerText;
                else
                    description = "";

                if (!String.IsNullOrEmpty(typeEle.InnerText))
                    type = typeEle.InnerText;
                else
                    type = "";

                if (!String.IsNullOrEmpty(completionEle.InnerText))
                    completion = completionEle.InnerText;
                else
                    completion = "";

                if (!String.IsNullOrEmpty(notesEle.InnerText))
                    notes = notesEle.InnerText;
                else
                    notes = "";

                shrineList.Add(new Shrine(name, region, description, type, completion, notes));
            }
            rfile.Close();
            return shrineList;
        }

        internal static void SaveChanges(List<Shrine> shrineList)
        {
            string filepath = @"D:\My Documents\ZeldaShrines.xml";

            XmlDocument xdoc = new XmlDocument();
            FileStream rfile = new FileStream(filepath, FileMode.Open);
            xdoc.Load(rfile);

            for (int i = 0; i < shrineList.Count; i++)
            {
                XmlElement descriptionEle = (XmlElement)xdoc.GetElementsByTagName("Description")[i];
                XmlElement typeEle = (XmlElement)xdoc.GetElementsByTagName("Type")[i];
                XmlElement completionEle = (XmlElement)xdoc.GetElementsByTagName("Completion")[i];
                XmlElement notesEle = (XmlElement)xdoc.GetElementsByTagName("Notes")[i];

                descriptionEle.InnerText = shrineList[i].Description;
                typeEle.InnerText = shrineList[i].Type.ToString();
                completionEle.InnerText = shrineList[i].Completion;
                notesEle.InnerText = shrineList[i].Notes;
            }
            rfile.Close();
            xdoc.Save(filepath);
            rfile.Dispose();
        }
    }
}
