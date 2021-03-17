using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace ForcedPVP
{
    [HarmonyPatch(typeof(InventoryGui), "UpdateCharacterStats")]
    public static class GuiItemChange
    {
        [HarmonyTranspiler]
        public static IEnumerable<CodeInstruction> Transpiler(
          IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> itemList = instructions.ToList<CodeInstruction>();
            int inventoryIterator = -1;
            for (int guiItems = 0; guiItems < itemList.Count; ++guiItems)
            {
                if (itemList[guiItems].opcode == OpCodes.Ldarg_0)
                {
                    ++inventoryIterator;
                    if (inventoryIterator == 3)
                    {
                        itemList[guiItems].opcode = OpCodes.Nop;
                        int guiItems2 = guiItems + 1;
                        itemList[guiItems2].opcode = OpCodes.Nop;
                        int guiItems3 = guiItems2 + 1;
                        itemList[guiItems3].opcode = OpCodes.Nop;
                        itemList[guiItems3] = new CodeInstruction(OpCodes.Ldc_I4_1);
                        break;
                    }
                }
            }
            return itemList.AsEnumerable<CodeInstruction>();
        }
    }
}