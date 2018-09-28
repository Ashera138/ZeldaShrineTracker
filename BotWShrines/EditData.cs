using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotWShrines
{
    static class EditData
    {
        internal static void ChangeDescription(string newDescription, ref List<Shrine> shrineList, int shrineToChangeIndex)
        {
            shrineList[shrineToChangeIndex].Description = newDescription;
        }

        internal static void ChangeType(string newType, ref List<Shrine> shrineList, int shrineToChangeIndex)
        {
            shrineList[shrineToChangeIndex].Type = newType;
        }

        internal static void ChangeCompletion(string newCompletion, ref List<Shrine> shrineList, int shrineToChangeIndex)
        {
            shrineList[shrineToChangeIndex].Completion = newCompletion;
        }

        internal static void ChangeNotes(string newNotes, ref List<Shrine> shrineList, int shrineToChangeIndex)
        {
            shrineList[shrineToChangeIndex].Notes = newNotes;
        }
    }
}
