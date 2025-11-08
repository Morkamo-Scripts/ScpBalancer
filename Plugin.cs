using System;
using System.Collections.Generic;
using DarkAPI.Handlers.Components;
using Exiled.API.Features;
using HarmonyLib;
using ScpBalancer.Handlers;

namespace ScpBalancer
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "ScpBalancer";
        public override string Prefix => Name;
        public override string Author => "Morkamo";
        public override Version RequiredExiledVersion => new Version(9, 1, 0);
        public override Version Version => new Version(0, 0, 1);

        public static Plugin Instance;
        private Harmony _harmony;

        public override void OnEnabled()
        {
            Instance = this;
            
            _harmony = new Harmony("ru.morkamo.scp_balancer.ps");
            _harmony.PatchAll();
            
            DarkAPI.Plugin.AddRegistrator(Config.Scp049);
            DarkAPI.Plugin.AddRegistrator(Config.Scp096);
            
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            DarkAPI.Plugin.AddRegistrator(Config.Scp096);
            DarkAPI.Plugin.AddRegistrator(Config.Scp049);
            
            _harmony.UnpatchAll();
            _harmony = null;
            
            Instance = null;
            
            base.OnDisabled();
        }
    }
}