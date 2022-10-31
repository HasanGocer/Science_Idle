using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Buttons : MonoSingleton<Buttons>
{
    [SerializeField] private GameObject _GlobalGame;
    public Text moneyText;
    public Text ResearchPointText;

    [SerializeField] private Sprite _red, _green;
    [SerializeField] private Button _settingBackButton;
    [SerializeField] private Button _soundButton, _vibrationButton;
    [SerializeField] private Button _settingButton;
    [SerializeField] private GameObject _settingGame;

    public Button runnerAddedButton, bobinCountButton, moneyPlaneButton;
    public Text runnerAddedText, bobinCountText, moneyPlaneText;

    public Button tableAddedButton, StartBarButton, researchPlaneButton;
    public Text tableAddedText, StartBarText, researchPlaneText;




    private void Start()
    {
        if (GameManager.Instance.sound == 1)
        {
            _soundButton.gameObject.GetComponent<Image>().sprite = _green;
            //SoundSystem.Instance.MainMusicPlay();
        }
        else
        {
            _soundButton.gameObject.GetComponent<Image>().sprite = _red;
        }

        if (GameManager.Instance.vibration == 1)
        {
            _vibrationButton.gameObject.GetComponent<Image>().sprite = _green;
        }
        else
        {
            _vibrationButton.gameObject.GetComponent<Image>().sprite = _red;
        }
    }

    public void ButtonStart()
    {
        _soundButton.onClick.AddListener(SoundButton);
        _vibrationButton.onClick.AddListener(VibrationButton);
        _settingButton.onClick.AddListener(SettingButton);
        _settingBackButton.onClick.AddListener(SettingBackButton);
        runnerAddedButton.onClick.AddListener(AddedRunner);
        bobinCountButton.onClick.AddListener(BobinCount);
        tableAddedButton.onClick.AddListener(AddedTable);
        StartBarButton.onClick.AddListener(StartBar);
        researchPlaneButton.onClick.AddListener(ResearchPlaneButton);
        moneyPlaneButton.onClick.AddListener(MoneyPlaneButton);
    }

    public void TextStart()
    {
        moneyText.text = GameManager.Instance.money.ToString();
        ResearchPointText.text = GameManager.Instance.researchPoint.ToString();
        moneyPlaneText.text = ItemData.Instance.fieldPrice.moneyPlane.ToString();
        researchPlaneText.text = ItemData.Instance.fieldPrice.researchPlane.ToString();
        tableAddedText.text = ItemData.Instance.fieldPrice.tableCount.ToString();
        if (ItemData.Instance.field.tableCount == ItemData.Instance.maxFactor.tableCount)
        {
            tableAddedText.text = "Full";
            tableAddedButton.enabled = false;
            BuyPlane.Instance.tableCountMaxBool = true;
        }
        bobinCountText.text = ItemData.Instance.fieldPrice.bobinCount.ToString();
        if (ItemData.Instance.field.bobinCount == ItemData.Instance.maxFactor.bobinCount)
        {
            bobinCountText.text = "Full";
            bobinCountButton.enabled = false;
            BuyPlane.Instance.BobinCountMaxBool = true;
        }
        runnerAddedText.text = ItemData.Instance.fieldPrice.runnerCount.ToString();
        if (ItemData.Instance.field.bobinCount == ItemData.Instance.maxFactor.bobinCount)
        {
            runnerAddedText.text = "Full";
            runnerAddedButton.enabled = false;
            BuyPlane.Instance.runnerCountMaxBool = true;
        }
        StartBarText.text = "2";

        if (BuyPlane.Instance.runnerCountMaxBool && BuyPlane.Instance.BobinCountMaxBool)
        {
            Buttons.Instance.bobinCountButton.gameObject.SetActive(false);
            Buttons.Instance.runnerAddedButton.gameObject.SetActive(false);
            Buttons.Instance.moneyPlaneButton.gameObject.SetActive(true);
        }

        if (BuyPlane.Instance.tableCountMaxBool)
        {
            Buttons.Instance.tableAddedButton.gameObject.SetActive(false);
            Buttons.Instance.researchPlaneButton.gameObject.SetActive(true);
        }
    }

    private void SettingButton()
    {
        _settingGame.SetActive(true);
        _GlobalGame.SetActive(false);
    }

    private void SettingBackButton()
    {
        _settingGame.SetActive(false);
        _GlobalGame.SetActive(true);
    }

    private void SoundButton()
    {
        if (GameManager.Instance.sound == 1)
        {
            GameManager.Instance.sound = 0;
            _soundButton.gameObject.GetComponent<Image>().sprite = _red;
            SoundSystem.Instance.MainMusicStop();
            GameManager.Instance.SetSound();
        }
        else
        {
            GameManager.Instance.sound = 1;
            _soundButton.gameObject.GetComponent<Image>().sprite = _green;
            SoundSystem.Instance.MainMusicPlay();
            GameManager.Instance.SetSound();
        }
    }

    private void VibrationButton()
    {
        if (GameManager.Instance.vibration == 1)
        {
            GameManager.Instance.vibration = 0;
            _vibrationButton.gameObject.GetComponent<Image>().sprite = _red;
            GameManager.Instance.SetVibration();
        }
        else
        {
            GameManager.Instance.vibration = 1;
            _vibrationButton.gameObject.GetComponent<Image>().sprite = _green;
            GameManager.Instance.SetVibration();
        }
    }

    private void AddedRunner()
    {
        if (GameManager.Instance.money >= ItemData.Instance.fieldPrice.runnerCount && ItemData.Instance.factor.runnerCount <= ItemData.Instance.maxFactor.runnerCount)
        {
            GameManager.Instance.money -= ItemData.Instance.fieldPrice.runnerCount;
            GameManager.Instance.SetMoney();
            moneyText.text = GameManager.Instance.money.ToString();
            RunnerManager.Instance.NewStartRunner();
        }
    }

    private void BobinCount()
    {
        if (GameManager.Instance.money >= ItemData.Instance.fieldPrice.bobinCount && ItemData.Instance.factor.bobinCount <= ItemData.Instance.maxFactor.bobinCount)
        {
            GameManager.Instance.money -= (int)ItemData.Instance.fieldPrice.bobinCount;
            GameManager.Instance.SetMoney();
            moneyText.text = GameManager.Instance.money.ToString();
            BuyPlane.Instance.MoneyPlanes[BuyPlane.Instance.MoneyPlanes.Count - 1].GetComponent<BobinManager>().BobinBuy();
        }
    }

    private void AddedTable()
    {
        if (GameManager.Instance.researchPoint >= ItemData.Instance.fieldPrice.tableCount && ItemData.Instance.factor.tableCount <= ItemData.Instance.maxFactor.tableCount)
        {
            GameManager.Instance.researchPoint -= (int)ItemData.Instance.fieldPrice.tableCount;
            GameManager.Instance.SetResearchPoint();
            ResearchPointText.text = GameManager.Instance.researchPoint.ToString();

            BuyPlane.Instance.ResearchPlanes[BuyPlane.Instance.ResearchPlanes.Count - 1].GetComponent<TableBuy>().TableBuyWithButton();
        }
    }

    /*private void BarSpeedUpdate()
    {
        if (GameManager.Instance.researchPoint >= ItemData.Instance.fieldPrice.barSpeed && ItemData.Instance.factor.barSpeed <= ItemData.Instance.maxFactor.barSpeed && ItemData.Instance.field.barSpeed > ItemData.Instance.max.barSpeed)
        {
            GameManager.Instance.researchPoint -= (int)ItemData.Instance.fieldPrice.barSpeed;
            GameManager.Instance.SetResearchPoint();
            ItemData.Instance.factor.barSpeed++;
            ItemData.Instance.BarSpeed();
            GameManager.Instance.SetBarSpeed();
        }
    }*/

    private void StartBar()
    {
        if (GameManager.Instance.researchPoint >= 2)
        {
            StartCoroutine(StartBarAyEnum());
        }
    }

    private void MoneyPlaneButton()
    {
        BuyPlane.Instance.AddNewMoneyPlane();
    }

    private void ResearchPlaneButton()
    {
        BuyPlane.Instance.AddNewResearchPlane();
    }

    IEnumerator StartBarAyEnum()
    {
        Debug.Log("1");
        for (int i1 = 0; i1 < BuyPlane.Instance.ResearchPlanes.Count; i1++)
        {
            Debug.Log("1");
            if (i1 != BuyPlane.Instance.ResearchPlanes.Count - 1)
            {
                Debug.Log("1");
                for (int i2 = 0; i2 < BuyPlane.Instance.ResearchPlanes[0].GetComponent<TableBuy>().TableTemplateCount; i2++)
                {
                    Debug.Log("2");
                    TableBuy tableBuy = BuyPlane.Instance.ResearchPlanes[i1].GetComponent<TableBuy>();
                    Debug.Log("3");
                    if (!tableBuy.ActiveTablesBool[i2])
                    {
                        Debug.Log("4");
                        StartCoroutine(tableBuy.ActiveTables[i2].GetComponent<TableWork>().StartBar(i2));
                        Debug.Log("5");
                        tableBuy.ActiveTablesBool[i2] = true;
                        Debug.Log("6");
                        yield return new WaitForSeconds(0.1f);
                    }
                }
            }
            else
            {
                Debug.Log("7");
                int tableLimit;
                if (ItemData.Instance.field.tableCount % BuyPlane.Instance.ResearchPlanes[0].GetComponent<TableBuy>().TableTemplateCount != 0)
                {
                    Debug.Log("8");
                    tableLimit = ItemData.Instance.field.tableCount % BuyPlane.Instance.ResearchPlanes[0].GetComponent<TableBuy>().TableTemplateCount;
                }
                else
                {
                    Debug.Log("9");
                    tableLimit = BuyPlane.Instance.ResearchPlanes[0].GetComponent<TableBuy>().TableTemplateCount;
                }

                for (int i2 = 0; i2 < tableLimit; i2++)
                {
                    Debug.Log("10");
                    TableBuy tableBuy = BuyPlane.Instance.ResearchPlanes[i1].GetComponent<TableBuy>();
                    Debug.Log("11");
                    if (!tableBuy.ActiveTablesBool[i2])
                    {
                        Debug.Log("12");
                        StartCoroutine(tableBuy.ActiveTables[i2].GetComponent<TableWork>().StartBar(i2));
                        Debug.Log("13");
                        tableBuy.ActiveTablesBool[i2] = true;
                        Debug.Log("14");
                        yield return new WaitForSeconds(0.1f);
                    }
                }
            }

        }
    }
}
