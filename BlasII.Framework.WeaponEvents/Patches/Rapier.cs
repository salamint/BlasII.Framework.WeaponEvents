using HarmonyLib;
using Il2CppTGK.Game.Components.Attack;
using Il2CppTGK.Game.Components.Attack.Data;

namespace BlasII.Framework.WeaponEvents.Patches;


[HarmonyPatch(typeof(RapierTrueSkillFiller), nameof(RapierTrueSkillFiller.OnEnable))]
class RapierTrueSkillFiller_OnEnable_Patch
{
	private static void Postfix(RapierTrueSkillFiller __instance)
	{
		Main.WeaponEventsFramework.RapierTrueSkillFiller = __instance;
	}
}


[HarmonyPatch(typeof(RapierTrueSkillFiller), nameof(RapierTrueSkillFiller.OnHitReceived))]
class RapierTrueSkillFiller_OnHitReceived_Patch
{
	private static void Prefix(RapierTrueSkillFiller __instance, AttackInfo attackInfo)
	{
		Main.WeaponEventsFramework.RapierHandlersManager.HandleHitReceived(attackInfo);
	}
}


[HarmonyPatch(typeof(RapierTrueSkillModifierApplier), nameof(RapierTrueSkillModifierApplier.OnTSTierChanged))]
class RapierTrueSkillModifierApplier_OnTSTierChanged_Patch
{
	private static void Prefix(WeaponEffectID weaponEffectID, int tier)
	{
		Main.WeaponEventsFramework.RapierHandlersManager.HandleIndicatorChange(tier);
	}
}
