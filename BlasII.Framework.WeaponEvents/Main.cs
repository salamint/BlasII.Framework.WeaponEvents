using MelonLoader;

namespace BlasII.Framework.WeaponEvents;

internal class Main : MelonMod
{
#nullable disable
    public static WeaponEventsFramework WeaponEventsFramework { get; private set; }
#nullable enable

    public override void OnLateInitializeMelon()
    {
        WeaponEventsFramework = new WeaponEventsFramework();
    }
}
