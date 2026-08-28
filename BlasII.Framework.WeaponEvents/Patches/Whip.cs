using HarmonyLib;
using Il2CppGame.Components.Attack;
using Il2CppTGK.Game.Components.Attack.Data;

namespace BlasII.Framework.WeaponEvents.Patches;


[HarmonyPatch(typeof(WhipCoreIgnitionModeFiller), nameof(WhipCoreIgnitionModeFiller.OnEnable))]
class WhipCoreIgnitionModeFiller_OnEnable_Patch
{
	private static void Prefix(WhipCoreIgnitionModeFiller __instance)
	{
		Main.WeaponEventsFramework.WhipCoreIgnitionModeFiller = __instance;
	}
}


[HarmonyPatch(typeof(WhipCoreIgnitionModeModifierApplier), nameof(WhipCoreIgnitionModeModifierApplier.OnEnable))]
class WhipCoreIgnitionModeModifierApplier_OnEnable_Patch
{
	private static void Prefix()
	{
		Main.WeaponEventsFramework.WhipHandlersManager.HandleIgnited();
	}
}


[HarmonyPatch(typeof(WhipCoreIgnitionModeModifierApplier), nameof(WhipCoreIgnitionModeModifierApplier.OnModeDeactivated))]
class WhipCoreIgnitionModeModifierApplier_OnModeDeactivated_Patch
{
	private static void Prefix(WeaponEffectID weaponEffectID)
	{
		Main.WeaponEventsFramework.WhipHandlersManager.HandleExtinguished();
	}
}

