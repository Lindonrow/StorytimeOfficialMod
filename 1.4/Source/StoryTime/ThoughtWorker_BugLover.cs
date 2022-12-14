using RimWorld;
using Verse;


namespace StoryTime
{
    public class ThoughtWorker_Buglover : ThoughtWorker
    {
        protected override ThoughtState CurrentSocialStateInternal(Pawn pawn, Pawn other)
        {
            if (!other.RaceProps.Humanlike || !RelationsUtility.PawnsKnowEachOther(pawn, other))
                return (ThoughtState)false;
            if (!other.story.traits.HasTrait(TraitDefOf.Buglover))
                return (ThoughtState)false;
            return (ThoughtState)true;
        }
    }

    public class ThoughtWorker_RareGenius : ThoughtWorker
    {
        protected override ThoughtState CurrentSocialStateInternal(Pawn pawn, Pawn other)
        {
            if (!other.RaceProps.Humanlike || !RelationsUtility.PawnsKnowEachOther(pawn, other))
                return (ThoughtState)false;
            if (!other.story.traits.HasTrait(TraitDefOf.RareGenius))
                return (ThoughtState)false;
            return (ThoughtState)true;
        }
    }
}
