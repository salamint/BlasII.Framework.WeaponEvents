using BlasII.Framework.WeaponEvents.Constants;
using Il2CppGame.Components.Attack;
using Il2CppTGK.Game.Components.Attack.Data;

namespace BlasII.Framework.WeaponEvents.Events;


/// <summary>
/// Abstract class that handles Mea Culpa's related events.
/// The corresponding methods are automatically called by the manager.
/// To handle these events, simply make a sub class of this class.
/// </summary>
public abstract class WhipHandler : CommonWeaponHandler
{
	/// <summary>
	/// Proxy to access and modify the value of the Berserk Mode stat.
	/// </summary>
	public static RangeStatProxy CoreIgnitionMode { get => WeaponEventsFramework.CoreIgnitionMode; }

	/// <summary>
	/// Shorthand to the global CenserIgniter object stored statically,
	/// to be able to access it as if it was an attribute.
	/// </summary>
	public static WhipCoreIgnitionModeFiller? CoreIgnitionModeFiller { get => Main.WeaponEventsFramework.WhipCoreIgnitionModeFiller; }

	/// <summary>
	/// Shorthand to the global boolean stored statically,
	/// to be able to access it as if it was an attribute.
	/// </summary>
	public bool IsIgnited { get => Main.WeaponEventsFramework.IsWhipIgnited; }

	/// <summary>
	/// A shortcut to the common global BladeBerserkModeFiller reference.
	/// </summary>
	public WhipCoreIgnitionModeFiller? WhipCoreIgnitionModeFiller { get => Main.WeaponEventsFramework.WhipCoreIgnitionModeFiller; }

	/* Crouch attack */

	/// <summary>
	/// Called when the player uses the simple strike attack while crouching.
	/// </summary>
	public virtual void OnCrouchAttack() {}

	/// <summary>
	/// Called when the player uses the simple strike attack while crouching and
	/// hits an enemy with it.
	/// </summary>
	public virtual void OnCrouchAttackHit(AttackInfo info) {}

	/* First attack */

	/// <summary>
	/// Called when the player does a simple strike attack.
	/// </summary>
	public virtual void OnFirstAttack(AttackDirection direction) {}

	/// <summary>
	/// Called when the player does a simple strike attack and hits an enemy
	/// with it.
	/// </summary>
	public virtual void OnFirstAttackHit(AttackDirection direction, AttackInfo info) {}

	/* Second attack */

	/// <summary>
	/// Called when the player does a simple strike attack again right after a
	/// previous simple strike attack (whether it hits or not).
	/// </summary>
	public virtual void OnSecondAttack(AttackDirection direction) {}

	/// <summary>
	/// Called when the player does a simple strike attack again right after a
	/// previous simple strike attack (whether it hits or not) and hits an enemy
	/// with it.
	/// </summary>
	public virtual void OnSecondAttackHit(AttackDirection direction, AttackInfo info) {}

	/* Slide attack */

	/// <summary>
	/// Called when the player does a slide "thrust like" attack.
	/// </summary>
	public virtual void OnSlideAttack() {}

	/// <summary>
	/// Called when the player does a slide "thrust like" attack and hits an
	/// enemy with it.
	/// </summary>
	public virtual void OnSlideAttackHit(AttackInfo info) {}

	/* Crouch spin attack */

	/// <summary>
	/// Called when the player executes the down spin attack while in the air,
	/// by holding the attack and down button.
	/// </summary>
	public virtual void OnCrouchSpinAttack() {}

	/// <summary>
	/// Called when the player executes the crouch spin attack,
	/// by holding the attack and down button and hits an enemy with it.
	/// </summary>
	public virtual void OnCrouchSpinAttackHit(AttackInfo info) {}

	/// <summary>
	/// Called at the end of the crouch spin attack.
	/// </summary>
	public virtual void OnCrouchSpinAttackFinisher() {}

	/// <summary>
	/// Called at the end of the crouch spin attack and hits an enemy with it.
	/// </summary>
	public virtual void OnCrouchSpinAttackFinisherHit(AttackInfo info) {}

	/* Grapling attack */

	/// <summary>
	/// Called when the player executes the special attack which consists of
	/// grappling an enemy and hitting it with a ghost-like version of The
	/// Penitent One.
	/// </summary>
	public virtual void OnGrapplingAttack(bool midair) {}

	/// <summary>
	/// Called when the player executes the special attack which consists of
	/// grappling an enemy and hitting it with a ghost-like version of The
	/// Penitent One, and hits an enemy with it.
	/// </summary>
	public virtual void OnGrapplingAttackHit(AttackInfo info, bool midair) {}

	/* Downward spiral attack */

	/// <summary>
	/// Called when the player executes the downward spiral attack by holding
	/// the attack button and the down key while in the air.
	/// </summary>
	public virtual void OnDownwardSpiral() {}

	/// <summary>
	/// Called when the player executes the downward spiral attack by holding
	/// the attack button and the down key while in the air, and hits an enemy
	/// with it whether during the fall or after landing.
	/// </summary>
	public virtual void OnDownwardSpiralHit(AttackInfo info) {}

	/* Mid air attack */

	/// <summary>
	/// Called when the player attacks with Embrujo while in the air.
	/// </summary>
	public virtual void OnMidAirAttack(AttackDirection direction) {}

	/// <summary>
	/// Called when the player attacks with Embrujo while in the air and hits an
	/// enemy with the attack.
	/// </summary>
	public virtual void OnMidAirAttackHit(AttackDirection direction, AttackInfo info) {}

	/* Spin attack */

	/// <summary>
	/// Called during the player's spin attack when holding the attack button
	/// while on the ground and not crouching.
	/// </summary>
	public virtual void OnSpinAttack() {}

	/// <summary>
	/// Called during the player's spin attack when holding the attack button
	/// while on the ground and not crouching, and hits an enemy.
	/// </summary>
	public virtual void OnSpinAttackHit(AttackInfo info) {}

	/// <summary>
	/// Called at the beginning of the spin attack.
	/// </summary>
	public virtual void OnSpinStart() {}

	/// <summary>
	/// Called at the beginning of the spin attack, if it hits an enemy.
	/// </summary>
	public virtual void OnSpinStartHit(AttackInfo info) {}

	/// <summary>
	/// Called when the spin attack is cancelled (supposedly, can't reproduce
	/// tho).
	/// </summary>
	public virtual void OnSpinCancelled() {}

	/// <summary>
	/// Called when the spin attack is cancelled (supposedly, can't reproduce
	/// tho), and hits an enemy (is that even possible?).
	/// </summary>
	public virtual void OnSpinCancelledHit(AttackInfo info) {}

	/// <summary>
	/// Called at the first acceleration of the spin attack.
	/// </summary>
	public virtual void OnSpinFirstAcceleration() {}

	/// <summary>
	/// Called if an enemy is hit after the first acceleration of the spin
	/// attack.
	/// </summary>
	public virtual void OnSpinFirstAccelerationHit(AttackInfo info) {}

	/// <summary>
	/// Called at the second acceleration of the spin attack.
	/// </summary>
	public virtual void OnSpinSecondAcceleration() {}

	/// <summary>
	/// Called if an enemy is hit after the second acceleration of the spin
	/// attack.
	/// </summary>
	public virtual void OnSpinSecondAccelerationHit(AttackInfo info) {}

	/// <summary>
	/// Called on the finisher strike of the spin attack.
	/// </summary>
	public virtual void OnSpinFinisher() {}

	/// <summary>
	/// Called on the finisher strike of the spin attack if it hits an enemy.
	/// </summary>
	public virtual void OnSpinFinisherHit(AttackInfo info) {}

	/// <summary>
	/// Called when the projectile of the finisher strike of the spin attack is
	/// launched.
	/// </summary>
	public virtual void OnSpinProjectile() {}

	/// <summary>
	/// Called when the projectile of the finisher strike of the spin attack is
	/// launched and hits an enemy.
	/// </summary>
	public virtual void OnSpinProjectileHit(AttackInfo info) {}

	/* Combo attack */

	/// <summary>
	/// Called when the player attacks again right after an attack that did hit
	/// an enemy, creating an attack with a larger hit area and more damage.
	/// </summary>
	public virtual void OnComboAttack() {}

	/// <summary>
	/// Called when the player attacks again right after an attack that did hit
	/// an enemy, creating an attack with a larger hit area and more damage and
	/// hits an enemy with it.
	/// </summary>
	public virtual void OnComboAttackHit(AttackInfo info) {}

	/// <summary>
	/// Called when the player attacks again right after an attack that did hit
	/// an enemy, creating an attack with a larger hit area and more damage.
	/// This is called by the upgraded version of this attack, and its function
	/// remains a mystery.
	/// </summary>
	public virtual void OnComboAttackDamage() {}

	/// <summary>
	/// Called when the player attacks again right after an attack that did hit
	/// an enemy, creating an attack with a larger hit area and more damage and
	/// hits an enemy with it.
	/// This is only called for the first hit of the attack.
	/// </summary>
	public virtual void OnComboAttackFirstHit(AttackInfo info) {}

	/* Wail of the Flame */

	/// <summary>
	/// Called when Embrujo is ignited.
	/// </summary>
	public virtual void OnIgnited() {}

	/// <summary>
	/// Called when Embrujo is either extinguished or ignited.
	/// This is called whether the ignition jauge fills or runs out or when the
	/// player switches weapon, extinguishing it.
	/// </summary>
	public virtual void OnToggled() {}

	/// <summary>
	/// Called when Embrujo is extinguished by the player.
	/// This is called whether the ignition jauge runs out or when the player
	/// switches weapon, extinguishing it.
	/// </summary>
	public virtual void OnExtinguished() {}

	/* Graple ability */

	/// <summary>
	/// When the player uses the grapple function of Embrujo.
	/// </summary>
	public virtual void OnGrapple(AttackDirection direction, bool midair) {}
}

