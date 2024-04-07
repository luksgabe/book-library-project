namespace BookLibrary.Domain.Interfaces.SeedWork
{
    public interface IMessage
    {
        public string MessageType { get; protected set; }

        public Guid AggregateId { get; protected set; }
    }
}
