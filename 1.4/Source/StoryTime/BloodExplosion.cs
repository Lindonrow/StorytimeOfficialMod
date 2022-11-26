
using Verse;

namespace StoryTime
{
    public class DeathActionWorker_BloodExplosion : DeathActionWorker
    {
        public override void PawnDied(Corpse corpse)
        {
            float radius = corpse.InnerPawn.ageTracker.CurLifeStageIndex != 0 ? (corpse.InnerPawn.ageTracker.CurLifeStageIndex != 1 ? 3.9f : 2.9f) : 5.9f;
            GenExplosion.DoExplosion(corpse.Position, corpse.Map, radius, DefDatabase<DamageDef>.GetNamed("BloodExplosion"), (Thing)corpse.InnerPawn, 10, explosionSound: SoundDef.Named("FrogPop"), postExplosionSpawnThingDef: ThingDef.Named("Filth_Blood"), postExplosionSpawnChance: 100f, postExplosionSpawnThingCount: 6);
        }
    }
}
