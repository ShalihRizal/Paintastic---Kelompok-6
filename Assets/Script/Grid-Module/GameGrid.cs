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
		//private int i = 0;

		[SerializeField] private GameObject gridCellPrefabs;
		private GridCell[,] gameGrid;
		private int playerScore=0;

		public event System.Action<int, int> OnGridSizeDecide;
		public event System.Action<string ,int> OnPlayerTilesCount;		

		public void Start()
		{
			foreach (GridCell go in gameGrid)
			{
				go.gameObject.GetComponent<PlayerDetection>().OnCollectPointPicked += OnCollcectPointPicked;
			}
		}
		private void OnEnable()
		{
			CreateGrid();
			OnGridSizeDecide?.Invoke(gridHeight, gridwidth);
		}
        private void OnDisable()
        {
			foreach (GridCell go in gameGrid)
			{
				go.gameObject.GetComponent<PlayerDetection>().OnCollectPointPicked -= OnCollcectPointPicked;
			}
		}

        private void OnCollcectPointPicked(GameObject _gameObject)
        {
			/*foreach (GridCell go in gameGrid)
            {
				//kirim score
				//reset warna
                if (go.CompareTag(_gameObject.tag))
                {
					playerScore += 1;
					go.ResetColor();
				}
            }
			OnPlayerTilesCount?.Invoke(_gameObject.tag, playerScore);
			playerScore = 0;*/
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

        /*public static GameObject[,] GetGrid()
        {
            return gameGrid;
        }*/

        private void Update()
        {
			//GameObject[,] _t = GetGrid();
			//Debug.Log(_t[_t, _t.Length-1].transform.position);
        }
        

		public GridCell[,] GetGrid() => gameGrid;
	}

}
