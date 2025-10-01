using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackwardsCommand : ICommand
{
    private Player player;
    private Vector3 previousPosition;

    public MoveBackwardsCommand(Player player)
    { this.player = player; }

    public void Execute()
    {
        previousPosition = player.transform.position;
        player.Move(Vector3.back);
    }

    public void Undo()
    {
        player.transform.position = previousPosition;
    }
}
