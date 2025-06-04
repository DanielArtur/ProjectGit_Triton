public static class InventoryDataUtils
{




    //public static void ItemPresetWriter(Bitpacker packer, ItemPresetSO preset)
    //{
    //    if (preset == null)
    //    {
    //        packer<bool>.Write(packer, false);
    //        return;

    //    }
    //    Packer<bool>.Write(packer, true);
    //    Packer<string>.Write(packer, preset.uid);



    //}


    //public static void ItemPresetReader(BitPacker packer, ref ItemPresetSO preset)
    //{

    //    bool hasPreset = false;

    //    Packer<bool>.Read(packer, ref hasPreset);

    //    if (!hasPreset)
    //    {
    //        preset = null;
    //        return;


    //    }

    //    if (!Instancehandler.TryGetInstance(out ItemDatabase database))
    //    {

    //        Debug.LogError($"Failed to get items database instance for reading ItemPresetSO!");

    //        return;
    //    }

    //    var uid = default(string);
    //    Packer<string>.Read(packer, ref uid);

    //    ItemDatabase.TryGetItemPreset(uid, out preset);


    //}

}
