using HarmonyLib;
using Il2CppTGK.Game.Components;

namespace BlasII.Framework.WeaponEvents.Patches;


[HarmonyPatch(typeof(MeaCulpaBerserkModeFiller), nameof(MeaCulpaBerserkModeFiller.OnEnable))]
class MeaCulpaBerserkModeFiller_OnEnable_Patch
{
	private static void Prefix(MeaCulpaBerserkModeFiller __instance)
	{
		Main.WeaponEventsFramework.MeaCulpaBerserkModeFiller = __instance;
	}
}

