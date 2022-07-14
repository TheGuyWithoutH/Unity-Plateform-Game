using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float speed = 2f;
    
    // Update is called once per frame
    void Update()
    {
        
        if (_player.position.y > 4f)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(_player.position.x, _player.position.y, transform.position.z) , Time.deltaTime * speed);
        }
        else
        {
            transform.position =Vector3.MoveTowards(transform.position, new Vector3(_player.position.x, 0.57f, transform.position.z), Time.deltaTime * speed);
        }
        
    }
}
