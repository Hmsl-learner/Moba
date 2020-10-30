using UnityEngine;
using System.Collections;

public enum AnimState
{
    Idle,
    Run,
    Attack1,
    Attack2,
    Dance

}
public class MoveController : MonoBehaviour {

    private Animator animator;
    private float timer = 0;    // 计算摇杆在中心停留的时间
    public float holdtimer = 0.5f;    // 判定摇杆停下时间阈值
    bool JoystickEnd = false;   // 摇杆过中心没有
    public bool statelocked = false;    // 状态是否锁定 锁定状态下不相应摇杆的任何操作
    public bool isMoving = false;   // 正在移动

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        EasyJoystick.On_JoystickMove += OnJoystickMove;
        EasyJoystick.On_JoystickMoveEnd += OnJoystickMoveEnd;
        EasyJoystick.On_JoystickTouchUp += OnJoystickTouchUp;
    }

    void OnDisable()
    {
        EasyJoystick.On_JoystickMove -= OnJoystickMove;
        EasyJoystick.On_JoystickMoveEnd -= OnJoystickMoveEnd;
        EasyJoystick.On_JoystickTouchUp -= OnJoystickTouchUp;
    }

    void OnDestroy()
    {
        EasyJoystick.On_JoystickMove -= OnJoystickMove;
        EasyJoystick.On_JoystickMoveEnd -= OnJoystickMoveEnd;
        EasyJoystick.On_JoystickTouchUp -= OnJoystickTouchUp;
    }

    private void Update()
    {
        // 如果摇杆经过中心就开始计时
        if (JoystickEnd && !statelocked)
        {
            timer += Time.deltaTime;
            // 如果在中心停留超过0.1s判定角色停下
            if (timer >= holdtimer)
            {
                animator.SetInteger("state", (int)AnimState.Idle);
                // 停下状态直切换一次，不影响后续状态
                JoystickEnd = false;
                isMoving = false;
            }
        }
        
    }
    // 摇杆到中心
    void OnJoystickMoveEnd(MovingJoystick move)
    {
        if (statelocked) return;
        if (move.joystickName == "EasyJoystick")
        {
            JoystickEnd = true; // 异步实现摇杆过中心的状态过度
        }
    }
    // 摇杆不在中心
    void OnJoystickMove(MovingJoystick move)
    {
        if (statelocked) return;
        if (move.joystickName != "EasyJoystick")
        {
            return;
        }
        // 每次摇杆从中心位置移走重新开始判断摇杆状态
        JoystickEnd = false;
        // 重置判定时间
        timer = 0;

        float joyPositionX = move.joystickAxis.x;
        float joyPositionY = move.joystickAxis.y;

        if (joyPositionY != 0 || joyPositionX != 0)
        {
            //设置角色的朝向（朝向当前坐标+摇杆偏移量）
           transform.LookAt(new Vector3(transform.position.x + joyPositionX, transform.position.y, transform.position.z + joyPositionY));
            //移动玩家的位置（按朝向位置移动）
            transform.Translate(Vector3.forward * Time.deltaTime * 5);
            //播放奔跑动画
            animator.SetInteger("state", (int)AnimState.Run);
            isMoving = true;
        }
    }
    // 松开摇杆
    void OnJoystickTouchUp(MovingJoystick move)
    {
        if (statelocked) return;
        if (move.joystickName != "EasyJoystick")
        {
            return;
        }
        animator.SetInteger("state", (int)AnimState.Idle);
        isMoving = false;
    }


    #region 碰撞检测
    /* 碰到障碍物后关闭动力学模式，进行刚体碰撞；
     * 碰撞结束后开启动力学模式，进行正常操控*/
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }
    } 
    #endregion
}
