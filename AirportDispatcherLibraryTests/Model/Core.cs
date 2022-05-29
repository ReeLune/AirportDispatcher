using AirportDispatcher.Model;
using AirportDispatcherLibraryTests.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportDispatcherLibraryTests.ModelTests
{
    class Core
    {
        public AirportDispatcherEntitiesTests context = new AirportDispatcherEntitiesTests();
        public AirportDispatcherEntities contextTest = new AirportDispatcherEntities();
    }
}
