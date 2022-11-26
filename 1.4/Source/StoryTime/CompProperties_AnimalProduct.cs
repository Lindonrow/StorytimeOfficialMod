// Decompiled with JetBrains decompiler
// Type: StoryTime.CompProperties_AnimalProduct
// Assembly: StoryTime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EE405786-011C-4323-A5E5-1846582421B6
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\RimWorld\Mods\Storytime Official Mod\1.3\Assemblies\StoryTime.dll

using System.Collections.Generic;
using Verse;

namespace StoryTime
{
  public class CompProperties_AnimalProduct : CompProperties
  {
    public int gatheringIntervalDays = 1;
    public int resourceAmount = 1;
    public ThingDef resourceDef;
    public string customResourceString = "";
    public bool isRandom;
    public List<string> randomItems;
    public List<string> seasonalItems;
    public bool hasAditional;
    public int additionalItemsProb = 1;
    public int additionalItemsNumber = 1;
    public List<string> additionalItems;
  }
}
