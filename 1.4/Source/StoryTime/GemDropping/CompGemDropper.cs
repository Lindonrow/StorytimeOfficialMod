// Decompiled with JetBrains decompiler
// Type: PokeWorld.CompPokFossilsEvoStoneDropper
// Assembly: PokeWorld, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA4A1BCC-9765-4397-A061-B40704682D24
// Assembly location: C:\Program Files (x86)\Steam\steamapps\workshop\content\294100\2652029657\Assemblies\PokeWorld.dll

using Verse;

namespace StoryTime
{
  public class CompGemDropper : ThingComp
  {
    public CompProperties_GemDropper Props => (CompProperties_GemDropper) this.props;

    public float commonGemDropRate => this.Props.commonGemDropRate;
    public float uncommonGemDropRate => this.Props.uncommonGemDropRate;
    public float rareGemDropRate => this.Props.rareGemDropRate;

    }
}
