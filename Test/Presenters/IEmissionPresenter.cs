﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Views;

namespace Test.Presenters
{
    public interface IEmissionPresenter
    {
        public void SetView(IEmissionView view);
    }
}
