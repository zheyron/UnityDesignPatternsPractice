using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRightCommand : ICommand
{
    private Player player;
    private Vector3 previousPosition;

    public MoveRightCommand(Player player)
    {
        this.player = player;
    }

    public void Execute()
    {
        previousPosition = player.transform.position;
        player.Move(Vector3.right);
    }

    public void Undo()
    {
        player.transform.position = previousPosition;
    }
}
