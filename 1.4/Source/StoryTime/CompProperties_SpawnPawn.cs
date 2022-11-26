// Decompiled with JetBrains decompiler
// Type: StoryTime.CompProperties_SpawnPawn
// Assembly: StoryTime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EE405786-011C-4323-A5E5-1846582421B6
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\RimWorld\Mods\Storytime Official Mod\1.3\Assemblies\StoryTime.dll

using RimWorld;
using Verse;

namespace StoryTime
{
  public class CompProperties_SpawnPawn : CompProperties_UseEffect
  {
    public PawnKindDef pawnKind;
    public int amount = 1;
    public FactionDef forcedFaction;
    public bool usePlayerFaction = true;
    public string pawnSpawnedStringKey = "BeanManSpawnedMessage";
    public bool sendMessage = true;

    public CompProperties_SpawnPawn() => this.compClass = typeof (CompUseEffect_SpawnPerson);
  }
}
