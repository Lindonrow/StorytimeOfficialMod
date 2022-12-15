using Verse;

namespace StoryTime
{
    [StaticConstructorOnStartup]
    public static class StorytimeStartup
    {
        static StorytimeStartup() => Log.Message("God answers to ME");
    }
}
