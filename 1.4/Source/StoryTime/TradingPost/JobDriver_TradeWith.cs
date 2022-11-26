// Decompiled with JetBrains decompiler
// Type: TradingPost.JobDriver_TradeWith
// Assembly: TradingPost, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 44708EF7-3863-45E8-AE80-1929C5AEAD6F
// Assembly location: C:\Program Files (x86)\Steam\steamapps\workshop\content\294100\2631559984\Assemblies\TradingPost.dll

using RimWorld;
using System;
using System.Collections.Generic;
using Verse;
using Verse.AI;

namespace StoryTime
{
  public class JobDriver_TradeWith : JobDriver
  {
    public override bool TryMakePreToilReservations(bool errorOnFailed) => this.pawn.Reserve((LocalTargetInfo) this.TargetThingA, this.job, errorOnFailed: errorOnFailed);

    protected override IEnumerable<Toil> MakeNewToils()
    {
      this.FailOnDespawnedOrNull<JobDriver_TradeWith>(TargetIndex.A);
      yield return Toils_Goto.GotoThing(TargetIndex.A, PathEndMode.InteractionCell);
      Toil trade = new Toil();
      trade.initAction = (Action) (() => Find.WindowStack.Add((Window) new Dialog_Trade(trade.actor, (ITrader) this.TargetThingA.TryGetComp<CompTradingPost>().tradingPost)));
      yield return trade;
    }
  }
}
