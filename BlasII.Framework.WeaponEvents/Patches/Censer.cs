using HarmonyLib;
using Il2CppTGK.Game.Components.Attack;

namespace BlasII.Framework.WeaponEvents.Patches;


[HarmonyPatch(typeof(CenserIgniter), nameof(CenserIgniter.Start))]
class CenserIgniter_Start_Patch
{
	private static void Prefix(CenserIgniter __instance)
	{
		Main.WeaponEventsFramework.CenserIgniter = __instance;
	}
}


[HarmonyPatch(typeof(CenserIgniter), nameof(CenserIgniter.EnableIgnitionEffects))]
class CenserIgniter_EnableIgnitionEffects_Patch
{
	private static void Prefix(CenserIgniter __instance)
	{
		Main.WeaponEventsFramework.CenserHandlersManager.HandleIgnition();
	}
}


[HarmonyPatch(typeof(CenserIgniter), nameof(CenserIgniter.DisableIgnitionEffects))]
class CenserIgniter_DisableIgnitionEffects_Patch
{
	private static void Prefix(CenserIgniter __instance)
	{
		Main.WeaponEventsFramework.CenserHandlersManager.HandleExtinguish();
	}
}

