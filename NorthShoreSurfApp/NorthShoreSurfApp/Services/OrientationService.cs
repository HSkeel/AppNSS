using System;
using System.Collections.Generic;
using System.Text;

namespace NorthShoreSurfApp
{
    public interface IOrientationService
    {
        void Landscape();
        void Portrait();
        void Unspecified();
    }
}
