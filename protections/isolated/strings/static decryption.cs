using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace blink_unpacker.protections.isolated.strings
{
    class static_decryption
    {
        private static readonly string PasswordHash = "p7K95451qB88sZ7J";
        private static readonly string SaltKey = "2GM23j301t60Z96T";
        private static readonly string VIKey = "IzTdhG6S8uwg141S";


        public static string Decrypt(string encryptedText)
        {
           
                byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
                byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
                var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.PKCS7 };

                var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
                var memoryStream = new MemoryStream(cipherTextBytes);
                var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                byte[] plainTextBytes = new byte[cipherTextBytes.Length];

                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                memoryStream.Close();
                cryptoStream.Close();
                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
            
        }

        public static void Execute(ModuleDef module)
        {
            foreach (TypeDef type in module.GetTypes())
            {
                if (type.IsGlobalModuleType) continue;
                foreach (MethodDef method in type.Methods)
                {
                    if (!method.HasBody) continue;
                    var instr = method.Body.Instructions;
                    for (int i = 0; i < instr.Count; i++)
                    {
                        if (instr[i].OpCode == OpCodes.Ldstr)
                        {
                            if (instr[i + 1].OpCode == OpCodes.Call)
                            {
                                if (instr[i + 1].ToString().Contains("Decrypt"))
                                {
                                    MethodDef decryptionMethod = null;

                                    decryptionMethod = instr[i + 1].Operand as MethodDef;
                                    if (decryptionMethod == null) continue;
                                    if (decryptionMethod.DeclaringType != module.GlobalType) continue;


                                    var originalSTR = instr[i].Operand as string;
                                    var decoded = Decrypt(originalSTR);
                                    instr[i].Operand = decoded;
                                    instr[i + 1].OpCode = OpCodes.Nop;
                                }
                            }
                        }
                    }
                    method.Body.SimplifyBranches();
                }
            }
        }


    }
}
