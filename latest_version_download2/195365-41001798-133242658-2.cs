     using UnityEngine;
     using System.Collections;
    
     public class NewBehaviourScript: MonoBehaviour {
         public GameObject objectA; //Needs to be initialized in the editor, or on Start
         public GameObject objectB; //Needs to be initialized in the editor, or on Start
         public float movementSpeed = 10;
         private Vector3 posA = Vector3.zero; //Vector3.zero is for initialization
         private Vector3 posB = Vector3.zero; //Vector3.zero is for initialization
    
         void Update() {
             if ( Input.GetMouseButtonDown(0)) {
                 posA = objectA.gameObject.transform.position;
                 posB = objectB.gameObject.transform.position;
                 objectA.gameObject.transform.position = posB;
                 objectB.gameObject.transform.position = posA;
             }
         }
     }
