// Decompiled with JetBrains decompiler
// Type: StoryTime.JobDefOf
// Assembly: StoryTime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EE405786-011C-4323-A5E5-1846582421B6
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\RimWorld\Mods\Storytime Official Mod\1.3\Assemblies\StoryTime.dll

using RimWorld;
using Verse;

namespace StoryTime
{
  [DefOf]
  public static class JobDefOf
  {
    public static JobDef FrogLegRipping;
    public static JobDef TomatoCutting;
    public static JobDef woodFrogHarvesting;

    static JobDefOf() => DefOfHelper.EnsureInitializedInCtor(typeof (JobDefOf));
  }


}
