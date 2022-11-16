using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Invector.vCharacterController;
using Invector;

public class Dragon : MonoBehaviour
{
    public vHealthController Health;
    public Transform target;

    public GameObject stalactite;
    public GameObject fireBall;
    public GameObject launcher;
    public vSimpleTrigger StartTrigger;
    public GameObject TrigerObjcect;
    public vFootStep step;
    public vTriggerChangeCameraState CameraChanger;

    bool _isRotate;
    bool _isMove;
    bool _isFlying;
    bool _isAlive;
    int atkStep;
    int rangeStack;
    int damageStack;

    NavMeshAgent nav;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        _isFlying = false;
    }
    void Start()
    {
        FreezeDragon();
        anim.Play("USleep Idle");
        InvokeRepeating("rangeStackReset", 30.0f, 30.0f);
        damageStack = 0;
        _isAlive = true;
    }

    void Update()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        if (_isAlive)
        {
            if (nav.isOnOffMeshLink && !_isFlying)
            {
                anim.Play("UJump Run");
                nav.speed = 5;
            }
            else if (_isMove)
            {
                if (_isFlying)
                {
                    nav.speed = 0;
                    nav.ResetPath();
                    _isFlying = false;
                }
                nav.speed = 1;
                MoveDragon();
            }
            AnimDragon();

            if (damageStack > 8)
            {
                reactionDragon();
            }
        }
    }

    void MoveDragon()
    {
        if ((target.position - transform.position).magnitude >= 7)
        {
            NavMeshPath path = new NavMeshPath();
            nav.CalculatePath(target.position, path);
            nav.SetPath(path);
        }

        if ((target.position - transform.position).magnitude < 7)
        {
            nav.ResetPath();
            if (_isRotate)
            {
                RotateDragon();
            }
        }
    }

    void RotateDragon()
    {
        Vector3 dir = target.position - transform.position;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.LookRotation(dir), 5 * Time.deltaTime);
    }

    void AnimDragon()
    {
        float speed = nav.desiredVelocity.magnitude;
        speed = Mathf.Clamp(speed, 0, 1);
        float animSpeed = Mathf.Abs(speed) > 0.1f ? speed : 0;
        var newInput = new Vector2(animSpeed, 0);
        var _input = Mathf.Clamp(newInput.magnitude, 0, 1f);
        anim.SetFloat("speed", _input, .2f, Time.deltaTime);
    }
    void DragonAtk()
    {
        if ((target.position - transform.position).magnitude < 7)
        {
            int temp1 = atkStep;
            while (temp1 == atkStep)
            {
                atkStep = Random.Range(0, 4);
            }
    
            switch (atkStep)
            {
                case 0:
                    Debug.Log("¹ßÅé");
                    anim.Play("UAttack Claws L");
                    break;
                case 1:
                    Debug.Log("À®");
                    anim.Play("UAttack Wings R");
                    break;
                case 2:
                    Debug.Log("²¿¸®");
                    anim.Play("UAttack Tail L");
                    break;
                case 3:
                    Debug.Log("¶¥ ³»·ÁÂö±â");
                    anim.Play("UAttack Stump");
                    break;
            }
        }
        if ((target.position - transform.position).magnitude >= 7)
        {
            if (rangeStack >= 3)
            {
                MoveDragon();
            }
            else
            {
                atkStep = Random.Range(0, 2);
                switch (atkStep)
                {
                    case 0:
                        anim.Play("UAttack FireBall");
                        break;
                    case 1:
                        anim.Play("UAttack Stump");
                        break;
                }
                rangeStack++;
                Debug.Log(rangeStack);
            }
        }
    }

    void rangeStackReset()
    {
        Debug.Log("½ÇÇà");
        rangeStack = 0;
    }
    void startDragonOn()
    {
        FreezeDragon();
        LockOn();
    }
    void startDragonOff()
    {
        unFreezeDragon();
        LockOff();
    }
    void FreezeDragon()
    {
        _isMove = false;
        _isRotate = false;
        nav.enabled = false;
        step.enabled = false;
    }

    void unFreezeDragon()
    {
        _isMove = true;
        _isRotate = true;
        nav.enabled = true;
        step.enabled = true;
    }

    public void Dragondie()
    {
        _isAlive = false;
        Health.healthRecovery = 0;
        FreezeDragon();
        anim.Play("UDeath Dramatic Left");
    }

    void Spawn_stalactite()
    {
        Vector3 playerPos = target.transform.position;
        float SpawnY = 20f;
        GameObject SpawnedObj = Instantiate(stalactite, new Vector3(playerPos.x, playerPos.y + SpawnY, playerPos.z), Quaternion.identity);
    }

    void launch_fireBall()
    {
        GameObject SpawnedObj = Instantiate(fireBall, launcher.transform.position, Quaternion.identity);
    }

    public void playerFind()
    {
        anim.SetTrigger("FindTrigger");
    }

    void reactionDragon()
    {
        int temp = Random.Range(0, 1);
        if (temp == 1)
        {
            anim.Play("UGetHit Front Left 1");
        }
        else
        {
            anim.Play("UGetHit Front Right 1");
        }
        damageStack = 0;
    }

    public void destroyGem()
    {
        Health.healthRecovery-=8;
    }

    public void lowSpeed()
    {
        nav.speed = 1;
    }

    public void MoveDragonA()
    {
        nav.CompleteOffMeshLink();
        nav.enabled = false;
        nav.enabled = true;
        nav.speed = 0;
        nav.ResetPath();
    }

    public void OnDamage()
    {
        if (_isAlive)
        {
            damageStack++;
        }
    }

    public void LockOn()
    {
        Debug.Log("Dragon.LockOn()");
        StartTrigger.playerLockOn();
        
    }

    public void LockOff()
    {
        Debug.Log("Dragon.LockOff()");
        StartTrigger.playerLockOff();
    }
}
