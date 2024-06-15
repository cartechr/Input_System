using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataSpace
{
    public interface IData
    {
        void LoadSettings(Settings data);

        void SaveSettings(Settings data);
    }

}