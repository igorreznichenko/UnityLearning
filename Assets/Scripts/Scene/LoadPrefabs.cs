using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPrefabs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void CreateCylinder()
    {
        UnityEngine.Object[] Objects = Resources.FindObjectsOfTypeAll(typeof(GameObject));
        foreach (var item in Objects)
        {
            if (item.name == "Cylinder")
            {
                Instantiate(item);
                break;
            }
        }
        Resources.UnloadUnusedAssets();
    }
}
