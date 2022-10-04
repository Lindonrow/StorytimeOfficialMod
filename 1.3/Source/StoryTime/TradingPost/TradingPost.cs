// Decompiled with JetBrains decompiler
// Type: TradingPost.TradingPost
// Assembly: TradingPost, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 44708EF7-3863-45E8-AE80-1929C5AEAD6F
// Assembly location: C:\Program Files (x86)\Steam\steamapps\workshop\content\294100\2631559984\Assemblies\TradingPost.dll

using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using Verse;
using Verse.AI;
using Verse.AI.Group;

namespace StoryTime
{
  public class TradingPost : IExposable, ITrader, IThingHolder
  {
    public TraderKindDef traderKindDef;
    private ThingOwner things;
    private List<Pawn> soldPrisoners = new List<Pawn>();
    private int randomPriceFactorSeed = -1;
    public ThingWithComps tradingPost;

    public int Silver => this.CountHeldOf(ThingDefOf.Silver);

    public TradeCurrency TradeCurrency => this.TraderKind.tradeCurrency;

    public IThingHolder ParentHolder => (IThingHolder) null;

    public TraderKindDef TraderKind => this.traderKindDef;

    public int RandomPriceFactorSeed => this.randomPriceFactorSeed;

    public float TradePriceImprovementOffsetForPlayer => 0.0f;

    public IEnumerable<Thing> Goods
    {
      get
      {
        CompTradingPost compTradingPost = this.CompTradingPost;
        if (compTradingPost.Props.tradeMode == TradeMode.BuyOnly || compTradingPost.Props.tradeMode == TradeMode.Both)
        {
          for (int i = 0; i < this.things.Count; ++i)
            yield return this.things[i];
        }
        else
        {
          foreach (Thing thing in this.things.Where<Thing>((Func<Thing, bool>) (x => x.def == ThingDefOf.Silver)))
            yield return thing;
        }
      }
    }

    public string TraderName => (string) this.traderKindDef.LabelCap;

    public bool CanTradeNow => true;

    public Faction Faction => (Faction) null;

    public CompTradingPost CompTradingPost => this.tradingPost.TryGetComp<CompTradingPost>();

    public TradingPost()
    {
      this.things = (ThingOwner) new ThingOwner<Thing>((IThingHolder) this);
      this.randomPriceFactorSeed = Rand.RangeInclusive(1, 10000000);
    }

    public TradingPost(ThingWithComps tradingPost, TraderKindDef traderKindDef)
    {
      this.things = (ThingOwner) new ThingOwner<Thing>((IThingHolder) this);
      this.randomPriceFactorSeed = Rand.RangeInclusive(1, 10000000);
      this.tradingPost = tradingPost;
      this.traderKindDef = traderKindDef;
    }

    public void Restock()
    {
      this.things.ClearAndDestroyContents();
      this.GenerateThings();
    }

    public IEnumerable<Thing> ColonyThingsWillingToBuy(Pawn playerNegotiator)
    {
      CompTradingPost compTradingPost = this.CompTradingPost;
      if (compTradingPost.Props.tradeMode == TradeMode.SellOnly || compTradingPost.Props.tradeMode == TradeMode.Both)
      {
        foreach (Thing thing in playerNegotiator.Map.listerThings.AllThings.Where<Thing>((Func<Thing, bool>) (x => x.def.category == ThingCategory.Item && TradeUtility.PlayerSellableNow(x, (ITrader) playerNegotiator) && !x.Position.Fogged(x.Map) && (playerNegotiator.Map.areaManager.Home[x.Position] || x.IsInAnyStorage()) && this.ReachableForTrade(playerNegotiator, x))))
          yield return thing;
        if (playerNegotiator.GetLord() != null)
        {
          foreach (Thing thing in TradeUtility.AllSellableColonyPawns(playerNegotiator.Map).Where<Pawn>((Func<Pawn, bool>) (x => !x.Downed)))
            yield return thing;
        }
      }
      else
      {
        foreach (Thing thing in playerNegotiator.Map.listerThings.ThingsOfDef(ThingDefOf.Silver).Where<Thing>((Func<Thing, bool>) (x => !x.Position.Fogged(x.Map) && (playerNegotiator.Map.areaManager.Home[x.Position] || x.IsInAnyStorage()) && this.ReachableForTrade(playerNegotiator, x))))
          yield return thing;
      }
    }

    private bool ReachableForTrade(Pawn playerNegotiator, Thing thing) => playerNegotiator.Map == thing.Map && playerNegotiator.Map.reachability.CanReach(playerNegotiator.Position, (LocalTargetInfo) thing, PathEndMode.Touch, TraverseMode.PassDoors, Danger.Some);

    public IEnumerable<Pawn> AllSellableColonyPawns(Pawn negotiator)
    {
      foreach (Pawn pawn in negotiator.Map.mapPawns.PrisonersOfColonySpawned)
      {
        if (pawn.guest.PrisonerIsSecure)
        {
          pawn.guest.joinStatus = JoinStatus.JoinAsColonist;
          yield return pawn;
        }
      }
      foreach (Pawn pawn in negotiator.Map.mapPawns.SpawnedPawnsInFaction(Faction.OfPlayer))
      {
        if (negotiator != pawn && (pawn.IsColonistPlayerControlled && pawn.HostFaction == null && !pawn.InMentalState && !pawn.Downed || pawn.IsSlave))
        {
          pawn.guest.joinStatus = JoinStatus.JoinAsColonist;
          yield return pawn;
        }
      }
    }

    public void GenerateThings() => this.things.TryAddRangeOrTransfer((IEnumerable<Thing>) ThingSetMakerDefOf.TraderStock.root.Generate(new ThingSetMakerParams()
    {
      traderDef = this.TraderKind,
      tile = new int?(this.tradingPost.Map.Tile)
    }));

    public void TraderTick()
    {
      for (int index = this.things.Count - 1; index >= 0; --index)
      {
        if (this.things[index] is Pawn thing)
        {
          thing.Tick();
          if (thing.Dead)
            this.things.Remove((Thing) thing);
        }
      }
    }

    public void ExposeData()
    {
      Scribe_Deep.Look<ThingOwner>(ref this.things, "things", (object) this);
      Scribe_Collections.Look<Pawn>(ref this.soldPrisoners, "soldPrisoners", LookMode.Reference);
      Scribe_Values.Look<int>(ref this.randomPriceFactorSeed, "randomPriceFactorSeed");
      Scribe_References.Look<ThingWithComps>(ref this.tradingPost, "tradingPost");
      Scribe_Defs.Look<TraderKindDef>(ref this.traderKindDef, "traderKindDef");
      if (Scribe.mode != LoadSaveMode.PostLoadInit)
        return;
      this.soldPrisoners.RemoveAll((Predicate<Pawn>) (x => x == null));
    }

    public int CountHeldOf(ThingDef thingDef, ThingDef stuffDef = null)
    {
      Thing thing = this.HeldThingMatching(thingDef, stuffDef);
      return thing == null ? 0 : thing.stackCount;
    }

    public void GiveSoldThingToTrader(Thing toGive, int countToGive, Pawn playerNegotiator)
    {
      Thing thing = toGive.SplitOff(countToGive);
      thing.PreTraded(TradeAction.None, playerNegotiator, (ITrader) this);
      Thing mergeWith = TradeUtility.ThingFromStockToMergeWith((ITrader) this, thing);
      if (mergeWith != null)
      {
        if (mergeWith.TryAbsorbStack(thing, false))
          return;
        thing.Destroy();
      }
      else
      {
        if (thing is Pawn pawn && pawn.RaceProps.Humanlike)
          this.soldPrisoners.Add(pawn);
        this.things.TryAddOrTransfer(thing, false);
      }
    }

    public void GiveSoldThingToPlayer(Thing toGive, int countToGive, Pawn playerNegotiator)
    {
      Thing thing = toGive.SplitOff(countToGive);
      thing.PreTraded(TradeAction.PlayerBuys, playerNegotiator, (ITrader) this);
      if (thing is Pawn pawn)
        this.soldPrisoners.Remove(pawn);
      if (this.CompTradingPost.Props.cargoPodsDelivery)
        TradeUtility.SpawnDropPod(DropCellFinder.TradeDropSpot(playerNegotiator.Map), playerNegotiator.Map, thing);
      else
        GenPlace.TryPlaceThing(thing, this.tradingPost.Position, this.tradingPost.Map, ThingPlaceMode.Near);
    }

    private Thing HeldThingMatching(ThingDef thingDef, ThingDef stuffDef)
    {
      for (int index = 0; index < this.things.Count; ++index)
      {
        if (this.things[index].def == thingDef && this.things[index].Stuff == stuffDef)
          return this.things[index];
      }
      return (Thing) null;
    }

    public void ChangeCountHeldOf(ThingDef thingDef, ThingDef stuffDef, int count)
    {
      Thing thing = this.HeldThingMatching(thingDef, stuffDef);
      if (thing == null)
        Log.Error("Changing count of thing trader doesn't have: " + thingDef?.ToString());
      thing.stackCount += count;
    }

    public ThingOwner GetDirectlyHeldThings() => this.things;

    public void GetChildHolders(List<IThingHolder> outChildren) => ThingOwnerUtility.AppendThingHoldersFromThings(outChildren, (IList<Thing>) this.GetDirectlyHeldThings());
  }
}
