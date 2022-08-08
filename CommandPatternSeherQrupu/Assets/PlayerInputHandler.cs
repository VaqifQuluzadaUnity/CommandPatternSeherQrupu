using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{

	[SerializeField] private Animator playerAnimator;

	[SerializeField] private float speed;

	

	private void Update()
	{

		if (Input.GetMouseButtonDown(0))
		{
			Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit();
			if (Physics.Raycast(mouseRay, out hit))
			{
				MoveCommand command = new MoveCommand(gameObject, transform.position, hit.point, speed);

				command.Execute();

				CommandManager.instance.AddCommandToList(command);
			}
		}

		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			AttackCommand command = new AttackCommand(playerAnimator);

			command.Execute();

			CommandManager.instance.AddCommandToList(command);
		}
	}
}
