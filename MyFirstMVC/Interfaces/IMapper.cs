﻿using MyFirstMVC.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helper
{
    public interface IMapper
    {
        List<PersonDetails> MapPersonDetails(string str);
    }
}
