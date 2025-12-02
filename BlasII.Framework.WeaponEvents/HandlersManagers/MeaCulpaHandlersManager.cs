using BlasII.Framework.WeaponEvents.Handlers;
using Il2CppTGK.Game.Components.Attack.Data;

namespace BlasII.Framework.WeaponEvents.HandlersManagers;


public class MeaCulpaHandlersManager : AbstractHandlersManager<MeaCulpaHandler>
{
	public MeaCulpaHandlersManager() : base() {}

	public override void HandleAttack(AttackID id)
	{
		Handlers.ForEach(handler => handler.OnAttack(id));
	}

	public override void HandleAttackHit(AttackInfo info)
	{
		Handlers.ForEach(handler => handler.OnAttackHit(info));
	}
}

