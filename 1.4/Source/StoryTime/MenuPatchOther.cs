using HarmonyLib;
using System.Reflection;
using Verse;

namespace StoryTime
{
    [StaticConstructorOnStartup]
    public class MenuPatch
    {
        static MenuPatch() => new Harmony("com.jonah.rimworld.mod.storytime").PatchAll(Assembly.GetExecutingAssembly());
    }
}
