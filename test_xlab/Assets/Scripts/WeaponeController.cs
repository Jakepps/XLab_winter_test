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

            //int randomWeaponIndex = Random.Range(0, weapons.Length);

            int randomCharacterIndex = Random.Range(0, characters.Length);
            GameObject selectedCharacter = characters[randomCharacterIndex];

            GameObject currentWeapon = null;

            for (int i = 0; i < weapons.Length;i++) 
            {
                if (selectedCharacter.transform.Find(weaponNames[i]) != null)
                {
                    currentWeapon = selectedCharacter.transform.Find(weaponNames[i]).gameObject;

                    break;
                }
            }

            if (currentWeapon != null)
            {
                Destroy(currentWeapon);

                int randomWeaponIndex = Random.Range(0, weapons.Length);
                GameObject newWeapon = Instantiate(weapons[randomWeaponIndex], selectedCharacter.transform.position, Quaternion.identity);
                newWeapon.transform.parent = selectedCharacter.transform;
                newWeapon.name = "Weapon " + newWeapon.name;

                Debug.Log("Weapon changed to " + newWeapon.name + " for character " + selectedCharacter.name);
            }
            else
            {
                Debug.Log("No weapon found with name " + selectedCharacter.name);
            }
        }
    }
}