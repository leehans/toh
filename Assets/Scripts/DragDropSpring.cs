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
     	spring.enabled = true;//I'm reactivating the SpringJoint2D component each time I'm clicking on my object becouse I'm disabling it after I'm releasing the mouse click so it will fly in the direction i was moving my mouse
     }
 
     void OnMouseDrag()        
     {
		if (spring.enabled) 
		{
			Vector2 cursorPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);//getting cursor position
			spring.connectedAnchor = cursorPosition;//the anchor get's cursor's position
		}
     }
     
     void OnMouseUp()        
     {
     	spring.enabled = false;//disabling the spring component
     }
 }