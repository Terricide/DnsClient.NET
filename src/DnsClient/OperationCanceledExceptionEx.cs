using System.Runtime.Serialization;

namespace System.Threading.Tasks
{
    [Serializable]
    internal class OperationCanceledExceptionEx : OperationCanceledException
    {
        public CancellationToken CancellationToken;

        public OperationCanceledExceptionEx()
        {
        }

        public OperationCanceledExceptionEx(CancellationToken cancellationToken)
        {
            this.CancellationToken = cancellationToken;
        }

        public OperationCanceledExceptionEx(string message) : base(message)
        {
        }

        public OperationCanceledExceptionEx(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OperationCanceledExceptionEx(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}