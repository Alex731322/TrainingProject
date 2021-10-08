using System;


namespace ServiceCL.Services
{
    public class RouteService : IRouteService
    {
        public string handleRoute(string pathRoute, int lengthRoute)
        {
            return lengthRoute > 3 ? pathRoute.Substring(3).ToString() :
                                                           String.Empty;
        }
    }
}
