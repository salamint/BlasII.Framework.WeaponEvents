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
	/// <summary>
	/// Calls the base class constructor.
	/// </summary>
	public BladeHandlersManager() : base() {}

	/// <summary>
	/// </summary>
	public override void HandleAttack(AttackID id)
	{
		Handlers.ForEach(handler => handler.OnAttack(id));

		BladeAttack attack = (BladeAttack) id.id;
		if (!Enum.IsDefined(typeof(BladeAttack), attack))
		{
			ModLog.Error($"Error: Unknown attack ID for Ruego al Alba: {id.id}");
			return;
		}

		switch (attack)
		{
			case BladeAttack.COMBO_1:
			case BladeAttack.COMBO_2:
			case BladeAttack.COMBO_3:
			case BladeAttack.COMBO_3_ASCENDING:
			case BladeAttack.COMBO_3_SPIN:
			case BladeAttack.COMBO_4:
			case BladeAttack.COMBO_4_BERSERK:
				HandleComboAttack(attack);
				break;
			case BladeAttack.CROUCH:
				Handlers.ForEach(handler => handler.OnCrouchAttack());
				break;
			case BladeAttack.AIR_SLASH_1:
			case BladeAttack.AIR_SLASH_2:
				HandleMidAirSlashAttack(attack);
				break;
			case BladeAttack.NORMAL_RETRIBUTION:
			case BladeAttack.PERFECT_RETRIBUTION:
				HandleCounterAttack(attack);
				break;
			case BladeAttack.LOWER_PLUNGING_STRIKE:
			case BladeAttack.MIDDLE_PLUNGING_STRIKE:
			case BladeAttack.HIGH_PLUNGING_STRIKE:
				HandlePlungingStrikeAttack(attack);
				break;
			case BladeAttack.BLOODPACT_START:
			case BladeAttack.BLOODPACT_SPECIAL:
			case BladeAttack.BLOODPACT_MIDAIR_SPECIAL:
				HandleBloodPactAttack(attack);
				break;
			default:
				ModLog.Error($"Error: Unsupported attack ID for Ruego al Alba: {id.id}");
				break;
		}
	}

	/// <summary>
	/// </summary>
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
			case BladeAttack.COMBO_2:
			case BladeAttack.COMBO_3:
			case BladeAttack.COMBO_3_ASCENDING:
			case BladeAttack.COMBO_3_SPIN:
			case BladeAttack.COMBO_4:
			case BladeAttack.COMBO_4_BERSERK:
				HandleComboAttackHit(attack, info);
				break;
			case BladeAttack.CROUCH:
				Handlers.ForEach(handler => handler.OnCrouchAttackHit(info));
				break;
			case BladeAttack.AIR_SLASH_1:
			case BladeAttack.AIR_SLASH_2:
				HandleMidAirSlashAttackHit(attack, info);
				break;
			case BladeAttack.NORMAL_RETRIBUTION:
			case BladeAttack.PERFECT_RETRIBUTION:
				HandleCounterAttackHit(attack, info);
				break;
			case BladeAttack.LOWER_PLUNGING_STRIKE:
			case BladeAttack.MIDDLE_PLUNGING_STRIKE:
			case BladeAttack.HIGH_PLUNGING_STRIKE:
				HandlePlungingStrikeAttackHit(attack, info);
				break;
			case BladeAttack.BLOODPACT_START:
			case BladeAttack.BLOODPACT_SPECIAL:
			case BladeAttack.BLOODPACT_MIDAIR_SPECIAL:
				HandleBloodPactAttackHit(attack, info);
				break;
			default:
				ModLog.Error($"Error: Unsupported attack ID for Ruego al Alba: {info.attackID.id}");
				break;
		}
	}

	/// <summary>
	/// </summary>
	public void HandleComboAttack(BladeAttack attack)
	{
		Handlers.ForEach(handler => handler.OnCombo(attack));
		switch (attack)
		{
			case BladeAttack.COMBO_1:
				Handlers.ForEach(handler => handler.OnCombo1());
				break;
			case BladeAttack.COMBO_2:
				Handlers.ForEach(handler => handler.OnCombo2());
				break;
			case BladeAttack.COMBO_3:
				Handlers.ForEach(handler => handler.OnCombo3());
				break;
			case BladeAttack.COMBO_3_ASCENDING:
				Handlers.ForEach(handler => handler.OnCombo3Ascending());
				break;
			case BladeAttack.COMBO_3_SPIN:
				Handlers.ForEach(handler => handler.OnCombo3Spin());
				break;
			case BladeAttack.COMBO_4:
				Handlers.ForEach(handler => handler.OnCombo4());
				break;
			case BladeAttack.COMBO_4_BERSERK:
				/* TODO */
				break;
			default:
				ModLog.Error($"Error: Unknown combo attack for Ruego al Alba: {attack}");
				break;
		}
	}

	/// <summary>
	/// </summary>
	public void HandleComboAttackHit(BladeAttack attack, AttackInfo info)
	{
		Handlers.ForEach(handler => handler.OnComboHit(attack, info));
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
			default:
				ModLog.Error($"Error: Unknown combo attack for Ruego al Alba: {attack}");
				break;
		}
	}

	/// <summary>
	/// </summary>
	public void HandleMidAirSlashAttack(BladeAttack attack)
	{
		Handlers.ForEach(handler => handler.OnMidAirSlash(attack));
		switch (attack)
		{
			case BladeAttack.AIR_SLASH_1:
				Handlers.ForEach(handler => handler.OnMidAirSlash1());
				break;
			case BladeAttack.AIR_SLASH_2:
				Handlers.ForEach(handler => handler.OnMidAirSlash2());
				break;
			default:
				ModLog.Error($"Error: Unknown mid air slash attack for Ruego al Alba: {attack}");
				break;
		}
	}

	/// <summary>
	/// </summary>
	public void HandleMidAirSlashAttackHit(BladeAttack attack, AttackInfo info)
	{
		Handlers.ForEach(handler => handler.OnMidAirSlashHit(attack, info));
		switch (attack)
		{
			case BladeAttack.AIR_SLASH_1:
				Handlers.ForEach(handler => handler.OnMidAirSlash1Hit(info));
				break;
			case BladeAttack.AIR_SLASH_2:
				Handlers.ForEach(handler => handler.OnMidAirSlash2Hit(info));
				break;
			default:
				ModLog.Error($"Error: Unknown mid air slash attack for Ruego al Alba: {attack}");
				break;
		}
	}

	/// <summary>
	/// </summary>
	public void HandleCounterAttack(BladeAttack attack)
	{
		Handlers.ForEach(handler => handler.OnRetribution(attack));
		switch (attack)
		{
			case BladeAttack.NORMAL_RETRIBUTION:
				Handlers.ForEach(handler => handler.OnNormalRetribution());
				break;
			case BladeAttack.PERFECT_RETRIBUTION:
				Handlers.ForEach(handler => handler.OnPerfectRetribution());
				break;
			default:
				ModLog.Error($"Error: Unknown retribution attack for Ruego al Alba: {attack}");
				break;
		}
	}

	/// <summary>
	/// </summary>
	public void HandleCounterAttackHit(BladeAttack attack, AttackInfo info)
	{
		Handlers.ForEach(handler => handler.OnRetributionHit(attack, info));
		switch (attack)
		{
			case BladeAttack.NORMAL_RETRIBUTION:
				Handlers.ForEach(handler => handler.OnNormalRetributionHit(info));
				break;
			case BladeAttack.PERFECT_RETRIBUTION:
				Handlers.ForEach(handler => handler.OnPerfectRetributionHit(info));
				break;
			default:
				ModLog.Error($"Error: Unknown retribution attack for Ruego al Alba: {attack}");
				break;
		}
	}

	/// <summary>
	/// </summary>
	public void HandlePlungingStrikeAttack(BladeAttack attack)
	{
		Handlers.ForEach(handler => handler.OnPlungingStrike(attack));
		switch (attack)
		{
			case BladeAttack.LOWER_PLUNGING_STRIKE:
				Handlers.ForEach(handler => handler.OnLowerPlungingStrike());
				break;
			case BladeAttack.MIDDLE_PLUNGING_STRIKE:
				Handlers.ForEach(handler => handler.OnMiddlePlungingStrike());
				break;
			case BladeAttack.HIGH_PLUNGING_STRIKE:
				Handlers.ForEach(handler => handler.OnHighPlungingStrike());
				break;
			default:
				ModLog.Error($"Error: Unknown plunging strike attack for Ruego al Alba: {attack}");
				break;
		}
	}

	/// <summary>
	/// </summary>
	public void HandlePlungingStrikeAttackHit(BladeAttack attack, AttackInfo info)
	{
		Handlers.ForEach(handler => handler.OnPlungingStrikeHit(attack, info));
		switch (attack)
		{
			case BladeAttack.LOWER_PLUNGING_STRIKE:
				Handlers.ForEach(handler => handler.OnLowerPlungingStrikeHit(info));
				break;
			case BladeAttack.MIDDLE_PLUNGING_STRIKE:
				Handlers.ForEach(handler => handler.OnMiddlePlungingStrikeHit(info));
				break;
			case BladeAttack.HIGH_PLUNGING_STRIKE:
				Handlers.ForEach(handler => handler.OnHighPlungingStrikeHit(info));
				break;
			default:
				ModLog.Error($"Error: Unknown plunging strike attack for Ruego al Alba: {attack}");
				break;
		}
	}

	/// <summary>
	/// </summary>
	public void HandleBloodPactAttack(BladeAttack attack)
	{
		Handlers.ForEach(handler => handler.OnBloodPactAttack(attack));
		switch (attack)
		{
			case BladeAttack.BLOODPACT_START:
				Handlers.ForEach(handler => handler.OnBloodPactStart());
				break;
			case BladeAttack.BLOODPACT_SPECIAL:
				Handlers.ForEach(handler => handler.OnBloodPactSpecialAttack(attack));
				Handlers.ForEach(handler => handler.OnBloodPactSpecialAttackGround());
				break;
			case BladeAttack.BLOODPACT_MIDAIR_SPECIAL:
				Handlers.ForEach(handler => handler.OnBloodPactSpecialAttack(attack));
				Handlers.ForEach(handler => handler.OnBloodPactSpecialAttackMidAir());
				break;
			default:
				ModLog.Error($"Error: Unknown blood pact attack for Ruego al Alba: {attack}");
				break;
		}
	}

	/// <summary>
	/// </summary>
	public void HandleBloodPactAttackHit(BladeAttack attack, AttackInfo info)
	{
		Handlers.ForEach(handler => handler.OnBloodPactAttackHit(attack, info));
		switch (attack)
		{
			case BladeAttack.BLOODPACT_START:
				Handlers.ForEach(handler => handler.OnBloodPactStartHit(info));
				break;
			case BladeAttack.BLOODPACT_SPECIAL:
				Handlers.ForEach(handler => handler.OnBloodPactSpecialAttackHit(attack, info));
				Handlers.ForEach(handler => handler.OnBloodPactSpecialAttackGroundHit(info));
				break;
			case BladeAttack.BLOODPACT_MIDAIR_SPECIAL:
				Handlers.ForEach(handler => handler.OnBloodPactSpecialAttackHit(attack, info));
				Handlers.ForEach(handler => handler.OnBloodPactSpecialAttackMidAirHit(info));
				break;
			default:
				ModLog.Error($"Error: Unknown blood pact attack for Ruego al Alba: {attack}");
				break;
		}
	}

	/// <summary>
	/// </summary>
	public void HandleBloodPactStart()
	{
		Handlers.ForEach(handler => handler.OnBloodPactStart());
	}

	/// <summary>
	/// </summary>
	public void HandleBloodPactEnd()
	{
		Handlers.ForEach(handler => handler.OnBloodPactEnd());
	}
}

