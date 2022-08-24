using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
	private int height = 8;
	private int width = 8;
	private float gridSpaceSize = 3.1f;
	private int i = 0;

	[SerializeField] private GameObject gridCellPrefabs;
	private GameObject[,] gameGrid;
	[SerializeField] PlayerController player1, player2;

	void Start()
	{
		CreateGrid();
	}
    private void Update()
    {
        foreach (GameObject go in gameGrid)
        {
			if (go.tag == "Owner1")
            {
				i++;
            }
        }
		Debug.Log(i);
		i = 0;
    }

    private void CreateGrid()
	{
		gameGrid = new GameObject[height, width];

		for (int y = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
			{
				gameGrid[x, y] = Instantiate(gridCellPrefabs, new Vector3(x * gridSpaceSize, 0, y * gridSpaceSize), Quaternion.identity);
				gameGrid[x, y].GetComponent<GridCell>().SetPosition(x, y);
				gameGrid[x, y].transform.parent = transform;
			}
		}
		player1.SetInit(player2,gameGrid,new Vector2Int(0,0));
		player2.SetInit(player1,gameGrid,new Vector2Int(gameGrid.GetLength(0)-1,gameGrid.GetLength(1)-1));
	}
	
}
