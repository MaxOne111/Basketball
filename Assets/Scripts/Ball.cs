using System;
using System.Collections;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
    public class Ball : MonoBehaviour
    {
        private float _Grow_Speed = 3f;
        public Rigidbody Rigidbody { get; private set; }

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
        }

        private IEnumerator Grow()
        {
            Vector3 _max_Scale = new Vector3(0.25f, 0.25f, 0.25f);
            Vector3 _min_Scale = new Vector3(0.01f, 0.01f, 0.01f);

            transform.localScale = _min_Scale;
            
            while (transform.localScale != _max_Scale)
            {
                transform.localScale =
                    Vector3.Lerp(transform.localScale, _max_Scale, _Grow_Speed * Time.deltaTime);
                yield return null;
            }
        }

        public void StartGrow()
        {
            StartCoroutine(Grow());
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Basket"))
            {
                GameEvents.Hit();
            }

            if (other.CompareTag("BasketWall"))
            {
                GameEvents.Miss();
            }
        }
    }
