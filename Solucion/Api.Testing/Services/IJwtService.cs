﻿using Api.Testing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Testing.Services
{
    public interface IJwtService
    {
        string Generate(User user);
    }
}
