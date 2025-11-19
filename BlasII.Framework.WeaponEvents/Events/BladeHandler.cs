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
	/// The getter and setter call the get and set methods of the player stats.
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
	public virtual void OnAttackMidAir() {}

	/// <summary>
	/// Called when the player attacks with Ruego al Alba while in the air and
	/// hits an enemy with the attack.
	/// </summary>
	public virtual void OnAttackMidAirHit(AttackInfo info) {}

	/* Combo attacks */

	/// <summary>
	/// Called when the player does one of the "combo" attacks. This refer to
	/// the attacks the player can do if on ground and not looking up or down.
	/// They can be chained to obtain special combos, this function is called
	/// for any of those combo attacks (from first to last, with variants).
	/// </summary>
	public virtual void OnCombo(BladeAttackID attack) {}

	/// <summary>
	/// Called when the player does one of the "combo" attack (see the <seealso
	/// cref="OnCombo"/> method for reference), and hit an enemy with it.
	/// </summary>
	public virtual void OnComboHit(BladeAttackID attack, AttackInfo info) {}

	/// <summary>
	/// Called when the player does the first attack of the usual combo
	/// sequence (when not following a previous combo attack).
	/// </summary>
	public virtual void OnCombo1() {}

	/// <summary>
	/// Called when the player does the first attack of the usual combo
	/// sequence (when not following a previous combo attack), and hits an
	/// enemy with it.
	/// </summary>
	public virtual void OnCombo1Hit(AttackInfo info) {}

	/// <summary>
	/// Called when the player does the second attack of the usual combo
	/// sequence (when following the first combo attack).
	/// </summary>
	public virtual void OnCombo2() {}

	/// <summary>
	/// Called when the player does the second attack of the usual combo
	/// sequence (when following the first combo attack), and hits an enemy.
	/// </summary>
	public virtual void OnCombo2Hit(AttackInfo info) {}

	/// <summary>
	/// Called when the player does the third attack of the combo sequence (when
	/// following the second combo attack), whether it is a normal attack,
	/// ascending attack or spin attack.
	/// </summary>
	public virtual void OnCombo3() {}

	/// <summary>
	/// Called when the player does the third attack of the combo sequence (when
	/// following the second combo attack), whether it is a normal attack,
	/// ascending attack or spin attack, and also hits an enemy with it.
	/// </summary>
	public virtual void OnCombo3Hit(AttackInfo info) {}

	/// <summary>
	/// Called when the player does the normal third attack of the usual combo
	/// sequence (when following the second combo attack).
	/// This is different from the ascending or spin attacks that can also be
	/// executed on the third combo.
	/// </summary>
	public virtual void OnCombo3Normal() {}

	/// <summary>
	/// Called when the player does the normal third attack of the usual combo
	/// sequence (when following the second combo attack), and hits an enemy.
	/// This is different from the ascending or spin attacks that can also be
	/// executed on the third combo.
	/// </summary>
	public virtual void OnCombo3NormalHit(AttackInfo info) {}

	/// <summary>
	/// Called when the player does the ascending third attack of the usual
	/// combo sequence (when following the second combo attack).
	/// This is different from the normal or spin attacks that can also be
	/// executed on the third combo.
	/// </summary>
	public virtual void OnCombo3Ascending() {}

	/// <summary>
	/// Called when the player does the ascending third attack of the usual
	/// combo sequence (when following the second combo attack), and hits an
	/// enemy with it.
	/// This is different from the normal or spin attacks that can also be
	/// executed on the third combo.
	/// </summary>
	public virtual void OnCombo3AscendingHit(AttackInfo info) {}

	/// <summary>
	/// Called when the player does the spin third attack of the usual combo
	/// sequence (when following the second combo attack).
	/// This is different from the normal or ascending attacks that can also be
	/// executed on the third combo.
	/// </summary>
	public virtual void OnCombo3Spin() {}

	/// <summary>
	/// Called when the player does the spin third attack of the usual combo
	/// sequence (when following the second combo attack), and hits an enemey.
	/// This is different from the normal or ascending attacks that can also be
	/// executed on the third combo.
	/// </summary>
	public virtual void OnCombo3SpinHit(AttackInfo info) {}

	/// <summary>
	/// Called when the player does the fourth attack of the usual combo
	/// sequence (when following the normal third combo attack).
	/// </summary>
	public virtual void OnCombo4() {}

	/// <summary>
	/// Called when the player does the fourth attack of the usual combo
	/// sequence (when following the normal third combo attack), and hits an
	/// enemy with it.
	/// </summary>
	public virtual void OnCombo4Hit(AttackInfo info) {}

	/// <summary>
	/// Called when the player does the fourth attack of the usual combo
	/// sequence (when following the normal third combo attack), but the 4th
	/// attack is the unupgraded version (without the blood ripple).
	/// </summary>
	public virtual void OnCombo4Normal() {}

	/// <summary>
	/// Called when the player does the fourth attack of the usual combo
	/// sequence (when following the normal third combo attack), but the 4th
	/// attack is the unupgraded version (without the blood ripple), and the
	/// playerhits an enemy with this attack.
	/// </summary>
	public virtual void OnCombo4NormalHit(AttackInfo info) {}

	/// <summary>
	/// Called when the player does the fourth attack of the usual combo
	/// sequence (when following the normal third combo attack), but the 4th
	/// attack is the upgraded version (with the blood ripple).
	/// </summary>
	public virtual void OnCombo4Upgraded() {}

	/// <summary>
	/// Called when the player does the fourth attack of the usual combo
	/// sequence (when following the normal third combo attack), but the 4th
	/// attack is the upgraded version (with the blood ripple), and the player
	/// hits an enemy with this attack.
	/// </summary>
	public virtual void OnCombo4UpgradedHit(AttackInfo info) {}

	/* Crouch attacks */

	/// <summary>
	/// Called when the player attacks while crouched on the ground.
	/// </summary>
	public virtual void OnCrouchAttack() {}

	/// <summary>
	/// Called when the player attacks while crouched on the ground, and hits an
	/// enemy with this attack.
	/// </summary>
	public virtual void OnCrouchAttackHit(AttackInfo info) {}

	/* Mid air attacks */

	/// <summary>
	/// Called when the player attacks while in the air.
	/// </summary>
	public virtual void OnMidAirSlash(BladeAttackID attack) {}

	/// <summary>
	/// Called when the player attacks while in the air, and hits an enemy with
	/// it.
	/// </summary>
	public virtual void OnMidAirSlashHit(BladeAttackID attack, AttackInfo info) {}

	/// <summary>
	/// Called when the player does the first attack of the mid air attack
	/// combo.
	/// </summary>
	public virtual void OnMidAirSlash1() {}

	/// <summary>
	/// Called when the player does the first attack of the mid air attack
	/// combo, and hits an enemy with it.
	/// </summary>
	public virtual void OnMidAirSlash1Hit(AttackInfo info) {}

	/// <summary>
	/// Called when the player does the second attack of the mid air attack
	/// combo.
	/// </summary>
	public virtual void OnMidAirSlash2() {}

	/// <summary>
	/// Called when the player does the second attack of the mid air attack
	/// combo, and hits an enemy with it.
	/// </summary>
	public virtual void OnMidAirSlash2Hit(AttackInfo info) {}

	/* Up slash attack */

	/// <summary>
	/// Called when the player attack upward while on the ground.
	/// </summary>
	public virtual void OnUpSlashAttack() {}

	/// <summary>
	/// Called when the player attack upward while on the ground, and hits an
	/// enemy.
	/// </summary>
	public virtual void OnUpSlashAttackHit(AttackInfo info) {}

	/* Counter attacks */

	/// <summary>
	/// Called when the player parries an incoming attack with Ruego al Alba.
	/// </summary>
	public virtual void OnRetribution(BladeAttackID attack) {}

	/// <summary>
	/// Called when the player parries an incoming attack with Ruego al Alba,
	/// and hit an enemy with it.
	/// </summary>
	public virtual void OnRetributionHit(BladeAttackID attack, AttackInfo info) {}

	/// <summary>
	/// Called when the player parries an incoming attack with Ruego al Alba,
	/// but missed the timing to do a perfect parry.
	/// </summary>
	public virtual void OnNormalRetribution() {}

	/// <summary>
	/// Called when the player parries an incoming attack with Ruego al Alba,
	/// but missed the timing to do a perfect parry, but hits an enemy with it.
	/// </summary>
	public virtual void OnNormalRetributionHit(AttackInfo info) {}

	/// <summary>
	/// Called when the player parries an incoming attack with Ruego al Alba,
	/// right on time to perform a devastating repercussion.
	/// </summary>
	public virtual void OnPerfectRetribution() {}

	/// <summary>
	/// Called when the player parries an incoming attack with Ruego al Alba,
	/// right on time to perform a devastating repercussion, and hits an enemy
	/// with it.
	/// </summary>
	public virtual void OnPerfectRetributionHit(AttackInfo info) {}

	/* Plunging strike */

	/// <summary>
	/// Called when the player makes a plunging strike with Ruego al Alba, by
	/// holding the down key and attacking in the air.
	/// </summary>
	public virtual void OnPlungingStrike(BladeAttackID attack) {}

	/// <summary>
	/// Called when the player makes a plunging strike with Ruego al Alba, by
	/// holding the down key and attacking in the air, and hits an enemy with
	/// this attack.
	/// </summary>
	public virtual void OnPlungingStrikeHit(BladeAttackID attack, AttackInfo info) {}

	/// <summary>
	/// Called when the player makes a plunging strike with Ruego al Alba, by
	/// holding the down key and attacking in the air, but from a short height
	/// (simple jump).
	/// </summary>
	public virtual void OnLowerPlungingStrike() {}

	/// <summary>
	/// Called when the player makes a plunging strike with Ruego al Alba, by
	/// holding the down key and attacking in the air, but from a short height
	/// (simple jump), and hits an enemy with this attack.
	/// </summary>
	public virtual void OnLowerPlungingStrikeHit(AttackInfo info) {}

	/// <summary>
	/// Called when the player makes a plunging strike with Ruego al Alba, by
	/// holding the down key and attacking in the air, but from a medium height
	/// (simple jump).
	/// </summary>
	public virtual void OnMiddlePlungingStrike() {}

	/// <summary>
	/// Called when the player makes a plunging strike with Ruego al Alba, by
	/// holding the down key and attacking in the air, but from a medium height
	/// (simple jump), and hits an enemy with this attack.
	/// </summary>
	public virtual void OnMiddlePlungingStrikeHit(AttackInfo info) {}

	/// <summary>
	/// Called when the player makes a plunging strike with Ruego al Alba, by
	/// holding the down key and attacking in the air, but from a high height
	/// (double jump peak).
	/// </summary>
	public virtual void OnHighPlungingStrike() {}

	/// <summary>
	/// Called when the player makes a plunging strike with Ruego al Alba, by
	/// holding the down key and attacking in the air, but from a high height
	/// (double jump peak), and hits an enemy with it.
	/// </summary>
	public virtual void OnHighPlungingStrikeHit(AttackInfo info) {}

	/* Blood pact */

	/// <summary>
	/// Called when the player any type of attack during the blood pact, causing
	/// them to become stronger with a bigger range.
	/// </summary>
	public virtual void OnBloodPactAttack(BladeAttackID attack) {}

	/// <summary>
	/// Called when the player any type of attack during the blood pact, and
	/// hits an enemy with it.
	/// </summary>
	public virtual void OnBloodPactAttackHit(BladeAttackID attack, AttackInfo info) {}

	/// <summary>
	/// Called when the player starts the blood pact (berserk) mode of Ruego al
	/// Alba. This plays an animation that damages enemies around the player.
	/// </summary>
	public virtual void OnBloodPactStart() {}

	/// <summary>
	/// Called when the player starts the blood pact (berserk) mode of Ruego al
	/// Alba, and hits an enemy during the start animation.
	/// </summary>
	public virtual void OnBloodPactStartHit(AttackInfo info) {}

	/// <summary>
	/// Called when the player uses the special attack, only available during
	/// the blood pact.
	/// </summary>
	public virtual void OnBloodPactSpecialAttack(BladeAttackID attack) {}

	/// <summary>
	/// Called when the player uses the special attack, only available during
	/// the blood pact, and hits an enemy with it
	/// </summary>
	public virtual void OnBloodPactSpecialAttackHit(BladeAttackID attack, AttackInfo info) {}

	/// <summary>
	/// Called when the player uses the special attack, while on the ground.
	/// </summary>
	public virtual void OnBloodPactSpecialAttackGround() {}

	/// <summary>
	/// Called when the player uses the special attack, while on the ground, and
	/// hits an enemy with it.
	/// </summary>
	public virtual void OnBloodPactSpecialAttackGroundHit(AttackInfo info) {}

	/// <summary>
	/// Called when the player uses the special attack, while in the air.
	/// </summary>
	public virtual void OnBloodPactSpecialAttackMidAir() {}

	/// <summary>
	/// Called when the player uses the special attack, while in the air, and
	/// hits an enemy with it.
	/// </summary>
	public virtual void OnBloodPactSpecialAttackMidAirHit(AttackInfo info) {}

	/// <summary>
	/// Called when the blood pact comes to an end.
	/// </summary>
	public virtual void OnBloodPactEnd() {}
}

