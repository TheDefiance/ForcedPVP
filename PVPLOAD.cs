using HarmonyLib;
using BepInEx;
using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using UnityEngine;
using ForcedPVP;


namespace ForcedPVP
{
    [BepInPlugin("pvp_force", "ForcePVP", version)]
    public class PVPLOAD : BaseUnityPlugin
    {
        public const string version = "1.0.0.5";
        public static string newestVersion = "";
        public static bool isUpToDate = false;

        // Project Repository Info
        public static string Repository = "https://www.nexusmods.com/valheim/mods/448?tab=files";
        public static string ApiRepository = "https://api.github.com/repos/TheDefiance/ForcedPVP/tags";
        private void Awake()
        {
            Harmony harmony = new Harmony("mod.pvp_force");
            harmony.PatchAll();
            isUpToDate = !Settings.isNewVersionAvailable();
            if (!isUpToDate)
            {
                Logger.LogError("There is a newer version available of ForcedPVP.");
                Logger.LogWarning("Please visit " + PVPLOAD.Repository + ".");
            }
            else
            {
                Logger.LogInfo("ForcedPVP [" + version + "] is up to date.");
            }
        }
        

    }
}