namespace BlasII.Framework.WeaponEvents.Constants;


/// <summary>
/// Veredicto is the name of the war censer The Penitent One uses.
/// Aka. mace, censer, war censer.
/// Heavy and slow attacks with extra range.
/// Can be lit on fire for a damage boost and some combos.
/// TODO: charged attacks
/// </summary>
public enum CenserAttackID
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
