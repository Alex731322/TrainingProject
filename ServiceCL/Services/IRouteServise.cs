using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCL.Services
{
    public interface IRouteService
    {
         string handleRoute(string pathRoute, int LengthRoute);
    }
}
