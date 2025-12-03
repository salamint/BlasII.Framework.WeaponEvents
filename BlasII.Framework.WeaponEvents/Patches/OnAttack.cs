using BlasII.Framework.WeaponEvents.Constants;
using HarmonyLib;
using Il2CppTGK.Game.Components.Attack;
using Il2CppTGK.Game.Components.Attack.Data;
using Il2CppTGK.Game.Components.Attack.Requesters;

namespace BlasII.Framework.WeaponEvents.Patches;

[HarmonyPatch(typeof(AttacksTable), nameof(AttacksTable.IsAttackHandledByTimes))]
class AttacksTable_TryGetAttackID_Patch_4
{
	private static void Prefix(AttacksTable __instance, AttackID attack)
	{
		if (!PlayerAttackTable.Contains(__instance.name))
			return;
		Main.WeaponEventsFramework.HandleAttack(attack);
	}
}


/// <summary>
/// Called by Censer
/// </summary>
[HarmonyPatch(typeof(SimpleAttackRequester), nameof(SimpleAttackRequester.OnAttackHit))]
class SimpleAttackRequester_OnAttackHit_Patch
{
	private static void Prefix(SimpleAttackRequester __instance, AttackInfo attackInfo)
	{
		if (__instance.attackAbility.characterBody.name != "#Main Player")
			return;

		if (__instance.attackAbility.attacks.name == PlayerAttackTable.CENSER)
		{
			Main.WeaponEventsFramework.HandleAttackHit(attackInfo);
		}
	}
}


/// <summary>
/// Called by Rapiers, Blade and Mea Culpa
/// </summary>
[HarmonyPatch(typeof(HitJump), nameof(HitJump.OnAttackHit))]
class HitJump_OnAttackHit_Patch
{
	private static void Prefix(HitJump __instance, AttackInfo attackInfo)
	{
		if (__instance.jumpAbility.characterBody.name != "#Main Player")
			return;

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
