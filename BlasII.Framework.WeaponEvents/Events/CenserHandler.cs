using Il2CppTGK.Game.Components.Attack;
using Il2CppTGK.Game.Components.Attack.Data;

namespace BlasII.Framework.WeaponEvents.Events;


/// <summary>
/// Abstract class that handles Veredicto's related events.
/// The corresponding methods are automatically called by the manager.
/// To handle these events, simply make a sub class of this class.
/// </summary>
public abstract class CenserHandler : CommonWeaponHandler
{
	/// <summary>
	/// Shorthand to the global CenserIgniter object stored statically,
	/// to be able to access it as if it was an attribute.
	/// </summary>
	public CenserIgniter Igniter { get => Main.WeaponEventsFramework.CenserIgniter; }

	/// <summary>
	/// Shorthand to the global boolean stored statically,
	/// to be able to access it as if it was an attribute.
	/// </summary>
	public bool IsIgnited { get => Main.WeaponEventsFramework.IsCenserIgnited; }

	/* Swing */

	/// <summary>
	/// Called when the player swings Veredicto while standing on the ground.
	/// </summary>
	public virtual void OnSwing() {}

	/// <summary>
	/// Called when the player swings Veredicto while standing on the ground,
	/// and hits an enemy with this attack.
	/// </summary>
	public virtual void OnSwingHit(AttackInfo info) {}

	/// <summary>
	/// Called when the player swings Veredicto while standing on the ground,
	/// and hits an enemy with the first hit of this attack.
	/// </summary>
	public virtual void OnSwingHit1(AttackInfo info) {}

	/// <summary>
	/// Called when the player swings Veredicto while standing on the ground,
	/// and hits an enemy with the second hit of this attack.
	/// </summary>
	public virtual void OnSwingHit2(AttackInfo info) {}

	/// <summary>
	/// Called when the player attacks with Veredicto while crouching.
	/// </summary>
	public virtual void OnCrouchAttack() {}

	/// <summary>
	/// Called when the player attacks with Veredicto while crouching and hits
	/// an enemy with this attack.
	/// </summary>
	public virtual void OnCrouchAttackHit(AttackInfo info) {}

	/// <summary>
	/// Called when the player swings Veredicto while in the air.
	/// </summary>
	public virtual void OnMidairSwing() {}

	/// <summary>
	/// Called when the player swings Veredicto while in the air and hits an
	/// enemy with this attack.
	/// </summary>
	public virtual void OnMidairSwingHit(AttackInfo info) {}

	/// <summary>
	/// Called when the player swings Veredicto while in the air and hits an
	/// enemy with the first hit of this attack.
	/// </summary>
	public virtual void OnMidairSwingHit1(AttackInfo info) {}

	/// <summary>
	/// Called when the player swings Veredicto while in the air and hits an
	/// enemy with the second hit of this attack.
	/// </summary>
	public virtual void OnMidairSwingHit2(AttackInfo info) {}

	/// <summary>
	/// Called when the player ignites Veredicto on the ground with the upgrades
	/// that damages the enemies nearby.
	/// </summary>
	public virtual void OnIgnitionArea() {}

	/// <summary>
	/// Called when the player ignites Veredicto on the ground with the upgrades
	/// that damages the enemies nearby, and it hits an enemy.
	/// </summary>
	public virtual void OnIgnitionAreaHit(AttackInfo info) {}

	/* Ignition or temper strikes */

	/// <summary>
	/// Called when the player ignites Veredicto right after a normal attack, or
	/// after an ignition or temper strike, generating an ignition or temper
	/// strike.
	/// </summary>
	public virtual void OnIgnitionOrTemperStrike() {}

	/// <summary>
	/// Called when the player ignites Veredicto right after a normal attack, or
	/// after an ignition or temper strike, generating an ignition or temper
	/// strike, and hits an enemy with it.
	/// The hit number is passed as a paramater, there is one call of this
	/// method per hit.
	/// </summary>
	public virtual void OnIgnitionOrTemperStrikeHit(AttackInfo info, int hit) {}

	/// <summary>
	/// Called when the player ignites Veredicto right after a normal attack, or
	/// after a temper strike, generating an ignition strike.
	/// </summary>
	public virtual void OnIgnitionStrike() {}

	/// <summary>
	/// Called when the player ignites Veredicto right after a normal attack,
	/// after a temper strike, generating an ignition strike, and hits an enemy
	/// with it.
	/// The hit number is passed as a paramater, there is one call of this
	/// method per hit.
	/// </summary>
	public virtual void OnIgnitionStrikeHit(AttackInfo info, int hit) {}

	/// <summary>
	/// Called when the player ignites Veredicto right after a normal ignited
	/// attack, or after an ignition strike, generating a temper strike.
	/// </summary>
	public virtual void OnTemperStrike() {}

	/// <summary>
	/// Called when the player ignites Veredicto right after a normal ignited
	/// attack, or after an ignition strike, generating a temper strike, and
	/// hits an enemy with it.
	/// The hit number is passed as a paramater, there is one call of this
	/// method per hit.
	/// </summary>
	public virtual void OnTemperStrikeHit(AttackInfo info, int hit) {}

	/// <summary>
	/// Called when the player ignites Veredicto while in the air.
	/// </summary>
	public virtual void OnMidairIgnition() {}

	/// <summary>
	/// Called when the player ignites Veredicto while in the air, and hits an
	/// enemy with it.
	/// </summary>
	public virtual void OnMidairIgnitionHit(AttackInfo info) {}

	/// <summary>
	/// Called when the player releases the charged attack in the air, creating
	/// a whirlwind and making them spin.
	/// </summary>
	public virtual void OnWhirlwind() {}

	/// <summary>
	/// Called when the player releases the charged attack in the air, creating
	/// a whirlwind and making them spin, and hits an enemy.
	/// </summary>
	public virtual void OnWhirlwindHit(AttackInfo info) {}

	/// <summary>
	/// Called when the player releases the charged attack on the ground,
	/// creating a big impact, as well as a shockwave (if upgraded).
	/// </summary>
	public virtual void OnChargedAttack() {}

	/// <summary>
	/// Called when the player releases the charged attack on the ground,
	/// creating a big impact, as well as a shockwave (if upgraded), and this
	/// attack hits an enemy.
	/// </summary>
	public virtual void OnChargedAttackHit(AttackInfo info) {}

	/// <summary>
	/// Called when Veredicto is ignited by the player.
	/// This is called when the player manually ignites Veredicto.
	/// </summary>
	public virtual void OnIgnited() {}

	/// <summary>
	/// Called when Veredicto is either extinguished or ignited by the player.
	/// This is called whether the player manually extinguishes or ignites
	/// Veredicto or when the player switches weapon, extinguishing it.
	/// </summary>
	public virtual void OnToggled() {}

	/// <summary>
	/// Called when Veredicto is extinguished by the player.
	/// This is called whether the player manually extinguishes Veredicto or
	/// when the player switches weapon.
	/// </summary>
	public virtual void OnExtinguished() {}
}

