using RimWorld;
using Verse;

namespace StoryTime
{

    public class CompProperties_Wood : CompProperties
    {
        public int woodHarvestIntervalDays;
        public int woodAmount = 1;
        public ThingDef woodDef;

        public CompProperties_Wood() => this.compClass = typeof(CompWoodFrog);
    }

    public class JobDriver_FrogWood : JobDriver_GatherAnimalBodyResources
    {
        protected override float WorkTotal => 400f;

        protected override CompHasGatherableBodyResource GetComp(
          Pawn animal)
        {
            return (CompHasGatherableBodyResource)animal.TryGetComp<CompWoodFrog>();
        }
    }

    public class CompWoodFrog : CompHasGatherableBodyResource
    {
        protected override int GatherResourcesIntervalDays => this.Props.woodHarvestIntervalDays;

        protected override int ResourceAmount => this.Props.woodAmount;

        protected override ThingDef ResourceDef => this.Props.woodDef;

        protected override string SaveKey => "woolGrowth";

        public CompProperties_Wood Props => (CompProperties_Wood)this.props;

        protected override bool Active
        {
            get
            {
                if (!base.Active)
                    return false;
                return !(this.parent is Pawn parent) || parent.ageTracker.CurLifeStage.shearable;
            }
        }

        public override string CompInspectStringExtra() => this.Active ? (string)("woodGrowth".Translate() + ": " + this.Fullness.ToStringPercent()) : (string)null;
    }

    public class WorkGiver_woodFrog : WorkGiver_GatherAnimalBodyResources
    {
        protected override JobDef JobDef => JobDefOf.woodFrogHarvesting;

        protected override CompHasGatherableBodyResource GetComp(
          Pawn animal)
        {
            return (CompHasGatherableBodyResource)animal.TryGetComp<CompWoodFrog>();
        }
    }
}

