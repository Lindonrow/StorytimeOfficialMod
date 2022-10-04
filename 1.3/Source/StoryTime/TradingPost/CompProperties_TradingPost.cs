// Decompiled with JetBrains decompiler
// Type: TradingPost.CompProperties_TradingPost
// Assembly: TradingPost, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 44708EF7-3863-45E8-AE80-1929C5AEAD6F
// Assembly location: C:\Program Files (x86)\Steam\steamapps\workshop\content\294100\2631559984\Assemblies\TradingPost.dll

using RimWorld;
using System.Collections.Generic;
using Verse;

namespace StoryTime
{
  public class CompProperties_TradingPost : CompProperties
  {
    public List<TraderKindDef> traderKinds;
    public int refreshTraderTicks;
    public bool alerts;
    public bool cargoPodsDelivery;
    public TradeMode tradeMode;

    public CompProperties_TradingPost() => this.compClass = typeof (CompTradingPost);
  }
}
