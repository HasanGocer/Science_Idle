using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventSystem : MonoSingleton<EventSystem>
{
    [SerializeField] private int _maxRandom›nteger;
    [SerializeField] private int evetWaitSecond;
    [SerializeField] private bool panelOpen;

    [SerializeField] private GameObject eventPanel;
    [SerializeField] private Text eventText;
    [SerializeField] private List<string> eventStrings = new List<string>();
    [SerializeField] private List<Button> eventButtons = new List<Button>();

    public void EventSystemStart()
    {
        StartButton();
        StartCoroutine(RandomEvenent(_maxRandom›nteger));
    }

    private void StartButton()
    {
        eventButtons[0].onClick.AddListener(EventPanelButton1);
        eventButtons[1].onClick.AddListener(EventPanelButton2);
        eventButtons[2].onClick.AddListener(EventPanelButton3);
        eventButtons[3].onClick.AddListener(EventPanelButton4);
        eventButtons[4].onClick.AddListener(EventPanelButton5);
        eventButtons[5].onClick.AddListener(EventPanelButton6);
        eventButtons[6].onClick.AddListener(EventPanelButton7);
        eventButtons[7].onClick.AddListener(EventPanelButton8);
        eventButtons[8].onClick.AddListener(EventPanelButton9);
        eventButtons[9].onClick.AddListener(EventPanelButton10);
    }

    public IEnumerator RandomEvenent(int maxRandom›nteger)
    {
        while (true)
        {
            if (!panelOpen)
            {
                int range = Random.Range(0, maxRandom›nteger);
                panelOpen = true;
                if (range < 5)
                {
                    eventPanel.SetActive(true);
                    eventText.text = eventStrings[0];
                    eventButtons[0].gameObject.SetActive(true);
                    int randomMoney = GameManager.Instance.money / 100;
                    eventButtons[0].gameObject.transform.GetChild(0).GetComponent<Text>().text = "+ " + randomMoney.ToString() + " Money";
                }
                else if (range < 10)
                {
                    eventPanel.SetActive(true);
                    eventText.text = eventStrings[1];
                    eventButtons[1].gameObject.SetActive(true);
                    int randomMoney = GameManager.Instance.money / 10;
                    eventButtons[1].gameObject.transform.GetChild(0).GetComponent<Text>().text = "- " + randomMoney.ToString() + " Money";
                }
                else if (range < 15)
                {
                    eventPanel.SetActive(true);
                    eventText.text = eventStrings[2];
                    eventButtons[2].gameObject.SetActive(true);
                    int randomMoney = GameManager.Instance.money / 100;
                    eventButtons[2].gameObject.transform.GetChild(0).GetComponent<Text>().text = "+ " + randomMoney.ToString() + " Money";
                }
                else if (range < 20)
                {
                    eventPanel.SetActive(true);
                    eventText.text = eventStrings[3];
                    eventButtons[3].gameObject.SetActive(true);
                    int randomMoney = GameManager.Instance.money / 10;
                    eventButtons[3].gameObject.transform.GetChild(0).GetComponent<Text>().text = "- " + randomMoney.ToString() + " Money";

                }
                else if (range < 25)
                {
                    eventPanel.SetActive(true);
                    eventText.text = eventStrings[4];
                    eventButtons[4].gameObject.SetActive(true);
                    int randomMoney = GameManager.Instance.money / 100;
                    eventButtons[4].gameObject.transform.GetChild(0).GetComponent<Text>().text = "- " + randomMoney.ToString() + " Money";
                }
                else if (range < 30)
                {
                    eventPanel.SetActive(true);
                    eventText.text = eventStrings[5];
                    eventButtons[5].gameObject.SetActive(true);
                    int randomMoney = GameManager.Instance.money / 10;
                    eventButtons[5].gameObject.transform.GetChild(0).GetComponent<Text>().text = "- " + randomMoney.ToString() + " Money";
                }
                else if (range < 35)
                {
                    eventPanel.SetActive(true);
                    eventText.text = eventStrings[6];
                    eventButtons[6].gameObject.SetActive(true);
                    int randomMoney = GameManager.Instance.money / 100;
                    eventButtons[6].gameObject.transform.GetChild(0).GetComponent<Text>().text = "+ " + randomMoney.ToString() + " Money";
                }
                else if (range < 40)
                {
                    eventPanel.SetActive(true);
                    eventText.text = eventStrings[7];
                    eventButtons[7].gameObject.SetActive(true);
                    int randomMoney = GameManager.Instance.money / 10;
                    eventButtons[7].gameObject.transform.GetChild(0).GetComponent<Text>().text = "+ " + randomMoney.ToString() + " Money";
                }
                else if (range < 45)
                {
                    eventPanel.SetActive(true);
                    eventText.text = eventStrings[8];
                    eventButtons[8].gameObject.SetActive(true);
                    int randomMoney = GameManager.Instance.money / 100;
                    eventButtons[8].gameObject.transform.GetChild(0).GetComponent<Text>().text = "+ " + randomMoney.ToString() + " Money";
                }
                else if (range < 50)
                {
                    eventPanel.SetActive(true);
                    eventText.text = eventStrings[9];
                    eventButtons[8].gameObject.SetActive(true);
                    int randomMoney = GameManager.Instance.money / 10;
                    eventButtons[8].gameObject.transform.GetChild(0).GetComponent<Text>().text = "+ " + randomMoney.ToString() + " Money";
                }
                else
                    panelOpen = false;

                yield return new WaitForSeconds(evetWaitSecond);
            }
            yield return null;
        }
    }

    private void EventPanelButton1()
    {
        int randomMoney = GameManager.Instance.money / 100;
        eventButtons[0].gameObject.SetActive(false);
        MoneySystem.Instance.MoneyTextRevork(randomMoney);
        LastFunc();
        eventButtons[0].gameObject.SetActive(false);
    }

    private void EventPanelButton2()
    {
        int randomMoney = GameManager.Instance.money / 10;
        eventButtons[1].gameObject.SetActive(false);
        MoneySystem.Instance.MoneyTextRevork(randomMoney * -1);
        LastFunc();
        eventButtons[1].gameObject.SetActive(false);
    }

    private void EventPanelButton3()
    {
        int randomMoney = GameManager.Instance.money / 100;
        eventButtons[2].gameObject.SetActive(false);
        MoneySystem.Instance.MoneyTextRevork(randomMoney);
        LastFunc();
        eventButtons[2].gameObject.SetActive(false);
    }

    private void EventPanelButton4()
    {
        int randomMoney = GameManager.Instance.money / 10;
        eventButtons[3].gameObject.SetActive(false);
        MoneySystem.Instance.MoneyTextRevork(randomMoney * -1);
        LastFunc();
        eventButtons[3].gameObject.SetActive(false);
    }

    private void EventPanelButton5()
    {
        int randomMoney = GameManager.Instance.money / 100;
        eventButtons[4].gameObject.SetActive(false);
        MoneySystem.Instance.MoneyTextRevork(randomMoney * -1);
        LastFunc();
        eventButtons[4].gameObject.SetActive(false);
    }

    private void EventPanelButton6()
    {
        int randomMoney = GameManager.Instance.money / 10;
        eventButtons[5].gameObject.SetActive(false);
        MoneySystem.Instance.MoneyTextRevork(randomMoney);
        LastFunc();
        eventButtons[5].gameObject.SetActive(false);
    }

    private void EventPanelButton7()
    {
        int randomMoney = GameManager.Instance.money / 100;
        eventButtons[6].gameObject.SetActive(false);
        MoneySystem.Instance.MoneyTextRevork(randomMoney * -1);
        LastFunc();
        eventButtons[6].gameObject.SetActive(false);
    }

    private void EventPanelButton8()
    {
        int randomMoney = GameManager.Instance.money / 10;
        eventButtons[7].gameObject.SetActive(false);
        MoneySystem.Instance.MoneyTextRevork(randomMoney);
        LastFunc();
        eventButtons[7].gameObject.SetActive(false);
    }

    private void EventPanelButton9()
    {
        int randomMoney = GameManager.Instance.money / 100;
        eventButtons[8].gameObject.SetActive(false);
        MoneySystem.Instance.MoneyTextRevork(randomMoney);
        LastFunc();
        eventButtons[8].gameObject.SetActive(false);
    }

    private void EventPanelButton10()
    {
        int randomMoney = GameManager.Instance.money / 10;
        eventButtons[8].gameObject.SetActive(false);
        MoneySystem.Instance.MoneyTextRevork(randomMoney);
        LastFunc();
        eventButtons[8].gameObject.SetActive(false);
    }

    private void LastFunc()
    {
        eventPanel.SetActive(false);
        panelOpen = false;
    }
}
