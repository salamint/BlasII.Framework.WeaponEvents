using Il2CppGame.Components.Attack;
using Il2CppTGK.Game.Components.Attack.Data;

namespace BlasII.Framework.WeaponEvents.Handlers;


/// <summary>
/// Abstract class that handles Ruego al Alba's related events.
/// The corresponding methods are automatically called by the manager.
/// To handle these events, simply make a sub class of this class.
/// </summary>
public abstract class BladeHandler : CommonWeaponHandler
{
	protected internal static bool manuallySettingBerserkMode = false;

	/// <summary>
	/// A shortcut to the common global BladeBerserkModeFiller reference.
	/// </summary>
	public BladeBerserkModeFiller BerserkModeFiller { get => Main.WeaponEventsFramework.BladeBerserkModeFiller; }

	protected internal static int currentBerserkModeValue = 0;
	public int CurrentBerserkModeValue
	{
		get => currentBerserkModeValue;
		set
		{
			if (BerserkModeFiller != null)
			{
				manuallySettingBerserkMode = true;
				BerserkModeFiller.SetCurrentBerserkModeValue(value);
				manuallySettingBerserkMode = false;
			}
		}
	}

	protected internal virtual void OnSetCurrentBerserkModeValue(int value) {}

	/* Normal attacks */

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

	/* Counter attacks */

	/// <summary>
	/// Called when the player parries an incoming attack with Ruego al Alba,
	/// but missed the timing to do a perfect parry.
	/// </summary>
	protected internal virtual void OnRetribution() {}

	/// <summary>
	/// Called when the player parries an incoming attack with Ruego al Alba,
	/// but missed the timing to do a perfect parry, but hits an enemy with it.
	/// </summary>
	protected internal virtual void OnRetributionHit(AttackInfo info) {}

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

	/* Blood pact */

	protected internal virtual void OnBloodPactStart() {}
	protected internal virtual void OnBloodPactStartHit(AttackInfo info) {}

	protected internal virtual void OnBloodPactAttack() {}
	protected internal virtual void OnBloodPactAttackHit(AttackInfo info) {}

	protected internal virtual void OnBloodPactAttackMidAir() {}
	protected internal virtual void OnBloodPactAttackMidAirHit(AttackInfo info) {}

	protected internal virtual void OnBloodPactSpecialAttack() {}
	protected internal virtual void OnBloodPactSpecialAttackHit(AttackInfo info) {}

	protected internal virtual void OnBloodPactSpecialAttackMidAir() {}
	protected internal virtual void OnBloodPactSpecialAttackMidAirHit(AttackInfo info) {}

	protected internal virtual void OnBloodPactEnd() {}
}

