using System;
using BlasII.Framework.WeaponEvents.Handlers;
using BlasII.ModdingAPI;
using Il2CppTGK.Game.Components.Attack.Data;

namespace BlasII.Framework.WeaponEvents.HandlersManagers;

/// <summary>
/// Manages the handlers for Veredicto.
/// </summary>
public class CenserHandlersManager : AbstractHandlersManager<CenserHandler>
{
	public CenserHandlersManager() : base() {}

	public override void HandleAttack(AttackID id)
	{
		Handlers.ForEach(handler => handler.OnAttack(id));
	}

	public override void HandleAttackHit(AttackInfo info)
	{
		Handlers.ForEach(handler => handler.OnAttackHit(info));

		CenserAttack attack = (CenserAttack) info.attackID.id;
		if (!Enum.IsDefined(typeof(CenserAttack), attack))
		{
			ModLog.Error($"Error: Unknown attack ID for Veredicto: {info.attackID.id}");
			return;
		}

		switch (attack)
		{
			case CenserAttack.SWING:
				Handlers.ForEach(handler => handler.OnSwingHit(info));
				break;
			case CenserAttack.CROUCH:
				Handlers.ForEach(handler => handler.OnCrouchAttackHit(info));
				break;
			case CenserAttack.MIDAIR_SWING:
				Handlers.ForEach(handler => handler.OnMidairSwingHit(info));
				break;
			case CenserAttack.IGNITION_AREA:
				Handlers.ForEach(handler => handler.OnIgnitionAreaHit(info));
				break;
			case CenserAttack.IGNITION_OR_TEMPER_STRIKE:
				/* TODO */
				break;
			case CenserAttack.TEMPER_STRIKE_FIRST_HIT:
				Handlers.ForEach(handler => handler.OnTemperStrikeHit(info));
				break;
			case CenserAttack.MIDAIR_IGNITION_STRIKE:
				Handlers.ForEach(handler => handler.OnMidairIgnitionHit(info));
				break;
			case CenserAttack.WHIRLWIND:
				Handlers.ForEach(handler => handler.OnWhirlwindHit(info));
				break;
			case CenserAttack.CHARGED_ATTACK:
				/* TODO */
				break;
		}
	}

	public void HandleExtinguish()
	{
		Handlers.ForEach(handler => handler.OnToggled());
		Main.WeaponEventsFramework.IsCenserIgnited = false;
		Handlers.ForEach(handler => handler.OnExtinguished());
	}

	public void HandleIgnition()
	{
		Handlers.ForEach(handler => handler.OnToggled());
		Main.WeaponEventsFramework.IsCenserIgnited = true;
		Handlers.ForEach(handler => handler.OnIgnited());
	}
}

