using System.Collections.Generic;

namespace ZeldaShrineTracker
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

        internal static void ChangeCompletion(bool newCompletion, ref List<Shrine> shrineList, int shrineToChangeIndex)
        {
            shrineList[shrineToChangeIndex].Completed = newCompletion;
        }

        internal static void ChangeNotes(string newNotes, ref List<Shrine> shrineList, int shrineToChangeIndex)
        {
            shrineList[shrineToChangeIndex].Notes = newNotes;
        }
    }
}
