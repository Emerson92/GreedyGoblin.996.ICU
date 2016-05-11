using UnityEngine;
using System.Collections;

public class MonkeyMoveMent : MonoBehaviour
{


    public bool isMoving = true;

    public Vector3 MovingDirection;
    private Transform _transform;
    private AudioSource[] _AudioSource;
    public GameObject player;
    private PlayerController _playerScript;

    // Use this for initialization
    void Start()
    {
        _transform = this.GetComponent<Transform>();
        _AudioSource  =  this.GetComponents<AudioSource>();
        _playerScript = player.GetComponent<PlayerController>();
        //Destroy(this.gameObject,10f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMoving)
        {
            _transform.position += MovingDirection;
        }
    }

    public void OnTriggerEnter(Collider other)
    {

        print(other.tag);
        if (other.tag.Equals("Player")) {
            if (PlayerController.isDeathing)
            {
                return;
            }
            isMoving = false;
            _AudioSource[1].Play();
        }
        if (other.tag.Equals("goldchest") || other.tag.Equals("goldspeedchest") || other.tag.Equals("golddragon")) {
            _AudioSource[0].Play();
            Destroy(other.gameObject);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerStay(Collider other)
    {
        /**
         如何处理当人物死亡后，猴子继续移动的问题方向是当前面朝方向？
        **/
        if (other.tag.Equals("Player")) {
            if (PlayerController.isDeathing)
            {
                isMoving = true;
                return;
            }
            _transform.LookAt(other.transform.position);
            _transform.position = Vector3.MoveTowards(_transform.position, other.transform.position,Time.deltaTime*3f);
            if (!PlayerController.isDeathing) {
                if (other.gameObject.transform.position == _transform.position)
                {
                    PlayerController.count = 0;
                    _playerScript.setCountext();
                }
            }
        }

    }

    public void OnTriggerExit(Collider other)
    {

        if (other.tag.Equals("Player")) {
            if (PlayerController.isDeathing)
            {
                return;
            }
            isMoving = true;
            MovingDirection = Vector3.Normalize(other.transform.position - _transform.position)*0.08f;
            _transform.LookAt(other.transform.position);
        }
    }
}
