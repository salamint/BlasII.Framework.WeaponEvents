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
	public virtual void OnHitReceived(AttackInfo hit) {}

	/* Normal attacks */

	/// <summary>
	/// </summary>
	public virtual void OnNormalAttack() {}

	/// <summary>
	/// </summary>
	public virtual void OnNormalAttackHit(AttackInfo info) {}

	/// <summary>
	/// </summary>
	public virtual void OnDiagonalAttack() {}

	/// <summary>
	/// </summary>
	public virtual void OnDiagonalAttackHit(AttackInfo info) {}

	/// <summary>
	/// </summary>
	public virtual void OnCrouchedAttack() {}

	/// <summary>
	/// </summary>
	public virtual void OnCrouchedAttackHit(AttackInfo info) {}

	/// <summary>
	/// </summary>
	public virtual void OnVerticalAttack() {}

	/// <summary>
	/// </summary>
	public virtual void OnVerticalAttackHit(AttackInfo info) {}

	/// <summary>
	/// </summary>
	public virtual void OnMidAirAttack() {}

	/// <summary>
	/// </summary>
	public virtual void OnMidAirAttackHit(AttackInfo info) {}

	/// <summary>
	/// </summary>
	public virtual void OnMidAirDiagonalAttack() {}

	/// <summary>
	/// </summary>
	public virtual void OnMidAirDiagonalAttackHit(AttackInfo info) {}

	/// <summary>
	/// </summary>
	public virtual void OnMidAirPogo() {}

	/// <summary>
	/// </summary>
	public virtual void OnMidAirPogoHit(AttackInfo info) {}

	/// <summary>
	/// </summary>
	public virtual void OnStormOfThrusts(RapierAttackID attack) {}

	/// <summary>
	/// </summary>
	public virtual void OnStormOfThrustsHit(RapierAttackID attack, AttackInfo info) {}

	/// <summary>
	/// </summary>
	public virtual void OnWeakStormOfThrusts() {}

	/// <summary>
	/// </summary>
	public virtual void OnWeakStormOfThrustsHit(AttackInfo info) {}

	/// <summary>
	/// </summary>
	public virtual void OnPowerfulStormOfThrusts() {}

	/// <summary>
	/// </summary>
	public virtual void OnPowerfulStormOfThrustsHit(AttackInfo info) {}

	/* Thrust attacks */

	/// <summary>
	/// </summary>
	public virtual void OnThrust(RapierAttackID attack) {}

	/// <summary>
	/// </summary>
	public virtual void OnThrustHit(RapierAttackID attack, AttackInfo info) {}

	/// <summary>
	/// </summary>
	public virtual void OnNormalThrust() {}

	/// <summary>
	/// </summary>
	public virtual void OnNormalThrustHit(AttackInfo info) {}

	/// <summary>
	/// </summary>
	public virtual void OnElectricThrust() {}

	/// <summary>
	/// </summary>
	public virtual void OnElectricThrustHit(AttackInfo info) {}

	/* Air cross attacks */

	/// <summary>
	/// </summary>
	public virtual void OnAirCross(RapierAttackID attack) {}

	/// <summary>
	/// </summary>
	public virtual void OnAirCrossHit(RapierAttackID attack, AttackInfo info) {}

	/// <summary>
	/// </summary>
	public virtual void OnNormalAirCross() {}

	/// <summary>
	/// </summary>
	public virtual void OnNormalAirCrossHit(AttackInfo info) {}

	/// <summary>
	/// </summary>
	public virtual void OnElectricAirCross() {}

	/// <summary>
	/// </summary>
	public virtual void OnElectricAirCrossHit(AttackInfo info) {}

	/* Finisher attacks */

	/// <summary>
	/// </summary>
	public virtual void OnFinisherAttack() {}

	/// <summary>
	/// </summary>
	public virtual void OnFinisherAttackHit(AttackInfo info) {}

	/* Counter attacks */

	/// <summary>
	/// </summary>
	public virtual void OnDashCounterAttack() {}

	/// <summary>
	/// </summary>
	public virtual void OnDashCounterAttackHit(AttackInfo info) {}

	/* Indicators */

	/// <summary>
	/// Called when the player fills an indicator of Sarmiento y Centella.
	/// </summary>
	public virtual void OnIndicator(int tier) {}

	/// <summary>
	/// Called when the player fills the first indicator of Sarmiento y Centella.
	/// </summary>
	public virtual void OnIndicator1() {}

	/// <summary>
	/// Called when the player fills the second indicator of Sarmiento y Centella.
	/// </summary>
	public virtual void OnIndicator2() {}

	/// <summary>
	/// Called when the player fills the third indicator of Sarmiento y Centella.
	/// </summary>
	public virtual void OnIndicator3() {}
}

