using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xBitz.EasyXLR.LogManager
{
    public class Context
    {
        public string UserID { get; set; }
        public string UserName { get; set; }

        public override string ToString()
        {
            return string.Format("UserName :{0} ,UserID:{2}",UserName, UserID);
        }
    }


}
