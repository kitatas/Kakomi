using System;
using Kakomi.InGame.Application;
using UnityEngine;

namespace Kakomi.InGame.Presentation.View.Interface
{
    public interface IEnclosureObject
    {
        int EffectValue { get; }
        EnclosureObjectType EnclosureObjectType { get; }
        void Enclose(Action<int, Color> action);
    }
}