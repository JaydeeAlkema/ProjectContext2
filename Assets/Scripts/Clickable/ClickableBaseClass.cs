using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickableBaseClass : Clickable
{
	[SerializeField] private List<UnityEvent> eventsOnClick = new List<UnityEvent>();

	[SerializeField] public override bool clicked { get; set; }

	private void Start()
	{
		clicked = eventsOnClick.Count == 0 ? true : false;
	}

	private void OnMouseDown()
	{
		Click();
	}

	public override void Click()
	{
		if( !clicked )
		{
			foreach( UnityEvent onClickEvent in eventsOnClick )
			{
				onClickEvent.Invoke();
			}
			clicked = true;
		}
	}
}
