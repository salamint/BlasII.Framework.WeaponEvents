namespace BlasII.Framework.WeaponEvents.Events;


/// <summary>
/// Abstract class that handles the events of no weapon in particular, meaning
/// whether you use Veredicto, Sarmiento y Centella, Ruego al Alba of Mea Culpa,
/// the methods in this class will be called.
/// The corresponding methods are automatically called by the manager.
/// To handle these events, simply make a sub class of this class.
/// </summary>
public abstract class WeaponHandler : CommonWeaponHandler {}

