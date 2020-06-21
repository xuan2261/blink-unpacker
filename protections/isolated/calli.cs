using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blink_unpacker.protections.isolated
{
    class calli
    {
        public static void Execute(ModuleDef module)
        {
           
            foreach (TypeDef type in module.GetTypes().Where(t => t.HasMethods))
            {
                foreach (MethodDef method in type.Methods.Where(m => m.HasBody && m.Body.HasInstructions))
                {
                    IList<Instruction> instr = method.Body.Instructions;
                    for (var i = 0; i < instr.Count; i++)
                    {
                        if (instr[i].OpCode != OpCodes.Ldftn || instr[i + 1].OpCode != OpCodes.Calli) continue;

                        instr[i + 1].OpCode = OpCodes.Nop;
                        instr[i].OpCode = OpCodes.Call;

                    }
                }
            }

          
        }
    }
}
