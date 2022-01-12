using System.Collections.Generic;
using Actor.Entity;
using Actor.UseCase;
using Actor.UseCase.Repository;
using DDDCore.Usecase.CQRS;
using ThirtyParty.DDDCore.Implement.CQRS;
using Zenject;
using Utilities.Contract;

namespace Actor.Adapter.Controller
{
    public class ActorController
    {

        [Inject] private CreateActorUseCase createActorUseCase;
        [Inject] private IActorRepository   actorRepository;
        
        public void CreateActor(string actorDataId) {

            var input  = new CreateActorInput(actorDataId);
            var output = new CqrsCommandPresenter();
            createActorUseCase.Execute(input, output);

            var exitCode = output.GetExitCode();
            Contract.Ensure(exitCode == ExitCode.SUCCESS, "ExitCode should be success.");
        }

        public List<IActor> GetAllActor() {
            var actors = actorRepository.GetAll();
            return actors;
        }
    }
}
