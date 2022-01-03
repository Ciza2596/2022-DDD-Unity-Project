using Actor.UseCase;
using DDDCore.Usecase.CQRS;
using ThirtyParty.DDDCore.Implement.CQRS;
using Zenject;
using Utilities.Contract;

namespace Actor.Adapter
{
    public class ActorController
    {

        [Inject] private CreateActorUseCase createActorUseCase;
        
        public void CreateActor() {

            var input  = new CreateActorInput();
            var output = new CqrsCommandPresenter();
            createActorUseCase.Execute(input, output);

            var exitCode = output.GetExitCode();
            Contract.Ensure(exitCode == ExitCode.SUCCESS, "ExitCode should be success.");
        }
    }
}
