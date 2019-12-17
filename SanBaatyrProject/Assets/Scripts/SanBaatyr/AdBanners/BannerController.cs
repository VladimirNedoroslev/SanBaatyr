using UnityEngine;

namespace Prefabs.AdBanner
{
    public class BannerController : MonoBehaviour
    {
        public Camera Camera;//Камера которая будет пускать лучи
    
        //TODO: Refactor AdBanner
        void Update ()
        {
            if (Input.GetMouseButtonDown(0))
            {

                RaycastHit2D aHit = new RaycastHit2D(); //инициализируем луч.
                if (Camera.orthographic)
                {
                    // Присваиваем нашему лучу позицию мыши при клике .
                    if (Camera.main != null)
                        aHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),
                            Vector2.zero);
                }
		   
            
                if(Input.GetMouseButtonDown(0) && aHit.transform.tag!="Obstacle")
                {//Если луч сталкивается с кубом а не с со стеной.
                    gameObject.SetActive(false);

                }
			
            }
        }
    }
}
