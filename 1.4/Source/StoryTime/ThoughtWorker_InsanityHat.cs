// Decompiled with JetBrains decompiler
// Type: StoryTime.ThoughtWorker_InsanityHat
// Assembly: StoryTime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EE405786-011C-4323-A5E5-1846582421B6
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\RimWorld\Mods\Storytime Official Mod\1.3\Assemblies\StoryTime.dll

using RimWorld;
using System.Collections.Generic;
using Verse;

namespace StoryTime
{
  public class ThoughtWorker_InsanityHat : ThoughtWorker
  {
    protected override ThoughtState CurrentStateInternal(Pawn p)
    {
      List<Apparel> wornApparel = p.apparel.WornApparel;
      for (int index = 0; index < wornApparel.Count; ++index)
      {
        if (wornApparel[index].def.defName == "Insanity_Hat")
          return ThoughtState.ActiveAtStage(0);
      }
      return ThoughtState.Inactive;
    }
  }
}
