using UnityEngine;

public abstract class Player_BaseState
{
    public abstract void EnterState(Player_State_Manager player);

    public abstract void UpdateState(Player_State_Manager player);
}
