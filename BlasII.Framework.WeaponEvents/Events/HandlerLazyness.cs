using System;

namespace BlasII.Framework.WeaponEvents.Events;


/// <summary>
/// Attribute used to set the lazyness of a handler class.
/// The lazyness of a class if not specified is 0 by default.
/// The lazyness controls the execution order of the handlers, if multiple
/// handlers override the same method for example.
/// This can allow the user to forcibly execute their method before or after the
/// method of another mod.
/// Every handler of the same type that have the same lazyness have not
/// guaranteed order of execution.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class HandlerLazynessAttribute : Attribute
{
	/// <summary>
	/// Represents the lazyness of the handler to be executed.
	/// The higher the lazyness, the later it gets executed.
	/// Negative values are accepted and will make the handler execute before
	/// others.
	/// </summary>
	public int Lazyness { get; private set; }

	/// <summary>
	/// Sets the lazyness of the current handler.
	/// The default value is 0.
	/// The higher the value, the later it gets executed.
	/// The lower the value, the earlier it gets executed.
	/// Negative values are accepted and will cause this handler to execute
	/// before others.
	/// Handlers of the same lazyness have no guaranteed order.
	/// </summary>
	public HandlerLazynessAttribute(int lazyness = 0) => Lazyness = lazyness;
}
