using Il2Cpp;
using Il2CppTGK.Game.Components.Attack.Data;

namespace BlasII.Framework.WeaponEvents.Events;


public abstract class CommonWeaponHandler
{
	public UIWeaponController UIWeaponController { get => Main.WeaponEventsFramework.UIWeaponController; }

	protected internal virtual void OnAttack(AttackID id) {}
	protected internal virtual void OnAttackHit(AttackInfo info) {}

	protected internal virtual void OnUnequip() {}
	protected internal virtual void OnEquip() {}
}
