using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TestXlab
{
    public class WeaponController : MonoBehaviour
    {
        public GameObject[] weapons; 
        public GameObject[] characters; 
        public List<string> weaponNames = new List<string>();

        private void Start()
        {
            foreach (var weapon in weapons)
            {
                weaponNames.Add(weapon.name);
            }

        }

        public void Change()
        {
            Debug.Log("Try change!");

            int randomCharacterIndex = Random.Range(0, characters.Length);
            GameObject selectedCharacter = characters[randomCharacterIndex];

            GameObject currentWeapon = null;

            for (int i = 0; i < weapons.Length; i++) 
            {
                string weapChild = $"DummyRig/root/B-hips/B-spine/B-chest/B-upperChest/B-shoulder_R/B-upper_arm_R/B-forearm_R/B-hand_R/{weaponNames[i]}";
                if (selectedCharacter.transform.Find(weapChild) != null)
                {
                    currentWeapon = selectedCharacter.transform.Find(weapChild).gameObject;

                    break;
                }
            }

            if (currentWeapon != null)
            {
                Transform parentTrans = currentWeapon.transform.parent;

                Vector3 weaponPosition = currentWeapon.transform.position;
                Quaternion weaponRotation = currentWeapon.transform.rotation;

                currentWeapon.SetActive(false);

                int randomWeaponIndex = Random.Range(0, weaponNames.Count);
                GameObject newWeapon = Instantiate(weapons[randomWeaponIndex], weaponPosition, weaponRotation);

                newWeapon.transform.SetParent(parentTrans);

                newWeapon.name = weapons[randomWeaponIndex].name;

                Debug.Log("Weapon changed to " + newWeapon.name + " for character " + selectedCharacter.name);
            }
            else
            {
                Debug.Log("No weapon found with name " + selectedCharacter.name);
            }
        }
    }
}