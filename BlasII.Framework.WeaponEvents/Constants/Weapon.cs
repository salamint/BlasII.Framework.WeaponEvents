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


public sealed class PlayerAttackTable
{
	public const string CENSER = "Censer Attacks Table";
	public const string RAPIER = "Rapier Attacks Table";
	public const string BLADE = "Blade Attacks Table";
	public const string MEA_CULPA = "Mea Culpa Attacks Table";

	private static readonly List<string> TableNames = [
		CENSER, RAPIER, BLADE, MEA_CULPA
	];

	public static bool Contains(string tableName)
	{
		return TableNames.Contains(tableName);
	}
}

