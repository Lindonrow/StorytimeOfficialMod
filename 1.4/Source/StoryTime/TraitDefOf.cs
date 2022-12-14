using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;

namespace StoryTime
{
    [DefOf]
    public static class TraitDefOf
    {
        public static TraitDef Buglover;
        public static TraitDef Kind;
        public static TraitDef RareGenius;
        static TraitDefOf() => DefOfHelper.EnsureInitializedInCtor(typeof(ThingDefOf));
    }
}
