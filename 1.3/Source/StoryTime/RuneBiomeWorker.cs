// Decompiled with JetBrains decompiler
// Type: StoryTime.RuneBiomeWorker
// Assembly: StoryTime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EE405786-011C-4323-A5E5-1846582421B6
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\RimWorld\Mods\Storytime Official Mod\1.3\Assemblies\StoryTime.dll

using RimWorld;
using RimWorld.Planet;
using Verse;

namespace StoryTime
{
    public class RuneBiomeWorker : BiomeWorker
    {
        public override float GetScore(Tile tile, int tileID)
        {
            double num1 = 610.0;
            double num2 = -10.0;
            double num3 = 0.007;
            return tile.WaterCovered ? -100f : ((double)tile.temperature > num2 || (double)tile.rainfall > num1 || (double)Rand.Value > num3 ? 0.0f : (float)(70.0 + ((double)tile.temperature - 7.0) + ((double)tile.rainfall - num1) / 180.0));
        }
    }

}
