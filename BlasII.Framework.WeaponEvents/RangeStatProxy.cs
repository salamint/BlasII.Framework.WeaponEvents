namespace BlasII.Framework.WeaponEvents;
using BlasII.ModdingAPI.Assets;
using Il2CppTGK.Game.Components.StatsSystem.Data;

/// <summary>
/// Give easy access to the properties of a RangeStat object.
/// </summary>
public class RangeStatProxy(string name)
{
	/// <summary>
	/// Name of the stat in the asset storage.
	/// </summary>
	public string Name { get; init; } = name;

	/// <summary>
	/// Returns the stat ID corresponding to the stat name.
	/// </summary>
	public RangeStatID StatID { get => AssetStorage.RangeStats[Name]; }

	/// <summary>
	/// Maximum value of the stat
	/// </summary>
	public int Max
	{
		get { return AssetStorage.PlayerStats.GetMaxValue(StatID); }
	}

	/// <summary>
	/// Minimum value of the stat.
	/// </summary>
	public int Min
	{
		get { return AssetStorage.PlayerStats.GetMinValue(StatID); }
	}

	/// <summary>
	/// Current value of the stat.
	/// </summary>
	public int Value
	{
		get { return AssetStorage.PlayerStats.GetCurrentValue(StatID); }
		set { AssetStorage.PlayerStats.SetCurrentValue(StatID, value); }
	}
}

