using UnityEngine;
using ScriptableObjectsPractice.Items;
using UnityEngine.UI;
using TMPro;
namespace ScriptableObjectsPractice.Menu
{
    public class MenuScript : MonoBehaviour
    {
        public SwordItem[] Swords;
        public ClothItem[] Cloths;
        public PotionItem[] Potions;

        public Image Sword;
        public Image Cloth;
        public Image Potion;

        public TextMeshProUGUI SwordName;
        public TextMeshProUGUI SwordDamage;
        public TextMeshProUGUI SwordLevel;
        public TextMeshProUGUI ClothName;
        public TextMeshProUGUI ClothArmor;
        public TextMeshProUGUI ClothLevel;
        public TextMeshProUGUI PotionName;
        public TextMeshProUGUI PotionType;
        public TextMeshProUGUI PotionAction;

        public Button SwordLeft;
        public Button SwordRight;
        public Button ClothLeft;
        public Button ClothRight;
        public Button PotionLeft;
        public Button PotionRight;

        int currentSword = 0;
        int currentCloth = 0;
        int currentPotion = 0;
        private void Start()
        {
            LoadSword(currentSword);
            LoadCloth(currentCloth);
            LoadPotion(currentPotion);
        }
        public void GetPreviousSword()
        {
            currentSword--;
            LoadSword(currentSword);
        }
        public void GetNextSword()
        {
            currentSword++;
            LoadSword(currentSword);
        }
        public void GetPreviousCloth()
        {
            currentCloth--;
            LoadCloth(currentCloth);
        }
        public void GetNextCloth()
        {
            currentCloth++;
            LoadCloth(currentCloth);
        }
        public void GetPreviousPotion()
        {
            currentPotion--;
            LoadPotion(currentPotion);
        }
        public void GetNextPotion()
        {
            currentPotion++;
            LoadPotion(currentPotion);
        }

        private void SetupButtons(int index, int length, Button Left, Button Right)
        {
            if (index == 0)
            {
               Left.interactable = false;
                if (length == 2)
                    Right.interactable = true;
            }
            if (index == length - 1)
            {
                Right.interactable = false;
                if (length == 2)
                    Left.interactable = true;
            }
            if (index > 0 && index < Swords.Length - 1)
                Left.interactable = Right.interactable = true;
        }
        private bool CheckIndex(int index, int length)
        {
            if (index < 0 || index >= length)
                return false;
            return true;
        }
        private void LoadSword(int index)
        {
            if (CheckIndex(index, Swords.Length))
            {
                SetupButtons(index, Swords.Length, SwordLeft, SwordRight);
            }
            else return;
            if(index > 0 && index < Swords.Length-1)
                SwordLeft.interactable = SwordRight.interactable = true;
            SwordItem sword = Swords[index];
            SwordName.text = sword.name;
            SwordDamage.text = "Damage: " + sword.Damage;
            SwordLevel.text = "Level: " + sword.Level;
            Sword.sprite = sword.sprite;
        }
        private void LoadCloth(int index)
        {
            if (CheckIndex(index, Cloths.Length))
            {
                SetupButtons(index, Cloths.Length, ClothLeft, ClothRight);
            }
            else return;
            ClothItem cloth = Cloths[index];
            ClothName.text = cloth.name;
            ClothArmor.text = "Armor: " + cloth.Armor;
            ClothLevel.text = "Level: " + cloth.Level;
            Cloth.sprite = cloth.sprite;
        }
        private void LoadPotion(int index)
        {
            if (CheckIndex(index, Potions.Length))
            {
                SetupButtons(index, Potions.Length, PotionLeft, PotionRight);
            }
            else return;
            PotionItem potion = Potions[index];
            PotionName.text = potion.PotionName;
            PotionType.text = potion.potionType.ToString();
            PotionAction.text = potion.potionType.ToString() + ": +" + potion.Action;
            Potion.sprite = potion.sprite;
        }

     
    }

}