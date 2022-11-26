// Decompiled with JetBrains decompiler
// Type: TradingPost.CompTradingPost
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
  public class CompTradingPost : ThingComp
  {
    public int lastRestockTick;
    public TradingPost tradingPost;

    public CompProperties_TradingPost Props => this.props as CompProperties_TradingPost;

    public override void PostSpawnSetup(bool respawningAfterLoad)
    {
      base.PostSpawnSetup(respawningAfterLoad);
      if (respawningAfterLoad)
        return;
      this.Restock();
    }

    public override IEnumerable<Gizmo> CompGetGizmosExtra()
    {
      foreach (Gizmo gizmo in base.CompGetGizmosExtra())
        yield return gizmo;
      yield return (Gizmo) new Designator_ZoneAddStockpile_Resources();
    }

    public override IEnumerable<FloatMenuOption> CompFloatMenuOptions(
      Pawn selPawn)
    {
      CompTradingPost compTradingPost = this;
      // ISSUE: reference to a compiler-generated method
      foreach (FloatMenuOption floatMenuOption in base.CompFloatMenuOptions(selPawn))
        yield return floatMenuOption;
      if (!selPawn.CanReach((LocalTargetInfo) (Thing) compTradingPost.parent, PathEndMode.OnCell, Danger.Deadly))
        yield return new FloatMenuOption((string) ("CannotTrade".Translate() + ": " + "NoPath".Translate().CapitalizeFirst()), (Action) null);
      else if (selPawn.skills.GetSkill(SkillDefOf.Social).TotallyDisabled)
        yield return new FloatMenuOption((string) "CannotPrioritizeWorkTypeDisabled".Translate((NamedArgument) SkillDefOf.Social.LabelCap), (Action) null);
      yield return FloatMenuUtility.DecoratePrioritizedTask(new FloatMenuOption((string) "TradeWith".Translate((NamedArgument) (compTradingPost.parent.LabelShort + ", " + compTradingPost.tradingPost.TraderKind.label)), (Action) (() =>
      {
        Job job = JobMaker.MakeJob(TP_DefOf.TP_TradeWith, (LocalTargetInfo) (Thing) this.parent);
        job.playerForced = true;
        selPawn.jobs.TryTakeOrderedJob(job);
        PlayerKnowledgeDatabase.KnowledgeDemonstrated(ConceptDefOf.InteractingWithTraders, KnowledgeAmount.Total);
      }), MenuOptionPriority.InitiateSocial, revalidateClickTarget: ((Thing) compTradingPost.parent)), selPawn, (LocalTargetInfo) (Thing) compTradingPost.parent);
    }

    private void Restock()
    {
      this.tradingPost = new TradingPost(this.parent, this.Props.traderKinds.RandomElement<TraderKindDef>());
      this.tradingPost.Restock();
      this.lastRestockTick = Find.TickManager.TicksGame;
      if (!this.Props.alerts)
        return;
      Find.LetterStack.ReceiveLetter("TP.TradesUpdate".Translate(), "TP.TradesUpdateDesc".Translate(), LetterDefOf.NeutralEvent, (LookTargets) (Thing) this.parent);
    }

    public override void CompTick()
    {
      base.CompTick();
      if (Find.TickManager.TicksGame <= this.lastRestockTick + this.Props.refreshTraderTicks)
        return;
      this.Restock();
    }

    public override void PostExposeData()
    {
      base.PostExposeData();
      Scribe_Values.Look<int>(ref this.lastRestockTick, "lastRestockTick");
      Scribe_Deep.Look<TradingPost>(ref this.tradingPost, "tradingPost");
    }
  }
}
