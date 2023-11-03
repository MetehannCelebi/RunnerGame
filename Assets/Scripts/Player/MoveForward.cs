using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
   [SerializeField] private float moveSpeed = 3f;

   private void Update()
   {
      transform.position+=Vector3.forward * (moveSpeed * Time.deltaTime);
   }
}
