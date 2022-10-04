// Decompiled with JetBrains decompiler
// Type: StoryTime.CompProperties_Rippable
// Assembly: StoryTime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EE405786-011C-4323-A5E5-1846582421B6
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\RimWorld\Mods\Storytime Official Mod\1.3\Assemblies\StoryTime.dll

using Verse;

namespace StoryTime
{
  public class CompProperties_Rippable : CompProperties
  {
    public int ripIntervalDays;
    public int legAmount = 1;
    public ThingDef legDef;

    public CompProperties_Rippable() => this.compClass = typeof (CompRippable);
  }
}
