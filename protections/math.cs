using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blink_unpacker.protections
{
    class math
    {
        public static void DoMath(ModuleDef md)
        {
            Execute(md);

            StringLength(md);
            Execute(md);

            Abs(md);
            Execute(md);

            Cos(md);
            Execute(md);

            Log(md);
            Execute(md);

            Log10(md);
            Execute(md);

            Round(md);
            Execute(md);

            Sin(md);
            Execute(md);

            Tan(md);
            Execute(md);

            Tanh(md);
            Execute(md);

            Truncate(md);
            Execute(md);

            CeilingReplacer(md);
            Execute(md);

            DoubleParse(md);
            Execute(md);

            SqrtReplacer(md);
            Execute(md);

            FloorReplacer(md);
            IntParse(md);
            Execute(md);

            ZeroReplacer(md);
            Execute(md);

            Sizeof(md);
            Execute(md);

            Arthmetic(md);

            Execute(md);

            Int32(md);

            Execute(md);
            ZeroReplacer(md);
            Execute(md);

        }

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
                        if (instr[i].OpCode == OpCodes.Call)
                        {
                            if (instr[i].ToString().Contains("System.Double::Parse"))
                            {
                                if (instr[i - 1].OpCode == OpCodes.Ldstr)
                                {
                                    string orignal_string = (string)instr[i - 1].Operand;

                                    double original = double.Parse(orignal_string);

                                    instr[i].OpCode = OpCodes.Ldc_I4;
                                    instr[i].Operand = original;

                                    instr[i - 1].OpCode = OpCodes.Nop;
                                }


                            }
                        }
                    }
                }
            }
        }

        public static void Cos(ModuleDef md)
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
                        if (instr[i].OpCode == OpCodes.Call)
                        {
                            if (instr[i].ToString().Contains("System.Math::Cos"))
                            {
                                if (instr[i - 1].OpCode == OpCodes.Ldc_R8)
                                {
                                    double orignal_string = (double)instr[i - 1].Operand;

                                    double original = Math.Cos(orignal_string);

                                    instr[i].OpCode = OpCodes.Ldc_R8;
                                    instr[i].Operand = original;

                                    instr[i - 1].OpCode = OpCodes.Nop;
                                }


                            }
                        }
                    }
                }
            }
        }

        public static void Log(ModuleDef md)
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
                        if (instr[i].OpCode == OpCodes.Call)
                        {
                            if (instr[i].ToString().Contains("System.Math::Log"))
                            {
                                if (instr[i - 1].OpCode == OpCodes.Ldc_R8)
                                {
                                    double orignal_string = (double)instr[i - 1].Operand;

                                    double original = Math.Log(orignal_string);

                                    instr[i].OpCode = OpCodes.Ldc_R8;
                                    instr[i].Operand = original;

                                    instr[i - 1].OpCode = OpCodes.Nop;
                                }


                            }
                        }
                    }
                }
            }
        }

        public static void Log10(ModuleDef md)
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
                        if (instr[i].OpCode == OpCodes.Call)
                        {
                            if (instr[i].ToString().Contains("System.Math::Log"))
                            {
                                if (instr[i - 1].OpCode == OpCodes.Ldc_R8)
                                {
                                    double orignal_string = (double)instr[i - 1].Operand;

                                    double original = Math.Log10(orignal_string);

                                    instr[i].OpCode = OpCodes.Ldc_R8;
                                    instr[i].Operand = original;

                                    instr[i - 1].OpCode = OpCodes.Nop;
                                }


                            }
                        }
                    }
                }
            }
        }

        public static void Round(ModuleDef md)
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
                        if (instr[i].OpCode == OpCodes.Call)
                        {
                            if (instr[i].ToString().Contains("System.Math::Round"))
                            {
                                if (instr[i - 1].OpCode == OpCodes.Ldc_R8)
                                {
                                    double orignal_string = (double)instr[i - 1].Operand;

                                    double original = Math.Round(orignal_string);

                                    instr[i].OpCode = OpCodes.Ldc_R8;
                                    instr[i].Operand = original;

                                    instr[i - 1].OpCode = OpCodes.Nop;
                                }


                            }
                        }
                    }
                }
            }
        }

        public static void Sin(ModuleDef md)
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
                        if (instr[i].OpCode == OpCodes.Call)
                        {
                            if (instr[i].ToString().Contains("System.Math::Sin"))
                            {
                                if (instr[i - 1].OpCode == OpCodes.Ldc_R8)
                                {
                                    double orignal_string = (double)instr[i - 1].Operand;

                                    double original = Math.Sin(orignal_string);

                                    instr[i].OpCode = OpCodes.Ldc_R8;
                                    instr[i].Operand = original;

                                    instr[i - 1].OpCode = OpCodes.Nop;
                                }


                            }
                        }
                    }
                }
            }
        }

        public static void Tan(ModuleDef md)
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
                        if (instr[i].OpCode == OpCodes.Call)
                        {
                            if (instr[i].ToString().Contains("System.Math::Tan"))
                            {
                                if (instr[i - 1].OpCode == OpCodes.Ldc_R8)
                                {
                                    double orignal_string = (double)instr[i - 1].Operand;

                                    double original = Math.Tan(orignal_string);

                                    instr[i].OpCode = OpCodes.Ldc_R8;
                                    instr[i].Operand = original;

                                    instr[i - 1].OpCode = OpCodes.Nop;
                                }


                            }
                        }
                    }
                }
            }
        }

        public static void Tanh(ModuleDef md)
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
                        if (instr[i].OpCode == OpCodes.Call)
                        {
                            if (instr[i].ToString().Contains("System.Math::Tanh"))
                            {
                                if (instr[i - 1].OpCode == OpCodes.Ldc_R8)
                                {
                                    double orignal_string = (double)instr[i - 1].Operand;

                                    double original = Math.Tanh(orignal_string);

                                    instr[i].OpCode = OpCodes.Ldc_R8;
                                    instr[i].Operand = original;

                                    instr[i - 1].OpCode = OpCodes.Nop;
                                }


                            }
                        }
                    }
                }
            }
        }


        public static void Truncate(ModuleDef md)
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
                        if (instr[i].OpCode == OpCodes.Call)
                        {
                            if (instr[i].ToString().Contains("System.Math::Truncate"))
                            {
                                if (instr[i - 1].OpCode == OpCodes.Ldc_R8)
                                {
                                    double orignal_string = (double)instr[i - 1].Operand;

                                    double original = Math.Truncate(orignal_string);

                                    instr[i].OpCode = OpCodes.Ldc_R8;
                                    instr[i].Operand = original;

                                    instr[i - 1].OpCode = OpCodes.Nop;
                                }


                            }
                        }
                    }
                }
            }
        }



        public static void Abs(ModuleDef md)
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
                        if (instr[i].OpCode == OpCodes.Call)
                        {
                            if (instr[i].ToString().Contains("System.Math::Abs"))
                            {
                                if (instr[i - 1].OpCode == OpCodes.Ldc_R8)
                                {
                                    double orignal_string = (double)instr[i - 1].Operand;

                                    double original = Math.Abs(orignal_string);

                                    instr[i].OpCode = OpCodes.Ldc_R8;
                                    instr[i].Operand = original;

                                    instr[i - 1].OpCode = OpCodes.Nop;
                                }


                            }
                        }
                    }
                }
            }
        }

        public static void IntParse(ModuleDef md)
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
                        if (instr[i].OpCode == OpCodes.Call)
                        {

                            if (instr[i].ToString().Contains("System.Int32::Parse"))
                            {
                                if (instr[i - 1].OpCode == OpCodes.Ldstr)
                                {

                                    string orignal_string = (string)instr[i - 1].Operand;

                                    int original = int.Parse(orignal_string);

                                    instr[i].OpCode = OpCodes.Ldc_I4;
                                    instr[i].Operand = original;

                                    instr[i - 1].OpCode = OpCodes.Nop;
                                }


                            }
                        }
                    }
                }
            }
        }


        public static void ZeroReplacer(ModuleDef md)
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
                        try
                        {

                            if (instr[i].OpCode == OpCodes.Ldc_I4 || instr[i].OpCode == OpCodes.Ldc_I4_S || instr[i].OpCode == OpCodes.Ldc_R8)
                            {



                                string orignal_string = instr[i].Operand.ToString();

                                if (orignal_string == "0")
                                {
                                    try
                                    {


                                        if (instr[i - 1].OpCode == OpCodes.Add || instr[i - 1].OpCode == OpCodes.Sub || instr[i - 1].OpCode == OpCodes.Mul || instr[i - 1].OpCode == OpCodes.Sub || instr[i - 1].OpCode == OpCodes.Xor)
                                        {
                                            instr[i - 1].OpCode = OpCodes.Nop;

                                            instr[i].OpCode = OpCodes.Nop;
                                        }
                                    }
                                    catch
                                    {

                                    }

                                    try
                                    {


                                        if (instr[i + 1].OpCode == OpCodes.Add || instr[i + 1].OpCode == OpCodes.Sub || instr[i + 1].OpCode == OpCodes.Mul || instr[i + 1].OpCode == OpCodes.Sub || instr[i + 1].OpCode == OpCodes.Xor)
                                        {
                                            instr[i + 1].OpCode = OpCodes.Nop;

                                            instr[i].OpCode = OpCodes.Nop;
                                        }
                                    }
                                    catch
                                    {

                                    }


                                }
                            }
                        }
                        catch
                        {

                        }

                        
                    }
                }
            }
        }

        public static void Execute(ModuleDef module)
        {
            foreach (TypeDef type in module.Types.Where(t => t.HasMethods))
            {
                foreach (MethodDef method in type.Methods.Where(m => m.HasBody && m.Body.HasInstructions))
                {
                    IList<Instruction> instr = method.Body.Instructions;
                    for (var i = 0; i < instr.Count; i++)
                    {
                        if (instr[i].OpCode != OpCodes.Nop || IsNopBranchTarget(method, instr[i]) ||
                            IsNopSwitchTarget(method, instr[i]) ||
                            IsNopExceptionHandlerTarget(method, instr[i])) continue;

                        instr.RemoveAt(i);
                        i--;
                    }
                }
            }
        }

        private static bool IsNopBranchTarget(MethodDef method, Instruction nopInstr)
        {
            return (from instr in method.Body.Instructions
                    where instr.OpCode.OperandType == OperandType.InlineBrTarget ||
                          instr.OpCode.OperandType == OperandType.ShortInlineBrTarget && instr.Operand != null
                    select (Instruction)instr.Operand).Any(instruction2 => instruction2 == nopInstr);
        }

        private static bool IsNopSwitchTarget(MethodDef method, Instruction nopInstr)
        {
            return (from t in method.Body.Instructions
                    where t.OpCode.OperandType == OperandType.InlineSwitch && t.Operand != null
                    select (Instruction[])t.Operand).Any(source => source.Contains(nopInstr));
        }

        private static bool IsNopExceptionHandlerTarget(MethodDef method, Instruction nopInstr)
        {
            if (!method.Body.HasExceptionHandlers) return false;
            return method.Body.ExceptionHandlers.Any(exceptionHandler => exceptionHandler.FilterStart == nopInstr ||
                                                                         exceptionHandler.HandlerEnd == nopInstr ||
                                                                         exceptionHandler.HandlerStart == nopInstr ||
                                                                         exceptionHandler.TryEnd == nopInstr ||
                                                                         exceptionHandler.TryStart == nopInstr);
        }

        public static void CeilingReplacer(ModuleDef md)
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
                        if (instr[i].OpCode == OpCodes.Call)
                        {

                            if (instr[i].ToString().Contains("System.Math::Ceiling"))
                            {
                                if (instr[i - 1].OpCode == OpCodes.Ldc_R8)
                                {

                                    double orignal_string = (double)instr[i - 1].Operand;

                                    double original = Math.Ceiling(orignal_string);

                                    instr[i].OpCode = OpCodes.Ldc_R8;
                                    instr[i].Operand = original;

                                    instr[i - 1].OpCode = OpCodes.Nop;
                                }


                            }
                        }
                    }
                }
            }
        }


        public static void SqrtReplacer(ModuleDef md)
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
                        if (instr[i].OpCode == OpCodes.Call)
                        {

                            if (instr[i].ToString().Contains("System.Math::Sqrt"))
                            {
                                if (instr[i - 1].OpCode == OpCodes.Ldc_R8)
                                {

                                    double orignal_string = (double)instr[i - 1].Operand;

                                    double original = Math.Sqrt(orignal_string);

                                    instr[i].OpCode = OpCodes.Ldc_R8;
                                    instr[i].Operand = original;

                                    instr[i - 1].OpCode = OpCodes.Nop;
                                }


                            }
                        }
                    }
                }
            }
        }

        public static void FloorReplacer(ModuleDef md)
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
                        if (instr[i].OpCode == OpCodes.Call)
                        {

                            if (instr[i].ToString().Contains("System.Math::Floor"))
                            {
                                if (instr[i - 1].OpCode == OpCodes.Ldc_R8)
                                {

                                    double orignal_string = (double)instr[i - 1].Operand;

                                    double original = Math.Floor(orignal_string);

                                    instr[i].OpCode = OpCodes.Ldc_R8;
                                    instr[i].Operand = original;

                                    instr[i - 1].OpCode = OpCodes.Nop;
                                }


                            }
                        }
                    }
                }
            }
        }

        public static void Sizeof(ModuleDef md)
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
                        if (instr[i].OpCode == OpCodes.Sizeof)
                        {

                            if (instr[i].ToString().Contains("System.Byte"))
                            {



                                instr[i].OpCode = OpCodes.Ldc_I4;
                                instr[i].Operand = 1;




                            }

                            if (instr[i].ToString().Contains("System.Int32"))
                            {



                                instr[i].OpCode = OpCodes.Ldc_I4;
                                instr[i].Operand = 4;




                            }

                            if (instr[i].ToString().Contains("System.Security.SecurityZone"))
                            {



                                instr[i].OpCode = OpCodes.Ldc_I4;
                                instr[i].Operand = 4;




                            }

                            if (instr[i].ToString().Contains("System.Boolean"))
                            {



                                instr[i].OpCode = OpCodes.Ldc_I4;
                                instr[i].Operand = 1;




                            }
                        }
                    }
                }
            }
        }

        public static void StringLength(ModuleDef md)
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
                        if (instr[i].OpCode == OpCodes.Ldstr)
                        {

                            if (instr[i + 1].OpCode == OpCodes.Ldlen)
                            {

                                string orignal_string = instr[i].Operand.ToString();


                                instr[i].OpCode = OpCodes.Ldc_I4;

                                instr[i].Operand = orignal_string.Length;

                                instr[i + 1].OpCode = OpCodes.Nop;



                            }


                        }
                    }
                }
            }
        }

        public static void Int32(ModuleDef md)
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
                        if (instr[i].OpCode == OpCodes.Ldc_R8)
                        {

                            if (instr[i + 1].OpCode == OpCodes.Call)
                            {

                                if (instr[i + 1].ToString().Contains("System.Convert::ToInt32"))
                                {
                                    int final = Convert.ToInt32((double)instr[i].Operand);
                                    instr[i].OpCode = OpCodes.Ldc_I4;
                                    instr[i].Operand = final;
                                    instr[i + 1].OpCode = OpCodes.Nop;

                                }





                            }


                        }
                    }
                }
            }
        }

        public static void Arthmetic(ModuleDef md)
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
                        if (instr[i].OpCode == OpCodes.Ldc_I4)
                        {

                            if (instr[i + 1].OpCode == OpCodes.Ldc_I4)
                            {
                                if (instr[i + 2].OpCode == OpCodes.Add)
                                {
                                    int orignal_int = (int)instr[i].Operand;

                                    int orignal_int1 = (int)instr[i + 1].Operand;

                                    instr[i].Operand = orignal_int + orignal_int1;

                                    instr[i + 1].OpCode = OpCodes.Nop;
                                    instr[i + 2].OpCode = OpCodes.Nop;

                                    i += 2;
                                }






                            }

                            if (instr[i + 1].OpCode == OpCodes.Ldc_I4)
                            {
                                if (instr[i + 2].OpCode == OpCodes.Xor)
                                {
                                    int orignal_int = (int)instr[i].Operand;

                                    int orignal_int1 = (int)instr[i + 1].Operand;

                                    instr[i].Operand = orignal_int ^ orignal_int1;

                                    instr[i + 1].OpCode = OpCodes.Nop;
                                    instr[i + 2].OpCode = OpCodes.Nop;

                                    i += 2;
                                }






                            }

                            if (instr[i + 1].OpCode == OpCodes.Ldc_I4)
                            {
                                if (instr[i + 2].OpCode == OpCodes.Sub)
                                {
                                    int orignal_int = (int)instr[i].Operand;

                                    int orignal_int1 = (int)instr[i + 1].Operand;

                                    instr[i].Operand = orignal_int - orignal_int1;

                                    instr[i + 1].OpCode = OpCodes.Nop;
                                    instr[i + 2].OpCode = OpCodes.Nop;

                                    i += 2;
                                }






                            }

                            if (instr[i + 1].OpCode == OpCodes.Ldc_I4)
                            {
                                if (instr[i + 2].OpCode == OpCodes.Mul)
                                {
                                    int orignal_int = (int)instr[i].Operand;

                                    int orignal_int1 = (int)instr[i + 1].Operand;

                                    instr[i].Operand = orignal_int * orignal_int1;

                                    instr[i + 1].OpCode = OpCodes.Nop;
                                    instr[i + 2].OpCode = OpCodes.Nop;

                                    i += 2;
                                }






                            }

                            if (instr[i + 1].OpCode == OpCodes.Ldc_I4)
                            {
                                if (instr[i + 2].OpCode == OpCodes.Div)
                                {
                                    int orignal_int = (int)instr[i].Operand;

                                    int orignal_int1 = (int)instr[i + 1].Operand;

                                    instr[i].Operand = orignal_int / orignal_int1;

                                    instr[i + 1].OpCode = OpCodes.Nop;
                                    instr[i + 2].OpCode = OpCodes.Nop;

                                    i += 2;
                                }






                            }





                        }

                        if (instr[i].OpCode == OpCodes.Ldc_R8)
                        {
                           



                                if (instr[i + 1].OpCode == OpCodes.Ldc_R8)
                                {
                                    if (instr[i + 2].OpCode == OpCodes.Add)
                                    {
                                    double orignal_int = (double)instr[i].Operand;

                                    double orignal_int1 = (double)instr[i + 1].Operand;

                                        instr[i].Operand = orignal_int + orignal_int1;

                                        instr[i + 1].OpCode = OpCodes.Nop;
                                        instr[i + 2].OpCode = OpCodes.Nop;

                                        i += 2;
                                    }

                                }






                                if (instr[i + 1].OpCode == OpCodes.Ldc_R8)
                                {
                                    if (instr[i + 2].OpCode == OpCodes.Sub)
                                    {
                                    double orignal_int = (double)instr[i].Operand;

                                    double orignal_int1 = (double)instr[i + 1].Operand;

                                        instr[i].Operand = orignal_int - orignal_int1;

                                        instr[i + 1].OpCode = OpCodes.Nop;
                                        instr[i + 2].OpCode = OpCodes.Nop;

                                        i += 2;
                                    }






                                }

                                if (instr[i + 1].OpCode == OpCodes.Ldc_R8)
                                {
                                    if (instr[i + 2].OpCode == OpCodes.Mul)
                                    {
                                        double orignal_int = (double)instr[i].Operand;

                                    double orignal_int1 = (double)instr[i + 1].Operand;

                                        instr[i].Operand = orignal_int * orignal_int1;

                                        instr[i + 1].OpCode = OpCodes.Nop;
                                        instr[i + 2].OpCode = OpCodes.Nop;

                                        i += 2;
                                    }






                                }

                                if (instr[i + 1].OpCode == OpCodes.Ldc_R8)
                                {
                                    if (instr[i + 2].OpCode == OpCodes.Div)
                                    {
                                    double orignal_int = (double)instr[i].Operand;

                                    double orignal_int1 = (double)instr[i + 1].Operand;

                                        instr[i].Operand = orignal_int / orignal_int1;

                                        instr[i + 1].OpCode = OpCodes.Nop;
                                        instr[i + 2].OpCode = OpCodes.Nop;

                                        i += 2;
                                    }






                                }



                       

                        }
                    }
                }
            }
        }
    }
}
