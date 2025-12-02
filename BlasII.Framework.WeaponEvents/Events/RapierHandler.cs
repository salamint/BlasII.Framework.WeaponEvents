using Il2CppTGK.Game.Components.Attack;
using Il2CppTGK.Game.Components.Attack.Data;

namespace BlasII.Framework.WeaponEvents.Handlers;


/// <summary>
/// Abstract class that handles Sarmiento y Centella's related events.
/// The corresponding methods are automatically called by the manager.
/// To handle these events, simply make a sub class of this class.
/// </summary>
public abstract class RapierHandler : CommonWeaponHandler
{
	/// <summary>
	/// Shorthand to the global RapierTrueSkillFiller object stored statically,
	/// to be able to access it as if it was an attribute.
	/// </summary>
	public RapierTrueSkillFiller TrueSkillFiller { get => Main.WeaponEventsFramework.RapierTrueSkillFiller; }

	/// <summary>
	/// Called when the player is hit by an enemy.
	/// The normal behavior in that case, is Sarmiento y Centella's indicator
	/// being reset.
	/// </summary>
	protected internal virtual void OnHitReceived(AttackInfo hit) {}

	/// <summary>
	/// Called when the player rests at a Prie Dieu.
	/// The normal behavior in that case, is Sarmiento y Centella's indicator
	/// being reset.
	/// </summary>
	protected internal virtual void OnRestAtPrieDieu() {}

	/* Indicators */

	/// <summary>
	/// Called when the player fills an indicator of Sarmiento y Centella.
	/// </summary>
	protected internal virtual void OnIndicator() {}

	/// <summary>
	/// Called when the player fills the first indicator of Sarmiento y Centella.
	/// </summary>
	protected internal virtual void OnIndicator1() {}

	/// <summary>
	/// Called when the player fills the second indicator of Sarmiento y Centella.
	/// </summary>
	protected internal virtual void OnIndicator2() {}

	/// <summary>
	/// Called when the player fills the third indicator of Sarmiento y Centella.
	/// </summary>
	protected internal virtual void OnIndicator3() {}
}

