using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftCommand : ICommand
{
    private Player player;
    private Vector3 previousPosition;

    public MoveLeftCommand(Player player)
    {
        this.player = player;
    }

    public void Execute()
    {
        previousPosition = player.transform.position;
        player.Move(Vector3.left);
    }

    public void Undo()
    {
        player.transform.position = previousPosition;
    }
}
