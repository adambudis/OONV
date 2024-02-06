using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OONV
{
    internal interface IHeroObserver
    {
        // nebo string mgs 
        void Update(IHeroState state);
    }
}
