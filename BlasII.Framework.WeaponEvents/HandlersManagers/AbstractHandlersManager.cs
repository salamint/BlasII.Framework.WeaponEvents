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

