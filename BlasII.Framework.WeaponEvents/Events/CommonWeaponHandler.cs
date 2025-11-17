using Il2Cpp;
using Il2CppTGK.Game.Components.Attack.Data;

namespace BlasII.Framework.WeaponEvents.Events;


/// <summary>
/// Abstract class that handles any weapon's related events.
/// The corresponding methods are automatically called by the manager.
/// To handle these events, simply make a sub class of this class.
/// </summary>
public abstract class CommonWeaponHandler
{
	/// <summary>
	/// Shorthand to the global UIWeaponController object stored statically,
	/// to be able to access it as if it was an attribute.
	/// </summary>
	public UIWeaponController UIWeaponController { get => Main.WeaponEventsFramework.UIWeaponController; }

	/// <summary>
	/// Called when the player attacks with a weapon.
	/// </summary>
	public virtual void OnAttack(AttackID id) {}

	/// <summary>
	/// Called when the player attacks with a weapon and hits an enemy.
	/// </summary>
	public virtual void OnAttackHit(AttackInfo info) {}

	/// <summary>
	/// Called when the player unequips the currently held weapon.
	/// </summary>
	public virtual void OnUnequip() {}

	/// <summary>
	/// Called when the player equips a new weapon.
	/// </summary>
	public virtual void OnEquip() {}

	/// <summary>
	/// Called when the player rests at a Prie Dieu.
	/// The normal behavior in that case, is Sarmiento y Centella's indicator
	/// getting reseted, Veredicto getting extinguished, and Ruego or Mea Culpa's
	/// berserk mode deactivating and their jauge reseting.
	/// </summary>
	public virtual void OnRestAtPrieDieu() {}
}
