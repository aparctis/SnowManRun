using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnowManRun
{
    public class Smoke : MonoBehaviour
    {
        [SerializeField]private float timer = 3f;



        void Update()
        {
            timer -= Time.deltaTime;
            if (timer<= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
