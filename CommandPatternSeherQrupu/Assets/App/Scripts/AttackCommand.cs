using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : MonoBehaviour, ICommand
{
	public Animator animator;

	public AttackCommand(Animator _animator)
	{
		animator = _animator;
	}


	public void Execute()
	{
		CommandManager.instance.Attack(animator);
	}

	public void Undo()
	{
		CommandManager.instance.Attack(animator);
	}
}
