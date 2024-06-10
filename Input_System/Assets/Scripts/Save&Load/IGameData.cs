using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameData
{
    //reads the data
    void LoadData (GameData data);

    //ref allows script to modify data
    void SaveData (GameData data);
}
