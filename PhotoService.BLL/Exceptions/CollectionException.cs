using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.BLL.Exceptions
{
    [Serializable]
    public class CollectionException:Exception
    {
        public CollectionException() { }
        public CollectionException(string message) : base(message) { }
        public CollectionException(string msg, Exception inner) : base(msg, inner) { }
        protected CollectionException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
