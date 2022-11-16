using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Invector.Utils;
using Invector.vItemManager;
public class NpcSystem : MonoBehaviour
{
    public RectTransform TradeUI;
    public Sprite[] Talksprites;
    public Sprite[] RandomtalkImage;
    public Image TradetalkImage;
    public int[] itemPrice;
    public int[] SellitemPrice;
    public Text PlayercoinText;
    public PlayerHasCoin playerCoin;
    public vItemManager PlayerItem;
    public vRemoveCurrentItem.Type type = vRemoveCurrentItem.Type.DestroyItem;
    public bool getItemByName;
    public string itemName;
    public int itemID;
    public QuestManager questManager;
    public GameObject[] CurrentTalkButton;


    bool itemFirstReroad;
    bool coinReroad;
    bool itemSecReroad;

    List<int> PlayerItems;
    public List<Button> ItemList;
    public Transform slotRoot;
    void Start()
    {
        itemFirstReroad = false;
        coinReroad = false;
        itemSecReroad = false;
        PlayerItems = new List<int>();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerHasCoin>())
        {
            playerCoin = other.gameObject.GetComponent<PlayerHasCoin>();
            PlayerItem = other.gameObject.GetComponent<vItemManager>();
            questManager = other.gameObject.GetComponentInChildren<QuestManager>();
        }

    }

    private void Update()
    {
        if (PlayercoinText.IsActive() && !coinReroad)
        {
            PlayercoinText.text = string.Format("{0:n0}", playerCoin.coin);
            coinReroad = true;
        }

        if (PlayercoinText.IsActive() && !itemSecReroad)
        {
            SetWeapon();

            itemSecReroad = true;
        }

        if (PlayerItem && !itemFirstReroad)
        {
            if (PlayerItem.items.Count == 0)
            {
                return;
            }
            AddItemList();
            itemFirstReroad = true;
        }
    }
    void AddItemList()
    {
        List<int> tempList = new List<int>();
        for (int i = 0; i < PlayerItem.items.Count; i++)
        {
            int temp = PlayerItem.items[i].id;
            tempList.Add(temp);
            Debug.Log(i + "번 : " + tempList[i]);
        }
        PlayerItems = tempList;
    }

    public void Buy(int index)
    {
        int price = itemPrice[index];

        if (price > playerCoin.coin)
        {
            return;
        }
        else if (price < playerCoin.coin && index == 0)
        {
            var reference = new ItemReference(1);
            reference.amount = 1;
            PlayerItem.CollectItem(reference, textDelay: 2f, ignoreItemAnimation: false);
            PlayerItems.Add(1);
            Debug.Log(PlayerItems[PlayerItems.Count - 1]);
        }

        else if (price < playerCoin.coin && index == 1)
        {
            var reference = new ItemReference(6);
            reference.amount = 1;
            PlayerItem.CollectItem(reference, textDelay: 2f, ignoreItemAnimation: false);
            PlayerItems.Add(6);

            Debug.Log(PlayerItems[PlayerItems.Count - 1]);
        }
        else if (price < playerCoin.coin && index == 2)
        {
            var reference = new ItemReference(4);
            reference.amount = 1;
            PlayerItem.CollectItem(reference, textDelay: 2f, ignoreItemAnimation: false);
            PlayerItems.Add(4);
            Debug.Log(PlayerItems[PlayerItems.Count - 1]);
        }
        else if (price < playerCoin.coin && index == 3)
        {
            var reference = new ItemReference(11);
            reference.amount = 1;
            PlayerItem.CollectItem(reference, textDelay: 2f, ignoreItemAnimation: false);
            PlayerItems.Add(11);
            Debug.Log(PlayerItems[PlayerItems.Count - 1]);
        }
        else if (price < playerCoin.coin && index == 4)
        {
            var reference = new ItemReference(2);
            reference.amount = 1;
            PlayerItem.CollectItem(reference, textDelay: 2f, ignoreItemAnimation: false);
            PlayerItems.Add(2);
            Debug.Log(PlayerItems[PlayerItems.Count - 1]);
        }

        Destroymyself();
        itemSecReroad = false;
        playerCoin.coin -= price;
        coinReroad = false;
    }
    public void Sell(int index)
    {
        int price = SellitemPrice[index];
        if (index == 0)
        {
            itemID = 1;
            RemoveItem(PlayerItem);
            PlayerItems.Remove(1);

        }
        else if (index == 1)
        {

            itemID = 6;
            RemoveItem(PlayerItem);
            PlayerItems.Remove(6);
        }
        else if (index == 2)
        {
            itemID = 4;
            RemoveItem(PlayerItem);
            PlayerItems.Remove(4);
        }
        else if (index == 3)
        {
            itemID = 11;
            RemoveItem(PlayerItem);
            PlayerItems.Remove(11);
        }

        playerCoin.coin += price;
        SetText();
    }
    public void RemoveItem(vItemManager itemManager)
    {
        if (PlayerItem)
        {
            var item = GetItem(itemManager);

            if (item != null)
            {
                if (type == vRemoveCurrentItem.Type.UnequipItem)
                {
                    PlayerItem.UnequipItem(item);
                }
                else if (type == vRemoveCurrentItem.Type.DestroyItem)
                {
                    PlayerItem.DestroyItem(item, 1);
                }
                else
                {
                    PlayerItem.DropItem(item, 1);
                }
            }
        }
    }
    vItem GetItem(vItemManager itemManager)
    {
        if (getItemByName)
        {
            // Check if you have an item via name (string) in your Inventory
            if (itemManager.ContainItem(itemName))
            {
                return itemManager.GetItem(itemName);
            }
        }
        else
        {
            // Check if you have an item via ID (integer) in your Inventory
            if (itemManager.ContainItem(itemID))
            {
                return itemManager.GetItem(itemID);
            }
        }

        return null;
    }

    public void SetText()
    {
        PlayercoinText.text = string.Format("{0:n0}", playerCoin.coin);
    }

    void SetWeapon()
    {

        for (int i = 0; i < PlayerItems.Count; i++)
        {
            switch (PlayerItems[i])
            {
                case 1:
                    Button weapon03 = Instantiate(ItemList[0], transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y - 60.527f, transform.rotation.z)) as Button;
                    weapon03.onClick.AddListener(delegate { Sell(0); });
                    weapon03.onClick.AddListener(Destroymyself);
                    weapon03.transform.SetParent(slotRoot.transform, false);
                    RectTransform rt03 = weapon03.gameObject.GetComponent<RectTransform>();
                    rt03.localRotation = Quaternion.Euler(0, 0, 0);
                    break;
                case 11:
                    Button Shield06 = Instantiate(ItemList[3], transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y - 60.527f, transform.rotation.z)) as Button;
                    Shield06.onClick.AddListener(delegate { Sell(3); });
                    Shield06.onClick.AddListener(Destroymyself);
                    Shield06.transform.SetParent(slotRoot.transform, false);
                    RectTransform rt06 = Shield06.gameObject.GetComponent<RectTransform>();
                    rt06.localRotation = Quaternion.Euler(0, 0, 0);
                    break;
                case 6:
                    Button weapon07 = Instantiate(ItemList[1], transform.position, transform.rotation) as Button;
                    weapon07.onClick.AddListener(delegate { Sell(1); });
                    weapon07.onClick.AddListener(Destroymyself);
                    weapon07.transform.SetParent(slotRoot.transform, false);
                    RectTransform rt07 = weapon07.gameObject.GetComponent<RectTransform>();
                    rt07.localRotation = Quaternion.Euler(0, 0, 0);
                    break;
                case 4:
                    Button weapon08 = Instantiate(ItemList[2], transform.position, transform.rotation) as Button;
                    weapon08.onClick.AddListener(delegate { Sell(2); });
                    weapon08.onClick.AddListener(Destroymyself);
                    weapon08.transform.SetParent(slotRoot.transform, false);
                    RectTransform rt08 = weapon08.gameObject.GetComponent<RectTransform>();
                    rt08.localRotation = Quaternion.Euler(0, 0, 0);
                    break;

            }
        }
    }


    public void Destroymyself()
    {
        if (slotRoot.childCount == null)
        {
            return;
        }
        else 
        {
            for (int i = 0; i < slotRoot.childCount; i++)
            {
                Destroy(slotRoot.GetChild(i).gameObject);
            }
        }

        itemSecReroad = false;
    }

    public void StartChat(int index)
    {
        Sprite select = Talksprites[index];
        TradetalkImage.sprite = select;
        itemFirstReroad = false;
    }

    public void StartChatandQuest1(int index) // BlackSmith
    {
        Sprite select = Talksprites[index];

        if (index == 1)
        {
            for (int i = 0; i < PlayerItem.items.Count; i++)
            {
                int temp = PlayerItem.items[i].id;
                if (questManager.questList.Contains(12) == true)
                {
                    select = Talksprites[9];
                    TradetalkImage.sprite = select;
                    CurrentTalkButton[3].SetActive(true);
                }
                else if (questManager.questList.Contains(10) == true)
                {
                    select = Talksprites[6];
                    TradetalkImage.sprite = select;
                    CurrentTalkButton[2].SetActive(true);
                }
                else if (questManager.questList.Contains(10) == false)
                {
                    select = Talksprites[1];
                    TradetalkImage.sprite = select;
                    CurrentTalkButton[1].SetActive(true);
                }

            }
        }
        TradetalkImage.sprite = select;
        itemFirstReroad = false;
    }

    public void StartChatandQuest2(int index) // Estate
    {
        Sprite select = Talksprites[index];

        if (index == 1)
        {
            for (int i = 0; i < PlayerItem.items.Count; i++)
            {
                int temp = PlayerItem.items[i].id;
                if (questManager.questList.Contains(13) == true)
                {
                    select = Talksprites[9];
                    TradetalkImage.sprite = select;
                    CurrentTalkButton[2].SetActive(true);
                }
                else if (questManager.questList.Contains(11) == true)
                {
                    select = Talksprites[4];
                    TradetalkImage.sprite = select;
                    CurrentTalkButton[1].SetActive(true);
                }
                else if (questManager.questList.Contains(11) == false)
                {
                    select = Talksprites[1];
                    TradetalkImage.sprite = select;
                    CurrentTalkButton[0].SetActive(true);
                }
            }
        }
        TradetalkImage.sprite = select;
        itemFirstReroad = false;
    }

    public void RandomTalk()
    {
        int index = Random.Range(0, RandomtalkImage.Length);
        Sprite select2 = RandomtalkImage[index];
        TradetalkImage.sprite = select2;

    }

    public void QuestAccept(int index)
    {
        if (index == 1)
        {
            if (questManager.questList.Contains(10))
            {
                return;
            }
            else
            {
                questManager.questList.Add(10);
            }
        }

        else if (index == 2)
        {
            if (questManager.questList.Contains(11))
            {
                return;
            }
            else
            {
                questManager.questList.Add(11);
            }
        }

    }

    public void QuestDeaccept(int index)
    {
        if (index == 1)
        {
            if (questManager.questList.Contains(10))
            {
                questManager.questList.Remove(10);
            }
            else
            {
                return;
            }
        }

        else if (index == 2)
        {
            if (questManager.questList.Contains(11))
            {
                questManager.questList.Remove(11);
            }
            else
            {
                return;
            }
        }

    }

    public void QuestCompleteCheck(int index)
    {
        if (index == 1) // 대장장이 퀘스트 완료 체크
        {
            for (int i = 0; i < PlayerItem.items.Count; i++)
            {
                int check = PlayerItem.items[i].id;
                if (check != 14)
                {
                    Sprite select = Talksprites[7];
                    TradetalkImage.sprite = select;
                }
                else if (check == 14)
                {
                    Sprite select = Talksprites[8];
                    TradetalkImage.sprite = select;
                    itemID = 14;
                    RemoveItem(PlayerItem);
                    questManager.questList.Remove(10);
                    playerCoin.coin += 500;
                    questManager.questList.Add(12);
                }
            }
            CurrentTalkButton[3].SetActive(true);
        }

        if (index == 2) // 보석 퀘스트 완료 체크 
        {
            for (int i = 0; i < PlayerItem.items.Count; i++)
            {
                int check = PlayerItem.items[i].id;
                if (check != 13)
                {
                    Sprite select = Talksprites[6];
                    TradetalkImage.sprite = select;
                }
                else if (check == 13)
                {
                    Sprite select = Talksprites[7];
                    TradetalkImage.sprite = select;
                    itemID = 13;
                    RemoveItem(PlayerItem);
                    questManager.questList.Remove(11);
                    playerCoin.coin += 500;
                    questManager.questList.Add(13);
                }
                CurrentTalkButton[2].SetActive(true);
            }
        }
    }

}









