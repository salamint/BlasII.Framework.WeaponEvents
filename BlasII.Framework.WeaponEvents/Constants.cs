namespace BlasII.Framework.WeaponEvents;


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
/// Ruego al Alba is the name of a blade The Penitent One uses.
/// Aka. Ruego, blade, rosary blade.
/// Balanced range and speed, with average damage.
/// After multiple hits, a blood pact can be made to temporarily increase
/// the damages made.
/// </summary>
public enum BladeAttack
{
	/// <summary>ID: <c>WPN03_M01_1</c></summary>
	COMBO_1 = -222371605,

	/// <summary>ID: <c>WPN03_M01_2</c></summary>
	COMBO_2 = -222371606,

	/// <summary>ID: <c>WPN03_M01_3</c></summary>
	COMBO_3 = -222371607,

	/// <summary>ID: <c>WPN03_M01_3B</c></summary>
	COMBO_3_ASCENDING = 1199531539,

	/// <summary>ID: <c>WPN03_M01_03C</c></summary>
	COMBO_3_SPIN = -366552402,

	/// <summary>ID: <c>WPN03_M01_4</c></summary>
	COMBO_4 = -222371600,

	/// <summary>ID: <c>WPN03_M01_4B</c></summary>
	COMBO_4_BERSERK = 1199531546,

	/// <summary>ID: <c>WPN03_M02</c></summary>
	CROUCH = 1900301794,

	/// <summary>ID: <c>WPN03_M03_1</c></summary>
	AIR_SLASH_1 = -222371671,

	/// <summary>ID: <c>WPN03_M03_2</c></summary>
	AIR_SLASH_2 = -222371668,

	/// <summary>ID: <c>WPN03_M05_A</c></summary>
	NORMAL_RETRIBUTION = -222371489,

	/// <summary>ID: <c>WPN03_M05_B</c></summary>
	PERFECT_RETRIBUTION = -222371490,

	/// <summary>ID: <c>WPN03_M06</c></summary>
	BLOODPACT_START = 1900301798,

	/// <summary>ID: <c>WPN03_M07</c></summary>
	LOWER_PLUNGING_STRIKE = 1900301799,

	/// <summary>ID: <c>WPN03_M07 B</c></summary>
	MIDDLE_PLUNGING_STRIKE = -289628567,

	/// <summary>ID: <c>WPN03_M07 C</c></summary>
	HIGH_PLUNGING_STRIKE = -289628568,

	/// <summary>ID: <c>WPN03_M08</c></summary>
	BLOODPACT_SPECIAL = 1900301804,

	/// <summary>ID: <c>WPN03_M08B</c></summary>
	BLOODPACT_MIDAIR_SPECIAL = -2110223710
}


/// <summary>
/// Veredicto is the name of the war censer The Penitent One uses.
/// Aka. mace, censer, war censer.
/// Heavy and slow attacks with extra range.
/// Can be lit on fire for a damage boost and some combos.
/// TODO: charged attacks
/// </summary>
public enum CenserAttack
{
	/// <summary>ID: <c>WPN01_M01</c></summary>
	SWING = 1900295395,

	/// <summary>ID: <c>WPN01_M02</c></summary>
	CROUCH = 1900295396,

	/// <summary>ID: <c>WPN01_M03</c></summary>
	MIDAIR_SWING = 1900295397,

	/// <summary>ID: <c>WPN01_M04_Area</c></summary>
	IGNITION_AREA = -1254659442,

	/// <summary>ID: <c>WPN01_M05</c></summary>
	IGNITION_OR_TEMPER_STRIKE = 1900295399,

	/// <summary>ID: <c>WPN01_M05B</c></summary>
	TEMPER_STRIKE_FIRST_HIT = -2110230115,

	/// <summary>ID: <c>WPN01_M07</c></summary>
	MIDAIR_IGNITION_STRIKE = 1900295401,

	/// <summary>ID: <c>WPN01_M08B</c></summary>
	WHIRLWIND = -2110230112,

	/// <summary>ID: <c>WPN01_M09C</c></summary>
	CHARGED_ATTACK = -544146170
}


/// <summary>
/// Sarmiento and Centella are the names of the two rapiers The Penitent One uses.
/// Aka. SyC, rapiers.
/// Fast but with a small range.
/// After multiple strikes without being hit, they gain power, adding up a
/// large amount of elemental damages.
/// </summary>
public enum RapierAttack
{
	/// <summary>ID: <c>WPN02_M01A</c></summary>
	NORMAL = -1706940215,

	/// <summary>ID: <c>WPN02_M01B</c></summary>
	DIAGONAL = -2110224742,

	/// <summary>ID: <c>WPN02_M02</c></summary>
	CROUCHED = 1900300771,

	/// <summary>ID: <c>WPN02_M03</c></summary>
	MIDAIR = 1900300770,

	/// <summary>ID: <c>WPN02_M03C</c></summary>
	MIDAIR_DIAGONAL = -544140803,

	/// <summary>ID: <c>WPN02_M03D</c></summary>
	MIDAIR_POGO = -1303655690,

	/// <summary>ID: <c>WPN02_M05</c></summary>
	STORM_OF_THRUSTS = 1900300776,

	/// <summary>ID: <c>WPN02_M05B</c></summary>
	STORM_OF_THRUSTS_WEAK = -2110224738,

	/// <summary>ID: <c>WPN02_M09</c></summary>
	UP_SLASH = 1900300780,

	/// <summary>ID: <c>WPN02_M010</c></summary>
	DASH_COUNTER = -828582582,

	/// <summary>ID: <c>WPN02_M011</c></summary>
	NORMAL_THRUST = -828582583,

	/// <summary>ID: <c>WPN02_M011B</c></summary>
	ELECTRIC_THRUST = -564343777,

	/// <summary>ID: <c>WPN02_M012</c></summary>
	FINISHER = -828582584,

	/// <summary>ID: <c>WPN02_M013</c></summary>
	AIR_CROSS = -828582585,

	/// <summary>ID: <c>WPN02_M013B</c></summary>
	ELECTRIC_AIR_CROSS = -564343779
}


/// <summary>
/// Mea Culpa is the name of the blade The Penitent One first used in the
/// previous game. It came back in a DLC.
/// Same speed as Ruego al Alba, but with slightly more range.
/// </summary>
public enum MeaCulpa
{
	/// <summary>ID: <c>WPN101_M01_01</c></summary>
	COMBO_1 = -857645334,

	/// <summary>ID: <c>WPN101_M01_01PS</c></summary>
	COMBO_1_PROJECTILE_SPAWNER = 1029811307,

	/// <summary>ID: <c>WPN101_M01_02</c></summary>
	COMBO_2 = -857645333,

	/// <summary>ID: <c>WPN101_M01_03</c></summary>
	COMBO_3 = -857645332,

	/// <summary>ID: <c>WPN101_M01_03B</c></summary>
	COMBO_3_ASCENDING = 1241157654,

	/// <summary>ID: <c>WPN101_M01_03C</c></summary>
	COMBO_3_SPIN = -324926287,

	/// <summary>ID: <c>WPN101_M01_04</c></summary>
	COMBO_4 = -857645339,

	/// <summary>ID: <c>WPN101_M02</c></summary>
	CROUCH = 1638739701,

	/// <summary>ID: <c>WPN101_M03_1</c></summary>
	MIDAIR_COMBO_1 = 1826341950,

	/// <summary>ID: <c>WPN101_M03_01PS</c></summary>
	MIDAIR_COMBO_1_PROJECTILE_SPAWNER = 1756601781,

	/// <summary>ID: <c>WPN101_M03_02</c></summary>
	MIDAIR_COMBO_2 = -575320331,

	/// <summary>ID: <c>WPN101_M04</c></summary>
	UP_ATTACK = 475940287,

	/// <summary>ID: <c>WPN101_M04PS</c></summary>
	UP_ATTACK_PROJECTILE_SPAWNER = 1066827054,

	/// <summary>ID: <c>WPN101_M05_A</c></summary>
	RETRIBUTION = -48918184,

	/// <summary>ID: <c>WPN101_M05_B</c></summary>
	PERFECT_RETRIBUTION = 354366343,

	/// <summary>ID: <c>WPN101_M06 - Phantom Projectile</c></summary>
	PHANTOM_PROJECTILE = -1893509238,

	/// <summary>ID: <c>WPN101_M07</c></summary>
	PLUNGING_STRIKE = 879224814,

	/// <summary>ID: <c>WPN101_M07 C</c></summary>
	HIGH_PLUNGING_STRIKE = -8512353,

	/// <summary>ID: <c>WPN101_M08B</c></summary>
	CHARGED = 1866180001,

	/// <summary>ID: <c>WPN101_M10</c></summary>
	THRUST = -1493428182,

	/// <summary>ID: <c>WPN101_M99</c></summary>
	REMORSE_START = 428886127
}

