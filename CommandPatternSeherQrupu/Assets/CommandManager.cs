using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
  public static CommandManager instance;

	[SerializeField] private List<ICommand> executedCommands=new List<ICommand>();

	private GameObject currentGameObject = null;

	private void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy(instance.gameObject);
		}
		instance = this;
		DontDestroyOnLoad(this);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			StartCoroutine(UndoAllCommands());
		}
	}

	public void MovePlayer(GameObject _movedObject,Vector3 destinationPoint,float speed)
	{

		if (currentGameObject != null)
		{
			Debug.Log("Current action in progress");
			return;
		}

		currentGameObject = _movedObject;

		StartCoroutine(MovePlayerCoroutine(_movedObject,destinationPoint,speed));
	}

	public void AddCommandToList(ICommand command)
	{
		executedCommands.Add(command);
	}

	public void Attack(Animator animator)
	{
		//animator.Play("Attack");

		print("Attacked");
	}

	IEnumerator UndoAllCommands()
	{
		for(int i = executedCommands.Count-1; i >=0; i--)
		{
			executedCommands[i].Undo();
			yield return new WaitForSeconds(2f);
		}

		//executedCommands.Clear();
	}
	IEnumerator MovePlayerCoroutine(GameObject _movedObject, Vector3 destinationPoint, float speed)
	{
		while (_movedObject.transform.position != destinationPoint)
		{
			_movedObject.transform.position = 
				Vector3.MoveTowards(_movedObject.transform.position, destinationPoint, speed);

			yield return new WaitForEndOfFrame();
		}

		currentGameObject = null;
	}
}
