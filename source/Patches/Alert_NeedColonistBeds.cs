using HarmonyLib;
using RimWorld;

namespace SK_Unassigned_Beds_Message.Patches
{
    public static class Alert_NeedColonistBedsPatches
    {
        [HarmonyPatch(typeof(Alert_NeedColonistBeds), "GetReport")]
        public static class GetReport
        {
            public static bool Prefix()
            {
                return false;
            }
        }
    }
}
