using System;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class MovingObject : MonoBehaviour
    {
        protected bool isActive;

        protected void Start()
        {
            isActive = true;
        }

        public void Pause()
        {
            isActive = false;
        }

        public void Resume()
        {
            isActive = true;
        }
    }
}