// Decompiled with JetBrains decompiler
// Type: StoryTime.JobDriver_Tomato
// Assembly: StoryTime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EE405786-011C-4323-A5E5-1846582421B6
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\RimWorld\Mods\Storytime Official Mod\1.3\Assemblies\StoryTime.dll

using RimWorld;
using Verse;

namespace StoryTime
{
  public class JobDriver_Tomato : JobDriver_GatherAnimalBodyResources
  {
    protected override float WorkTotal => 400f;

    protected override CompHasGatherableBodyResource GetComp(
      Pawn animal)
    {
      return (CompHasGatherableBodyResource) animal.TryGetComp<CompTomato>();
    }
  }
}
