using BlasII.Framework.WeaponEvents.Constants;
using BlasII.Framework.WeaponEvents.Events;
using Il2CppTGK.Game.Components.Attack.Data;
using System;

namespace BlasII.Framework.WeaponEvents.HandlersManagers;


/// <summary>
/// Manages the handlers for Sarmiento y Centella.
/// </summary>
public class RapierHandlersManager : AbstractHandlersManager<RapierHandler>
{
	/// <summary>Calls the base class constructor.</summary>
	public RapierHandlersManager() : base("Sarmiento y Centella") {}

	public override void HandleAttack(AttackID id)
	{
		Handlers.ForEach(handler => handler.OnAttack(id));

		RapierAttackID attack = (RapierAttackID) id.id;
		if (!Enum.IsDefined(typeof(RapierAttackID), attack))
		{
			LogUnknownAttackIDError(id);
			return;
		}

		switch (attack)
		{
			case RapierAttackID.NORMAL:
				Handlers.ForEach(handler => handler.OnNormalAttack());
				break;
			case RapierAttackID.DIAGONAL:
				Handlers.ForEach(handler => handler.OnDiagonalAttack());
				break;
			case RapierAttackID.CROUCHED:
				Handlers.ForEach(handler => handler.OnCrouchedAttack());
				break;
			case RapierAttackID.VERTICAL:
				Handlers.ForEach(handler => handler.OnVerticalAttack());
				break;
			case RapierAttackID.MIDAIR:
				Handlers.ForEach(handler => handler.OnMidAirAttack());
				break;
			case RapierAttackID.MIDAIR_DIAGONAL:
				Handlers.ForEach(handler => handler.OnMidAirDiagonalAttack());
				break;
			case RapierAttackID.MIDAIR_POGO:
				Handlers.ForEach(handler => handler.OnMidAirPogo());
				break;
			case RapierAttackID.POWERFUL_STORM_OF_THRUSTS:
			case RapierAttackID.WEAK_STORM_OF_THRUSTS:
				HandleStormOfThrusts(attack);
				break;
			default:
				LogUnsupportedAttackIDError(id);
				break;
		}
	}

	public override void HandleAttackHit(AttackInfo info)
	{
		Handlers.ForEach(handler => handler.OnAttackHit(info));

		RapierAttackID attack = (RapierAttackID) info.attackID.id;
		if (!Enum.IsDefined(typeof(RapierAttackID), attack))
		{
			LogUnknownAttackIDError(info.attackID);
			return;
		}

		switch (attack)
		{
			default:
				LogUnsupportedAttackIDError(info.attackID);
				break;
		}
	}

	public void HandleStormOfThrusts(RapierAttackID attack)
	{
		Handlers.ForEach(handler => handler.OnStormOfThrusts(attack));
		switch (attack)
		{
			case RapierAttackID.POWERFUL_STORM_OF_THRUSTS:
				Handlers.ForEach(handler => handler.OnPowerfulStormOfThrusts());
				break;
			case RapierAttackID.WEAK_STORM_OF_THRUSTS:
				Handlers.ForEach(handler => handler.OnWeakStormOfThrusts());
				break;
		}
	}

	public void HandleIndicatorChange(int tier)
	{
		Handlers.ForEach(handler => handler.OnIndicator());
		switch (tier)
		{
			case 1:
				Handlers.ForEach(handler => handler.OnIndicator1());
				break;
			case 2:
				Handlers.ForEach(handler => handler.OnIndicator2());
				break;
			case 3:
				Handlers.ForEach(handler => handler.OnIndicator3());
				break;
		}
	}

	public void HandleHitReceived(AttackInfo info)
	{
		Handlers.ForEach(handler => handler.OnHitReceived(info));
	}
}

