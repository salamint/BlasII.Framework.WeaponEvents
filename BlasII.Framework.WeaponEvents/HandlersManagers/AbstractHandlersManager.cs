using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using BlasII.Framework.WeaponEvents.Events;
using BlasII.ModdingAPI;

using Il2CppTGK.Game.Components.Attack.Data;

namespace BlasII.Framework.WeaponEvents.HandlersManagers;

/// <summary>
/// The common behavior of all handlers managers.
/// Mostly used to centralise the method that registers all the handlers in the
/// manager automatically, and instantiating the handlers list.
/// </summary>
public abstract class AbstractHandlersManager<HandlerType> where HandlerType : CommonWeaponHandler
{
	/// <summary>
	/// The name of the weapon the type of handler that is being managed is
	/// handling events for. This is used for error messages.
	/// </summary>
	public string Name { get; private set; }

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
	public AbstractHandlersManager(string name)
	{
		Handlers = new List<HandlerType>();
		LastAttack = null;
	}

	/// <summary>
	/// Instantiate every subclass of the type <typeparamref name="HandlerType"/>,
	/// then adds the instances to the list of handlers.
	/// The handlers are sorted by their lazyness.
	/// </summary>
	public void RegisterAllHandlers()
	{

		string assemblyLocation = Assembly.GetExecutingAssembly().Location;
		string pluginsDir = Path.GetDirectoryName(assemblyLocation);
		SortedDictionary<int, List<HandlerType>> foundHandlers = new ();
		HandlerLazynessAttribute lazynessAttribute = null;

		foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
		{
			// This filters out dynamic assemblies, not to be mistaken with
			// dynamic libraries. Dynamic assemblies do not come from a
			// file, so they do not have a Location.
			if (assembly.IsDynamic)
			{
				continue;
			}

			// Checking only other mods
			string dir = Path.GetDirectoryName(assembly.Location);
			if (dir != pluginsDir)
			{
				continue;
			}

			// Fecthing the types that inherit from the HandlerType
			IEnumerable<HandlerType> handlers = assembly.GetTypes()
					.Where(thisType => thisType.IsSubclassOf(typeof(HandlerType)))
					.Select(handlerType => (HandlerType) Activator.CreateInstance(handlerType));

			foreach (HandlerType handler in handlers)
			{
				// Retrieving the lazyness attribute of the class/type
				lazynessAttribute = (HandlerLazynessAttribute) handler.GetType().GetCustomAttribute(typeof(HandlerLazynessAttribute));

				// Calculating the lazyness (0 is the default)
				int lazyness = 0;
				if (lazynessAttribute != null)
				{
					lazyness = lazynessAttribute.Lazyness;
				}

				// Creating the handler list for this lazyness
				// if it didn't already exist
				if (!foundHandlers.ContainsKey(lazyness))
				{
					foundHandlers.Add(lazyness, new ());
				}

				// Adding the handler to that list
				List<HandlerType> handlersOfSameLazyness = foundHandlers[lazyness];
				handlersOfSameLazyness.Add(handler);
			}
		}

		// Adding each handler list to the final list in the order of their
		// lazyness, from smallest to largest, although the order of the
		// handlers with the same lazyness can't be guaranteed
		foreach (List<HandlerType> handlersOfSameLazyness in foundHandlers.Values)
		{
			Handlers.AddRange(handlersOfSameLazyness);
		}
        ModLog.Info($"Registered {Handlers.Count()} {nameof(HandlerType)}");
	}

	/// <summary>
	/// Method called on the manager when the player makes an attack (whether it
	/// hits an enemy or not).
	/// </summary>
	public abstract void HandleAttack(AttackID id);

	/// <summary>
	/// Methods called on the manager when the player makes an attack that hits
	/// the enemy.
	/// </summary>
	public abstract void HandleAttackHit(AttackInfo info);

	/// <summary>
	/// Methods called on the manager when the player rests at a prie dieu.
	/// </summary>
	public void HandleRestAtPrieDieu()
	{
		Handlers.ForEach(handler => handler.OnRestAtPrieDieu());
	}

	/// <summary>
	/// Prints an error in the Melon Loader console alerting that there has been
	/// an attack ID that wasn't accounted for in this API.
	/// </summary>
	protected void LogUnknownAttackIDError(AttackID id)
	{
		ModLog.Error($"Error: Unknown attack ID for {Name}: {id.id} {id.name}");
	}

	/// <summary>
	/// Prints an error in the Melon Loader console alerting that there has been
	/// an attack ID that wasn't handled correctly by the API.
	/// </summary>
	protected void LogUnsupportedAttackIDError(AttackID id)
	{
		ModLog.Error($"Error: Unsupported attack ID for {Name}: {id.id} {id.name}");
	}
}

