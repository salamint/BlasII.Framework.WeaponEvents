using System;
using BlasII.Framework.WeaponEvents.Constants;
using BlasII.Framework.WeaponEvents.Events;
using Il2CppTGK.Game.Components.Attack.Data;

namespace BlasII.Framework.WeaponEvents.HandlersManagers;

/// <summary>
/// Manages the handlers for Veredicto.
/// </summary>
public class CenserHandlersManager : AbstractHandlersManager<CenserHandler>
{
	/// <summary>Calls the base class constructor.</summary>
	public CenserHandlersManager() : base("Veredicto") {}

	/// <summary>
	/// Calls the corresponding methods for Veredicto's attacks.
	/// </summary>
	public override void HandleAttack(AttackID id)
	{
		Handlers.ForEach(handler => handler.OnAttack(id));

		CenserAttackID attack = (CenserAttackID) id.id;
		if (!Enum.IsDefined(typeof(CenserAttackID), attack))
		{
			LogUnknownAttackIDError(id);
			return;
		}

		switch (attack)
		{
			case CenserAttackID.SWING:
			case CenserAttackID.SWING_FOLLOW_UP:
				Handlers.ForEach(handler => handler.OnSwing());
				break;
			case CenserAttackID.CROUCH:
				Handlers.ForEach(handler => handler.OnCrouchAttack());
				break;
			case CenserAttackID.MIDAIR_SWING:
				Handlers.ForEach(handler => handler.OnMidairSwing());
				break;
			case CenserAttackID.IGNITION_AREA:
				Handlers.ForEach(handler => handler.OnIgnitionArea());
				break;
			case CenserAttackID.IGNITION_STRIKE:
				Handlers.ForEach(handler => handler.OnIgnitionStrike());
				break;
			case CenserAttackID.TEMPER_STRIKE:
				Handlers.ForEach(handler => handler.OnTemperStrike());
				break;
			case CenserAttackID.MIDAIR_IGNITION_STRIKE:
				Handlers.ForEach(handler => handler.OnMidairIgnition());
				break;
			case CenserAttackID.WHIRLWIND:
			case CenserAttackID.WHIRLWIND_HIT:
				Handlers.ForEach(handler => handler.OnWhirlwind());
				break;
			case CenserAttackID.CHARGED_ATTACK:
				Handlers.ForEach(handler => handler.OnChargedAttack());
				break;
			default:
				LogUnsupportedAttackIDError(id);
				break;
		}
	}

	/// <summary>
	/// Calls the corresponding methods for Veredicto's attacks that hit at
	/// least one enemy.
	/// </summary>
	public override void HandleAttackHit(AttackInfo info)
	{
		Handlers.ForEach(handler => handler.OnAttackHit(info));

		CenserAttackID attack = (CenserAttackID) info.attackID.id;
		if (!Enum.IsDefined(typeof(CenserAttackID), attack))
		{
			LogUnknownAttackIDError(info.attackID);
			return;
		}

		switch (attack)
		{
			case CenserAttackID.SWING:
			case CenserAttackID.SWING_FOLLOW_UP:
				Handlers.ForEach(handler => handler.OnSwingHit(info));
				break;
			case CenserAttackID.CROUCH:
				Handlers.ForEach(handler => handler.OnCrouchAttackHit(info));
				break;
			case CenserAttackID.MIDAIR_SWING:
				Handlers.ForEach(handler => handler.OnMidairSwingHit(info));
				break;
			case CenserAttackID.IGNITION_AREA:
				Handlers.ForEach(handler => handler.OnIgnitionAreaHit(info));
				break;
			case CenserAttackID.IGNITION_STRIKE:
			case CenserAttackID.TEMPER_STRIKE:
				HandleIgnitionOrTemperStrikeHit(attack, info);
				break;
			case CenserAttackID.MIDAIR_IGNITION_STRIKE:
				Handlers.ForEach(handler => handler.OnMidairIgnitionHit(info));
				break;
			case CenserAttackID.WHIRLWIND:
			case CenserAttackID.WHIRLWIND_HIT:
				Handlers.ForEach(handler => handler.OnWhirlwindHit(info));
				break;
			case CenserAttackID.CHARGED_ATTACK:
				Handlers.ForEach(handler => handler.OnChargedAttackHit(info));
				break;
			default:
				LogUnsupportedAttackIDError(info.attackID);
				break;
		}
	}

	public void HandleIgnitionOrTemperStrikeHit(CenserAttackID attack, AttackInfo info)
	{
		if (ReferenceEquals(info, LastAttack))
		{
			return;
		}

		switch (attack)
		{
			case CenserAttackID.IGNITION_STRIKE:
				Handlers.ForEach(handler => handler.OnIgnitionStrikeHit(info));
				break;
			case CenserAttackID.TEMPER_STRIKE:
				Handlers.ForEach(handler => handler.OnTemperStrikeHit(info));
				break;
			default:
				LogUnsupportedAttackIDError(info.attackID);
				break;
		}
		LastAttack = info;
	}

	/// <summary>
	/// Calls the toggled and extinguish methods when Veredicto is extinguished.
	/// </summary>
	public void HandleExtinguish()
	{
		Handlers.ForEach(handler => handler.OnToggled());
		Main.WeaponEventsFramework.IsCenserIgnited = false;
		Handlers.ForEach(handler => handler.OnExtinguished());
	}

	/// <summary>
	/// Calls the toggled and ignited methods when Veredicto is ignited.
	/// </summary>
	public void HandleIgnition()
	{
		Handlers.ForEach(handler => handler.OnToggled());
		Main.WeaponEventsFramework.IsCenserIgnited = true;
		Handlers.ForEach(handler => handler.OnIgnited());
	}
}

