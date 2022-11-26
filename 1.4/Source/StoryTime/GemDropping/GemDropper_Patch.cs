// Decompiled with JetBrains decompiler
// Type: PokeWorld.FossilsEvoStoneDropper_Patch
// Assembly: PokeWorld, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA4A1BCC-9765-4397-A061-B40704682D24
// Assembly location: C:\Program Files (x86)\Steam\steamapps\workshop\content\294100\2652029657\Assemblies\PokeWorld.dll

using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace StoryTime
{
  internal class GemDropper_Patch
  {
    [HarmonyPatch(typeof (Thing))]
    [HarmonyPatch("ButcherProducts")]
    public class Thing_ButcherProducts_Patch
    {
      public static void Postfix(Thing __instance, Pawn __0, ref IEnumerable<Thing> __result)
      {
                CompGemDropper comp = __instance.TryGetComp<CompGemDropper>();
        if (comp == null)
          return;
        ThingDef def = GemDropperUtility.TryGetItem(comp.commonGemDropRate, comp.uncommonGemDropRate, comp.rareGemDropRate);
        if (def != null)
        {
          Thing thing = ThingMaker.MakeThing(def);
          thing.stackCount = 1;
          List<Thing> list = __result.ToList<Thing>();
          list.Add(thing);
          __result = list.AsEnumerable<Thing>();
          if (__0 != null && __0.Faction == Faction.OfPlayer)
            Messages.Message((string) "ST_FoundGem".Translate((NamedArgument) __0.LabelShortCap, (NamedArgument) thing.Label), (LookTargets) thing, MessageTypeDefOf.PositiveEvent);
        }
      }
    }
  }
}
