using System;
using Kakomi.InGame.Application;

namespace Kakomi.InGame.Presentation.View.Interface
{
    public interface IEnclosureObject
    {
        EnclosureObjectData EnclosureObjectData { get; }
        void Enclose(Action<int> action);
    }
}