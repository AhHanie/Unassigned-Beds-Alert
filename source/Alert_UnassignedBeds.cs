using RimWorld;
using System.Collections.Generic;
using System.Text;
using Verse;

namespace SK_Unassigned_Beds_Message
{
    public class Alert_UnassignedBeds : Alert
    {
        private List<Pawn> colonistsWithoutBedsResult = new List<Pawn>();
        private StringBuilder sb = new StringBuilder();

        private List<Pawn> ColonistsWithoutBeds
        {
            get
            {
                colonistsWithoutBedsResult.Clear();
                foreach (Pawn pawn in PawnsFinder.AllMaps_FreeColonistsSpawned)
                {
                    if (pawn.ownership != null && pawn.ownership.OwnedBed == null)
                    {
                        colonistsWithoutBedsResult.Add(pawn);
                    }
                }
                return colonistsWithoutBedsResult;
            }
        }

        public Alert_UnassignedBeds()
        {
            defaultLabel = "UnassignedBeds".Translate();
            defaultPriority = AlertPriority.High;
        }

        public override TaggedString GetExplanation()
        {
            sb.Length = 0;
            foreach (Pawn pawn in colonistsWithoutBedsResult)
            {
                sb.AppendLine("  - " + pawn.NameShortColored.Resolve());
            }
            return "UnassignedBedsDesc".Translate(sb.ToString().TrimEndNewlines());
        }

        public override AlertReport GetReport()
        {
            return AlertReport.CulpritsAre(ColonistsWithoutBeds);
        }
    }
}