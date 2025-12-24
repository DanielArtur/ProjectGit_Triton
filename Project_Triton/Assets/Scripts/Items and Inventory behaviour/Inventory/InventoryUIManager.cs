using Inventory;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InventoryUIManager : MonoBehaviour
{
    ////////////////////////////////////////////////////////////////Refrences////////////////////////////////////////////////////////////////////

    [SerializeField] PlayerInventory playerInventory;
    PlayerInput PlayerInput;

    [Header("References")]
    [SerializeField] GameObject InventoryCellPrefab;
    [SerializeField] GameObject CellHolder;


    ////////////////////////////////////////////////////////////////Settings////////////////////////////////////////////////////////////////////
    [Header("Inventory Settings")]
    [Tooltip("Only whole numbers permitted")]
    [SerializeField] Vector2 inventorySize = new Vector2(5, 6);

    ////////////////////////////////////////////////////////////////Technical variables////////////////////////////////////////////////////////////////////
    Dictionary<int, InventoryUIItem> GridPositions;
    int gridCellAmount;
    Vector2 gridStartPoint;
    Vector2 cellSize;

    void Start()
    {
        PlayerInput = GetComponent<PlayerInput>();

        gridCellAmount = (int)(inventorySize.x * inventorySize.y);



        CreateCells(InventoryCellPrefab, CellHolder.transform, gridCellAmount, out gridStartPoint);
        // AssignCellPositions(inventory.GetInventory());
    }

    //private void AssignCellPositions(List<Item> inventory)
    //{

    //    GridPositions = new List<Vector2>();

    //    cellSize = CellHolder.GetComponent<GridLayoutGroup>().cellSize;

    //    Vector2 gridPos = gridStartPoint;

    //    for (int i = 0; i < gridCellAmount; i++)
    //    {
    //        GridPositions.Add(gridPos);
    //        Debug.Log(GridPositions[i]);
    //        gridPos += cellSize;

    //    }
    //}

    public void UpdateInventory()
    {




    }


    public void CreateCells(GameObject cellPrefab, Transform destinationObject, int cellAmount, out Vector2 firstCell)
    {

        firstCell = Instantiate(cellPrefab, destinationObject).transform.position;

        for (int i = 1; i < cellAmount; i++)
        {

            Instantiate(cellPrefab, destinationObject);
        }
    }



}
