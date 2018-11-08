﻿using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet_code_challenge.Utilities
{
    public interface IDataLoader
    {
        // entry function of the loader
        void processData();

        // function to deserialize data
        void Deserialize();
    }
}
