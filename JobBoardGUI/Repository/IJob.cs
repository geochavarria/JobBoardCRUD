﻿using JobBoardApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoardGUI.Repository
{
    public interface IJob
    {
        List<Jobs> GetAll();
        Jobs Get(int jobKey);
        Jobs Create(Jobs jobs);
        Jobs Update(Jobs jobs);
        void Remove(int jobKey);
    }
}
