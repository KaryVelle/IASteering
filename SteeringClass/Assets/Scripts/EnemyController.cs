using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   public Transform target;
   public Seek seek;
   public RunAway runaway;
   public bool _isSeek;

   private void Update()
   {
      if (_isSeek)
      {
         seek.Target = target.position;
      }
      else
      {
         runaway.Target = target.position;
      }
      
   }
}
