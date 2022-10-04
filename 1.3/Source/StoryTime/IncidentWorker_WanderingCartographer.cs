// Decompiled with JetBrains decompiler
// Type: StoryTime.IncidentWorker_WanderingCartographer
// Assembly: StoryTime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EE405786-011C-4323-A5E5-1846582421B6
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\RimWorld\Mods\Storytime Official Mod\1.3\Assemblies\StoryTime.dll

using RimWorld;
using Verse;

namespace StoryTime
{
  public class IncidentWorker_WanderingCartographer : IncidentWorker
  {
    protected override bool CanFireNowSub(IncidentParms parms)
    {
      if (!base.CanFireNowSub(parms))
        return false;
      Map target = (Map) parms.target;
      return !target.gameConditionManager.ConditionIsActive(GameConditionDefOf.ToxicFallout) && target.mapTemperature.SeasonAndOutdoorTemperatureAcceptableFor(ThingDefOf.Cartographer) && this.TryFindEntryCell(target, out IntVec3 _);
    }

    protected override bool TryExecuteWorker(IncidentParms parms)
    {
      Map target = (Map) parms.target;
      IntVec3 cell;
      if (!this.TryFindEntryCell(target, out cell))
        return false;
      PawnKindDef cartographer = PawnKindDefOf.Cartographer;
      int num1 = 1;
      int num2 = Rand.RangeInclusive(90000, 150000);
      IntVec3 result = IntVec3.Invalid;
      if (!RCellFinder.TryFindRandomCellOutsideColonyNearTheCenterOfTheMap(cell, target, 10f, out result))
        result = IntVec3.Invalid;
      Pawn pawn = (Pawn) null;
      for (int index = 0; index < num1; ++index)
      {
        IntVec3 loc = CellFinder.RandomClosewalkCellNear(cell, target, 10);
        pawn = PawnGenerator.GeneratePawn(cartographer);
        GenSpawn.Spawn((Thing) pawn, loc, target, Rot4.Random);
        pawn.mindState.exitMapAfterTick = Find.TickManager.TicksGame + num2;
        if (result.IsValid)
          pawn.mindState.forcedGotoPosition = CellFinder.RandomClosewalkCellNear(result, target, 10);
      }
      Find.LetterStack.ReceiveLetter("LetterLabelWanderingCartographer".Translate(), "WanderingCartographer".Translate(), LetterDefOf.PositiveEvent, (LookTargets) (Thing) pawn);
      return true;
    }

    private bool TryFindEntryCell(Map map, out IntVec3 cell) => RCellFinder.TryFindRandomPawnEntryCell(out cell, map, CellFinder.EdgeRoadChance_Animal + 0.2f);
  }
}
