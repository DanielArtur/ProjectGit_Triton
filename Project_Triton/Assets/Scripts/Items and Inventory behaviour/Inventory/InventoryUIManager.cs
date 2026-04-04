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

    ////////////////////////////////////////////////////////////////Technical variables////////////////////////////////////////////////////////////////////
    Dictionary<int, InventoryUIItem> GridPositions;
    int gridCellAmount;
    public Transform gridStartPoint;
    Vector2 cellImageSize;
    Vector2 inventorySize;




    void Start()
    {

        inventorySize = playerInventory.inventorySize;

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
        //Vector2 itemUIPos = new Vector2(inventoryItem.itemCellIndex.x + globalGridPosition.x, inventoryItem.itemCellIndex.y + globalGridPosition.y);
        //itemUIPos = ItemHolder.transform.InverseTransformPoint(itemUIPos);


        //GameObject newItemObject = Instantiate(ItemIconPrefab, itemUIPos, Quaternion.identity, ItemHolder.transform);
        //newItemObject.GetComponent<Image>().sprite = inventoryItem.inventoryItem.itemIcon;





        Vector2 anchoredGridPosition = gridStartPoint.GetComponent<RectTransform>().anchoredPosition;


        // Adjust the posiiton relatively to cell size which is 100
        float UIPosX = item.itemCellIndex.x * 100;
        float UIPosY = -item.itemCellIndex.y * 100;

        Vector2 itemUIPos = new Vector2(UIPosX + anchoredGridPosition.x, UIPosY + anchoredGridPosition.y);
        GameObject newItemObject = Instantiate(ItemIconPrefab, Vector2.zero, Quaternion.identity, ItemHolder.transform);

        Transform childObject = newItemObject.transform.GetChild(0);


        RectTransform itemObjectRectTransform = newItemObject.GetComponent<RectTransform>();
        RectTransform itemIconRectTranform = childObject.GetComponent<RectTransform>();


        childObject.GetComponent<Image>().sprite = item.inventoryItem.itemIcon;

        itemObjectRectTransform.anchoredPosition = itemUIPos;

        //Test
        Vector2 newSize = new Vector2(item.inventoryItem.itemSize.x * 100, item.inventoryItem.itemSize.y * 100);
        itemIconRectTranform.sizeDelta = newSize;

        //150 for y because Unity counts from bottom left.
        //Vector2 newPivotPosition = new Vector2(50 / newSize.x, (newSize.y - 50) / newSize.y);
        Vector2 newPivotPosition = new Vector2(0, 1);
        itemIconRectTranform.pivot = newPivotPosition;




    }


}
