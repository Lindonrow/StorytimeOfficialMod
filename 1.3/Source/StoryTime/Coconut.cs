using RimWorld;
using Verse;
using UnityEngine;
using System.Collections.Generic;

namespace StoryTime
{
    public class HediffCompProperties_CoconutDeath : HediffCompProperties
    {
        public string targetCoconut = "";

        public HediffCompProperties_CoconutDeath()
        {
            compClass = typeof(HediffComp_CoconutDeath);
        }
    }

    public class HediffComp_CoconutDeath : HediffComp
    {
        public HediffCompProperties_CoconutDeath Props => (HediffCompProperties_CoconutDeath)props;
        public bool CoconutDeath;

        public override void Notify_PawnDied()
        {
            Map map = parent.pawn.Corpse.MapHeld;
            IntVec3 pos = parent.pawn.Corpse.Position;

            if (map != null)
            {
                CoconutDeath = true;
                if (CoconutDeath)
                {
                    GenSpawn.Spawn(ThingDef.Named(Props.targetCoconut), pos, map, WipeMode.Vanish);
                    parent.pawn.Corpse.Destroy();
                }
            }
        }
    }
}