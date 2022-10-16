using System.Runtime.Serialization;

namespace PhotoService.BLL.Exceptions
{
    [Serializable]
    public class AuthorizationException:Exception
    {
        public AuthorizationException() { }
        public AuthorizationException(string message) : base(message) { }
        public AuthorizationException(string msg, Exception inner) : base(msg, inner) { }
        protected AuthorizationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
