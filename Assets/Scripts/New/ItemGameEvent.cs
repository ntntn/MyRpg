using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemGameEvent : ScriptableObject
{
	private List<ItemEventListener> listeners =
		new List<ItemEventListener>();

	public void Raise(Item value)
	{
		for (int i = listeners.Count - 1; i >= 0; i--)
			listeners[i].OnEventRaised(value);
	}

	public void RegisterListener(ItemEventListener listener)
	{ listeners.Add(listener); }

	public void UnregisterListener(ItemEventListener listener)
	{ listeners.Remove(listener); }
}
