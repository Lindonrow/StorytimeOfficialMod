// Decompiled with JetBrains decompiler
// Type: StoryTime.CompRippable
// Assembly: StoryTime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EE405786-011C-4323-A5E5-1846582421B6
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\RimWorld\Mods\Storytime Official Mod\1.3\Assemblies\StoryTime.dll

using RimWorld;
using Verse;

namespace StoryTime
{
  public class CompRippable : CompHasGatherableBodyResource
  {
    protected override int GatherResourcesIntervalDays => this.Props.ripIntervalDays;

    protected override int ResourceAmount => this.Props.legAmount;

    protected override ThingDef ResourceDef => this.Props.legDef;

    protected override string SaveKey => "woolGrowth";

    public CompProperties_Rippable Props => (CompProperties_Rippable) this.props;

    protected override bool Active
    {
      get
      {
        if (!base.Active)
          return false;
        return !(this.parent is Pawn parent) || parent.ageTracker.CurLifeStage.shearable;
      }
    }

    public override string CompInspectStringExtra() => this.Active ? (string) ("legGrowth".Translate() + ": " + this.Fullness.ToStringPercent()) : (string) null;
  }
}
