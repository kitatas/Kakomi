using System;

namespace Kakomi.InGame.Presentation.View.Interface
{
    public interface IEnclosureObject
    {
        void Enclose(Action<int> action);
    }
}