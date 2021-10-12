using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{    
    public class SingletonLazyT
    {
        private static readonly Lazy<SingletonLazyT> lazy =
            new Lazy<SingletonLazyT>(() => new SingletonLazyT());

        public string Name { get; private set; }

        private SingletonLazyT()
        {
            Name = Guid.NewGuid().ToString();
        }

        public static SingletonLazyT GetInstance()
        {
            return lazy.Value;
        }
    }
}
