using UnityEngine;

public class ItemCreator : MonoBehaviour
{
    public Item CreateItem(ShotgunItemPreset preset)
    {

        return new ShotgunItem(preset);

    }


}
