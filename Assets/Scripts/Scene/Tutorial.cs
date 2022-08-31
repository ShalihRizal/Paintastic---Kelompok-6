using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
	[SerializeField] GameObject scrollBar;
	private float scrollPos = 0;
	private float[] pos;
	private int Pos = 0;

	public void NextSlide()
	{
		if (Pos < pos.Length - 1)
		{
			Pos += 1;
			scrollPos = pos[Pos];
		}
	}
	public void PrevSlide()
	{
		if (Pos > 0)
		{
			Pos -= 1;
			scrollPos = pos[Pos];
		}
	}

	void Update()
	{
		pos = new float[transform.childCount];
		float distance = 1f / (pos.Length - 1f);
		for (int i = 0; i < pos.Length; i++)
		{
			pos[i] = distance * i;
		}
		if (Input.GetMouseButton(0))
		{
			scrollPos = scrollBar.GetComponent<Scrollbar>().value;
		}
		else
		{
			for (int i = 0; i < pos.Length; i++)
			{
				if (scrollPos < pos[i] + (distance / 2) && scrollPos > pos[i] - (distance / 2))
				{
					scrollBar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollBar.GetComponent<Scrollbar>().value, pos[i], 0.15f);
					Pos = i;
				}
			}
		}
	}
}
