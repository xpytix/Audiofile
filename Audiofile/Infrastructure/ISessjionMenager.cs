using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audiofile.Infrastructure
{
    public interface ISessjionMenager
    {
        T Get<T>(string key);
        void Set<T>(string name, T value);
        void Abandon();
        T TryGet<T>(string key);

    }
}
