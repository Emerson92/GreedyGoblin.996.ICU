using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject Player;

    public GameObject WeaponShot;
    public GameObject GlodChest;
    public GameObject GlodSpeed;
    public GameObject GlodProtect;
    private Vector3 offset;
    private Vector3 moveDirection;
    private float MoveSpeed = 0.08f;
    private float nowTime = 0;
    private float produtTime = 2f;
    private enum WallPosition
    {
        North = 0,
        Sourth = 1,
        East = 2,
        West = 3
    };
    private Vector3 GlaivePosition;
    private float nextTime = 0;
    private Transform _GoldChestTransform;
    private Transform _GlodSpeedTransform;
    private Transform _GlodProtectTransform;
    private float monkeyTime =0;
    public GameObject MonkeyKing;
    private Quaternion faceDirection;
    private Vector3 MonkeyKingPosition;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - Player.transform.position;
        _GoldChestTransform  = GlodChest.GetComponent<Transform>();
        _GlodSpeedTransform  = GlodSpeed.GetComponent<Transform>();
        _GlodProtectTransform  = GlodProtect.GetComponent<Transform>();
    }

    public void Update()
    {
        if (nowTime > 3)
        {
            CreateChest();
            GetGoldSpeedChest();
            GetGoldProtectChest();
            nowTime = 0;
        }
        if (monkeyTime > Random.Range(5,8))
        {
            MonkeyKingSetPostion();
            GameObject MonkeyKingObject = Instantiate(MonkeyKing, MonkeyKingPosition, MonkeyKing.GetComponent<Transform>().rotation = faceDirection) as GameObject;
            setMonkeyKingToMove(MonkeyKingObject);
            monkeyTime = 0;
        }else{
            monkeyTime += Time.deltaTime;
        }
        if (nextTime > produtTime)
        {
            GlaiveSetPostion();
            GameObject glaive = Instantiate(WeaponShot, GlaivePosition, Quaternion.identity) as GameObject;
            setGlaiveToMove(glaive);
            nextTime = 0;

            if (produtTime > 0.08)
            {
                produtTime -= 0.03f;
                if (MoveSpeed > 4)
                {
                    return;
                }
                else
                {
                    MoveSpeed += 0.002f;
                }
                
            }
            else {
                produtTime = 0.08f;
            }
        }
        else {
            nowTime += Time.deltaTime;
            nextTime += Time.deltaTime;
        }

    }

    private void setMonkeyKingToMove(GameObject monkeyKingObject)
    {
        MonkeyMoveMent monkeyKingScript = monkeyKingObject.GetComponent<MonkeyMoveMent>();
        monkeyKingScript.MovingDirection = moveDirection * MoveSpeed;
        monkeyKingScript.isMoving = true;
    }

    private void MonkeyKingSetPostion()
    {
        switch ((int)Random.Range(0, 3))
        {
            case (int)WallPosition.North:
                MonkeyKingPosition = new Vector3(Random.Range(-9.02f, 9.204f), 0.5f, 8.77f);
                moveDirection = -Vector3.forward;
                faceDirection = Quaternion.AngleAxis(180,Vector3.up);
                break;
            case (int)WallPosition.Sourth:
                MonkeyKingPosition = new Vector3(Random.Range(-9.02f, 9.204f), 0.5f, -9.1f);
                moveDirection = Vector3.forward;
                faceDirection = Quaternion.AngleAxis(0, Vector3.up);
                break;
            case (int)WallPosition.East:
                MonkeyKingPosition = new Vector3(-9.02f, 0.5f, Random.Range(-9.1f, 8.77f));
                moveDirection = Vector3.right;
                faceDirection = Quaternion.AngleAxis(90, Vector3.up);
                break;
            case (int)WallPosition.West:
                MonkeyKingPosition = new Vector3(9.204f, 0.5f, Random.Range(-9.1f, 8.77f));
                moveDirection = -Vector3.right;
                faceDirection = Quaternion.AngleAxis(-90, Vector3.up);
                break;
        }
    }

    private void GetGoldProtectChest()
    {
        if (((int)Random.Range(0, 8)) == 1)
        {
            Instantiate(
                GlodProtect,
                new Vector3(
                     Random.Range(-9.3f, 9.4f),
                     0f,
                     Random.Range(-9.3f, 9.4f)
                ),
            _GlodProtectTransform.rotation
            );
        }
    }

    private void GetGoldSpeedChest()
    {
        if (((int)Random.Range(0, 5)) == 1)
        {
            Instantiate(
                GlodSpeed,
                new Vector3(
                     Random.Range(-9.3f, 9.4f),
                     0f,
                     Random.Range(-9.3f, 9.4f)
                ),
            _GlodSpeedTransform.rotation
            );
        }
    }

    private void setGlaiveToMove(GameObject glaive)
    {
        GlaiveMovement glScript = glaive.GetComponent<GlaiveMovement>();
        glScript.moveDirection = moveDirection * MoveSpeed;
        glScript.isMoving = true;
    }

    private void CreateChest()
    {
        Instantiate(
            GlodChest,
            new Vector3(
                Random.Range(-9.3f, 9.4f),
               0f,
                Random.Range(-9.3f, 9.4f)
                ),
            _GoldChestTransform.rotation
            );
    }

    /// <summary>
    /// 选择攻击物的出生位置
    /// </summary>
    void GlaiveSetPostion()
    {
        switch ((int)Random.Range(0, 3))
        {
            case (int)WallPosition.North:
                GlaivePosition = new Vector3(Random.Range(-9.02f, 9.204f), 0.5f, 8.77f);
                moveDirection = -Vector3.forward;
                break;
            case (int)WallPosition.Sourth:
                GlaivePosition = new Vector3(Random.Range(-9.02f, 9.204f), 0.5f, -9.1f);
                moveDirection = Vector3.forward;
                break;
            case (int)WallPosition.East:
                GlaivePosition = new Vector3(-9.02f, 0.5f, Random.Range(-9.1f, 8.77f));
                moveDirection = Vector3.right;
                break;
            case (int)WallPosition.West:
                GlaivePosition = new Vector3(9.204f, 0.5f, Random.Range(-9.1f, 8.77f));
                moveDirection = -Vector3.right;
                break;
        }

    }

    public void RestartSetting() {
        MoveSpeed = 0.08f;
        produtTime = 2f;
        nowTime = 0;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (Player != null ) {
         transform.position = Player.transform.position + offset;
        }
    }
}
