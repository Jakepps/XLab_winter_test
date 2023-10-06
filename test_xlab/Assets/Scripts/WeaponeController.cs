using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestXlab
{
    public class WeaponController : MonoBehaviour
    {
        public GameObject[] weapons; 
        public GameObject[] characters; 
        public string[] weaponNames;

        private void Start()
        {
            weaponNames = new string[weapons.Length];
            
            for (int i = 0; i < weapons.Length; i++)
            {
                weaponNames[i] = weapons[i].name;
            }
        }
        
        public void Change()
        {
            Debug.Log("Try change!");

            int randomWeaponIndex = Random.Range(0, weapons.Length);
            int randomCharacterIndex = Random.Range(0, characters.Length);

            string selectedWeaponName = weaponNames[randomWeaponIndex];
            GameObject selectedCharacter = characters[randomCharacterIndex];

            //GameObject selectedWeapon = Array.Find(weapons, weapon => weapon.name == selectedWeaponName);
            GameObject selectedWeapon = weapons[randomWeaponIndex];

            if (selectedWeapon != null)
            {
                GameObject currentWeapon = selectedCharacter.transform.Find(selectedWeaponName).gameObject;
                Destroy(currentWeapon);

                GameObject newWeapon = Instantiate(selectedWeapon, selectedCharacter.transform.position, Quaternion.identity); 
                newWeapon.transform.parent = selectedCharacter.transform;
                newWeapon.name = "Weapon " + newWeapon.name;

                Debug.Log("Weapon changed to " + selectedWeapon.name + " for character " + selectedCharacter.name);
            }
            else
            {
                Debug.LogWarning("No weapon found with name " + selectedWeaponName);
            }
        }
    }
}