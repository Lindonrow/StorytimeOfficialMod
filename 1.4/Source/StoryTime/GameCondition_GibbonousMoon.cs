// Decompiled with JetBrains decompiler
// Type: StoryTime.GameCondition_GibbonousMoon
// Assembly: StoryTime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EE405786-011C-4323-A5E5-1846582421B6
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\RimWorld\Mods\Storytime Official Mod\1.3\Assemblies\StoryTime.dll

using RimWorld;
using UnityEngine;
using Verse;

namespace StoryTime
{
  internal class GameCondition_GibbonousMoon : GameCondition
  {
    private SkyColorSet GibbonMoonSkyColors = new SkyColorSet(new Color(0.403f, 0.6f, 0.8f), Color.white, new Color(0.6f, 0.6f, 0.6f), 1f);
    private int currentTicks = 295;
    private int ticksPerEvent = 3000;
    private bool gibbonMoonBegun = false;

    public override float SkyGazeChanceFactor(Map map) => 8f;

    public override float SkyGazeJoyGainFactor(Map map) => 5f;

    public override int TransitionTicks => 300;

    public override float SkyTargetLerpFactor(Map map) => GameConditionUtility.LerpInOutValue((GameCondition) this, (float) this.TransitionTicks);

    public override Verse.SkyTarget? SkyTarget(Map map) => new Verse.SkyTarget?(new Verse.SkyTarget(0.8f, this.GibbonMoonSkyColors, 1f, 0.0f));

    public override void ExposeData()
    {
      base.ExposeData();
      Scribe_Values.Look<int>(ref this.currentTicks, "currentTicks");
      Scribe_Values.Look<int>(ref this.ticksPerEvent, "ticksPerEvent", 3000);
      Scribe_Values.Look<bool>(ref this.gibbonMoonBegun, "gibbonMoonBegun");
    }

    public override void GameConditionTick()
    {
      if (!this.gibbonMoonBegun && this.currentTicks <= this.TransitionTicks)
      {
        foreach (Map affectedMap in this.AffectedMaps)
          GibbonousMoon_Utility.SpawnMoonGibbon(affectedMap);
      }
      ++this.currentTicks;
    }

    public override void End()
    {
      base.End();
      if (!this.AffectedMaps.NullOrEmpty<Map>())
        ;
    }
  }
}
