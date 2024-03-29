﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OONV
{
    internal interface IHeroObservable
    {
        void Subscribe(IHeroObserver observer);
        void Unsubscribe(IHeroObserver observer);
        void Notify(IHeroState state);
    }
}
