using UnityEngine;
namespace ScriptableObjectsPractice.Items
{
    [CreateAssetMenu(fileName = "Data", menuName = "Cloth", order = 1)]
    public class ClothItem : ScriptableObject
    {
        public string ClothName;
        public int Armor;
        public int Level;
        public Sprite sprite;
    }
}