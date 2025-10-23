using BlasII.Framework.WeaponEvents.Constants;
using Il2CppTGK.Game.Components;
using Il2CppTGK.Game.Components.Attack.Data;

namespace BlasII.Framework.WeaponEvents.Events;


public abstract class MeaCulpaHandler : CommonWeaponHandler
{
	public MeaCulpaBerserkModeFiller BerserkModeFiller { get => Main.WeaponEventsFramework.MeaCulpaBerserkModeFiller; }

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

	protected internal virtual void OnCombo(MeaCulpaAttackID attack) {}

	protected internal virtual void OnComboHit(MeaCulpaAttackID attack, AttackInfo info) {}

	protected internal virtual void OnCombo1() {}

	protected internal virtual void OnCombo1ProjectileSpawner() {}

	protected internal virtual void OnCombo1Hit(AttackInfo info) {}

	protected internal virtual void OnCombo1ProjectileSpawnerHit(AttackInfo info) {}

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

	/* Mid air attacks */

	protected internal virtual void OnMidairSlash(MeaCulpaAttackID attack) {}

	protected internal virtual void OnMidairSlashHit(MeaCulpaAttackID attack, AttackInfo info) {}

	protected internal virtual void OnMidairSlash1() {}

	protected internal virtual void OnMidairSlash1Hit(AttackInfo info) {}

	protected internal virtual void OnMidairSlash1ProjectileSpawner() {}

	protected internal virtual void OnMidairSlash1ProjectileSpawnerHit(AttackInfo info) {}

	protected internal virtual void OnMidairSlash2() {}

	protected internal virtual void OnMidairSlash2Hit(AttackInfo info) {}

	/* Charged attacks */

	protected internal virtual void OnChargedAttack() {}

	protected internal virtual void OnChargedAttackHit(AttackInfo info) {}

	/* Thrust attacks */

	protected internal virtual void OnThrustAttack() {}

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

	protected internal virtual void OnUpSlashAttack() {}

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

	protected internal virtual void OnRemorseAttack(BladeAttackID attack) {}

	protected internal virtual void OnRemorseAttackHit(BladeAttackID attack, AttackInfo info) {}

	protected internal virtual void OnRemorseStart() {}

	protected internal virtual void OnRemorseStartHit(AttackInfo info) {}
}

