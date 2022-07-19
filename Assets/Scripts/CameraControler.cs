using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runer24
{
    public class CameraControler : MonoBehaviour
    {
        [SerializeField] private Transform player;
        private Vector3 offset;
        private Animator anim;

        void Start()
        {
            offset = transform.position - player.position;

        }

        void FixedUpdate()
        {
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + player.position.z);
            transform.position = newPosition;
        }
 
    }
}