using UnityEngine;

public interface IState
{
    void StateUpdate();
    void StateEnter();
    void StateExit();
}
