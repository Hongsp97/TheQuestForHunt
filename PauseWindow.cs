using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Invector.vCharacterController;
using Invector.vMelee;
public class PauseWindow : MonoBehaviour
{
    public QuestManager questManager;

    public GameObject villagePauseBoard;
    public GameObject stage2PauseBoard;
    public vMeleeCombatInput meleeCombat;
    public vThirdPersonController meleeTpc;
    public vMeleeManager meleeManager;
    public GameObject[] villageHpButton;
    public GameObject[] villageSpButton;
    public GameObject[] villageFsButton;
    public GameObject[] stage2HpButton;
    public GameObject[] stage2SpButton;
    public GameObject[] stage2FsButton;

    public bool pauseisopen;
    public bool isStamina;
    public bool isOtherWindow;
    public bool isSpeed;

    void Start()
    {
        isSpeed = false;
        pauseisopen = false;
        isOtherWindow = false;
        meleeCombat = GetComponentInParent<vMeleeCombatInput>();
        meleeTpc = GetComponentInParent<vThirdPersonController>();
        meleeManager = GetComponentInParent<vMeleeManager>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!questManager.isOpen && !pauseisopen && !isOtherWindow)
            {
                OpenPauseBoard();
            }
            else
            {
                ClosePauseBoard();
            }
        }

        if (isStamina)
        {  
            meleeTpc.staminaRecovery = 500f;
            meleeTpc.jumpStamina = 0f;
            meleeTpc.sprintStamina = 0f;
            meleeTpc.rollStamina = 0f;
            meleeManager.defaultStaminaCost = 0f;
            if (meleeManager.rightWeapon != null && meleeManager.rightWeapon.meleeType != vMeleeType.OnlyDefense && meleeManager.rightWeapon.gameObject.activeInHierarchy)
            {
                meleeManager.rightWeapon.staminaRecoveryDelay = 0f;
            }
        }
        else
        {
            meleeTpc.staminaRecovery = 1.5f;
            meleeTpc.jumpStamina = 30f;
            meleeTpc.sprintStamina = 30f;
            meleeTpc.rollStamina = 25f;
            meleeManager.defaultStaminaCost = 20f;
            if (meleeManager.rightWeapon != null && meleeManager.rightWeapon.meleeType != vMeleeType.OnlyDefense && meleeManager.rightWeapon.gameObject.activeInHierarchy)
            {
                meleeManager.rightWeapon.staminaRecoveryDelay = 1f;
            }
        }

        if (isSpeed)
        {
            meleeTpc.freeSpeed.runningSpeed = 8;
            meleeTpc.freeSpeed.sprintSpeed = 10;
        }
        else if (!isSpeed)
        {
            meleeTpc.freeSpeed.runningSpeed = 4;
            meleeTpc.freeSpeed.sprintSpeed = 6;
        }     
    }

    public virtual void OpenPauseBoard()
    {
        if (pauseisopen)
        {
            return;
        }

        else if (!pauseisopen)
        {
            if (SceneManager.GetActiveScene().name == "Main")
            {
                return;
            }

            else if (SceneManager.GetActiveScene().name == "Village")
            {
                villagePauseBoard.SetActive(true);
                meleeCombat.ShowCursor(true);
                meleeCombat.LockCursor(true);
                meleeCombat.lockCameraInput = true;
                meleeCombat.lockInput = true;
                meleeCombat.lockMeleeInput = true;
                pauseisopen = true;

             

            }
            else if (SceneManager.GetActiveScene().name == "Stage 2")
            {
                stage2PauseBoard.SetActive(true);
                meleeCombat.ShowCursor(true);
                meleeCombat.LockCursor(true);
                meleeCombat.lockCameraInput = true;
                meleeCombat.lockInput = true;
                meleeCombat.lockMeleeInput = true;
                pauseisopen = true;


                
            }

        }
        Hpbutton();
        Spbutton();
        Fsbutton();
    }

    public virtual void ClosePauseBoard()
    {
        if (!pauseisopen)
        {
            return;
        }

        else if (pauseisopen)
        {
            if (SceneManager.GetActiveScene().name == "Main")
            {
                return;
            }

            else if (SceneManager.GetActiveScene().name == "Village")
            {
                villagePauseBoard.SetActive(false);
                meleeCombat.ShowCursor(false);
                meleeCombat.LockCursor(false);
                meleeCombat.lockCameraInput = false;
                meleeCombat.lockInput = false;
                meleeCombat.lockMeleeInput = false;
                pauseisopen = false;
            }
            else if (SceneManager.GetActiveScene().name == "Stage 2")
            {
                stage2PauseBoard.SetActive(false);
                meleeCombat.ShowCursor(false);
                meleeCombat.LockCursor(false);
                meleeCombat.lockCameraInput = false;
                meleeCombat.lockInput = false;
                meleeCombat.lockMeleeInput = false;
                pauseisopen = false;
            }
        }
    }

    void Hpbutton()
    {
        if (SceneManager.GetActiveScene().name == "Village")
        {
            if (meleeTpc.isImmortal)
            {
                villageHpButton[0].SetActive(false); // off
                villageHpButton[1].SetActive(true); // on
            }
            else if (!meleeTpc.isImmortal)
            {
                villageHpButton[0].SetActive(true);
                villageHpButton[1].SetActive(false);
            }
        }

        else if (SceneManager.GetActiveScene().name == "Stage 2")
        {
            if (meleeTpc.isImmortal)
            {
                stage2HpButton[0].SetActive(false);
                stage2HpButton[1].SetActive(true);
            }
            else if (!meleeTpc.isImmortal)
            {
                stage2HpButton[0].SetActive(true);
                stage2HpButton[1].SetActive(false);
            }
        }
    }

    void Spbutton()
    {
        if (pauseisopen && SceneManager.GetActiveScene().name == "Village")
        {
            if (isStamina)
            {
                villageSpButton[0].SetActive(false);
                villageSpButton[1].SetActive(true);
            }
            else if (!isStamina)
            {
                villageSpButton[0].SetActive(true);
                villageSpButton[1].SetActive(false);
            }
        }

        else if (pauseisopen && SceneManager.GetActiveScene().name == "Stage 2")
        {
            if (isStamina)
            {
                stage2SpButton[0].SetActive(false);
                stage2SpButton[1].SetActive(true);
            }
            else if (!isStamina)
            {
                stage2SpButton[0].SetActive(true);
                stage2SpButton[1].SetActive(false);
            }
        }
    }

    void Fsbutton()
    {
        if(pauseisopen && SceneManager.GetActiveScene().name == "Village")
        {
            if (isSpeed)
            {
                villageFsButton[0].SetActive(false);
                villageFsButton[1].SetActive(true);
            }
            else if (!isSpeed)
            {
                villageFsButton[0].SetActive(true);
                villageFsButton[1].SetActive(false);
            }
        }

        else if (pauseisopen && SceneManager.GetActiveScene().name == "Stage 2")
        {
            if (isSpeed)
            {
                stage2FsButton[0].SetActive(false);
                stage2FsButton[1].SetActive(true);
            }
            else if (!isSpeed)
            {
                stage2FsButton[0].SetActive(true);
                stage2FsButton[1].SetActive(false);
            }
        }
    }

    public void OnInfiniteHp()
    {
        if (!meleeTpc.isImmortal)
        {
            meleeTpc.isImmortal = true;
        }
        else
        {
            meleeTpc.isImmortal = false;
        }
    }

    public virtual void SetStaminaRecovery(int index)
    {
        if (index == 0)
        {
            isStamina = true;
        }
        else
        {
            isStamina = false;
        }
    }

    public virtual void SetSpeed(int index)
    {
        if (index == 0)
        {
            isSpeed = true;
        }
        else
        {
            isSpeed = false;
        }
    }
}
