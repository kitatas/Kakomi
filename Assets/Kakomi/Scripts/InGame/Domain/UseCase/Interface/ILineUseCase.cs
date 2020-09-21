using System.Threading;

namespace Kakomi.InGame.Domain.UseCase.Interface
{
    public interface ILineUseCase
    {
        void DrawLine(CancellationToken token);
    }
}