using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xBitz.EasyXLR.ServiceManager
{
    public class BaseServiceManager<T> where T:class, new ()
    {      

        public BaseServiceManager()
        {
            _Manger = new T();                   
        }
        
        private T _Manger = default(T);

        public T Manger {
            get {
                if (_Manger == null) {
                    _Manger = new T();
                }
                return _Manger;
            }
            set {
                _Manger = value;
            }
        }

    }
}

