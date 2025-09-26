using BlasII.Framework.WeaponEvents.Events;
using Il2CppTGK.Game.Components.Attack.Data;

namespace BlasII.Framework.WeaponEvents.HandlersManagers;


/// <summary>
/// Manages the handlers for no particular weapon.
/// </summary>
public class WeaponHandlersManager : AbstractHandlersManager<WeaponHandler>
{
	/// <summary>Calls the base class constructor.</summary>
	public WeaponHandlersManager() : base("weapon") {}

	public override void HandleAttack(AttackID id)
	{
		Handlers.ForEach(handler => handler.OnAttack(id));
	}

	public override void HandleAttackHit(AttackInfo info)
	{
		Handlers.ForEach(handler => handler.OnAttackHit(info));
	}
}

