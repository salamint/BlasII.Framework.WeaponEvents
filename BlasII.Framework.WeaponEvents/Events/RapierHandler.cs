using BlasII.Framework.WeaponEvents.Constants;
using Il2CppTGK.Game.Components.Attack;
using Il2CppTGK.Game.Components.Attack.Data;

namespace BlasII.Framework.WeaponEvents.Events;


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

	/* Normal attacks */

	/// <summary>
	/// </summary>
	protected internal virtual void OnNormalAttack() {}

	/// <summary>
	/// </summary>
	protected internal virtual void OnNormalAttackHit(AttackInfo info) {}

	/// <summary>
	/// </summary>
	protected internal virtual void OnDiagonalAttack() {}

	/// <summary>
	/// </summary>
	protected internal virtual void OnDiagonalAttackHit(AttackInfo info) {}

	/// <summary>
	/// </summary>
	protected internal virtual void OnCrouchedAttack() {}

	/// <summary>
	/// </summary>
	protected internal virtual void OnCrouchedAttackHit(AttackInfo info) {}

	/// <summary>
	/// </summary>
	protected internal virtual void OnVerticalAttack() {}

	/// <summary>
	/// </summary>
	protected internal virtual void OnVerticalAttackHit(AttackInfo info) {}

	/// <summary>
	/// </summary>
	protected internal virtual void OnMidAirAttack() {}

	/// <summary>
	/// </summary>
	protected internal virtual void OnMidAirAttackHit(AttackInfo info) {}

	/// <summary>
	/// </summary>
	protected internal virtual void OnMidAirDiagonalAttack() {}

	/// <summary>
	/// </summary>
	protected internal virtual void OnMidAirDiagonalAttackHit(AttackInfo info) {}

	/// <summary>
	/// </summary>
	protected internal virtual void OnMidAirPogo() {}

	/// <summary>
	/// </summary>
	protected internal virtual void OnMidAirPogoHit(AttackInfo info) {}

	/// <summary>
	/// </summary>
	protected internal virtual void OnStormOfThrusts(RapierAttackID attack) {}

	/// <summary>
	/// </summary>
	protected internal virtual void OnStormOfThrustsHit(AttackInfo info) {}

	/// <summary>
	/// </summary>
	protected internal virtual void OnWeakStormOfThrusts() {}

	/// <summary>
	/// </summary>
	protected internal virtual void OnWeakStormOfThrustsHit(AttackInfo info) {}

	/// <summary>
	/// </summary>
	protected internal virtual void OnPowerfulStormOfThrusts() {}

	/// <summary>
	/// </summary>
	protected internal virtual void OnPowerfulStormOfThrustsHit(AttackInfo info) {}

	/* Indicators */

	/// <summary>
	/// Called when the player fills an indicator of Sarmiento y Centella.
	/// </summary>
	protected internal virtual void OnIndicator(int tier) {}

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

