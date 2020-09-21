using Kakomi.InGame.Presentation.View;

namespace Kakomi.InGame.Domain.Repository.Interface
{
    public interface ILineRepository
    {
        LineView GenerateLineView();
    }
}