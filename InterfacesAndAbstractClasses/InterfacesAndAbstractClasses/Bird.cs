using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesAndAbstractClasses
{
    public class Bird : Flying, IFlyable
    {
        public Bird (Coordinate currentPosition) : base(currentPosition) { }

        public bool FlyTo(Coordinate newCoordinate)
        {
            throw new NotImplementedException();
        }

        public DateTime GetFlyTime(Coordinate newCoordinate)
        {
            throw new NotImplementedException();
        }
    }
}
