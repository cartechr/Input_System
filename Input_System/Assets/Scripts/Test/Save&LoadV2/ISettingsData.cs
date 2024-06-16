using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataSpace
{
    public interface ISettingsData
    {
        void LoadSettings(SettingsData data);

        void SaveSettings(SettingsData data);
    }
}
