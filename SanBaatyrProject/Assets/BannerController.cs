using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerController : MonoBehaviour
{
    public UnityEngine.Camera Camera;//Камера которая будет пускать лучи
    
    // Update is called once per frame
    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit2D aHit = new RaycastHit2D(); //инициализируем луч.
            if (Camera.orthographic)
            {
                // Присваиваем нашему лучу позицию мыши при клике .
                if (UnityEngine.Camera.main != null)
                    aHit = Physics2D.Raycast(UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition),
                        Vector2.zero);
            }
		   
            
            if(Input.GetMouseButtonDown(0) && aHit.transform.tag!="Obstacle")
            {//Если луч сталкивается с кубом а не с со стеной.
                gameObject.SetActive(false);

            }
			
        }
    }
}
