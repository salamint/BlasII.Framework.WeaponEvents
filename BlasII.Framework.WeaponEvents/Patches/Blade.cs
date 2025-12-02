using HarmonyLib;
using Il2CppGame.Components.Attack;
using Il2CppTGK.Game.Components.Attack.Data;

namespace BlasII.Framework.WeaponEvents.Patches;


[HarmonyPatch(typeof(BladeBerserkModeFiller), nameof(BladeBerserkModeFiller.OnEnable))]
class BladeBerserkModeFiller_OnEnable_Patch
{
	private static void Prefix(BladeBerserkModeFiller __instance)
	{
		Main.WeaponEventsFramework.BladeBerserkModeFiller = __instance;
	}
}


[HarmonyPatch(typeof(BladeBerserkModeModifierApplier), nameof(BladeBerserkModeModifierApplier.OnBerserkModeActivated))]
class BladeBerserkModeModifierApplier_OnBerserkModeActivated_Patch
{
	private static void Prefix(WeaponEffectID weaponEffectID)
	{
		Main.WeaponEventsFramework.BladeHandlersManager.HandleBloodPactStart();
	}
}


[HarmonyPatch(typeof(BladeBerserkModeModifierApplier), nameof(BladeBerserkModeModifierApplier.OnBerserkModeDeactivated))]
class BladeBerserkModeModifierApplier_OnBerserkModeDeactivated_Patch
{
	private static void Postfix(WeaponEffectID weaponEffectID)
	{
		Main.WeaponEventsFramework.BladeHandlersManager.HandleBloodPactEnd();
	}
}
