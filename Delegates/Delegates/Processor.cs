using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class Processor<TObject, TRequest>
    {
        public Processor(Func<TRequest, bool> Check,
                         Func<TRequest, TObject> Register,
                         Action<TObject> Save)
        {
            this.Check = Check;
            this.Register = Register;
            this.Save = Save;
        }

        public TObject Process(TRequest request)
        {
            if (!Check(request))
                throw new ArgumentException();

            var result = Register(request);
            Save(result);

            return result;
        }

        private Func<TRequest, bool> Check;
        private Func<TRequest, TObject> Register;
        private Action<TObject> Save;
    }
}
