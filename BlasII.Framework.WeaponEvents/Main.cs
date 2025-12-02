using MelonLoader;

namespace BlasII.Framework.WeaponEvents;

internal class Main : MelonMod
{
    public static WeaponEventsFramework WeaponEventsFramework { get; private set; }

    public override void OnLateInitializeMelon()
    {
        WeaponEventsFramework = new WeaponEventsFramework();
    }
}
