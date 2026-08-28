namespace BlasII.Framework.WeaponEvents.Constants;

/// <summary>
/// Direction of the attack, based on the angle.
/// It covers the 4 cardinal directions as well as the diagonals.
/// Since the sprites are mirrored, the game uses the same attacks for the left
/// and right side, only 5 of the 8 directions are useful, the up and down
/// directions not being mirrored and the front, diagonal up and diagonal down
/// directions being mirrored.
/// </summary>
public enum AttackDirection
{
	/// <summary>
	/// The attack is in front of the player, at a 0 degree angle.
	/// </summary>
	FRONT,

	/// <summary>
	/// The attack is directed to the sky but is still in front of the player,
	/// at a 45 degree angle.
	/// </summary>
	DIAGONAL_UP,

	/// <summary>
	/// The attack is right above the player, at a 90 degree angle.
	/// </summary>
	UP,

	/// <summary>
	/// The attack is right below the player, at a 270 degree angle.
	/// </summary>
	DOWN,

	/// <summary>
	/// The attack is directed to the ground but is still in front of the
	/// player, at a 315 degree angle.
	/// </summary>
	DIAGONAL_DOWN
}

