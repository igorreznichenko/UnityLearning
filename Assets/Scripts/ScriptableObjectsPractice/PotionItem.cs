using UnityEngine;
namespace ScriptableObjectsPractice.Items
{
    [CreateAssetMenu(fileName = "Data", menuName = "Potion", order = 1)]
    public class PotionItem : ScriptableObject
    {
        public string PotionName;
        public int Action;
        public PotionType potionType;
        public Sprite sprite;
    }
    public enum PotionType
    {
        Health,
        Manna
    }
}
