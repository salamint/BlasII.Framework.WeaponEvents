using BlasII.Framework.WeaponEvents.Constants;
using BlasII.Framework.WeaponEvents.Events;
using Il2CppTGK.Game.Components.Attack.Data;
using System;

namespace BlasII.Framework.WeaponEvents.HandlersManagers;


/// <summary>
/// Manages the handlers for Mea Culpa.
/// </summary>
public class MeaCulpaHandlersManager : AbstractHandlersManager<MeaCulpaHandler>
{
	/// <summary>Calls the base class constructor.</summary>
	public MeaCulpaHandlersManager() : base("Mea Culpa") {}

	public override void HandleAttack(AttackID id)
	{
		Handlers.ForEach(handler => handler.OnAttack(id));

		MeaCulpaAttackID attack = (MeaCulpaAttackID) id.id;
		if (!Enum.IsDefined(typeof(MeaCulpaAttackID), attack))
		{
			LogUnknownAttackIDError(id);
			return;
		}

		switch (attack)
		{
			default:
				LogUnsupportedAttackIDError(id);
				break;
		}
	}

	public override void HandleAttackHit(AttackInfo info)
	{
		Handlers.ForEach(handler => handler.OnAttackHit(info));

		MeaCulpaAttackID attack = (MeaCulpaAttackID) info.attackID.id;
		if (!Enum.IsDefined(typeof(MeaCulpaAttackID), attack))
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
}

