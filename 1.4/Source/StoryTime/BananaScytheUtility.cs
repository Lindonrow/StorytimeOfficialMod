using RimWorld;
using Verse;
using UnityEngine;
using System.Collections.Generic;

namespace StoryTime
{
    public class HediffCompProperties_Polymorph : HediffCompProperties
    {
        public string targetPolymorph = "";
        public string polymorphLetterLabel = "";
        public string polymorphLetter = "";
        public LetterDef polymorphLetterDef;

        public HediffCompProperties_Polymorph()
        {
            compClass = typeof(HediffComp_Polymorph);
        }
    }

    public class HediffComp_Polymorph : HediffComp
    {
        public HediffCompProperties_Polymorph Props => (HediffCompProperties_Polymorph)props;
        public bool PolymorphDeath;

        public override void Notify_PawnDied()
        {
            Map map = parent.pawn.Corpse.MapHeld;
            IntVec3 pos = parent.pawn.Corpse.Position;

            if (map != null)
            {
                PolymorphDeath = true;
                if (PolymorphDeath)
                {
                    Find.LetterStack.ReceiveLetter(this.Props.polymorphLetterLabel.Translate(),
                        this.Props.polymorphLetter.Translate(parent.pawn),
                        (Props.polymorphLetterDef), null, null, null);

                    GenSpawn.Spawn(ThingDef.Named(Props.targetPolymorph), pos, map, WipeMode.Vanish);
                    FilthMaker.TryMakeFilth(parent.pawn.Position, parent.pawn.Corpse.Map, ThingDefOf.Filth_Blood);
                    parent.pawn.Corpse.Destroy();
                }
            }
        }
    }
}