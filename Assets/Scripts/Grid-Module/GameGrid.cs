using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.Player;

namespace Paintastic.GridSystem
{
	public class GameGrid : MonoBehaviour
	{
		public int gridHeight { get; private set; } = 8;
		public int gridwidth { get; private set; } = 8;
		[SerializeField]
		private float gridSpaceSize = 3.1f;

		[SerializeField] private GameObject gridCellPrefabs;
		private GridCell[,] gameGrid;

		public event System.Action<int, int> OnGridSizeDecide;
		public event System.Action<string ,int> OnPlayerTilesCount;		

		public void StartInit()
		{
			CreateGrid();
			OnGridSizeDecide?.Invoke(gridHeight, gridwidth);
		}

        private void CreateGrid()
		{
			gameGrid = new GridCell[gridHeight, gridwidth];

			for (int y = 0; y < gridHeight; y++)
			{
				for (int x = 0; x < gridwidth; x++)
				{
					gameGrid[x, y] = Instantiate(gridCellPrefabs, new Vector3(x * gridSpaceSize, 0, y * gridSpaceSize), Quaternion.identity).GetComponent<GridCell>();
					gameGrid[x, y].GetComponent<GridCell>().SetPosition(x, y);
					gameGrid[x, y].transform.parent = transform;
				}
			}
		}
		public GridCell[,] GetGrid() => gameGrid;
	}

}
