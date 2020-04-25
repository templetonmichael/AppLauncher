﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLauncher
{
    class UserApplication
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public UserApplication(string path, string category = "default")
        {
            Path = path;
            Category = category;
            Name = System.IO.Path.GetFileNameWithoutExtension(path);
        }
        public string Display()
        {
            return $"{Name}   -   {Path}";
        }
    }
}
