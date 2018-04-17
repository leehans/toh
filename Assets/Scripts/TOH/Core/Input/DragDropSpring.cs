using UnityEngine;
using UnityEngine.Events;
using System.Collections;
 
 namespace TOH.Core
 {
    // Simple drag drop controls used in conjunction with a SpringJoint2D component
    // Based on: https://answers.unity.com/questions/618546/how-to-drag-and-throw-2d-objects.html
    public class DragDropSpring : MonoBehaviour 
    {
        [SerializeField]
        private SpringJoint2D spring;

        public UnityEvent onInputDown;
        public UnityEvent onInputUp;
    
        void Awake()
        {
            spring.connectedAnchor = transform.position;
            spring.enabled = false;
        }
    
        void OnMouseDown()
        {
            spring.enabled = true;
            SetConnectedAnchor(Camera.main.ScreenToWorldPoint (Input.mousePosition));
            if (onInputDown != null)
                onInputDown.Invoke();
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
            if (onInputUp != null)
                onInputUp.Invoke();
        }

        public void Disable()
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
 }