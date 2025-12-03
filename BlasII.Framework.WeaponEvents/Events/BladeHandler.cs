using BlasII.Framework.WeaponEvents.Constants;
using Il2CppGame.Components.Attack;
using Il2CppTGK.Game.Components.Attack.Data;

namespace BlasII.Framework.WeaponEvents.Events;


/// <summary>
/// Abstract class that handles Ruego al Alba's related events.
/// The corresponding methods are automatically called by the manager.
/// To handle these events, simply make a sub class of this class.
/// </summary>
public abstract class BladeHandler : CommonWeaponHandler
{
	/// <summary>
	/// A shortcut to the common global BladeBerserkModeFiller reference.
	/// </summary>
	public BladeBerserkModeFiller BerserkModeFiller { get => Main.WeaponEventsFramework.BladeBerserkModeFiller; }

	/// <summary>
	/// A shortcut to the common global current berserk mode value.
	/// The setter has been overloaded to call the game's setter instead.
	/// </summary>
	public int CurrentBerserkModeValue
	{
		get
		{
			if (BerserkModeFiller != null)
			{
				return BerserkModeFiller.stats.GetCurrentValue(BerserkModeFiller.berserkModeStatID);
			}
			return 0;
		}
		set
		{
			if (BerserkModeFiller != null)
			{
				BerserkModeFiller.stats.SetCurrentValue(BerserkModeFiller.berserkModeStatID, value);
			}
		}
	}

	/* Combo attacks */

	/// <summary>
	/// Called when the player attacks with Ruego al Alba while in the air.
	/// </summary>
	protected internal virtual void OnAttackMidAir() {}

	/// <summary>
	/// Called when the player attacks with Ruego al Alba while in the air and
	/// hits an enemy with the attack.
	/// </summary>
	protected internal virtual void OnAttackMidAirHit(AttackInfo info) {}

	/* Combo attacks */

	protected internal virtual void OnCombo(BladeAttackID attack) {}

	protected internal virtual void OnComboHit(BladeAttackID attack, AttackInfo info) {}

	protected internal virtual void OnCombo1() {}

	protected internal virtual void OnCombo1Hit(AttackInfo info) {}

	protected internal virtual void OnCombo2() {}

	protected internal virtual void OnCombo2Hit(AttackInfo info) {}

	protected internal virtual void OnCombo3() {}

	protected internal virtual void OnCombo3Hit(AttackInfo info) {}

	protected internal virtual void OnCombo3Ascending() {}

	protected internal virtual void OnCombo3AscendingHit(AttackInfo info) {}

	protected internal virtual void OnCombo3Spin() {}

	protected internal virtual void OnCombo3SpinHit(AttackInfo info) {}

	protected internal virtual void OnCombo4() {}

	protected internal virtual void OnCombo4Hit(AttackInfo info) {}

	/* Crouch attacks */

	protected internal virtual void OnCrouchAttack() {}

	protected internal virtual void OnCrouchAttackHit(AttackInfo info) {}

	/* Mid air attacks */

	protected internal virtual void OnMidAirSlash(BladeAttackID attack) {}

	protected internal virtual void OnMidAirSlashHit(BladeAttackID attack, AttackInfo info) {}

	protected internal virtual void OnMidAirSlash1() {}

	protected internal virtual void OnMidAirSlash1Hit(AttackInfo info) {}

	protected internal virtual void OnMidAirSlash2() {}

	protected internal virtual void OnMidAirSlash2Hit(AttackInfo info) {}

	/* Counter attacks */

	/// <summary>
	/// Called when the player parries an incoming attack with Ruego al Alba.
	/// </summary>
	protected internal virtual void OnRetribution(BladeAttackID attack) {}

	/// <summary>
	/// Called when the player parries an incoming attack with Ruego al Alba,
	/// and hit an enemy with it.
	/// </summary>
	protected internal virtual void OnRetributionHit(BladeAttackID attack, AttackInfo info) {}

	/// <summary>
	/// Called when the player parries an incoming attack with Ruego al Alba,
	/// but missed the timing to do a perfect parry.
	/// </summary>
	protected internal virtual void OnNormalRetribution() {}

	/// <summary>
	/// Called when the player parries an incoming attack with Ruego al Alba,
	/// but missed the timing to do a perfect parry, but hits an enemy with it.
	/// </summary>
	protected internal virtual void OnNormalRetributionHit(AttackInfo info) {}

	/// <summary>
	/// Called when the player parries an incoming attack with Ruego al Alba,
	/// right on time to perform a devastating repercussion.
	/// </summary>
	protected internal virtual void OnPerfectRetribution() {}

	/// <summary>
	/// Called when the player parries an incoming attack with Ruego al Alba,
	/// right on time to perform a devastating repercussion, and hits an enemy
	/// with it.
	/// </summary>
	protected internal virtual void OnPerfectRetributionHit(AttackInfo info) {}

	/* Plunging strike */

	/// <summary>
	/// Called when the player makes a plunging strike with Ruego al Alba, by
	/// holding the down key and attacking in the air.
	/// </summary>
	protected internal virtual void OnPlungingStrike(BladeAttackID attack) {}

	/// <summary>
	/// Called when the player makes a plunging strike with Ruego al Alba, by
	/// holding the down key and attacking in the air, and hits an enemy with
	/// this attack.
	/// </summary>
	protected internal virtual void OnPlungingStrikeHit(BladeAttackID attack, AttackInfo info) {}

	/// <summary>
	/// Called when the player makes a plunging strike with Ruego al Alba, by
	/// holding the down key and attacking in the air, but from a short height
	/// (simple jump).
	/// </summary>
	protected internal virtual void OnLowerPlungingStrike() {}

	/// <summary>
	/// Called when the player makes a plunging strike with Ruego al Alba, by
	/// holding the down key and attacking in the air, but from a short height
	/// (simple jump), and hits an enemy with this attack.
	/// </summary>
	protected internal virtual void OnLowerPlungingStrikeHit(AttackInfo info) {}

	/// <summary>
	/// Called when the player makes a plunging strike with Ruego al Alba, by
	/// holding the down key and attacking in the air, but from a medium height
	/// (simple jump).
	/// </summary>
	protected internal virtual void OnMiddlePlungingStrike() {}

	/// <summary>
	/// Called when the player makes a plunging strike with Ruego al Alba, by
	/// holding the down key and attacking in the air, but from a medium height
	/// (simple jump), and hits an enemy with this attack.
	/// </summary>
	protected internal virtual void OnMiddlePlungingStrikeHit(AttackInfo info) {}

	/// <summary>
	/// Called when the player makes a plunging strike with Ruego al Alba, by
	/// holding the down key and attacking in the air, but from a high height
	/// (double jump peak).
	/// </summary>
	protected internal virtual void OnHighPlungingStrike() {}

	/// <summary>
	/// Called when the player makes a plunging strike with Ruego al Alba, by
	/// holding the down key and attacking in the air, but from a high height
	/// (double jump peak), and hits an enemy with it.
	/// </summary>
	protected internal virtual void OnHighPlungingStrikeHit(AttackInfo info) {}

	/* Blood pact */

	protected internal virtual void OnBloodPactAttack(BladeAttackID attack) {}

	protected internal virtual void OnBloodPactAttackHit(BladeAttackID attack, AttackInfo info) {}

	protected internal virtual void OnBloodPactStart() {}

	protected internal virtual void OnBloodPactStartHit(AttackInfo info) {}

	protected internal virtual void OnBloodPactSpecialAttack(BladeAttackID attack) {}

	protected internal virtual void OnBloodPactSpecialAttackHit(BladeAttackID attack, AttackInfo info) {}

	protected internal virtual void OnBloodPactSpecialAttackGround() {}

	protected internal virtual void OnBloodPactSpecialAttackGroundHit(AttackInfo info) {}

	protected internal virtual void OnBloodPactSpecialAttackMidAir() {}

	protected internal virtual void OnBloodPactSpecialAttackMidAirHit(AttackInfo info) {}

	protected internal virtual void OnBloodPactEnd() {}
}

