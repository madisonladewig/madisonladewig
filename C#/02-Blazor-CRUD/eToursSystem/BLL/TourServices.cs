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
    public class TourServices
    {
        #region setup of the context connection variable and class constructor

        private readonly eToursContext _context;

        internal TourServices(eToursContext registeredcontext)
        {
            _context = registeredcontext;
        }
        #endregion

        #region Services
        public List<Tour> Tour_GetList()
        {
            return _context.Tours.OrderBy(t => t.Name).ToList();
        }
        #endregion
    }
}
