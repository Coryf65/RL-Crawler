using UnityEngine;
using UnityEngine.Events;

namespace Cory.RL_Crawler.Interfaces
{
    public interface IInputHandler
    {
        UnityEvent<Vector2> OnMovementKeyPressed { get; set; }
        UnityEvent<Vector2> OnPointerPosisitonChanged { get; set; }
        UnityEvent OnShootButtonPressed { get; set; }
        UnityEvent OnShootButtonReleased { get; set; }
    }
}