﻿using System;
using System.IO;

namespace Injecter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string exe_name = args[0];
                string process_name = Path.GetFileNameWithoutExtension(exe_name);
                string auth_code = Injecter.GetKey(process_name);
                Console.WriteLine(auth_code);
            }
            catch (Exception error) {
                Console.WriteLine(error);
            }
            Console.ReadLine();
        }
    }
}
