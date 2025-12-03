using HarmonyLib;
using Il2CppTGK.Game.Components;
using Il2CppTGK.Game.Components.Attack;

namespace BlasII.Framework.WeaponEvents.Patches;


[HarmonyPatch(typeof(MeaCulpaBerserkModeFiller), nameof(MeaCulpaBerserkModeFiller.OnEnable))]
class MeaCulpaBerserkModeFiller_OnEnable_Patch
{
	private static void Prefix(MeaCulpaBerserkModeFiller __instance)
	{
		Main.WeaponEventsFramework.MeaCulpaBerserkModeFiller = __instance;
	}
}


[HarmonyPatch(typeof(MeaCulpaPhantomTeleportAbility), nameof(MeaCulpaPhantomTeleportAbility.ResetProjectileSpawnerAttackCooldown))]
class MeaCulpaPhantomTeleportAbility_ResetProjectileSpawnerAttackCooldown_Patch
{
	private static void Prefix(MeaCulpaPhantomTeleportAbility __instance)
	{
		Main.WeaponEventsFramework.MeaCulpaHandlersManager.HandlePhantomProjectileReady();
	}
}

