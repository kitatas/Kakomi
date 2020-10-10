using System;
using UnityEngine;

namespace Kakomi.InGame.Presentation.View.Interface
{
    public interface IEnclosureObject
    {
        Color CoreColor { get; }
        void Enclose(Action<int> action);
    }
}