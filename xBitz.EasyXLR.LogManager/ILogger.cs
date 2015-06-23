using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xBitz.EasyXLR.LogManager
{
    public interface ILogger
    {
        //interface used  to store  the debug log details without error message
        void DebugFormat(Context context, string message, params object[] param);
        //interface used to store  the debug exception details
        void DebugFormat(Context context, Exception exception);

        //interface used to store  the error log details without error message
        void ErrorFormat(Context context, string Message, params object[] param);
        //interface used to store  the error exception details
        void ErrorFormat(Context context, Exception exception);
        //interface used to store  the error exception details
        void ErrorFormat(Context context, string Message, Exception exception);

        //interface used to store  the info log details without error message
        void InfoFormat(Context context, string Message, params object[] param);
        //interface used to store  the info exception details
        void InfoFormat(Context context, Exception exception);

        //interface used to store  the warn log details without error message
        void WarnFormat(Context context, string Message, params object[] param);
        //interface used to store only the warn exception details
        void WarnFormat(Context context, Exception exception);

        //interface used to store  the the fatal log details without error message
        void FatalFormat(Context context, string Message, params object[] param);
        //interface used to store  the fatal exception details
        void FatalFormat(Context context, Exception exception);
    }
}
