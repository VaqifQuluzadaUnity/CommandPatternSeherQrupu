using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : MonoBehaviour, ICommand
{
	public GameObject movedObject;

	public Vector3 initialPos;

	public Vector3 latestPos;

	public float speed;

	public MoveCommand(GameObject _movedObject, Vector3 _initialPos, Vector3 _latestPos, float _speed)
	{
		movedObject = _movedObject;

		initialPos = _initialPos;

		latestPos = _latestPos;

		speed = _speed;
	}

	public void Execute()
	{

		CommandManager.instance.MovePlayer(movedObject,latestPos,speed);
	}

	public void Undo()
	{
		CommandManager.instance.MovePlayer(movedObject, initialPos, speed);
	}
}

public interface ICommand
{
  public void Execute();

  public void Undo();
}
