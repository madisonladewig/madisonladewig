using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using eToursSystem.DAL;
using eToursSystem.Entities;
#endregion

namespace eToursSystem.BLL
{
    public class DestinationServices
    {
        #region setup of the context connection variable and class constructor

        private readonly eToursContext _context;

        internal DestinationServices(eToursContext registeredcontext)
        {
            _context = registeredcontext;
        }
        #endregion

        #region Services
        public List<Destination> Destination_GetByTour(int tourid)
        {
            IEnumerable<Destination> info = _context.Destinations
                                                    .Where(d => d.TourID == tourid)
                                                    .OrderBy(d => d.VisitDate);
            return info.ToList();
        }

        public int Destination_AddDestination(Destination item)
        {
            DateTime currentTime = DateTime.Now;

            if (item == null)
            {
                throw new ArgumentNullException("You must provide a destination.");
            }

            if (item.VisitDate <= currentTime)
            {
                throw new ArgumentException($"The date of your trip must be in the future. Today's date is {currentTime}, and you stated that your trip is on {item.VisitDate}");
            }

            item.DestinationID = 0;

            _context.Destinations.Add(item);
            _context.SaveChanges();

            return item.DestinationID;
        }
        #endregion
    }
}
