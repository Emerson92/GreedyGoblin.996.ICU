using UnityEngine;
using System.Collections;
using System;

public class MoveJoystick : MonoBehaviour
{

    private bool isIdle = true;
    private Transform _transform;

    public static Vector3 ShotDirection;
    private CharacterController _characterController;
    private Animator _animation;
    public static bool isDeath = false;
    public static float Speed = 0.1f;

    //private GameObject _Spirt;
    //private Transform _SpirtTransform;

    //private Animator _AnimatorBloodeMale;

    public void Start()
    {
        _transform = this.GetComponent<Transform>();
        _animation = this.GetComponent<Animator>();
        _characterController = this.GetComponent<CharacterController>();
    }

    //当摇杆可用时注册事件
    void OnEnable()
    {
        EasyJoystick.On_JoystickMove += OnJoystickMove;
        EasyJoystick.On_JoystickMoveEnd += OnJoystickMoveEnd;
    }

    //当摇杆不可用时移除事件
    void OnDisable()
    {
        //EasyJoystick.On_JoystickMove -= OnJoystickMove;
        //EasyJoystick.On_JoystickMoveEnd -= OnJoystickMoveEnd;
    }

    //当摇杆销毁时移除事件
    void OnDestroy()
    {
        //EasyJoystick.On_JoystickMove -= OnJoystickMove;
        //EasyJoystick.On_JoystickMoveEnd -= OnJoystickMoveEnd;
    }

    //当摇杆处于停止状态时，角色进入待机状态
    void OnJoystickMoveEnd(MovingJoystick move)
    {
        if (PlayerController.isDeathing)
        {
            return;
        }
        if (move.joystickName == "playjoystick")
        {
            _animation.SetBool("GobinRun", false);
            isIdle = true;
        }
    }

    //当摇杆处于移动状态时，角色开始奔跑
    void OnJoystickMove(MovingJoystick move)
    {

        if (PlayerController.isDeathing ) {
            return;
        }
        if (move.joystickName != "playjoystick")
        {
            return;
        }
        //获取摇杆偏移量
        float joyPositionX = move.joystickAxis.x;
        float joyPositionY = move.joystickAxis.y;
        if (joyPositionY != 0 || joyPositionX != 0)
        {
            if (isIdle)
            {
                _animation.SetBool("GobinRun",true);
                isIdle = false;
            }
            //设置角色的朝向（朝向当前坐标+摇杆偏移量）
            Vector3 direction= new Vector3(transform.position.x + joyPositionX, transform.position.y, transform.position.z + joyPositionY);
            transform.LookAt(direction);
            //移动玩家的位置（按朝向位置移动）
            //transform.Translate(Vector3.Normalize(new Vector3(joyPositionX,0f, joyPositionY)) * Time.deltaTime * 8F);
            //播放奔跑动画
            //animation.CrossFade("Run");

            //float angle = move.Axis2Angle(true);
            //_transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
            //print(move.joystickValue.magnitude);
            //_transform.Translate(Vector3.forward * 8F * Time.deltaTime);
            ShotDirection = new Vector3(joyPositionX , 0f, joyPositionY);
            _transform.position += ShotDirection* Speed;
            //_characterController.Move(ShotDirection);
        }
    }

}
