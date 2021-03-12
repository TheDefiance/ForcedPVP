using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace ForcedPVP
{
    [HarmonyPatch(typeof(InventoryGui), "UpdateCharacterStats")]
    public static class SettingGui
    {
        [HarmonyTranspiler]
        public static IEnumerable<CodeInstruction> Transpiler(
          IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> list = instructions.ToList<CodeInstruction>();
            int num = -1;
            for (int index1 = 0; index1 < list.Count; ++index1)
            {
                if (list[index1].opcode == OpCodes.Ldarg_0)
                {
                    ++num;
                    if (num == 3)
                    {
                        list[index1].opcode = OpCodes.Nop;
                        int index2 = index1 + 1;
                        list[index2].opcode = OpCodes.Nop;
                        int index3 = index2 + 1;
                        list[index3].opcode = OpCodes.Nop;
                        list[index3] = new CodeInstruction(OpCodes.Ldc_I4_1);
                        break;
                    }
                }
            }
            return list.AsEnumerable<CodeInstruction>();
        }
    }
}