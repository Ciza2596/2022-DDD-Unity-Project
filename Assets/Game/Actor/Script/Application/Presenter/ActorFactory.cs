using Actor.Application.Component;

namespace Actor.Application.Preseter
{
    public class ActorFactory
    {
        private readonly ActorComponent.Pool pool;


        public ActorFactory(ActorComponent.Pool pool) {
            this.pool = pool;
        }

        public ActorComponent Create() {

            return pool.Spawn();
        }

        

    }
}
