using UnityEngine;
namespace Scene1.LoadingResources
{
    public class LoadPrefabs : MonoBehaviour
    {
        private void CreateCylinder()
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
}