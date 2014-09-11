using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[ExecuteInEditMode]
[RequireComponent (typeof(BoxCollider2D))]

public class ColliderFit : MonoBehaviour 
{
	private BoxCollider2D bc2d;

	void Awake()
	{
		bc2d = (BoxCollider2D)collider2D;
	}

	private void Update()
	{
		Bounds bounds = new Bounds(Vector3.zero, Vector3.zero);
		bool hasBounds = false;

		foreach (Transform childObject in transform)
		{
			Bounds b = childObject.GetComponentInChildren<SpriteRenderer>().bounds;
			if (hasBounds)
				bounds.Encapsulate(b);
			else
			{
				bounds = b;
				hasBounds = true;
			}
		}

		if (hasBounds)
		{
			bc2d.center = bounds.center - transform.position;
			bc2d.size = bounds.size;
		}
		else
		{
			bc2d.center = Vector3.zero;
			bc2d.size = Vector3.zero;
		}
	}
}
