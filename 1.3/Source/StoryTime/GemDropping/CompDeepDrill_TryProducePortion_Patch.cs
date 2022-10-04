// Decompiled with JetBrains decompiler
// Type: PokeWorld.CompDeepDrill_TryProducePortion_Patch
// Assembly: PokeWorld, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA4A1BCC-9765-4397-A061-B40704682D24
// Assembly location: C:\Program Files (x86)\Steam\steamapps\workshop\content\294100\2652029657\Assemblies\PokeWorld.dll

using HarmonyLib;
using RimWorld;
using Verse;

namespace StoryTime
{
  [HarmonyPatch(typeof (CompDeepDrill))]
  [HarmonyPatch("TryProducePortion")]
  public class CompDeepDrill_TryProducePortion_Patch
  {
    public static void Postfix(CompDeepDrill __instance)
    {
            CompGemDropper comp = __instance.parent.TryGetComp<CompGemDropper>();
      if (comp == null)
        return;
      ThingDef def = GemDropperUtility.TryGetItem(comp.commonGemDropRate, comp.uncommonGemDropRate, comp.rareGemDropRate);
      if (def != null)
      {
        Thing thing = ThingMaker.MakeThing(def);
        thing.stackCount = 1;
        GenPlace.TryPlaceThing(thing, __instance.parent.Position, __instance.parent.Map, ThingPlaceMode.Near);
        Building parent = __instance.parent as Building;
        Pawn firstPawn = parent.InteractionCell.GetFirstPawn(parent.Map);
        if (firstPawn != null && firstPawn.Faction == Faction.OfPlayer)
          Messages.Message((string) "ST_FoundGem".Translate((NamedArgument) firstPawn.LabelShortCap, (NamedArgument) thing.Label), (LookTargets) thing, MessageTypeDefOf.PositiveEvent);
      }
    }
  }
}
