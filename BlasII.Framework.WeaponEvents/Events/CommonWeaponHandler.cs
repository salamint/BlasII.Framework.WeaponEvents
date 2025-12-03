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

	/// <summary>
	/// Called when the player rests at a Prie Dieu.
	/// The normal behavior in that case, is Sarmiento y Centella's indicator
	/// getting reseted, Veredicto getting extinguished, and Ruego or Mea Culpa's
	/// berserk mode deactivating and their jauge reseting.
	/// </summary>
	protected internal virtual void OnRestAtPrieDieu() {}
}
