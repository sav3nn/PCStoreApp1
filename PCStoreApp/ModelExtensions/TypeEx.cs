using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStoreApp
{
    public partial class Type
    {
        public string ImagePath
        {
            get
            {
                return Environment.CurrentDirectory + @"\Image\" + Image;
            }
        }
    }
}
