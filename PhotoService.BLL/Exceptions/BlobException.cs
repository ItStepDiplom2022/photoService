using System.Runtime.Serialization;

namespace PhotoService.BLL.Exceptions
{
    [Serializable]
    public class BlobException:Exception
    {
        public BlobException() { }
        public BlobException(string message) : base(message) { }
        public BlobException(string msg, Exception inner) : base(msg, inner) { }
        protected BlobException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
