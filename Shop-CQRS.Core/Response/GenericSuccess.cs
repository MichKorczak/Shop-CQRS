namespace Shop_CQRS.Core.Response
{
    public class Success<TPayload> : Success
    {
        public TPayload Payload { get; }

        public Success(TPayload payload)
        {
            Payload = payload;
        }
    }
}
