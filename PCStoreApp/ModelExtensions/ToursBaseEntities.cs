using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStoreApp
{
    public partial class ToursBaseEntities
    {
        private static ToursBaseEntities _context;

        public static ToursBaseEntities GetContext()
        {
            if (_context == null)
                _context = new ToursBaseEntities();
            return _context;
        }
    }
}
