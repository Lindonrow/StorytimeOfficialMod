// Decompiled with JetBrains decompiler
// Type: PokeWorld.Mineable_TrySpawnYield_Patch
// Assembly: PokeWorld, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA4A1BCC-9765-4397-A061-B40704682D24
// Assembly location: C:\Program Files (x86)\Steam\steamapps\workshop\content\294100\2652029657\Assemblies\PokeWorld.dll

using HarmonyLib;
using RimWorld;
using System;
using Verse;

namespace StoryTime
{
  [HarmonyPatch(typeof (Mineable))]
  [HarmonyPatch("TrySpawnYield")]
  public class Mineable_TrySpawnYield_Patch
  {
    public static void Postfix(Mineable __instance, Map __0, Pawn __3)
    {
            CompGemDropper comp = __instance.TryGetComp<CompGemDropper>();
      if (comp == null)
        return;
      ThingDef def = GemDropperUtility.TryGetItem(comp.commonGemDropRate, comp.uncommonGemDropRate, comp.rareGemDropRate);
      if (def != null)
      {
        Thing thing = ThingMaker.MakeThing(def);
        thing.stackCount = 1;
        GenPlace.TryPlaceThing(thing, __instance.Position, __0, ThingPlaceMode.Near, new Action<Thing, int>(ForbidIfNecessary));
        if (__3 != null && __3.Faction == Faction.OfPlayer)
          Messages.Message((string) "ST_FoundGem".Translate((NamedArgument) __3.LabelShortCap, (NamedArgument) thing.Label), (LookTargets) thing, MessageTypeDefOf.PositiveEvent);
      }

      void ForbidIfNecessary(Thing thing, int count)
      {
        if (__3 != null && __3.IsColonist || !thing.def.EverHaulable || thing.def.designateHaulable)
          return;
        thing.SetForbidden(true, false);
      }
    }
  }
}
