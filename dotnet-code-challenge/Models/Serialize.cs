using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace dotnet_code_challenge.Model
{
    public class Serialize
    {
        public String TimeStamp { get; set; }
        public List<Horse> Horses { get; set; }
    }
}
