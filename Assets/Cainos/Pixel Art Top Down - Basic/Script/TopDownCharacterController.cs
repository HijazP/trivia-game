using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class TopDownCharacterController : MonoBehaviour
    {
        public static TopDownCharacterController instance;

        public float speed;
        private Animator animator;
        private Vector2 movement;
        private Vector2 dir;
        private bool touchStart = false;
        private Vector2 pointA;
        private Vector2 pointB;
        private Vector2 offset;
        private Vector2 direction;
        private bool moving = true;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            dir = Vector2.zero;
            if (moving)
            {
                movement.x = Input.GetAxisRaw("Horizontal");
                movement.y = Input.GetAxisRaw("Vertical");
            }

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

            if (Input.GetMouseButtonDown(0))
            {
                pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            }

            if (Input.GetMouseButton(0))
            {
                touchStart = true;
                pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            }
            else
            {
                touchStart = false;
                animator.SetBool("IsMoving", false);
            }

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);

            if (touchStart)
            {
                offset = pointB - pointA;
                direction = Vector2.ClampMagnitude(offset, 1f);

                animator.SetBool("IsMoving", true);

                if (offset.x < 0)
                {
                    animator.SetInteger("Direction", 3);
                }
                else if (offset.x > 0)
                {
                    animator.SetInteger("Direction", 2);
                }
                else if (offset.y > 0)
                {
                    animator.SetInteger("Direction", 1);
                }
                else if (offset.y < 0)
                {
                    animator.SetInteger("Direction", 0);
                }
            }
        }

        private void FixedUpdate()
        {
            GetComponent<Rigidbody2D>().velocity = speed * dir;

            if (touchStart)
            {
                MoveCharacter(direction * 1);
            }
        }

        public void ChangeStatus()
        {
            moving = false;
            speed = 0;
            animator.SetBool("IsMoving", dir.magnitude > 0);
        }

        public void ChangeStatusOn()
        {
            moving = true;
            speed = 3;
        }

        void MoveCharacter(Vector2 direction)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
