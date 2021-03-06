﻿using MovieScrapper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieScrapper.Data.Interfaces
{
    public interface INominationRepository
    {
        List<Nomination> GetAllNominations();
        List<Nomination> GetAllNominationsInCategory(int categoryId);
        void RemoveNomination(int nominationId);
    }
}
