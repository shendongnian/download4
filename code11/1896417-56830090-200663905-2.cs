    using UnityEngine;
    public class GetRaycast : MonoBehaviour
    {
        Camera camera;
    
        public Transform Player;
    
        // Start is called before the first frame update
        private void Start()
        {
            camera = Camera.main;
        }
    
        // Update is called once per frame
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out var hit))
                {
                    Player.position = hit.point + Vector3.up * 0.1f;
                }
            }
        }
    }
