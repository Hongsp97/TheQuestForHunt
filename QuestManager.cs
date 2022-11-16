using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Invector.vCharacterController;

public class QuestManager : MonoBehaviour
{
    public GameObject questBoard;
    public List<Button> questButton;
    public vMeleeCombatInput MeleeCombat;
    public Transform questRoot;
    public Transform questInforImage;
    public Transform questRewardImage;
    public List<int> questList;
    public bool isOpen;
    public bool isStop;
    public GameObject[] questInfor;
    public GameObject[] questReward;
    void Start()
    {
        MeleeCombat = GetComponentInParent<vMeleeCombatInput>();
        List<int> questList = new List<int>();
       // GameObject questboard = transform.GetChild(0).gameObject;
        isOpen = false;
        isStop = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (!isOpen)
            {
                OpenQuestboard();

            }
            else
            {
                CloseQuestboard();

            }
        }

        if (isOpen && isStop)
        {
            SetQuestButton();
            isStop = false;
        }

    }


    public virtual void OpenQuestboard()
    {
        if (isOpen)
        {
            return;
        }
        questBoard.SetActive(true);
        MeleeCombat.ShowCursor(true);
        MeleeCombat.LockCursor(true);
        MeleeCombat.lockCameraInput = true;
        MeleeCombat.lockInput = true;
        MeleeCombat.lockMeleeInput = true;
        isOpen = true;
        isStop = true;
    }

    public virtual void CloseQuestboard()
    {
        if (!isOpen)
        {
            return;
        }
        questBoard.SetActive(false);
        MeleeCombat.ShowCursor(false);
        MeleeCombat.LockCursor(false);
        MeleeCombat.lockCameraInput = false;
        MeleeCombat.lockInput = false;
        MeleeCombat.lockMeleeInput = false;
        isOpen = false;
        DestroyQuestList();
        QuestImageDestroy();
    }


    public void DestroyQuestList()
    {
        if (questRoot.childCount != null)
        {
            for (int i = 0; i < questRoot.childCount; i++)
            {
                Destroy(questRoot.GetChild(i).gameObject);
            }
        }
    }
    
    public void QuestImageDestroy()
    {
        if (questInforImage.childCount != null)
        {
            for (int i = 0; i < questInforImage.childCount; i++)
            {
                Destroy(questInforImage.GetChild(i).gameObject);
            }
        }

        if (questRewardImage.childCount != null)
        {
            for (int i = 0; i < questRewardImage.childCount; i++)
            {
                Destroy(questRewardImage.GetChild(i).gameObject);
            }
        }
    }
    public void QuestImageChange(int index)
    {
        QuestImageDestroy();

        if (index == 0)
        {
            GameObject Infor1 = Instantiate(questInfor[0], transform.position, transform.rotation) as GameObject;
            Infor1.transform.SetParent(questInforImage.transform, false);
            RectTransform Ifrt1 = Infor1.gameObject.GetComponent<RectTransform>();
            Ifrt1.localRotation = Quaternion.Euler(0, 0, 0);

            GameObject Reward1 = Instantiate(questReward[0], transform.position, transform.rotation) as GameObject;
            Reward1.transform.SetParent(questRewardImage.transform, false);
            RectTransform Rwrt1 = Reward1.gameObject.GetComponent<RectTransform>();
            Rwrt1.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if (index == 1)
        {
            GameObject Infor2 = Instantiate(questInfor[1], transform.position, transform.rotation) as GameObject;
            Infor2.transform.SetParent(questInforImage.transform, false);
            RectTransform Ifrt2 = Infor2.gameObject.GetComponent<RectTransform>();
            Ifrt2.localRotation = Quaternion.Euler(0, 0, 0);

            GameObject Reward2 = Instantiate(questReward[1], transform.position, transform.rotation) as GameObject;
            Reward2.transform.SetParent(questRewardImage.transform, false);
            RectTransform Rwrt2 = Reward2.gameObject.GetComponent<RectTransform>();
            Rwrt2.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
  

    public void SetQuestButton()
    {
        for (int i = 0; i < questList.Count; i++)
        {
            switch (questList[i])
            {
                case 10:
                    Quaternion quaternion = Quaternion.Euler(0, 0, 0);
                    Button quest00 = Instantiate(questButton[0], transform.position, quaternion) as Button;
                    quest00.transform.SetParent(questRoot.transform, false);
                    RectTransform rt10 = quest00.gameObject.GetComponent<RectTransform>();
                    rt10.localRotation = Quaternion.Euler(0, 0, 0);
                    quest00.onClick.AddListener(delegate { QuestImageChange(0); });
                    break;
                case 11:
                    Quaternion quaternion2 = Quaternion.Euler(0, 0, 0);
                    Button quest01 = Instantiate(questButton[1], transform.position, transform.rotation) as Button;
                    quest01.transform.SetParent(questRoot.transform, false);
                    RectTransform rt11 = quest01.gameObject.GetComponent<RectTransform>();
                    rt11.localRotation = Quaternion.Euler(0, 0, 0);
                    quest01.onClick.AddListener(delegate { QuestImageChange(1); });
                    break;
            }
        }

    }
}
