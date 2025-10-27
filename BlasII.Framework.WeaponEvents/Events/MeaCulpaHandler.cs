using BlasII.Framework.WeaponEvents.Constants;
using Il2CppTGK.Game.Components;
using Il2CppTGK.Game.Components.Attack.Data;

namespace BlasII.Framework.WeaponEvents.Events;


/// <summary>
/// Abstract class that handles Mea Culpa's related events.
/// The corresponding methods are automatically called by the manager.
/// To handle these events, simply make a sub class of this class.
/// </summary>
public abstract class MeaCulpaHandler : CommonWeaponHandler
{
	/// <summary>
	/// A shortcut to the common global MeaCulpaBerserkModeFiller reference.
	/// </summary>
	public MeaCulpaBerserkModeFiller BerserkModeFiller { get => Main.WeaponEventsFramework.MeaCulpaBerserkModeFiller; }

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
				return BerserkModeFiller.stats.GetCurrentValue(BerserkModeFiller.berserkStat);
			}
			return 0;
		}
		set
		{
			if (BerserkModeFiller != null)
			{
				BerserkModeFiller.stats.SetCurrentValue(BerserkModeFiller.berserkStat, value);
			}
		}
	}

	/* Combo attacks */

	/// <summary>
	/// Called when the player does one of the "combo" attacks. This refer to
	/// the attacks the player can do if on ground and not looking up or down.
	/// They can be chained to obtain special combos, this function is called
	/// for any of those combo attacks (from first to last, with variants).
	/// </summary>
	protected internal virtual void OnCombo(MeaCulpaAttackID attack) {}

	/// <summary>
	/// Called when the player does one of the "combo" attack (see the <seealso
	/// cref="OnCombo"/> method for reference), and hit an enemy with it.
	/// </summary>
	protected internal virtual void OnComboHit(MeaCulpaAttackID attack, AttackInfo info) {}

	/// <summary>
	/// Called when the player does the first attack of the usual combo
	/// sequence (when not following a previous combo attack).
	/// </summary>
	protected internal virtual void OnCombo1() {}

	/// <summary>
	/// Called when the player does the first attack of the usual combo
	/// sequence (when not following a previous combo attack), and hits an
	/// enemy with it.
	/// </summary>
	protected internal virtual void OnCombo1Hit(AttackInfo info) {}

	/// <summary>
	/// Called when the player does the first attack of the usual combo
	/// sequence (when not following a previous combo attack), and also spawns a
	/// projectile.
	/// The projectile's cooldown is then reset, and the player needs to stop
	/// attacking for a certain amount of time before being able to spawn a new
	/// projectile.
	/// </summary>
	protected internal virtual void OnCombo1ProjectileSpawner() {}

	/// <summary>
	/// Called when the player does the first attack of the usual combo
	/// sequence (when not following a previous combo attack), and also spawns a
	/// projectile, and hits an enemy with his attack (not the projectile).
	/// The projectile's cooldown is then reset, and the player needs to stop
	/// attacking for a certain amount of time before being able to spawn a new
	/// projectile.
	/// TODO
	/// </summary>
	protected internal virtual void OnCombo1ProjectileSpawnerHit(AttackInfo info) {}

	/// <summary>
	/// Called when the player does the first attack of the usual combo
	/// sequence (when not following a previous combo attack), but does not
	/// spawn a projectile.
	/// This happens when the projectile has already spawned not long ago, and
	/// is still in cooldown.
	/// </summary>
	protected internal virtual void OnCombo1NoProjectile() {}

	/// <summary>
	/// Called when the player does the first attack of the usual combo
	/// sequence (when not following a previous combo attack), but does not
	/// spawn a projectile, and also hist an enemy with his attack.
	/// This happens when the projectile has already spawned not long ago, and
	/// is still in cooldown.
	/// TODO
	/// </summary>
	protected internal virtual void OnCombo1NoProjectileHit(AttackInfo info) {}

	/// <summary>
	/// Called when the player does the second attack of the usual combo
	/// sequence (when following the first combo attack).
	/// </summary>
	protected internal virtual void OnCombo2() {}

	/// <summary>
	/// Called when the player does the second attack of the usual combo
	/// sequence (when following the first combo attack), and hits an enemy.
	/// </summary>
	protected internal virtual void OnCombo2Hit(AttackInfo info) {}

	/// <summary>
	/// Called when the player does the third attack of the combo sequence (when
	/// following the second combo attack), whether it is a normal attack,
	/// ascending attack or spin attack.
	/// </summary>
	protected internal virtual void OnCombo3() {}

	/// <summary>
	/// Called when the player does the third attack of the combo sequence (when
	/// following the second combo attack), whether it is a normal attack,
	/// ascending attack or spin attack, and also hits an enemy with it.
	/// </summary>
	protected internal virtual void OnCombo3Hit(AttackInfo info) {}

	/// <summary>
	/// Called when the player does the normal third attack of the usual combo
	/// sequence (when following the second combo attack).
	/// This is different from the ascending or spin attacks that can also be
	/// executed on the third combo.
	/// </summary>
	protected internal virtual void OnCombo3Normal() {}

	/// <summary>
	/// Called when the player does the normal third attack of the usual combo
	/// sequence (when following the second combo attack), and hits an enemy.
	/// This is different from the ascending or spin attacks that can also be
	/// executed on the third combo.
	/// </summary>
	protected internal virtual void OnCombo3NormalHit(AttackInfo info) {}

	/// <summary>
	/// Called when the player does the ascending third attack of the usual
	/// combo sequence (when following the second combo attack).
	/// This is different from the normal or spin attacks that can also be
	/// executed on the third combo.
	/// </summary>
	protected internal virtual void OnCombo3Ascending() {}

	/// <summary>
	/// Called when the player does the ascending third attack of the usual
	/// combo sequence (when following the second combo attack), and hits an
	/// enemy with it.
	/// This is different from the normal or spin attacks that can also be
	/// executed on the third combo.
	/// </summary>
	protected internal virtual void OnCombo3AscendingHit(AttackInfo info) {}

	/// <summary>
	/// Called when the player does the spin third attack of the usual combo
	/// sequence (when following the second combo attack).
	/// This is different from the normal or ascending attacks that can also be
	/// executed on the third combo.
	/// </summary>
	protected internal virtual void OnCombo3Spin() {}

	/// <summary>
	/// Called when the player does the spin third attack of the usual combo
	/// sequence (when following the second combo attack), and hits an enemey.
	/// This is different from the normal or ascending attacks that can also be
	/// executed on the third combo.
	/// </summary>
	protected internal virtual void OnCombo3SpinHit(AttackInfo info) {}

	/// <summary>
	/// Called when the player does the fourth attack of the usual combo
	/// sequence (when following the normal third combo attack).
	/// </summary>
	protected internal virtual void OnCombo4() {}

	/// <summary>
	/// Called when the player does the fourth attack of the usual combo
	/// sequence (when following the normal third combo attack), and hits an
	/// enemy with it.
	/// </summary>
	protected internal virtual void OnCombo4Hit(AttackInfo info) {}

	/* Mid air attacks */

	/// <summary>
	/// </summary>
	protected internal virtual void OnMidairSlash(MeaCulpaAttackID attack) {}

	protected internal virtual void OnMidairSlashHit(MeaCulpaAttackID attack, AttackInfo info) {}

	protected internal virtual void OnMidairSlash1() {}

	protected internal virtual void OnMidairSlash1Hit(AttackInfo info) {}

	protected internal virtual void OnMidairSlash1ProjectileSpawner() {}

	protected internal virtual void OnMidairSlash1ProjectileSpawnerHit(AttackInfo info) {}

	protected internal virtual void OnMidairSlash1NoProjectile() {}

	protected internal virtual void OnMidairSlash1NoProjectileHit(AttackInfo info) {}

	protected internal virtual void OnMidairSlash2() {}

	protected internal virtual void OnMidairSlash2Hit(AttackInfo info) {}

	/* Charged attacks */

	/// <summary>
	/// Called when the player does a charged attack with the Mea Culpa (when
	/// holding the attack button for a few seconds then releasing it).
	/// </summary>
	protected internal virtual void OnChargedAttack() {}

	/// <summary>
	/// Called when the player does a charged attack with the Mea Culpa (when
	/// holding the attack button for a few seconds then releasing it), and hits
	/// an enemy with it.
	/// </summary>
	protected internal virtual void OnChargedAttackHit(AttackInfo info) {}

	/* Thrust attacks */

	/// <summary>
	/// Called when the player does a thrust attack with the Mea Culpa (dodge
	/// then attack on the ground).
	/// </summary>
	protected internal virtual void OnThrustAttack() {}

	/// <summary>
	/// Called when the player does a thrust attack with the Mea Culpa (dodge
	/// then attack on the ground), and hits an enemy.
	/// </summary>
	protected internal virtual void OnThrustAttackHit(AttackInfo info) {}

	/* Phantom projectiles */

	protected internal virtual void OnProjectileSpawnerAttack(MeaCulpaAttackID attack) {}

	protected internal virtual void OnProjectileSpawnerAttackHit(MeaCulpaAttackID attack, AttackInfo info) {}

	protected internal virtual void OnPhantomProjectile() {}

	protected internal virtual void OnPhantomProjectileHit(AttackInfo info) {}

	/* Counter attacks */

	/// <summary>
	/// Called when the player parries an incoming attack with Mea Culpa.
	/// </summary>
	protected internal virtual void OnRetribution(MeaCulpaAttackID attack) {}

	/// <summary>
	/// Called when the player parries an incoming attack with Mea Culpa,
	/// and hit an enemy with it.
	/// </summary>
	protected internal virtual void OnRetributionHit(MeaCulpaAttackID attack, AttackInfo info) {}

	/// <summary>
	/// Called when the player parries an incoming attack with Mea Culpa,
	/// but missed the timing to do a perfect parry.
	/// </summary>
	protected internal virtual void OnNormalRetribution() {}

	/// <summary>
	/// Called when the player parries an incoming attack with Mea Culpa,
	/// but missed the timing to do a perfect parry, but hits an enemy with it.
	/// </summary>
	protected internal virtual void OnNormalRetributionHit(AttackInfo info) {}

	/// <summary>
	/// Called when the player parries an incoming attack with Mea Culpa,
	/// right on time to perform a devastating repercussion.
	/// </summary>
	protected internal virtual void OnPerfectRetribution() {}

	/// <summary>
	/// Called when the player parries an incoming attack with Mea Culpa,
	/// right on time to perform a devastating repercussion, and hits an enemy
	/// with it.
	/// </summary>
	protected internal virtual void OnPerfectRetributionHit(AttackInfo info) {}

	/* Up slash attack */

	/// <summary>
	/// Called when the player attacks upward with Mea Culpa.
	/// This only works on the ground.
	/// </summary>
	protected internal virtual void OnUpSlashAttack() {}

	/// <summary>
	/// Called when the player attacks upward with Mea Culpa, and hits an enemy.
	/// This only works on the ground.
	/// </summary>
	protected internal virtual void OnUpSlashAttackHit(AttackInfo info) {}

	/* Plunging strike */

	/// <summary>
	/// Called when the player makes a plunging strike with Mea Culpa, by
	/// holding the down key and attacking in the air.
	/// </summary>
	protected internal virtual void OnPlungingStrike(MeaCulpaAttackID attack) {}

	/// <summary>
	/// Called when the player makes a plunging strike with Mea Culpa, by
	/// holding the down key and attacking in the air, and hits an enemy with
	/// this attack.
	/// </summary>
	protected internal virtual void OnPlungingStrikeHit(MeaCulpaAttackID attack, AttackInfo info) {}

	/// <summary>
	/// Called when the player makes a plunging strike with Mea Culpa, by
	/// holding the down key and attacking in the air, but from a short height
	/// (simple jump).
	/// </summary>
	protected internal virtual void OnLowerPlungingStrike() {}

	/// <summary>
	/// Called when the player makes a plunging strike with Mea Culpa, by
	/// holding the down key and attacking in the air, but from a short height
	/// (simple jump), and hits an enemy with this attack.
	/// </summary>
	protected internal virtual void OnLowerPlungingStrikeHit(AttackInfo info) {}

	/// <summary>
	/// Called when the player makes a plunging strike with Mea Culpa, by
	/// holding the down key and attacking in the air, but from a high height
	/// (double jump peak).
	/// </summary>
	protected internal virtual void OnHighPlungingStrike() {}

	/// <summary>
	/// Called when the player makes a plunging strike with Mea Culpa, by
	/// holding the down key and attacking in the air, but from a high height
	/// (double jump peak), and hits an enemy with it.
	/// </summary>
	protected internal virtual void OnHighPlungingStrikeHit(AttackInfo info) {}

	/* Blood pact */

	/// <summary>
	/// Called when the player attacks while Mea Culpa is in remorse(berserk)
	/// mode, causing the attacks to have a larger area and damage.
	/// </summary>
	protected internal virtual void OnRemorseAttack(MeaCulpaAttackID attack) {}

	/// <summary>
	/// Called when the player attacks while Mea Culpa is in remorse(berserk)
	/// mode, and hits an enemy with it.
	/// </summary>
	protected internal virtual void OnRemorseAttackHit(MeaCulpaAttackID attack, AttackInfo info) {}

	/// <summary>
	/// Called when the player starts the remorse (berserk) mode of Mea Culpa.
	/// This plays an animation that damages enemies around the player.
	/// </summary>
	protected internal virtual void OnRemorseStart() {}

	/// <summary>
	/// Called when the player starts the remorse (berserk) mode of Mea Culpa,
	/// and hits an enemy during the start animation.
	/// </summary>
	protected internal virtual void OnRemorseStartHit(AttackInfo info) {}
}

