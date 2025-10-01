using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardCommand : ICommand
{
    private Player player;
    private Vector3 previousPosition;

    public MoveForwardCommand(Player player)
    { 
        this.player = player; 
    }
    public void Execute()
    {   
        previousPosition = player.transform.position;
        player.Move(Vector3.forward);
    }

    public void Undo()
    {
        player.transform.position = previousPosition;
    }
}
