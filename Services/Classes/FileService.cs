﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendyolApp.Services.Classes
{
    public static class FileService
    {

        public static void SaveData(string ToSave,string Where)
        {
            using (FileStream fs = new(Where, FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write(ToSave);
            }
        }

        public static string? ReadData(string Where)
        {
            using (FileStream fs = new(Where, FileMode.OpenOrCreate))
            using (StreamReader sw = new StreamReader(fs))
            {
                return sw.ReadLine();
            }
        }
    }
}
