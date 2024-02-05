using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OONV
{
    interface IHeroState
    {
        void Rest();
        void Explore();
        void Train();
    }
}
