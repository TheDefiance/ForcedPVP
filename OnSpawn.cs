using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;
using ValheimLib;

namespace ForcedPVP
{
    [HarmonyPatch(typeof(Player), "OnSpawned")]
    class OnSpawn
    {
        public static void Postfix(ref Player __instance)
        {
            if (__instance.IsPVPEnabled() == false)
            {
                __instance.SetPVP(true);
            }   
        }
    }
}
