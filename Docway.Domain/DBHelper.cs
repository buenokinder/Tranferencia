using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain
{


    public static class DBHelper
    {
        public static DbGeography GetDbGeographyFromLattitude(double latitude, double longitude)
        {
            return DbGeography.PointFromText(string.Format("POINT({ 0}  { 1})", latitude, longitude), 4326);
        }

    }


}
