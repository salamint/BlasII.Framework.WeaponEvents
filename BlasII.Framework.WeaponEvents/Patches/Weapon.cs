using HarmonyLib;
using Il2Cpp;
using Il2CppLightbug.Kinematic2D.Implementation;
using Il2CppTGK.Game.Components.Animation.Events.Player;
using Il2CppTGK.Game.Components.Abilities;
using Il2CppTGK.Game.Components.Attack.Data;
using Il2CppTGK.Game.Components.StatsSystem;

namespace BlasII.Framework.WeaponEvents.Patches;


[HarmonyPatch(typeof(PlayerStatsComponentPersistance), nameof(PlayerStatsComponentPersistance.UpdateFromPrieDieu))]
class PlayerStatsComponentPersistance_UpdateFromPrieDieu_Patch
{
	private static void Prefix(PlayerStatsComponentPersistance __instance)
	{
		Main.WeaponEventsFramework.HandleRestAtPrieDieu();
	}
}


[HarmonyPatch(typeof(UIWeaponController), nameof(UIWeaponController.OnEnable))]
class UIWeaponController_OnEnable_Patch
{
	private static void Prefix(UIWeaponController __instance)
	{
		Main.WeaponEventsFramework.UIWeaponController = __instance;
	}
}


[HarmonyPatch(typeof(ChangeWeaponAbility), nameof(ChangeWeaponAbility.RequestFastChange))]
class ChangeWeaponAbility_RequestFastChange_Patch
{
	private static void Postfix(ChangeWeaponAbility __instance, int slot)
	{
		if (__instance.currentState == AbilityState.READY_FOR_EXECUTION)
		{
			Main.WeaponEventsFramework.UnequipCurrentWeapon();
		}
	}
}


[HarmonyPatch(typeof(ChangeWeaponAbility), nameof(ChangeWeaponAbility.RequestFastChangeNextWeapon))]
class ChangeWeaponAbility_RequestFastChangeNextWeapon_Patch
{
	private static void Postfix(ChangeWeaponAbility __instance)
	{
		if (__instance.currentState == AbilityState.READY_FOR_EXECUTION)
		{
			Main.WeaponEventsFramework.UnequipCurrentWeapon();
		}
	}
}


[HarmonyPatch(typeof(ChangeWeaponAbility), nameof(ChangeWeaponAbility.RequestFastChangePrevWeapon))]
class ChangeWeaponAbility_RequestFastChangePrevWeapon_Patch
{
	private static void Postfix(ChangeWeaponAbility __instance)
	{
		if (__instance.currentState == AbilityState.READY_FOR_EXECUTION)
		{
			Main.WeaponEventsFramework.UnequipCurrentWeapon();
		}
	}
}


[HarmonyPatch(typeof(PlayerWeaponEventsHandler), nameof(PlayerWeaponEventsHandler.OnWeaponChanged))]
class PlayerWeaponEventsHandler_OnWeaponChanged_Patch
{
	private static void Postfix(WeaponsCollection.WeaponChangedEventData weaponData)
	{
		Main.WeaponEventsFramework.EquipNewWeapon(weaponData.ID.id);
	}
}
