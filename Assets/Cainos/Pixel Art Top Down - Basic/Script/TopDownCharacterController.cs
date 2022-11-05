using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;

        private Animator animator;
        private Vector2 movement;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }


        private void Update()
        {
            Vector2 dir = Vector2.zero;
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if (movement.x < 0)
            {
                dir.x = -1;
                animator.SetInteger("Direction", 3);
            }
            else if (movement.x > 0)
            {
                dir.x = 1;
                animator.SetInteger("Direction", 2);
            }

            if (movement.y > 0)
            {
                dir.y = 1;
                animator.SetInteger("Direction", 1);
            }
            else if (movement.y < 0)
            {
                dir.y = -1;
                animator.SetInteger("Direction", 0);
            }

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }
    }
}
