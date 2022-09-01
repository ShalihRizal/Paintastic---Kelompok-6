using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paintastic.Killfeed
{
    public class Killfeed : MonoBehaviour
    {
        [SerializeField]
        float duration = 4;
        public void StartInit()
        {
            gameObject.SetActive(true);
            StartCoroutine("Die", duration);
        }

        IEnumerator Die(float amount)
        {
            yield return new WaitForSeconds(amount);
            gameObject.SetActive(false);
        }
    }
}