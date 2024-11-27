using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
	[SerializeField] private List<WheelItem> _wheelItems;
	[SerializeField] private Transform _wheelVisualTransform;

	public Transform WheelVisualTransform => _wheelVisualTransform;

	public List<WheelItem> WheelItems
    {
		get { return _wheelItems; }
		set { _wheelItems = value; }
	}

	public int GetRandomItemIndex()
	{
		return Random.Range(0, _wheelItems.Count);
	}
}
