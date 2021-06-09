using UnityEngine;
namespace ScriptableObjectsPractice.Items {
    [CreateAssetMenu(fileName = "Data", menuName = "Sword", order = 1)]
    public class SwordItem : ScriptableObject
    {
        public string SwordName;
        public int Damage;
        public int Level;
        public Sprite sprite;
    }
}