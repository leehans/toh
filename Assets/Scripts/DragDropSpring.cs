/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Modified version of https://answers.unity.com/questions/618546/how-to-drag-and-throw-2d-objects.html  *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using UnityEngine;
using System.Collections;
 
 public class DragDropSpring : MonoBehaviour 
 {
     [SerializeField]
     private SpringJoint2D spring;
 
     void Awake()
     {
    	spring.connectedAnchor = transform.position;//i want the anchor position to start at the object's position
		spring.enabled = false;
     }
 
     void OnMouseDown()
     {
     	spring.enabled = true;
        SetConnectedAnchor(Camera.main.ScreenToWorldPoint (Input.mousePosition));
     }
 
     void OnMouseDrag()        
     {
		if (spring.enabled) 
		{
			SetConnectedAnchor(Camera.main.ScreenToWorldPoint (Input.mousePosition));
		}
     }
     
     void OnMouseUp()        
     {
     	spring.enabled = false;
     }

     #region Helpers
     private void SetConnectedAnchor(Vector2 pos)
     {
         spring.connectedAnchor = pos;
     }
     #endregion // Helpers
 }