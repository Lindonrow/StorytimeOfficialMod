// Decompiled with JetBrains decompiler
// Type: StoryTime.IncidentWorker_JeubSwarm
// Assembly: StoryTime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EE405786-011C-4323-A5E5-1846582421B6
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\RimWorld\Mods\Storytime Official Mod\1.3\Assemblies\StoryTime.dll

using RimWorld;
using System.Collections.Generic;
using Verse;

namespace StoryTime
{
  public class IncidentWorker_JeubSwarm : IncidentWorker
  {
    private const float PointsFactor = 1f;
    private const int AnimalsStayDurationMin = 60000;
    private const int AnimalsStayDurationMax = 120000;

    protected override bool CanFireNowSub(IncidentParms parms)
    {
      if (!base.CanFireNowSub(parms))
        return false;
      Map target = (Map) parms.target;
      return ManhunterPackIncidentUtility.TryFindManhunterAnimalKind(parms.points, target.Tile, out PawnKindDef _) && RCellFinder.TryFindRandomPawnEntryCell(out IntVec3 _, target, CellFinder.EdgeRoadChance_Animal);
    }

    protected override bool TryExecuteWorker(IncidentParms parms)
    {
      Map target = (Map) parms.target;
      PawnKindDef animalKind = PawnKindDefOf.Jeub;
      if (animalKind == null && !ManhunterPackIncidentUtility.TryFindManhunterAnimalKind(parms.points, target.Tile, out animalKind) || ManhunterPackIncidentUtility.GetAnimalsCount(animalKind, parms.points) == 0)
        return false;
      IntVec3 result = parms.spawnCenter;
      if (!result.IsValid && !RCellFinder.TryFindRandomPawnEntryCell(out result, target, CellFinder.EdgeRoadChance_Animal))
        return false;
      List<Pawn> animalsNewTmp = ManhunterPackIncidentUtility.GenerateAnimals(animalKind, target.Tile, parms.points * 3f, parms.pawnCount);
      Rot4 rot = Rot4.FromAngleFlat((target.Center - result).AngleFlat);
      for (int index = 0; index < animalsNewTmp.Count; ++index)
      {
        Pawn pawn = animalsNewTmp[index];
        QuestUtility.AddQuestTag((object) GenSpawn.Spawn((Thing) pawn, CellFinder.RandomClosewalkCellNear(result, target, 10), target, rot), parms.questTag);
        pawn.health.AddHediff(HediffDefOf.Scaria);
        pawn.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.ManhunterPermanent, (string) null, false, false, (Pawn) null, false);
        pawn.mindState.exitMapAfterTick = Find.TickManager.TicksGame + Rand.Range(60000, 120000);
      }
      this.SendStandardLetter("LetterLabelJeubSwarm".Translate(), "JeubSwarm".Translate((NamedArgument) animalKind.GetLabelPlural()), LetterDefOf.ThreatBig, parms, (LookTargets) (Thing) animalsNewTmp[0]);
      Find.TickManager.slower.SignalForceNormalSpeedShort();
      LessonAutoActivator.TeachOpportunity(ConceptDefOf.ForbiddingDoors, OpportunityType.Critical);
      LessonAutoActivator.TeachOpportunity(ConceptDefOf.AllowedAreas, OpportunityType.Important);
      return true;
    }
  }
}
