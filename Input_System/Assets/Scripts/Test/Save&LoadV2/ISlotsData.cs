using DataSpace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataSpace
{
    public interface ISlotsData
    {
        void LoadSlot(SlotData data);

        void SaveSlot(SlotData data);
    }
}
