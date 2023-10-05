using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestXlab
{
    public class WeaponController : MonoBehaviour
    {
        public string[] weaponTags;
        public GameObject[] characters;

        public void Change()
        {
            Debug.Log("Try change!");

            int randomWeaponTagIndex = Random.Range(0, weaponTags.Length);
            int randomCharacterIndex = Random.Range(0, characters.Length);

            string selectedWeaponTag = weaponTags[randomWeaponTagIndex];
            GameObject selectedCharacter = characters[randomCharacterIndex];

            GameObject[] weaponsWithSelectedTag = GameObject.FindGameObjectsWithTag(selectedWeaponTag);

            if (weaponsWithSelectedTag.Length > 0)
            {
                int randomWeaponIndex = Random.Range(0, weaponsWithSelectedTag.Length);
                GameObject selectedWeapon = weaponsWithSelectedTag[randomWeaponIndex];

                GameObject currentWeapon = selectedCharacter.transform.Find("Weapon").gameObject;
                Destroy(currentWeapon);

                GameObject newWeapon = Instantiate(selectedWeapon, selectedCharacter.transform.Find("WeaponSpawnPoint").position, Quaternion.identity);
                newWeapon.transform.parent = selectedCharacter.transform;
                newWeapon.name = "Weapon";

                Debug.Log("Weapon changed to " + selectedWeapon.name + " for character " + selectedCharacter.name);
            }
            else
            {
                Debug.LogWarning("No weapon found with tag " + selectedWeaponTag);
            }
        }
    }
}
