﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Savory.TitanService
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceBase.Run(new TitanService());
        }
    }
}
