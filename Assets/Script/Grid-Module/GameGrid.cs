using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paintastic.GridSystem
{
	public class GameGrid : MonoBehaviour
	{
		public int gridHeight { get; private set; } = 8;
		public int gridwidth { get; private set; } = 8;
		private float gridSpaceSize = 3.1f;
		//private int i = 0;

		[SerializeField] private GameObject gridCellPrefabs;
		public static GameObject[,] gameGrid;
		[SerializeField] PlayerController player1, player2; // change player refrence to array!
		private int playerScore=0;

		public event System.Action<int, int> OnGridSizeDecide;
		public event System.Action<string ,int> OnPlayerTilesCount;		

		void Start()
		{
			foreach (GameObject go in gameGrid)
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
			foreach (GameObject go in gameGrid)
			{
				go.gameObject.GetComponent<PlayerDetection>().OnCollectPointPicked -= OnCollcectPointPicked;
			}
		}

        private void OnCollcectPointPicked(GameObject _gameObject)
        {
			foreach (GameObject go in gameGrid)
            {
				//kirim score
				//reset warna
                if (go.CompareTag(_gameObject.tag))
                {
					playerScore += 1;
					ResetColor(go);
				}
            }
			OnPlayerTilesCount?.Invoke(_gameObject.tag, playerScore);
			playerScore = 0;
		}

        private void CreateGrid()
		{
			gameGrid = new GameObject[gridHeight, gridwidth];

			for (int y = 0; y < gridHeight; y++)
			{
				for (int x = 0; x < gridwidth; x++)
				{
					gameGrid[x, y] = Instantiate(gridCellPrefabs, new Vector3(x * gridSpaceSize, 0, y * gridSpaceSize), Quaternion.identity);
					gameGrid[x, y].GetComponent<GridCell>().SetPosition(x, y);
					gameGrid[x, y].transform.parent = transform;
				}
			}
			//update this to multiple case
			//player1.SetInit(player2,gameGrid,new Vector2Int(0,0));
			//player2.SetInit(player1,gameGrid,new Vector2Int(gameGrid.GetLength(0)-1,gameGrid.GetLength(1)-1));
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
        private void ResetColor(GameObject go)
        {
			//Debug.Log(go.tag);
			go.GetComponent<MeshRenderer>().material.color = Color.white;
			go.tag = "Tile";
		}
	
	}

}
