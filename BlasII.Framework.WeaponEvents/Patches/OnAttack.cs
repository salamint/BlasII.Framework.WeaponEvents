using BlasII.Framework.WeaponEvents.Constants;
using BlasII.ModdingAPI;
using HarmonyLib;
using Il2CppGame.Components.Attack;
using Il2CppLightbug.Kinematic2D.Implementation;
using Il2CppTGK.Game.Components;
using Il2CppTGK.Game.Components.Attack;
using Il2CppTGK.Game.Components.Attack.Data;
using Il2CppTGK.Game.Components.Attack.Requesters;

namespace BlasII.Framework.WeaponEvents.Patches;

[HarmonyPatch(typeof(SimpleAttackRequester), nameof(SimpleAttackRequester.OnAttack))]
class SimpleAttackRequester_OnAttack_Patch
{
	private static void Prefix(SimpleAttackRequester __instance, AttackID _attack)
	{
		ModLog.Debug($"TEST: ${__instance.name} {__instance.tag}");
		Main.WeaponEventsFramework.HandleAttack(_attack);
	}
}


[HarmonyPatch(typeof(AttackAbility), nameof(AttackAbility.RequestAttack), new[] {typeof(AttackID)})]
class AttackAbility_HandleWeaponAttack_Patch
{
	private static void Prefix(AttackID attackID)
	{
		//ModLog.Debug($"TEST: {attackID.id} {attackID.name}");
	}
}


[HarmonyPatch(typeof(BladeBerserkModeFiller), nameof(BladeBerserkModeFiller.OnAttack))]
class BladeBerserkModeFiller_OnAttack_Patch
{
	private static void Prefix(AttackID attackID)
	{
		Main.WeaponEventsFramework.HandleAttack(attackID);
	}
}


//[HarmonyPatch(typeof(MeaCulpaBerserkModeFiller), nameof(MeaCulpaBerserkModeFiller.OnAttack))]
//class MeaCulpaBerserkModeFiller_OnAttack_Patch
//{
//	private static void Prefix(AttackID attackID)
//	{
//		Main.WeaponEventsFramework.HandleAttack(attackID);
//	}
//}


/// <summary>
/// Called by Censer
/// </summary>
[HarmonyPatch(typeof(SimpleAttackRequester), nameof(SimpleAttackRequester.OnAttackHit))]
class SimpleAttackRequester_OnAttackHit_Patch
{
	private static void Prefix(AttackInfo attackInfo)
	{
		Main.WeaponEventsFramework.HandleAttackHit(attackInfo);
	}
}


/// <summary>
/// Called by Rapiers, Blade and Mea Culpa
/// </summary>
[HarmonyPatch(typeof(HitJump), nameof(HitJump.OnAttackHit))]
class HitJump_OnAttackHit_Patch
{
	private static void Prefix(AttackInfo attackInfo)
	{
		switch (Main.WeaponEventsFramework.CurrentWeapon)
		{
			case Weapon.NONE:
			case Weapon.BLADE:
			case Weapon.RAPIER:
			case Weapon.MEA_CULPA:
				Main.WeaponEventsFramework.HandleAttackHit(attackInfo);
				break;
		}
	}
}

