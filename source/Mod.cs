using HarmonyLib;
using Verse;


namespace SK_Unassigned_Beds_Message
{
    public class Mod: Verse.Mod
    {
        public static Harmony instance;

        public Mod(ModContentPack content) : base(content)
        {
            instance = new Harmony("rimworld.sk.unassignedbedsalert");
            LongEventHandler.QueueLongEvent(Init, "Sk.Unassigned_Beds_Message.Init", doAsynchronously: true, null);
        }

        public static void Init()
        {
            instance.PatchAll();
        }
    }
}
