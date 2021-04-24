using Kakomi.InGame.Domain.UseCase.Interface;
using Kakomi.InGame.Presentation.View;
using UniRx;

namespace Kakomi.InGame.Presentation.Presenter
{
    public sealed class TurnCountPresenter
    {
        public TurnCountPresenter(ITurnCountUseCase turnCountUseCase, TurnCountView turnCountView)
        {
            turnCountView.Init();

            turnCountUseCase.TurnCount()
                .Subscribe(turnCountView.Display)
                .AddTo(turnCountView);
        }
    }
}