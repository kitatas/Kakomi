using System;
using Kakomi.InGame.Application;

namespace Kakomi.InGame.Presentation.View.Interface
{
    public interface IEnclosureObject
    {
        int EffectValue { get; }
        EnclosureObjectType EnclosureObjectType { get; }
        void Enclose(Action<int> action);
    }
}