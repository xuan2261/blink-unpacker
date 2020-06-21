using dnlib.DotNet;
using dnlib.DotNet.Writer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blink_unpacker
{
    class Program
    {
        static string title = @".-. .-')                         .-') _ .-. .-')                          .-') _   _ (`-.    ('-.               .-. .-')     ('-.  _  .-')   
\  ( OO )                       ( OO ) )\  ( OO )                        ( OO ) ) ( (OO  )  ( OO ).-.           \  ( OO )  _(  OO)( \( -O )  
 ;-----.\  ,--.      ,-.-') ,--./ ,--,' ,--. ,--.        ,--. ,--.   ,--./ ,--,' _.`     \  / . --. /   .-----. ,--. ,--. (,------.,------.  
 | .-.  |  |  |.-')  |  |OO)|   \ |  |\ |  .'   /        |  | |  |   |   \ |  |\(__...--''  | \-.  \   '  .--./ |  .'   /  |  .---'|   /`. ' 
 | '-' /_) |  | OO ) |  |  \|    \|  | )|      /,        |  | | .-') |    \|  | )|  /  | |.-'-'  |  |  |  |('-. |      /,  |  |    |  /  | | 
 | .-. `.  |  |`-' | |  |(_/|  .     |/ |     ' _)       |  |_|( OO )|  .     |/ |  |_.' | \| |_.'  | /_) |OO  )|     ' _)(|  '--. |  |_.' | 
 | |  \  |(|  '---.',|  |_.'|  |\    |  |  .   \         |  | | `-' /|  |\    |  |  .___.'  |  .-.  | ||  |`-'| |  .   \   |  .--' |  .  '.' 
 | '--'  / |      |(_|  |   |  | \   |  |  |\   \       ('  '-'(_.-' |  | \   |  |  |       |  | |  |(_'  '--'\ |  |\   \  |  `---.|  |\  \  
 `------'  `------'  `--'   `--'  `--'  `--' '--'         `-----'    `--'  `--'  `--'       `--' `--'   `-----' `--' '--'  `------'`--' '--'";

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetWindowSize(150, 30);
            Console.WriteLine(title);
            Console.WriteLine("");
            Console.WriteLine("");
            ModuleDef md = ModuleDefMD.Load(args[0]);

            Console.WriteLine("Cleaning the assembly");

            md.Name = Path.GetFileNameWithoutExtension(args[0]);
            md.Assembly.Name = Path.GetFileName(args[0]);
            Console.WriteLine("");
            Console.WriteLine("");

            protections.isolated.proxy.Execute(md);

            protections.assembl.Execute(md);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Cleaned the assembly");
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Cleaning the math");
            protections.math.DoMath(md);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("cleaned the math");
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("checking for isolated (trash)");
            Console.ForegroundColor = ConsoleColor.Green;


            protections.isolated.ints.DoubleParse(md);
            protections.isolated.invalid_md.Deobfuscate(md);
            protections.isolated.calli.Execute(md);
            try
            {


                protections.isolated.strings.static_decryption.Execute(md);
            }
            catch
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error when decrypting strings, try running de4dot then this tool again!");
                Console.ForegroundColor = ConsoleColor.Yellow;

            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("cleaned all the skidded protections of obfuscators");

            Console.ForegroundColor = ConsoleColor.Yellow;


            Directory.CreateDirectory(@".\AtomicProtected");

            md.Write(@".\AtomicProtected\" + Path.GetFileName(args[0]), new ModuleWriterOptions(md)
            {
                PEHeadersOptions =
                {
                    NumberOfRvaAndSizes = new uint?(13u)
                },
                MetaDataOptions =
                {
                    TablesHeapOptions =
                    {
                        ExtraData = new uint?(4919u)
                    }
                },
                Logger = DummyLogger.NoThrowInstance
            });

            Process.Start(@".\AtomicProtected\");

            Console.Read();
        }
    }
}
