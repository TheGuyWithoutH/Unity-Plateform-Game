using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class StickyPlatform : MonoBehaviour
    {

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.name.Equals("Player"))
            {
                other.gameObject.transform.SetParent(null);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.name.Equals("Player"))
            {
                other.gameObject.transform.SetParent(transform);
            }
        }
    }
}