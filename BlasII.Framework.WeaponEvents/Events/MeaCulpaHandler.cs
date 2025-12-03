using Il2CppTGK.Game.Components;

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
}

