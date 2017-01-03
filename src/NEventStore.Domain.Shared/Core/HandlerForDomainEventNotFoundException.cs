namespace NEventStore.Domain.Core
{
    using System;
    using System.Runtime.Serialization;

#if !PCL
    [Serializable]
#endif
    public class HandlerForDomainEventNotFoundException : Exception
	{
		public HandlerForDomainEventNotFoundException()
		{}

		public HandlerForDomainEventNotFoundException(string message)
			: base(message)
		{}

		public HandlerForDomainEventNotFoundException(string message, Exception innerException)
			: base(message, innerException)
		{}
#if !PCL
		public HandlerForDomainEventNotFoundException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{}
#endif
	}
}