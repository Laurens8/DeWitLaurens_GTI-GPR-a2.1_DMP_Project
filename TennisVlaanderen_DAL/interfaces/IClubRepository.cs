﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisVlaanderen_DAL.interfaces
{
    public interface IClubRepository
    {
        IEnumerable<TennisVlaanderen_Models.Club> OphalenClub();
    }
}