using UnityEngine;

public class Lava : MonoBehaviour
{
    public float _speed;
    public float _accel;
    public float _maxSpeed;

    private void Update()
    {
        if(_speed < _maxSpeed) _speed += _accel * Time.deltaTime;
        this.transform.position = new Vector3(0, transform.position.y + _speed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            GameManager.KillPlayer();
            GameManager.instance.FinishGame();
        }
    }
}
