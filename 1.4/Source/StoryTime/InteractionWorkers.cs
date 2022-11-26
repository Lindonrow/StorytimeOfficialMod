using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace StoryTime
{
    public class InteractionWorker_StorytimeTalk : InteractionWorker
    {
        public override float RandomSelectionWeight(Pawn initiator, Pawn recipient) => 0.33f;
    }
}
