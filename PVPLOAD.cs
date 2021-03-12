using HarmonyLib;
using BepInEx;
using BepInEx.Configuration;

namespace ForcedPVP
{
    [BepInPlugin("pvp_force", "ForcePVP", "1.0.0.2")]
    public class PVPLOAD : BaseUnityPlugin
    {
        public const string version = "1.0.0.2";
        public static string newestVersion = "";
        public static bool isUpToDate = false;

        // Project Repository Info
        public static string Repository = "https://github.com/BetterWards/BetterWards";
        public static string ApiRepository = "https://api.github.com/repos/BetterWards/BetterWards/tags";
        void Awake()
        {
            Harmony harmony = new Harmony("mod.pvp_force");
            harmony.PatchAll();
                isUpToDate = !Settings.isNewVersionAvailable();
                if (!isUpToDate)
                {
                    Logger.LogError("There is a newer version available of BetterWards.");
                    Logger.LogWarning("Please visit " + PVPLOAD.Repository + ".");
                    
                }
                else
                {
                    Logger.LogInfo("BetterWards [" + version + "] is up to date.");
                }
            

        
    }


    }
}