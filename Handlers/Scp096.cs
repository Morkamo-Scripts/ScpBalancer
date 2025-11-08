using System.ComponentModel;
using DarkAPI.Handlers.Components;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using ScpBalancer.Components;

namespace ScpBalancer.Handlers;

public class Scp096 : IEventsRegistrator, IScpModifier
{
    public void RegisterEvents() => Exiled.Events.Handlers.Player.Hurting += OnPlayerHurting;
    public void UnregisterEvents() => Exiled.Events.Handlers.Player.Hurting -= OnPlayerHurting;
    
    public bool IsModifierEnabled { get; set; } = true;
    public bool IsOneShotEnabled { get; set; } = false;
    [Description("Значение '0' устанавливает базовый урон")]
    public float OverriddenDamage { get; set; } = 0f;

    private void OnPlayerHurting(HurtingEventArgs ev)
    {
        if (ev.Attacker.Role == RoleTypeId.Scp096)
        {
            if (!IsModifierEnabled)
                return;

            if (IsOneShotEnabled) ev.Player.Kill(ev.DamageHandler);
            else if (OverriddenDamage != 0) ev.Amount = OverriddenDamage;
        }
    }
}