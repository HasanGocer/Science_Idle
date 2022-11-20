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
                    int randomMoney = GameManager.Instance.money / 100;
                    eventButtons[1].gameObject.transform.GetChild(0).GetComponent<Text>().text = "- " + randomMoney.ToString() + " Money";
                }
                else if (range < 15)
                {
                    eventPanel.SetActive(true);
                    eventText.text = eventStrings[1];
                    eventButtons[2].gameObject.SetActive(true);
                    int randomMoney = GameManager.Instance.money / 10;
                    eventButtons[2].gameObject.transform.GetChild(0).GetComponent<Text>().text = "- " + randomMoney.ToString() + " Money";
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
        eventPanel.SetActive(false);
        panelOpen = false;
        eventButtons[0].gameObject.SetActive(false);
    }

    private void EventPanelButton2()
    {
        int randomMoney = GameManager.Instance.money / 100;
        eventButtons[1].gameObject.SetActive(false);
        eventButtons[1].gameObject.transform.GetChild(0).GetComponent<Text>().text = "- " + randomMoney.ToString() + " Money";
        MoneySystem.Instance.MoneyTextRevork(randomMoney * -1);
        eventPanel.SetActive(false);
        panelOpen = false;
        eventButtons[1].gameObject.SetActive(false);
    }

    private void EventPanelButton3()
    {
        int randomMoney = GameManager.Instance.money / 10;
        eventButtons[1].gameObject.SetActive(false);
        eventButtons[1].gameObject.transform.GetChild(0).GetComponent<Text>().text = "+ " + randomMoney.ToString() + " Money";
        MoneySystem.Instance.MoneyTextRevork(randomMoney);
        eventPanel.SetActive(false);
        panelOpen = false;
        eventButtons[2].gameObject.SetActive(false);
    }
}
