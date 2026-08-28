using BlasII.ModdingAPI;
using BlasII.Framework.WeaponEvents.Constants;
using BlasII.Framework.WeaponEvents.Events;
using Il2CppTGK.Game.Components.Attack.Data;
using System;

namespace BlasII.Framework.WeaponEvents.HandlersManagers;


/// <summary>
/// Manages the handlers for Embrujo.
/// </summary>
public class WhipHandlersManager : AbstractHandlersManager<WhipHandler>
{
	/// <summary>Calls the base class constructor.</summary>
	public WhipHandlersManager() : base("Embrujo") {}

	/// <summary>
	/// Handles Embrujo's attacks, and calls the corresponding managed
	/// handlers methods.
	/// </summary>
	public override void HandleAttack(AttackID id)
	{
		Handlers.ForEach(handler => handler.OnAttack(id));

		WhipAttackID attack = (WhipAttackID) id.id;
		if (!Enum.IsDefined(typeof(WhipAttackID), attack))
		{
			LogUnknownAttackIDError(id);
			return;
		}

		switch (attack)
		{
			case WhipAttackID.NORMAL_1:
			case WhipAttackID.DIAGONAL_1:
			case WhipAttackID.UP_1:
				HandleFirstAttack(attack);
				break;
			case WhipAttackID.NORMAL_2:
			case WhipAttackID.DIAGONAL_2:
			case WhipAttackID.UP_2:
				HandleSecondAttack(attack);
				break;
			case WhipAttackID.DOWN:
				Handlers.ForEach(handler => handler.OnCrouchAttack());
				break;
			case WhipAttackID.MIDAIR_ATTACK:
			case WhipAttackID.MIDAIR_DIAGONAL_UP:
			case WhipAttackID.MIDAIR_UP:
			case WhipAttackID.MIDAIR_DIAGONAL_DOWN:
				HandleMidAirAttack(attack);
				break;
			case WhipAttackID.SLIDE:
				Handlers.ForEach(handler => handler.OnSlideAttack());
				break;
			case WhipAttackID.CROUCH_SPIN:
			case WhipAttackID.CROUCH_SPIN_LAST_HIT:
				HandleCrouchSpinAttack(attack);
				break;
			case WhipAttackID.GRAPPLING:
			case WhipAttackID.AIR_GRAPPLING:
				HandleGrapplingAttack(attack);
				break;
			case WhipAttackID.SPIN_CANCEL:
			case WhipAttackID.SPIN_FINISHER:
			case WhipAttackID.SPIN_START:
			case WhipAttackID.SPIN_ACCELERATION:
			case WhipAttackID.SPIN_FULL_SPEED:
			case WhipAttackID.SPIN_PROJECTILE:
				HandleSpinAttack(attack);
				break;
			case WhipAttackID.DOWNWARD_SPIRAL:
				Handlers.ForEach(handler => handler.OnDownwardSpiral());
				break;
			case WhipAttackID.COMBO:
				Handlers.ForEach(handler => handler.OnComboAttack());
				break;
		}
	}

	/// <summary>
	/// Handles Embrujo's attacks when they hit an enemy, and calls the
	/// corresponding managed handlers methods.
	/// </summary>
	public override void HandleAttackHit(AttackInfo info)
	{
		Handlers.ForEach(handler => handler.OnAttackHit(info));

		WhipAttackID attack = (WhipAttackID) info.attackID.id;
		if (!Enum.IsDefined(typeof(WhipAttackID), attack))
		{
			LogUnknownAttackIDError(info.attackID);
			return;
		}

		switch (attack)
		{
			case WhipAttackID.NORMAL_1:
			case WhipAttackID.DIAGONAL_1:
			case WhipAttackID.UP_1:
				HandleFirstAttackHit(attack, info);
				break;
			case WhipAttackID.NORMAL_2:
			case WhipAttackID.DIAGONAL_2:
			case WhipAttackID.UP_2:
				HandleSecondAttackHit(attack, info);
				break;
			case WhipAttackID.DOWN:
				Handlers.ForEach(handler => handler.OnCrouchAttackHit(info));
				break;
			case WhipAttackID.MIDAIR_ATTACK:
			case WhipAttackID.MIDAIR_DIAGONAL_UP:
			case WhipAttackID.MIDAIR_UP:
			case WhipAttackID.MIDAIR_DIAGONAL_DOWN:
				HandleMidAirAttackHit(attack, info);
				break;
			case WhipAttackID.SLIDE:
				Handlers.ForEach(handler => handler.OnSlideAttackHit(info));
				break;
			case WhipAttackID.CROUCH_SPIN:
			case WhipAttackID.CROUCH_SPIN_LAST_HIT:
				HandleCrouchSpinAttackHit(attack, info);
				break;
			case WhipAttackID.GRAPPLING:
			case WhipAttackID.AIR_GRAPPLING:
				HandleGrapplingAttackHit(attack, info);
				break;
			case WhipAttackID.SPIN_CANCEL:
			case WhipAttackID.SPIN_FINISHER:
			case WhipAttackID.SPIN_START:
			case WhipAttackID.SPIN_ACCELERATION:
			case WhipAttackID.SPIN_FULL_SPEED:
			case WhipAttackID.SPIN_PROJECTILE:
				HandleSpinAttackHit(attack, info);
				break;
			case WhipAttackID.DOWNWARD_SPIRAL:
				Handlers.ForEach(handler => handler.OnDownwardSpiralHit(info));
				break;
			case WhipAttackID.COMBO:
			case WhipAttackID.COMBO_FIRST_HIT:
				HandleComboAttackHit(attack, info);
				break;
		}
    }

	/// <summary>
	/// Handles Embrujo's first simple attacks on ground.
	/// </summary>
	public void HandleFirstAttack(WhipAttackID attack)
	{
		switch (attack)
		{
			case WhipAttackID.NORMAL_1:
				Handlers.ForEach(handler => handler.OnFirstAttack(AttackDirection.FRONT));
				break;
			case WhipAttackID.DIAGONAL_1:
				Handlers.ForEach(handler => handler.OnFirstAttack(AttackDirection.DIAGONAL_UP));
				break;
			case WhipAttackID.UP_1:
				Handlers.ForEach(handler => handler.OnFirstAttack(AttackDirection.UP));
				break;
		}
	}

	/// <summary>
	/// Handles Embrujo's second simple attacks on ground.
	/// </summary>
	public void HandleSecondAttack(WhipAttackID attack)
	{
		switch (attack)
		{
			case WhipAttackID.NORMAL_2:
				Handlers.ForEach(handler => handler.OnSecondAttack(AttackDirection.FRONT));
				break;
			case WhipAttackID.DIAGONAL_2:
				Handlers.ForEach(handler => handler.OnSecondAttack(AttackDirection.DIAGONAL_UP));
				break;
			case WhipAttackID.UP_2:
				Handlers.ForEach(handler => handler.OnSecondAttack(AttackDirection.UP));
				break;
		}
	}

	/// <summary>
	/// Handles Embrujo's attacks mid air.
	/// </summary>
	public void HandleMidAirAttack(WhipAttackID attack)
	{
		switch (attack)
		{
			case WhipAttackID.MIDAIR_ATTACK:
				Handlers.ForEach(handler => handler.OnMidAirAttack(AttackDirection.FRONT));
				break;
			case WhipAttackID.MIDAIR_DIAGONAL_UP:
				Handlers.ForEach(handler => handler.OnMidAirAttack(AttackDirection.DIAGONAL_UP));
				break;
			case WhipAttackID.MIDAIR_UP:
				Handlers.ForEach(handler => handler.OnMidAirAttack(AttackDirection.UP));
				break;
			case WhipAttackID.MIDAIR_DIAGONAL_DOWN:
				Handlers.ForEach(handler => handler.OnMidAirAttack(AttackDirection.DIAGONAL_DOWN));
				break;
		}
	}

	/// <summary>
	/// Handles Embrujo's crouch spin attack.
	/// </summary>
	public void HandleCrouchSpinAttack(WhipAttackID attack)
	{
		Handlers.ForEach(handler => handler.OnCrouchSpinAttack());
		switch (attack)
		{
			case WhipAttackID.CROUCH_SPIN:
				Handlers.ForEach(handler => handler.OnCrouchSpinAttack());
				break;
			case WhipAttackID.CROUCH_SPIN_LAST_HIT:
				Handlers.ForEach(handler => handler.OnCrouchSpinAttackFinisher());
				break;
		}
	}

	/// <summary>
	/// Handles Embrujo's grappling attack.
	/// </summary>
	public void HandleGrapplingAttack(WhipAttackID attack)
	{
		switch (attack)
		{
			case WhipAttackID.GRAPPLING:
				Handlers.ForEach(handler => handler.OnGrapplingAttack(false));
				break;
			case WhipAttackID.AIR_GRAPPLING:
				Handlers.ForEach(handler => handler.OnGrapplingAttack(true));
				break;
		}
	}

	/// <summary>
	/// Handles Embrujo's spin attack.
	/// </summary>
	public void HandleSpinAttack(WhipAttackID attack)
	{
		Handlers.ForEach(handler => handler.OnSpinAttack());
		switch (attack)
		{
			case WhipAttackID.SPIN_CANCEL:
				Handlers.ForEach(handler => handler.OnSpinCancelled());
				break;
			case WhipAttackID.SPIN_FINISHER:
				Handlers.ForEach(handler => handler.OnSpinFinisher());
				break;
			case WhipAttackID.SPIN_START:
				Handlers.ForEach(handler => handler.OnSpinStart());
				break;
			case WhipAttackID.SPIN_ACCELERATION:
				Handlers.ForEach(handler => handler.OnSpinFirstAcceleration());
				break;
			case WhipAttackID.SPIN_FULL_SPEED:
				Handlers.ForEach(handler => handler.OnSpinSecondAcceleration());
				break;
			case WhipAttackID.SPIN_PROJECTILE:
				Handlers.ForEach(handler => handler.OnSpinProjectile());
				break;
		}
	}

	/// <summary>
	/// Handles Embrujo's first simple attacks on ground when they hit an enemy.
	/// </summary>
	public void HandleFirstAttackHit(WhipAttackID attack, AttackInfo info)
	{
		switch (attack)
		{
			case WhipAttackID.NORMAL_1:
				Handlers.ForEach(handler => handler.OnFirstAttackHit(AttackDirection.FRONT, info));
				break;
			case WhipAttackID.DIAGONAL_1:
				Handlers.ForEach(handler => handler.OnFirstAttackHit(AttackDirection.DIAGONAL_UP, info));
				break;
			case WhipAttackID.UP_1:
				Handlers.ForEach(handler => handler.OnFirstAttackHit(AttackDirection.UP, info));
				break;
		}
	}

	/// <summary>
	/// Handles Embrujo's second simple attacks on ground when they hit an enemy.
	/// </summary>
	public void HandleSecondAttackHit(WhipAttackID attack, AttackInfo info)
	{
		switch (attack)
		{
			case WhipAttackID.NORMAL_2:
				Handlers.ForEach(handler => handler.OnSecondAttackHit(AttackDirection.FRONT, info));
				break;
			case WhipAttackID.DIAGONAL_2:
				Handlers.ForEach(handler => handler.OnSecondAttackHit(AttackDirection.DIAGONAL_UP, info));
				break;
			case WhipAttackID.UP_2:
				Handlers.ForEach(handler => handler.OnSecondAttackHit(AttackDirection.UP, info));
				break;
		}
	}

	/// <summary>
	/// Handles Embrujo's attacks mid air when they hit an enemy.
	/// </summary>
	public void HandleMidAirAttackHit(WhipAttackID attack, AttackInfo info)
	{
		switch (attack)
		{
			case WhipAttackID.MIDAIR_ATTACK:
				Handlers.ForEach(handler => handler.OnMidAirAttackHit(AttackDirection.FRONT, info));
				break;
			case WhipAttackID.MIDAIR_DIAGONAL_UP:
				Handlers.ForEach(handler => handler.OnMidAirAttackHit(AttackDirection.DIAGONAL_UP, info));
				break;
			case WhipAttackID.MIDAIR_UP:
				Handlers.ForEach(handler => handler.OnMidAirAttackHit(AttackDirection.UP, info));
				break;
			case WhipAttackID.MIDAIR_DIAGONAL_DOWN:
				Handlers.ForEach(handler => handler.OnMidAirAttackHit(AttackDirection.DIAGONAL_DOWN, info));
				break;
		}
	}

	/// <summary>
	/// Handles Embrujo's crouch spin attack when it hits an enemy.
	/// </summary>
	public void HandleCrouchSpinAttackHit(WhipAttackID attack, AttackInfo info)
	{
		Handlers.ForEach(handler => handler.OnCrouchSpinAttackHit(info));
		switch (attack)
		{
			case WhipAttackID.CROUCH_SPIN:
				Handlers.ForEach(handler => handler.OnCrouchSpinAttackHit(info));
				break;
			case WhipAttackID.CROUCH_SPIN_LAST_HIT:
				Handlers.ForEach(handler => handler.OnCrouchSpinAttackHit(info));
				break;
		}
	}

	/// <summary>
	/// Handles Embrujo's grappling attack when it hits an enemy.
	/// </summary>
	public void HandleGrapplingAttackHit(WhipAttackID attack, AttackInfo info)
	{
		switch (attack)
		{
			case WhipAttackID.GRAPPLING:
				Handlers.ForEach(handler => handler.OnGrapplingAttackHit(info, false));
				break;
			case WhipAttackID.AIR_GRAPPLING:
				Handlers.ForEach(handler => handler.OnGrapplingAttackHit(info, true));
				break;
		}
	}

	/// <summary>
	/// Handles Embrujo's spin attack when it hits an enemy.
	/// </summary>
	public void HandleSpinAttackHit(WhipAttackID attack, AttackInfo info)
	{
		Handlers.ForEach(handler => handler.OnSpinAttackHit(info));
		switch (attack)
		{
			case WhipAttackID.SPIN_CANCEL:
				Handlers.ForEach(handler => handler.OnSpinCancelledHit(info));
				break;
			case WhipAttackID.SPIN_FINISHER:
				Handlers.ForEach(handler => handler.OnSpinFinisherHit(info));
				break;
			case WhipAttackID.SPIN_START:
				Handlers.ForEach(handler => handler.OnSpinStartHit(info));
				break;
			case WhipAttackID.SPIN_ACCELERATION:
				Handlers.ForEach(handler => handler.OnSpinFirstAccelerationHit(info));
				break;
			case WhipAttackID.SPIN_FULL_SPEED:
				Handlers.ForEach(handler => handler.OnSpinSecondAccelerationHit(info));
				break;
			case WhipAttackID.SPIN_PROJECTILE:
				Handlers.ForEach(handler => handler.OnSpinProjectileHit(info));
				break;
		}
	}

	/// <summary>
	/// Handles Embrujo's combo attacks when they hit an enemy.
	/// </summary>
	public void HandleComboAttackHit(WhipAttackID attack, AttackInfo info)
	{
		switch (attack)
		{
			case WhipAttackID.COMBO:
				Handlers.ForEach(handler => handler.OnComboAttackHit(info));
				break;
			case WhipAttackID.COMBO_FIRST_HIT:
				Handlers.ForEach(handler => handler.OnComboAttackFirstHit(info));
				break;
		}
	}

	/// <summary>
	/// Calls the toggled and ignited methods when Embrujo is ignited.
	/// </summary>
	public void HandleIgnited()
	{
		Handlers.ForEach(handler => handler.OnToggled());
		Main.WeaponEventsFramework.IsWhipIgnited = true;
		Handlers.ForEach(handler => handler.OnIgnited());
	}

	/// <summary>
	/// Calls the toggled and extinguish methods when Embrujo is extinguished.
	/// </summary>
	public void HandleExtinguished()
	{
		Handlers.ForEach(handler => handler.OnToggled());
		Main.WeaponEventsFramework.IsWhipIgnited = false;
		Handlers.ForEach(handler => handler.OnExtinguished());
	}

	/// <summary>
	/// Handles Embrujo's ability to graple to anchors.
	/// </summary>
	public void HandleGrapple(WhipAttackID attack)
	{
		switch (attack)
		{
			case WhipAttackID.GRAPLE_FRONT:
				Handlers.ForEach(handler => handler.OnGrapple(AttackDirection.FRONT, false));
				break;
			case WhipAttackID.GRAPLE_DIAGONAL_UP:
				Handlers.ForEach(handler => handler.OnGrapple(AttackDirection.DIAGONAL_UP, false));
				break;
			case WhipAttackID.GRAPLE_UP:
				Handlers.ForEach(handler => handler.OnGrapple(AttackDirection.UP, false));
				break;
			case WhipAttackID.GRAPLE_MIDAIR_FRONT:
				Handlers.ForEach(handler => handler.OnGrapple(AttackDirection.FRONT, true));
				break;
			case WhipAttackID.GRAPLE_MIDAIR_DIAGONAL_UP:
				Handlers.ForEach(handler => handler.OnGrapple(AttackDirection.DIAGONAL_UP, true));
				break;
			case WhipAttackID.GRAPLE_MIDAIR_UP:
				Handlers.ForEach(handler => handler.OnGrapple(AttackDirection.UP, true));
				break;
			case WhipAttackID.GRAPLE_MIDAIR_DIAGONAL_DOWN:
				Handlers.ForEach(handler => handler.OnGrapple(AttackDirection.DIAGONAL_DOWN, true));
				break;
			case WhipAttackID.GRAPLE_MIDAIR_DOWN:
				Handlers.ForEach(handler => handler.OnGrapple(AttackDirection.DOWN, true));
				break;
		}
	}
}
