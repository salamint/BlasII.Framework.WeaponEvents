using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using BlasII.ModdingAPI;

using Il2CppTGK.Game.Components.Attack.Data;

namespace BlasII.Framework.WeaponEvents.HandlersManagers;

/// <summary>
/// The common behavior of all handlers managers.
/// Mostly used to centralise the method that registers all the handlers in the
/// manager automatically, and instantiating the handlers list.
/// </summary>
public abstract class AbstractHandlersManager<HandlerType>
{
	/// <summary>
	/// The list of handlers managed by the manager.
	/// Every handler in this list will be called when an event (attack, attack
	/// hit) occurs in the game.
	/// </summary>
	public List<HandlerType> Handlers { get; private set; }

	/// <summary>
	/// </summary>
	public AttackInfo LastAttack { get; protected internal set; }

	/// <summary>
	/// Initialises the manager by instantiating the list of handlers with an
	/// emtpy list.
	/// </summary>
	public AbstractHandlersManager()
	{
		Handlers = new List<HandlerType>();
		LastAttack = null;
	}

	/// <summary>
	/// Instantiate every subclass of the type <typeparamref name="HandlerType"/>,
	/// then adds the instances to the list of handlers.
	/// </summary>
	public void RegisterAllHandlers()
	{

		string assemblyLocation = Assembly.GetExecutingAssembly().Location;
		string pluginsDir = Path.GetDirectoryName(assemblyLocation);

		foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
		{
			try
			{
				// Checking only other mods
				string dir = Path.GetDirectoryName(assembly.Location);
				if (dir != pluginsDir)
				{
					continue;
				}

				Handlers.AddRange(
						assembly.GetTypes()
						.Where(thisType => thisType.IsSubclassOf(typeof(HandlerType)))
						.Select(handlerType => (HandlerType) Activator.CreateInstance(handlerType))
						);
			}
			catch (NotSupportedException) { }
		}
        ModLog.Info($"Registered {Handlers.Count()} {nameof(HandlerType)}");
	}

	/// <summary>
	/// Method called on the manager when the player makes an attack (whether it
	/// hits an enemy or not).
	/// </summary>
	public abstract void HandleAttack(AttackID id);

	/// <summary>
	/// Methods called on the manager when the payer makes an attack that hits
	/// the enemy.
	/// </summary>
	public abstract void HandleAttackHit(AttackInfo info);
}

