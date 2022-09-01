using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paintastic.GridSystem
{
	public class GridCell : MonoBehaviour
	{
		private int posX;
		private int posY;

		private bool isOccupied = false;

		public void SetPosition(int x, int y)
		{
			posX = x;
			posY = y;
		}

		public Vector2Int GetPosition()
		{
			return new Vector2Int(posX, posY);
		}

		public bool GetCellAvailablility()
		{
			return isOccupied;
		}

		public void SetCellAvailablility()
		{
			isOccupied = !isOccupied;
		}

		public void ResetColor()
		{
			GetComponent<MeshRenderer>().material.color = Color.white;
			gameObject.tag = "Tile";
		}
	}
}