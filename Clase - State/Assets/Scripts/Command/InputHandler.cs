using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Player player;
    List<ICommand> recordedReplayCommands = new List<ICommand>();
    Stack<ICommand> commandsHistory = new Stack<ICommand>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            ICommand moveForward = new MoveForwardCommand(player);
            moveForward.Execute();
            recordedReplayCommands.Add(moveForward);
            commandsHistory.Push(moveForward);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            ICommand moveBackward = new MoveBackwardsCommand(player);
            moveBackward.Execute();
            recordedReplayCommands.Add(moveBackward);
            commandsHistory.Push(moveBackward);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            ICommand moveRight = new MoveRightCommand(player);
            moveRight.Execute();
            recordedReplayCommands.Add(moveRight);
            commandsHistory.Push(moveRight);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            ICommand moveLeft = new MoveLeftCommand(player);
            moveLeft.Execute();
            recordedReplayCommands.Add(moveLeft);
            commandsHistory.Push(moveLeft);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(ReplayActions());
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(ZaWarudo());
        }
    }

    private IEnumerator ReplayActions()
    {
        foreach (var command in recordedReplayCommands)
        {
            command.Execute();
            yield return new WaitForSeconds(0.5f);
        }
        recordedReplayCommands.Clear();
    }

    private IEnumerator ZaWarudo()
    {

        foreach (var command in commandsHistory)
        {
            command.Undo();
            yield return new WaitForSeconds(0.1f);
        }
        //int recordLength = commandsHistory.Count;

        //for (int i = recordLength-1; i > 0; i--) {
        //    //Debug.Log($"recorded index{recordedReplayCommands.pop} {i}");
        //    commandsHistory.Pop().Execute();
        //    yield return new WaitForSeconds(0.5f);
            

        //}
        commandsHistory.Clear();
    }

}
