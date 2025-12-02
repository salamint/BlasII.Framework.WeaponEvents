using BlasII.Framework.WeaponEvents.Handlers;
using BlasII.ModdingAPI;
using Il2CppTGK.Game.Components.Attack.Data;
using System;

namespace BlasII.Framework.WeaponEvents.HandlersManagers;


/// <summary>
/// Manages the handlers for Ruego al Alba.
/// </summary>
public class BladeHandlersManager : AbstractHandlersManager<BladeHandler>
{
	/// <summary>Calls the base class constructor.</summary>
	public BladeHandlersManager() : base() {}

	public override void HandleAttack(AttackID id)
	{
		Handlers.ForEach(handler => handler.OnAttack(id));
	}

	public override void HandleAttackHit(AttackInfo info)
	{
		Handlers.ForEach(handler => handler.OnAttackHit(info));

		BladeAttack attack = (BladeAttack) info.attackID.id;
		if (!Enum.IsDefined(typeof(BladeAttack), attack))
		{
			ModLog.Error($"Error: Unknown attack ID for Ruego al Alba: {info.attackID.id}");
			return;
		}

		switch (attack)
		{
			case BladeAttack.COMBO_1:
				Handlers.ForEach(handler => handler.OnCombo1Hit(info));
				break;
			case BladeAttack.COMBO_2:
				Handlers.ForEach(handler => handler.OnCombo2Hit(info));
				break;
			case BladeAttack.COMBO_3:
				Handlers.ForEach(handler => handler.OnCombo3Hit(info));
				break;
			case BladeAttack.COMBO_3_ASCENDING:
				Handlers.ForEach(handler => handler.OnCombo3AscendingHit(info));
				break;
			case BladeAttack.COMBO_3_SPIN:
				Handlers.ForEach(handler => handler.OnCombo3SpinHit(info));
				break;
			case BladeAttack.COMBO_4:
				Handlers.ForEach(handler => handler.OnCombo4Hit(info));
				break;
			case BladeAttack.COMBO_4_BERSERK:
				/* TODO */
				break;
			case BladeAttack.CROUCH:
				/* TODO */
				break;
			case BladeAttack.AIR_SLASH_1:
				/* TODO */
				break;
			case BladeAttack.AIR_SLASH_2:
				/* TODO */
				break;
			case BladeAttack.RETRIBUTION:
				Handlers.ForEach(handler => handler.OnRetributionHit(info));
				break;
			case BladeAttack.PERFECT_RETRIBUTION:
				Handlers.ForEach(handler => handler.OnPerfectRetributionHit(info));
				break;
			case BladeAttack.BLOODPACT_START:
				Handlers.ForEach(handler => handler.OnBloodPactStartHit(info));
				break;
			case BladeAttack.PLUNGING_STRIKE:
				/* TODO */
				break;
			case BladeAttack.NOT_SO_HIGH_PLUNGING_STRIKE:
				/* TODO */
				break;
			case BladeAttack.HIGH_PLUNGING_STRIKE:
				/* TODO */
				break;
			case BladeAttack.BLOODPACT_SPECIAL:
				/* TODO */
				break;
			case BladeAttack.BLOODPACT_MIDAIR_SPECIAL:
				/* TODO */
				break;
			default:
				ModLog.Error($"Error: Unsupported attack ID for Ruego al Alba: {info.attackID.id}");
				break;
		}
	}

	public void HandleBloodPactStart()
	{
		Handlers.ForEach(handler => handler.OnBloodPactStart());
	}

	public void HandleBloodPactEnd()
	{
		Handlers.ForEach(handler => handler.OnBloodPactEnd());
	}
}

