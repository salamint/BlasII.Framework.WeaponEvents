using System.Collections.Generic;

namespace BlasII.Framework.WeaponEvents.Constants;


/// <summary>
/// An enumeration that contains the integer ID for each weapon in the game.
/// </summary>
public enum Weapon
{
	/// <summary>
	/// Represents the absence of weapons.
	/// There is no name or string ID for this, it was chosen arbitrarily.
	/// </summary>
	NONE = 0,

	/// <summary>
	/// ID: <c>WPN01</c>
	/// </summary>
	CENSER = -1225666318,

	/// <summary>
	/// ID: <c>WPN02</c>
	/// </summary>
	RAPIER = 765471037,

	/// <summary>
	/// ID: <c>WPN03</c>
	/// </summary>
	BLADE = 886459938,

	/// <summary>
	/// ID: <c>WPN101</c>
	/// </summary>
	MEA_CULPA = -1038464864
}


/// <summary>
/// This class serves as an enumeration of strings.
/// The constants in this class represent the names of the attack tables for
/// each of the corresponding weapons.
/// This is used for some internal checks, and aren't meant to be used in real
/// applications (although you can).
/// </summary>
public sealed class PlayerAttackTable
{
	/// <summary>Name of the attack table of Veredicto</summary>
	public const string CENSER = "Censer Attacks Table";

	/// <summary>Name of the attack table of Sarmiento y Centella</summary>
	public const string RAPIER = "Rapier Attacks Table";

	/// <summary>Name of the attack table of Ruego al Alba</summary>
	public const string BLADE = "Blade Attacks Table";

	/// <summary>Name of the attack table of Mea Culpa</summary>
	public const string MEA_CULPA = "Mea Culpa Attacks Table";

	/// <summary>
	/// List of all the names of the attacks tables corresponding to a weapon.
	/// </summary>
	private static readonly List<string> TableNames = [
		CENSER, RAPIER, BLADE, MEA_CULPA
	];

	/// <summary>
	/// Checks if the given string matches one of the weapons' attack table.
	/// This is typically used to check if an attack was produced by the player,
	/// by checking if the attack's attack table is the attack table of a
	/// weapon.
	/// </summary>
	public static bool Contains(string tableName)
	{
		return TableNames.Contains(tableName);
	}
}

