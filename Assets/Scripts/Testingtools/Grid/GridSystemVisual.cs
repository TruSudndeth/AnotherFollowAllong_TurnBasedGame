using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class GridSystemVisual : MonoBehaviour
{
    [SerializeField] private Transform gridVisualObj;

    private GridVisualSingle[,] gridSystemVisualSingleArray;
    void Start()
    {
        gridSystemVisualSingleArray = new GridVisualSingle[LevelGrid.Instance.GetWidth(),LevelGrid.Instance.GetHeight()];
        for (int x = 0; x < LevelGrid.Instance.GetWidth(); x++)
        {
            for (int z = 0; z < LevelGrid.Instance.GetHeight(); z++)
            {
                GridPosition gridPosition = new GridPosition(x, z);
                Transform gridVisualSingleTransform = Instantiate(gridVisualObj, LevelGrid.Instance.GetWorldPosition(gridPosition), Quaternion.identity);
                gridSystemVisualSingleArray[x, z] = gridVisualSingleTransform.GetComponent<GridVisualSingle>();
            }
        }
    }

    public void HideAllGridPositions()
    {

    }
    public void ShowGridPositionList(List<GridPosition> _gridPositions)
    {

    }
}
