using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryUIManager : MonoBehaviour
{
    ////////////////////////////////////////////////////////////////Refrences////////////////////////////////////////////////////////////////////

    [SerializeField] PlayerInventory playerInventory;

    [Header("References")]
    [SerializeField] GameObject InventoryCellPrefab;
    [SerializeField] GameObject ItemIconPrefab;
    [SerializeField] GameObject CellHolder;
    [SerializeField] GameObject ItemHolder;


    ////////////////////////////////////////////////////////////////Settings////////////////////////////////////////////////////////////////////
    [Header("Inventory Settings")]
    [Tooltip("Only whole numbers permitted")]
    [SerializeField] Vector2 inventorySize = new Vector2(5, 6);

    ////////////////////////////////////////////////////////////////Technical variables////////////////////////////////////////////////////////////////////
    Dictionary<int, InventoryUIItem> GridPositions;
    int gridCellAmount;
    public Transform gridStartPoint;
    Vector2 cellImageSize;




    void Start()
    {

        gridCellAmount = (int)(inventorySize.x * inventorySize.y);
        CreateCells(InventoryCellPrefab, CellHolder.transform, gridCellAmount, out gridStartPoint);

    }




    //private void AssignCellPositions(List<inventoryItem> inventory)
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


    public void CreateCells(GameObject cellPrefab, Transform destinationObject, int cellAmount, out Transform firstCellPos)
    {

        GameObject firstCell = Instantiate(cellPrefab, destinationObject);
        firstCell.gameObject.name = "firstcell";
        firstCellPos = firstCell.transform;

        for (int i = 1; i < cellAmount; i++)
        {

            Instantiate(cellPrefab, destinationObject);
        }
    }

    public void AddItemIcon(InventoryItemSlot item)
    {

        //Vector3 globalGridPosition = CellHolder.transform.TransformPoint(gridStartPoint.position);
        //Debug.Log(gridStartPoint.GetComponent<RectTransform>().anchoredPosition);
        //Vector2 pos = new Vector2(inventoryItem.ItemPos.x + globalGridPosition.x, inventoryItem.ItemPos.y + globalGridPosition.y);
        //pos = ItemHolder.transform.InverseTransformPoint(pos);


        //GameObject newItemIcon = Instantiate(ItemIconPrefab, pos, Quaternion.identity, ItemHolder.transform);
        //newItemIcon.GetComponent<Image>().sprite = inventoryItem.inventoryItem.itemIcon;


        Vector2 anchoredGridPosition = gridStartPoint.GetComponent<RectTransform>().anchoredPosition;

        Vector2 pos = new Vector2(item.ItemPos.x + anchoredGridPosition.x, item.ItemPos.y + anchoredGridPosition.y);
        GameObject newItemIcon = Instantiate(ItemIconPrefab, Vector2.zero, Quaternion.identity, ItemHolder.transform);

        newItemIcon.GetComponent<Image>().sprite = item.inventoryItem.itemIcon;
        newItemIcon.GetComponent<RectTransform>().anchoredPosition = pos;


    }


}
