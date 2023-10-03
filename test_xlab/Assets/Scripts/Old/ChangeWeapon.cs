using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    private bool buttonSpace = false;
    
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Space))  buttonSpace = true;
        if (buttonSpace)
        {
            GameObject weaponPlow = GameObject.Find("VillagerPlow"); 
            GameObject weaponHam = GameObject.Find("VillagerHammer");
            GameObject weaponFish = GameObject.Find("VillagerFishingRod");
            GameObject weaponPick = GameObject.Find("VillagerPickaxe");
            GameObject weaponPlowX = GameObject.Find("VillagerPlowX");
            GameObject weaponFishX = GameObject.Find("VillagerFishingRodX");

            Destroy(weaponPlow);
            Destroy(weaponHam); 
            Destroy(weaponFish);
            Destroy(weaponPick); 
            Destroy(weaponFishX);
            Destroy(weaponPlowX);

            GameObject newWeapon1 = Instantiate(weaponHam, weaponPlow.transform.position, Quaternion.identity);                                    
            newWeapon1.transform.parent = weaponPlow.transform.parent;       
            newWeapon1.name = "newWeapon1";  

            GameObject newWeapon2 = Instantiate(weaponPlow, weaponHam.transform.position, Quaternion.identity);
            newWeapon2.transform.parent = weaponHam.transform.parent; 
            newWeapon2.name = "newWeapon2";    

            GameObject newWeapon3 = Instantiate(weaponPick, weaponFish.transform.position, Quaternion.identity);
            newWeapon3.transform.parent = weaponFish.transform.parent; 
            newWeapon3.name = "newWeapon3"; 

            GameObject newWeapon4 = Instantiate(weaponFish, weaponPick.transform.position, Quaternion.identity);
            newWeapon4.transform.parent = weaponPick.transform.parent; 
            newWeapon4.name = "newWeapon4"; 

            GameObject newWeapon5 = Instantiate(weaponPick, weaponFishX.transform.position, Quaternion.identity);
            newWeapon5.transform.parent = weaponFishX.transform.parent; 
            newWeapon5.name = "newWeapon5";

            GameObject newWeapon6 = Instantiate(weaponHam, weaponPlowX.transform.position, Quaternion.identity);
            newWeapon6.transform.parent = weaponPlowX.transform.parent; 
            newWeapon6.name = "newWeapon6";
        }
    }
}