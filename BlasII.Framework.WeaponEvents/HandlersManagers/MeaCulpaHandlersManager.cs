using BlasII.Framework.WeaponEvents.Handlers;
using Il2CppTGK.Game.Components.Attack.Data;

namespace BlasII.Framework.WeaponEvents.HandlersManagers;


/// <summary>
/// Manages the handlers for Mea Culpa.
/// </summary>
public class MeaCulpaHandlersManager : AbstractHandlersManager<MeaCulpaHandler>
{
	/// <summary>Calls the base class constructor.</summary>
	public MeaCulpaHandlersManager() : base() {}

	public override void HandleAttack(AttackID id)
	{
		Handlers.ForEach(handler => handler.OnAttack(id));
	}

	public override void HandleAttackHit(AttackInfo info)
	{
		Handlers.ForEach(handler => handler.OnAttackHit(info));
	}
}

