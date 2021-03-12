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
    [HarmonyPatch(typeof(Player), "Update")]
    
    public class KeyPress
    {
        private static void Postfix(ref Player __instance)
        {
            KeyCode esc = UnityEngine.KeyCode.Escape;
            KeyCode eKey = UnityEngine.KeyCode.E;
            KeyCode tabKey = UnityEngine.KeyCode.Tab;
            if ((UnityEngine.Input.GetKeyDown(esc) ||
                UnityEngine.Input.GetKeyDown(tabKey) || 
                UnityEngine.Input.GetKeyDown(eKey)) && 
                !__instance.IsPVPEnabled())
            {
                __instance.SetPVP(true);
                
            }
        }
    }
}
