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

    // === UI-callable PUBLIC methods ===
    public void PressUpButton() => Run(new MoveForwardCommand(player));
    public void PressDownButton() => Run(new MoveBackwardsCommand(player));
    public void PressLeftButton() => Run(new MoveLeftCommand(player));
    public void PressRightButton() => Run(new MoveRightCommand(player));

    public void StartReplay() => StartCoroutine(ReplayActions());
    public void StartUndoAll() => StartCoroutine(ZaWarudo());

    // === shared runner ===
    private void Run(ICommand cmd)
    {
        if (player == null) { Debug.LogWarning("InputHandler: Player is null."); return; }
        cmd.Execute();
        recordedReplayCommands.Add(cmd);
        commandsHistory.Push(cmd);
    }

    private IEnumerator ReplayActions()
    {
        foreach (var command in recordedReplayCommands)
        {
            command.Execute();
            yield return new WaitForSeconds(0.08f);
        }
        recordedReplayCommands.Clear();
    }

    private IEnumerator ZaWarudo()
    {

        foreach (var command in commandsHistory)
        {
            command.Undo();
            yield return new WaitForSeconds(0.08f);
        }
        commandsHistory.Clear();
    }

}
