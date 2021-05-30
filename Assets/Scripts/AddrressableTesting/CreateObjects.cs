using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class CreateObjects : MonoBehaviour
{
    public AssetReference _asset;
    private GameObject _result; 
    private void Start()
    {
        InstantiateObject();
    }

    private void LoadObject()
    {
        _asset.LoadAssetAsync<GameObject>().Completed += CreateObjects_Completed;
    }

    private void CreateObjects_Completed(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject> obj)
    {
        _result = obj.Result;
    }
    private void InstantiateObject()
    {
        _asset.InstantiateAsync();
    }
}
