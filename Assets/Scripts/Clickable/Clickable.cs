using UnityEngine;

public abstract class Clickable : MonoBehaviour
{
	public enum ClickableState
	{
		INACTIVE = 0,
		ACTIVE = 1
	}

	public abstract bool clicked { get; set; }

	public abstract void Click();
}
