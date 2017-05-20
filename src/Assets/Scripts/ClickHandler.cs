using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace AdventureJam
{
    public class ClickHandler : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _onClick;

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                RaycastHit hitInfo;
                var mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(mouseRay, out hitInfo) && hitInfo.transform.gameObject == gameObject)
                {
                    _onClick.Invoke();
                }
            }
        }
    }
}
