using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blink_unpacker.protections.isolated
{
    class ints
    {
        public static void DoubleParse(ModuleDef md)
        {
            foreach (TypeDef type in md.GetTypes())
            {


                foreach (MethodDef method in type.Methods)
                {

                    //check if method has a method.Body
                    if (!method.HasBody) continue;
                    //lets go to the method now
                    var instr = method.Body.Instructions;
                    for (int i = 0; i < instr.Count; i++)
                    {
                        if (instr[i].OpCode == OpCodes.Ldc_I4 || instr[i].OpCode == OpCodes.Ldc_I4_S)
                        {

                            if (instr[i + 1].OpCode == OpCodes.Sizeof)
                            {
                                if (instr[i + 2].OpCode == OpCodes.Add)
                                {
                                    if (instr[i + 3].OpCode == OpCodes.Ldc_R8)
                                    {
                                        if (instr[i + 4].OpCode == OpCodes.Call)
                                        {
                                            if (instr[i + 5].OpCode == OpCodes.Conv_I4)
                                            {
                                                if (instr[i + 6].OpCode == OpCodes.Sub)
                                                {
                                                    if (instr[i + 7].OpCode == OpCodes.Sizeof)
                                                    {
                                                        if (instr[i + 8].OpCode == OpCodes.Add)
                                                        {
                                                            if (instr[i + 9].OpCode == OpCodes.Ldc_R8)
                                                            {
                                                                if (instr[i + 10].OpCode == OpCodes.Call)
                                                                {
                                                                    if (instr[i + 11].OpCode == OpCodes.Conv_I4)
                                                                    {
                                                                        if (instr[i + 12].OpCode == OpCodes.Sub)
                                                                        {
                                                                            instr[i + 1].OpCode = OpCodes.Nop;
                                                                            instr[i + 2].OpCode = OpCodes.Nop;
                                                                            instr[i + 3].OpCode = OpCodes.Nop;
                                                                            instr[i + 4].OpCode = OpCodes.Nop;
                                                                            instr[i + 5].OpCode = OpCodes.Nop;
                                                                            instr[i + 6].OpCode = OpCodes.Nop;
                                                                            instr[i + 7].OpCode = OpCodes.Nop;
                                                                            instr[i + 8].OpCode = OpCodes.Nop;
                                                                            instr[i + 9].OpCode = OpCodes.Nop;
                                                                            instr[i + 10].OpCode = OpCodes.Nop;
                                                                            instr[i + 11].OpCode = OpCodes.Nop;
                                                                            instr[i + 12].OpCode = OpCodes.Nop;
                                                                         

                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            
                            }


                            
                        }
                    }
                }
            }
        }
    }
}
