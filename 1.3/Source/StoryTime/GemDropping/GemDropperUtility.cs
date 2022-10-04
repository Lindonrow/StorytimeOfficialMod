// Decompiled with JetBrains decompiler
// Type: PokeWorld.FossilEvoStoneDropperUtility
// Assembly: PokeWorld, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA4A1BCC-9765-4397-A061-B40704682D24
// Assembly location: C:\Program Files (x86)\Steam\steamapps\workshop\content\294100\2652029657\Assemblies\PokeWorld.dll

using System;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace StoryTime
{
	public static class GemDropperUtility
	{
		public static ThingDef TryGetItem(float commonGemDropRate, float uncommonGemDropRate, float rareGemDropRate)
		{
			if (Rand.Value <= commonGemDropRate)
			{
				IEnumerable<ThingDef> evoStones = DefDatabase<ThingDef>.AllDefs.Where((ThingDef x) => x.thingCategories != null && x.thingCategories.Contains(DefDatabase<ThingCategoryDef>.GetNamed("ST_GemsUncut_Common")));
				return evoStones.RandomElement();
			}
			if (Rand.Value <= uncommonGemDropRate)
			{
				IEnumerable<ThingDef> evoStones = DefDatabase<ThingDef>.AllDefs.Where((ThingDef x) => x.thingCategories != null && x.thingCategories.Contains(DefDatabase<ThingCategoryDef>.GetNamed("ST_GemsUncut_Uncommon")));
				return evoStones.RandomElement();
			}
			if (Rand.Value <= rareGemDropRate)
			{
				IEnumerable<ThingDef> evoStones = DefDatabase<ThingDef>.AllDefs.Where((ThingDef x) => x.thingCategories != null && x.thingCategories.Contains(DefDatabase<ThingCategoryDef>.GetNamed("ST_GemsUncut_Rare")));
				return evoStones.RandomElement();
			}
			return null;
		}
	}
}
