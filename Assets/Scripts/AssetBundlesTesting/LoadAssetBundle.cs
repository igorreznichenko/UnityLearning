using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace AssetBundlesTesitng
{
    public class LoadAssetBundle : MonoBehaviour
    {
        private void Start()
        {
            //LoadFromFile("car.porsche");
            LoadFromURL("car.porsche");
        }
        private void LoadFromFile(string assetName)
        {
            AssetBundle loadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.dataPath, "AssetBundles",assetName));
            if(loadedAssetBundle == null)
            {
                Debug.Log("Asset bundles not found");
            }
            foreach (var item in loadedAssetBundle.GetAllAssetNames())
            {
                Instantiate(loadedAssetBundle.LoadAsset(item));
            }
        }
        private void LoadFromURL(string assetName)
        {
            StartCoroutine(loadFromURL(assetName));
        }
        private IEnumerator loadFromURL(string assetName)
        {
            string url = "file:///" + Application.dataPath + "/AssetBundles/" + assetName;
            var request = UnityWebRequestAssetBundle.GetAssetBundle(url, 0);
            yield return request.SendWebRequest();
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
            foreach (var item in bundle.GetAllAssetNames())
            {
                Instantiate(bundle.LoadAsset(item));
            }
        }
    }
}
