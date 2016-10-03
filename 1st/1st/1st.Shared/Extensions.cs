using System;
using System.Collections.Generic;
using System.Text;
using Windows.Devices.Geolocation;

#if WINDOWS_APP
using Bing.Maps;
#endif

namespace _1st
{
    public static class Extensions
    {
#if WINDOWS_APP 

        public static LocationCollection ToLocationCollection(this IList<BasicGeoposition> _pointsList)
        {
            LocationCollection collection = new LocationCollection();

            for (int i = 0; i < _pointsList.Count; i++)
            {
                collection.Add(new Bing.Maps.Location(_pointsList[i].Latitude, _pointsList[i].Longitude));
            }

            return collection;
        }

        public static Geopoint ToGeopoint(this Location _location)
        {
            if (_location != null)
            {
                return new Geopoint(new BasicGeoposition() { Latitude = _location.Latitude, Longitude = _location.Longitude });
            }

            else
            {
                return null;
            }
        }

        public static Location ToLocation(this Geopoint _location)
        {
            return new Location() { Longitude = _location.Position.Longitude, Latitude = _location.Position.Latitude };
        }

        public static Location ToLocation(this BasicGeoposition _location)
        {
            return new Location() { Latitude = _location.Latitude, Longitude = _location.Longitude };
        }

#elif WINDOWS_PHONE_APP

#endif
    }
}
