namespace Actor.Adapter.EventHandler
{
    public interface IActorFlow
    {
        void WhenActorCreated(string dataId);
    }
}
