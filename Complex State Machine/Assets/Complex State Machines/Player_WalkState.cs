using UnityEngine;

public class Player_WalkState : Player_BaseState
{
    public override void EnterState(Player_State_Manager player)
    {
        Debug.Log("I'm walking");
    }

    public override void UpdateState(Player_State_Manager player)
    {
        //What do in this state?
        player.MovePlayer(player.DefaultSpeed);
        player.MoveCamera();

        //When leave this state?
        if (player.movement.magnitude < 0.1)
        {
            player.SwitchState(player.idleState);
        }
        else if (player.isSneaking)
        {
            player.SwitchState(player.sneakState);
        }
    }
}
