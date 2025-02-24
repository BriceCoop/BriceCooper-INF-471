using UnityEngine;

public class Player_IdleState : Player_BaseState
{
    public override void EnterState(Player_State_Manager player)
    {
        Debug.Log("I'm idling");
    }

    public override void UpdateState(Player_State_Manager player)
    {
        //What do in this state?
        //Nothing... for now
        player.MoveCamera();

        //When leave this state?
        if (player.movement.magnitude > 0.1)
        {
            if (player.isSneaking)
            {
                player.SwitchState(player.sneakState);
            } 
            else 
            {
                player.SwitchState(player.walkState);
            }
        }
    }
}
