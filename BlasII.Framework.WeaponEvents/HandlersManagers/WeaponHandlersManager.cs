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

	/// <summary>
	/// The base behavior of the events handler manager when handling an attack.
	/// This calls the handler method <c>OnAttack</c> of every managed handler.
	/// </summary>
	public override void HandleAttack(AttackID id)
	{
		Handlers.ForEach(handler => handler.OnAttack(id));
	}

	/// <summary>
	/// The base behavior of the events handler manager when handling an attack
	/// that hits an an enemy.
	/// This calls the handler method <c>OnAttackHit</c> of every managed
	/// handler.
	/// </summary>
	public override void HandleAttackHit(AttackInfo info)
	{
		Handlers.ForEach(handler => handler.OnAttackHit(info));
	}
}

