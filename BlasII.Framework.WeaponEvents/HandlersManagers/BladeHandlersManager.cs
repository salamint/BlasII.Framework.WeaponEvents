using BlasII.Framework.WeaponEvents.Constants;
using BlasII.Framework.WeaponEvents.Events;
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
	public BladeHandlersManager() : base("Ruego al Alba") {}

	/// <summary>
	/// Handles Ruego al Alba's attacks.
	/// </summary>
	public override void HandleAttack(AttackID id)
	{
		Handlers.ForEach(handler => handler.OnAttack(id));

		BladeAttackID attack = (BladeAttackID) id.id;
		if (!Enum.IsDefined(typeof(BladeAttackID), attack))
		{
			LogUnknownAttackIDError(id);
			return;
		}

		switch (attack)
		{
			case BladeAttackID.COMBO_1:
			case BladeAttackID.COMBO_2:
			case BladeAttackID.COMBO_3:
			case BladeAttackID.COMBO_3_ASCENDING:
			case BladeAttackID.COMBO_3_SPIN:
			case BladeAttackID.COMBO_4:
			case BladeAttackID.COMBO_4_BERSERK:
				HandleComboAttack(attack);
				break;
			case BladeAttackID.CROUCH:
				Handlers.ForEach(handler => handler.OnCrouchAttack());
				break;
			case BladeAttackID.AIR_SLASH_1:
			case BladeAttackID.AIR_SLASH_2:
				HandleMidAirSlashAttack(attack);
				break;
			case BladeAttackID.UP_SLASH:
				Handlers.ForEach(handler => handler.OnUpSlashAttack());
				break;
			case BladeAttackID.NORMAL_RETRIBUTION:
			case BladeAttackID.PERFECT_RETRIBUTION:
				HandleCounterAttack(attack);
				break;
			case BladeAttackID.LOWER_PLUNGING_STRIKE:
			case BladeAttackID.MIDDLE_PLUNGING_STRIKE:
			case BladeAttackID.HIGH_PLUNGING_STRIKE:
				HandlePlungingStrikeAttack(attack);
				break;
			case BladeAttackID.BLOODPACT_START:
			case BladeAttackID.BLOODPACT_SPECIAL_ON_GROUND:
			case BladeAttackID.BLOODPACT_SPECIAL_MIDAIR:
				HandleBloodPactAttack(attack);
				break;
			default:
				LogUnsupportedAttackIDError(id);
				break;
		}
	}

	/// <summary>
	/// Handles Ruego al Alba's attacks when they hit an enemy.
	/// </summary>
	public override void HandleAttackHit(AttackInfo info)
	{
		Handlers.ForEach(handler => handler.OnAttackHit(info));

		BladeAttackID attack = (BladeAttackID) info.attackID.id;
		if (!Enum.IsDefined(typeof(BladeAttackID), attack))
		{
			LogUnknownAttackIDError(info.attackID);
			return;
		}

		switch (attack)
		{
			case BladeAttackID.COMBO_1:
			case BladeAttackID.COMBO_2:
			case BladeAttackID.COMBO_3:
			case BladeAttackID.COMBO_3_ASCENDING:
			case BladeAttackID.COMBO_3_SPIN:
			case BladeAttackID.COMBO_4:
			case BladeAttackID.COMBO_4_BERSERK:
				HandleComboAttackHit(attack, info);
				break;
			case BladeAttackID.CROUCH:
				Handlers.ForEach(handler => handler.OnCrouchAttackHit(info));
				break;
			case BladeAttackID.AIR_SLASH_1:
			case BladeAttackID.AIR_SLASH_2:
				HandleMidAirSlashAttackHit(attack, info);
				break;
			case BladeAttackID.UP_SLASH:
				Handlers.ForEach(handler => handler.OnUpSlashAttackHit(info));
				break;
			case BladeAttackID.NORMAL_RETRIBUTION:
			case BladeAttackID.PERFECT_RETRIBUTION:
				HandleCounterAttackHit(attack, info);
				break;
			case BladeAttackID.LOWER_PLUNGING_STRIKE:
			case BladeAttackID.MIDDLE_PLUNGING_STRIKE:
			case BladeAttackID.HIGH_PLUNGING_STRIKE:
				HandlePlungingStrikeAttackHit(attack, info);
				break;
			case BladeAttackID.BLOODPACT_START:
			case BladeAttackID.BLOODPACT_SPECIAL_ON_GROUND:
			case BladeAttackID.BLOODPACT_SPECIAL_MIDAIR:
				HandleBloodPactAttackHit(attack, info);
				break;
			default:
				LogUnsupportedAttackIDError(info.attackID);
				break;
		}
	}

	/// <summary>
	/// Handles Ruego al Alba's combo attacks, when hitting a target multiple
	/// times.
	/// </summary>
	public void HandleComboAttack(BladeAttackID attack)
	{
		Handlers.ForEach(handler => handler.OnCombo(attack));
		switch (attack)
		{
			case BladeAttackID.COMBO_1:
				Handlers.ForEach(handler => handler.OnCombo1());
				break;
			case BladeAttackID.COMBO_2:
				Handlers.ForEach(handler => handler.OnCombo2());
				break;
			case BladeAttackID.COMBO_3:
				Handlers.ForEach(handler => handler.OnCombo3());
				break;
			case BladeAttackID.COMBO_3_ASCENDING:
				Handlers.ForEach(handler => handler.OnCombo3Ascending());
				break;
			case BladeAttackID.COMBO_3_SPIN:
				Handlers.ForEach(handler => handler.OnCombo3Spin());
				break;
			case BladeAttackID.COMBO_4:
				Handlers.ForEach(handler => handler.OnCombo4());
				Handlers.ForEach(handler => handler.OnCombo4Normal());
				break;
			case BladeAttackID.COMBO_4_BERSERK:
				Handlers.ForEach(handler => handler.OnCombo4());
				Handlers.ForEach(handler => handler.OnCombo4Upgraded());
				break;
		}
	}

	/// <summary>
	/// Handles Ruego al Alba's combo attacks, when hitting a target multiple
	/// times, when they hit.
	/// </summary>
	public void HandleComboAttackHit(BladeAttackID attack, AttackInfo info)
	{
		Handlers.ForEach(handler => handler.OnComboHit(attack, info));
		switch (attack)
		{
			case BladeAttackID.COMBO_1:
				Handlers.ForEach(handler => handler.OnCombo1Hit(info));
				break;
			case BladeAttackID.COMBO_2:
				Handlers.ForEach(handler => handler.OnCombo2Hit(info));
				break;
			case BladeAttackID.COMBO_3:
				Handlers.ForEach(handler => handler.OnCombo3Hit(info));
				break;
			case BladeAttackID.COMBO_3_ASCENDING:
				Handlers.ForEach(handler => handler.OnCombo3AscendingHit(info));
				break;
			case BladeAttackID.COMBO_3_SPIN:
				Handlers.ForEach(handler => handler.OnCombo3SpinHit(info));
				break;
			case BladeAttackID.COMBO_4:
				Handlers.ForEach(handler => handler.OnCombo4Hit(info));
				Handlers.ForEach(handler => handler.OnCombo4NormalHit(info));
				break;
			case BladeAttackID.COMBO_4_BERSERK:
				Handlers.ForEach(handler => handler.OnCombo4Hit(info));
				Handlers.ForEach(handler => handler.OnCombo4UpgradedHit(info));
				break;
			default:
				LogUnsupportedAttackIDError(info.attackID);
				break;
		}
	}

	/// <summary>
	/// Handles Ruego al Alba's mid air slash attacks.
	/// </summary>
	public void HandleMidAirSlashAttack(BladeAttackID attack)
	{
		Handlers.ForEach(handler => handler.OnMidAirSlash(attack));
		switch (attack)
		{
			case BladeAttackID.AIR_SLASH_1:
				Handlers.ForEach(handler => handler.OnMidAirSlash1());
				break;
			case BladeAttackID.AIR_SLASH_2:
				Handlers.ForEach(handler => handler.OnMidAirSlash2());
				break;
		}
	}

	/// <summary>
	/// Handles Ruego al Alba's mid air slash attacks when they hit.
	/// </summary>
	public void HandleMidAirSlashAttackHit(BladeAttackID attack, AttackInfo info)
	{
		Handlers.ForEach(handler => handler.OnMidAirSlashHit(attack, info));
		switch (attack)
		{
			case BladeAttackID.AIR_SLASH_1:
				Handlers.ForEach(handler => handler.OnMidAirSlash1Hit(info));
				break;
			case BladeAttackID.AIR_SLASH_2:
				Handlers.ForEach(handler => handler.OnMidAirSlash2Hit(info));
				break;
			default:
				LogUnsupportedAttackIDError(info.attackID);
				break;
		}
	}

	/// <summary>
	/// Handles Ruego al Alba's counter attacks.
	/// </summary>
	public void HandleCounterAttack(BladeAttackID attack)
	{
		Handlers.ForEach(handler => handler.OnRetribution(attack));
		switch (attack)
		{
			case BladeAttackID.NORMAL_RETRIBUTION:
				Handlers.ForEach(handler => handler.OnNormalRetribution());
				break;
			case BladeAttackID.PERFECT_RETRIBUTION:
				Handlers.ForEach(handler => handler.OnPerfectRetribution());
				break;
		}
	}

	/// <summary>
	/// Handles Ruego al Alba's counter attacks, when the ripostes hit an enemy.
	/// </summary>
	public void HandleCounterAttackHit(BladeAttackID attack, AttackInfo info)
	{
		Handlers.ForEach(handler => handler.OnRetributionHit(attack, info));
		switch (attack)
		{
			case BladeAttackID.NORMAL_RETRIBUTION:
				Handlers.ForEach(handler => handler.OnNormalRetributionHit(info));
				break;
			case BladeAttackID.PERFECT_RETRIBUTION:
				Handlers.ForEach(handler => handler.OnPerfectRetributionHit(info));
				break;
			default:
				LogUnsupportedAttackIDError(info.attackID);
				break;
		}
	}

	/// <summary>
	/// Handles Ruego al Alba's plunge attacks, generated by the player by
	/// attacking down while in the air.
	/// </summary>
	public void HandlePlungingStrikeAttack(BladeAttackID attack)
	{
		Handlers.ForEach(handler => handler.OnPlungingStrike(attack));
		switch (attack)
		{
			case BladeAttackID.LOWER_PLUNGING_STRIKE:
				Handlers.ForEach(handler => handler.OnLowerPlungingStrike());
				break;
			case BladeAttackID.MIDDLE_PLUNGING_STRIKE:
				Handlers.ForEach(handler => handler.OnMiddlePlungingStrike());
				break;
			case BladeAttackID.HIGH_PLUNGING_STRIKE:
				Handlers.ForEach(handler => handler.OnHighPlungingStrike());
				break;
		}
	}

	/// <summary>
	/// Handles Ruego al Alba's plunge attacks, when they hit an enemy.
	/// </summary>
	public void HandlePlungingStrikeAttackHit(BladeAttackID attack, AttackInfo info)
	{
		Handlers.ForEach(handler => handler.OnPlungingStrikeHit(attack, info));
		switch (attack)
		{
			case BladeAttackID.LOWER_PLUNGING_STRIKE:
				Handlers.ForEach(handler => handler.OnLowerPlungingStrikeHit(info));
				break;
			case BladeAttackID.MIDDLE_PLUNGING_STRIKE:
				Handlers.ForEach(handler => handler.OnMiddlePlungingStrikeHit(info));
				break;
			case BladeAttackID.HIGH_PLUNGING_STRIKE:
				Handlers.ForEach(handler => handler.OnHighPlungingStrikeHit(info));
				break;
			default:
				LogUnsupportedAttackIDError(info.attackID);
				break;
		}
	}

	/// <summary>
	/// Handles Reugo al Alba's blood pact attacks.
	/// </summary>
	public void HandleBloodPactAttack(BladeAttackID attack)
	{
		Handlers.ForEach(handler => handler.OnBloodPactAttack(attack));
		switch (attack)
		{
			case BladeAttackID.BLOODPACT_START:
				Handlers.ForEach(handler => handler.OnBloodPactStart());
				break;
			case BladeAttackID.BLOODPACT_SPECIAL_ON_GROUND:
				Handlers.ForEach(handler => handler.OnBloodPactSpecialAttack(attack));
				Handlers.ForEach(handler => handler.OnBloodPactSpecialAttackGround());
				break;
			case BladeAttackID.BLOODPACT_SPECIAL_MIDAIR:
				Handlers.ForEach(handler => handler.OnBloodPactSpecialAttack(attack));
				Handlers.ForEach(handler => handler.OnBloodPactSpecialAttackMidAir());
				break;
		}
	}

	/// <summary>
	/// Handles Reugo al Alba's blood pact attacks when they hit an enemy.
	/// </summary>
	public void HandleBloodPactAttackHit(BladeAttackID attack, AttackInfo info)
	{
		Handlers.ForEach(handler => handler.OnBloodPactAttackHit(attack, info));
		switch (attack)
		{
			case BladeAttackID.BLOODPACT_START:
				Handlers.ForEach(handler => handler.OnBloodPactStartHit(info));
				break;
			case BladeAttackID.BLOODPACT_SPECIAL_ON_GROUND:
				Handlers.ForEach(handler => handler.OnBloodPactSpecialAttackHit(attack, info));
				Handlers.ForEach(handler => handler.OnBloodPactSpecialAttackGroundHit(info));
				break;
			case BladeAttackID.BLOODPACT_SPECIAL_MIDAIR:
				Handlers.ForEach(handler => handler.OnBloodPactSpecialAttackHit(attack, info));
				Handlers.ForEach(handler => handler.OnBloodPactSpecialAttackMidAirHit(info));
				break;
			default:
				LogUnsupportedAttackIDError(info.attackID);
				break;
		}
	}

	/// <summary>
	/// Handle Ruego al Alba's blood pact start.
	/// </summary>
	public void HandleBloodPactStart()
	{
		Handlers.ForEach(handler => handler.OnBloodPactStart());
	}

	/// <summary>
	/// Handle Ruego al Alba's blood pact end.
	/// </summary>
	public void HandleBloodPactEnd()
	{
		Handlers.ForEach(handler => handler.OnBloodPactEnd());
	}
}

