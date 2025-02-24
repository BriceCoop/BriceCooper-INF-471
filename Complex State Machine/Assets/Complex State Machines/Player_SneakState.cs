using UnityEngine;

public class Player_SneakState : Player_BaseState
{
    public override void EnterState(Player_State_Manager player)
    {
        Debug.Log("I'm sneaking");
    }

    public override void UpdateState(Player_State_Manager player)
    {
        //What do in this state?
        player.MovePlayer(player.DefaultSpeed * 0.5f);
        player.MoveCamera();

        //When leave this state?
        if (player.movement.magnitude < 0.1)
        {
            player.SwitchState(player.idleState);
        } 
        else if (player.isSneaking == false)
        {
            player.SwitchState(player.walkState);
        }

    }
}
