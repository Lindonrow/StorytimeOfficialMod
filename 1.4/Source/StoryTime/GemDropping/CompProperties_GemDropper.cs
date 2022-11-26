// Decompiled with JetBrains decompiler
// Type: PokeWorld.CompProperties_PokFossilsEvoStoneDropper
// Assembly: PokeWorld, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA4A1BCC-9765-4397-A061-B40704682D24
// Assembly location: C:\Program Files (x86)\Steam\steamapps\workshop\content\294100\2652029657\Assemblies\PokeWorld.dll

using Verse;

namespace StoryTime
{
  public class CompProperties_GemDropper : CompProperties
  {
    public float commonGemDropRate;
    public float uncommonGemDropRate;
    public float rareGemDropRate;

        public CompProperties_GemDropper() => this.compClass = typeof (CompGemDropper);
  }
}
