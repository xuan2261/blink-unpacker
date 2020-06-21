using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blink_unpacker.protections
{
    class assembl
    {
        public static int Execute(ModuleDef module)
        {
            int x = 0;
            for (int i = 0; i < module.Types.Count; i++)
            {
                if (module.Types[i].HasInterfaces)
                {


                    try
                    {
                        for (int j = 0; j < module.Types[i].Interfaces.Count; j++)
                        {

                            if (module.Types[i].Interfaces[j].Interface != null)
                            {
                                if (module.Types[i].Interfaces[j].Interface.Name.Contains(module.Types[i].Name) ||
                                module.Types[i].Name.Contains(module.Types[i].Interfaces[j].Interface.Name))
                                {
                                    module.Types.RemoveAt(i);
                                    x++;
                                }
                            }
                        }

                    }
                    catch
                    {

                    }



                }
            }
            return x;
        }

    }
}
