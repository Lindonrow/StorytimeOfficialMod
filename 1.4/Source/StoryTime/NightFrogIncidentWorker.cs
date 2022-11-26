using RimWorld;
using UnityEngine;
using Verse;

namespace StoryTime
{
    internal class NightFrogIncidentWorker : IncidentWorker
    {
        private static readonly FloatRange CountPerColonistRange = new FloatRange(0.75f, 1.25f);
        private const int MinCount = 1;
        private const int MaxCount = 10;

        protected override bool CanFireNowSub(IncidentParms parms)
        {
            if (!base.CanFireNowSub(parms))
                return false;
            Map target = (Map)parms.target;
            return Find.World.tileTemperatures.SeasonAndOutdoorTemperatureAcceptableFor(target.Tile, PawnKindDefOf.NightFrog.race) && RCellFinder.TryFindRandomPawnEntryCell(out IntVec3 _, target, CellFinder.EdgeRoadChance_Animal);
        }

        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            Map target = (Map)parms.target;
            PawnKindDef nightfrog = PawnKindDefOf.NightFrog;
            IntVec3 result;
            if (!RCellFinder.TryFindRandomPawnEntryCell(out result, target, CellFinder.EdgeRoadChance_Animal))
                return false;
            int num = Mathf.Clamp(GenMath.RoundRandom((float)target.mapPawns.FreeColonistsCount * NightFrogIncidentWorker.CountPerColonistRange.RandomInRange), 1, 10);
            for (int index = 0; index < num; ++index)
            {
                IntVec3 loc = CellFinder.RandomClosewalkCellNear(result, target, 10);
                ((Pawn)GenSpawn.Spawn((Thing)PawnGenerator.GeneratePawn(nightfrog), loc, target)).needs.food.CurLevelPercentage = 1f;
            }
            this.SendStandardLetter("LetterLabelNightFrogsArrived".Translate(), "NightFrogsArrived".Translate(), LetterDefOf.ThreatSmall, parms, (LookTargets)new TargetInfo(result, target));
            return true;
        }
    }
}
