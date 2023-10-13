using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class MainMenuState : MonoBehaviour
    {
        public List<GameObject> views;

        private void OnEnable()
        {
            foreach (var item in views)
            {
                item.SetActive(true);
            }
        }

        private void OnDisable()
        {
            foreach (var item in views)
            {
                item.SetActive(false);
            }
        }
    }
}