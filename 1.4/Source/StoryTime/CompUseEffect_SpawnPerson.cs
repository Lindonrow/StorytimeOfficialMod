// Decompiled with JetBrains decompiler
// Type: StoryTime.CompUseEffect_SpawnPerson
// Assembly: StoryTime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EE405786-011C-4323-A5E5-1846582421B6
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\RimWorld\Mods\Storytime Official Mod\1.3\Assemblies\StoryTime.dll

using RimWorld;
using Verse;

namespace StoryTime
{
  public class CompUseEffect_SpawnPerson : CompUseEffect
  {
    public override float OrderPriority => 1000f;

    public CompProperties_SpawnPawn SpawnerProps => this.props as CompProperties_SpawnPawn;

    public virtual void DoSpawn(Pawn usedBy)
    {
      Pawn pawn = PawnGenerator.GeneratePawn(this.SpawnerProps.pawnKind, Faction.OfPlayer);
      if (pawn == null)
        return;
      GenPlace.TryPlaceThing((Thing) pawn, this.parent.Position, this.parent.Map, ThingPlaceMode.Near);
      if (!this.SpawnerProps.sendMessage)
        return;
      Messages.Message((string) "BeanSpawned".Translate((NamedArgument) pawn.Name.ToStringFull), MessageTypeDefOf.NeutralEvent);
    }

    public override void DoEffect(Pawn usedBy)
    {
      base.DoEffect(usedBy);
      for (int index = 0; index < this.SpawnerProps.amount; ++index)
        this.DoSpawn(usedBy);
    }
  }
}
