// Decompiled with JetBrains decompiler
// Type: StoryTime.GibbonousMoon_Utility
// Assembly: StoryTime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EE405786-011C-4323-A5E5-1846582421B6
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\RimWorld\Mods\Storytime Official Mod\1.3\Assemblies\StoryTime.dll

using RimWorld;
using UnityEngine;
using Verse;

namespace StoryTime
{
  internal class GibbonousMoon_Utility
  {
    public static void SpawnMoonGibbon(Map map)
    {
      int num1 = Mathf.Clamp(GenMath.RoundRandom(StorytellerUtility.DefaultThreatPointsNow((IIncidentTarget) map) / 100f), 1, Rand.RangeInclusive(1, 5));
      int num2 = Rand.RangeInclusive(45000, 60000);
      IntVec3 result;
      for (int index = 0; index < num1 && RCellFinder.TryFindRandomPawnEntryCell(out result, map, CellFinder.EdgeRoadChance_Animal); ++index)
      {
        IntVec3 loc = CellFinder.RandomClosewalkCellNear(result, map, 10);
        Pawn pawn = PawnGenerator.GeneratePawn(PawnKindDefOf.MoonGibbon);
        GenSpawn.Spawn((Thing) pawn, loc, map, Rot4.Random);
        pawn.mindState.exitMapAfterTick = Find.TickManager.TicksGame + num2;
      }
    }
  }
}
