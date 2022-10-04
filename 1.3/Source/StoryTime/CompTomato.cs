// Decompiled with JetBrains decompiler
// Type: StoryTime.CompTomato
// Assembly: StoryTime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EE405786-011C-4323-A5E5-1846582421B6
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\RimWorld\Mods\Storytime Official Mod\1.3\Assemblies\StoryTime.dll

using RimWorld;
using Verse;

namespace StoryTime
{
  public class CompTomato : CompHasGatherableBodyResource
  {
    protected override int GatherResourcesIntervalDays => this.Props.tomatoIntervalDays;

    protected override int ResourceAmount => this.Props.tomatoAmount;

    protected override ThingDef ResourceDef => this.Props.tomatoDef;

    protected override string SaveKey => "woolGrowth";

    public CompProperties_Tomato Props => (CompProperties_Tomato) this.props;

    protected override bool Active
    {
      get
      {
        if (!base.Active)
          return false;
        return !(this.parent is Pawn parent) || parent.ageTracker.CurLifeStage.shearable;
      }
    }

    public override string CompInspectStringExtra() => this.Active ? (string) ("tomatoGrowth".Translate() + ": " + this.Fullness.ToStringPercent()) : (string) null;
  }
}
