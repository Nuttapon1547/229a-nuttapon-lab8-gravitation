using System;
using System.Collections.Generic;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
   private Rigidbody rb;
   private const float G = 0.006674f;

   public static List<Gravity> planetslist;
   private void Awake()
   {
      rb = GetComponent<Rigidbody>();
      if (planetslist == null)
      {
         planetslist = new List<Gravity>();
      }
      
      planetslist.Add(this);
   }

   private void FixedUpdate()
   {
      foreach (var planet in planetslist)
      {
         if (planet != this)
         {
            Attract(planet);
         }
         
      }
   }

   void Attract(Gravity other)
   { 
      Rigidbody otherRb = other.rb;
      Vector3 direction = rb.position - otherRb.position;
      //get distance in meter
      float distance = direction.magnitude; // magnitude เอาแค่ระยะทางจาก Rigibody (ไม่เอาทิศ)
      
      //calculate gravity
      float forceMagnitude = G * (rb.mass * otherRb.mass) / Mathf.Pow(distance, 2);
      Vector3 finalForce = forceMagnitude * direction.normalized;
      otherRb.AddForce(finalForce);
   }
}
