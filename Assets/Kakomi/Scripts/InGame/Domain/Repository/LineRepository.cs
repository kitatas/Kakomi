using Kakomi.InGame.Data.DataStore;
using Kakomi.InGame.Domain.Repository.Interface;
using Kakomi.InGame.Presentation.View;
using UnityEngine;

namespace Kakomi.InGame.Domain.Repository
{
    public sealed class LineRepository : ILineRepository
    {
        private readonly LineView _lineView;

        public LineRepository(EnclosureTable enclosureTable)
        {
            _lineView = enclosureTable.LineView;
        }

        public LineView GenerateLineView()
        {
            return Object.Instantiate(_lineView);
        }
    }
}