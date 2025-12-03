using BlasII.Framework.WeaponEvents.Constants;
using BlasII.Framework.WeaponEvents.Events;
using Il2CppTGK.Game.Components.Attack.Data;

namespace BlasII.Framework.WeaponEvents.HandlersManagers;


/// <summary>
/// Manages the handlers for Sarmiento y Centella.
/// </summary>
public class RapierHandlersManager : AbstractHandlersManager<RapierHandler>
{
	/// <summary>Calls the base class constructor.</summary>
	public RapierHandlersManager() : base() {}

	public override void HandleAttack(AttackID id)
	{
		Handlers.ForEach(handler => handler.OnAttack(id));
	}

	public override void HandleAttackHit(AttackInfo info)
	{
		Handlers.ForEach(handler => handler.OnAttackHit(info));
	}

	public void HandlerIndicatorChange(int tier)
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
}

