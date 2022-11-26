// Decompiled with JetBrains decompiler
// Type: StoryTime.PawnKindDefOf
// Assembly: StoryTime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EE405786-011C-4323-A5E5-1846582421B6
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\RimWorld\Mods\Storytime Official Mod\1.3\Assemblies\StoryTime.dll

using RimWorld;
using Verse;

namespace StoryTime
{
  [DefOf]
  public static class PawnKindDefOf
  {
    public static PawnKindDef Jeub;
    public static PawnKindDef Cartographer;
    public static PawnKindDef MoonGibbon;
    public static PawnKindDef NightFrog;
    public static PawnKindDef ManFrog;

    static PawnKindDefOf() => DefOfHelper.EnsureInitializedInCtor(typeof (PawnKindDefOf));
  }
}
