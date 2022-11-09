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
    public Text counterPointText;

    [SerializeField] private Sprite _red, _green;
    [SerializeField] private Button _settingBackButton;
    [SerializeField] private Button _soundButton, _vibrationButton;
    [SerializeField] private Button _settingButton;
    [SerializeField] private GameObject _settingGame;

    public Button runnerAddedButton, bobinCountButton, moneyPlaneButton;
    public Text runnerAddedText, bobinCountText, moneyPlaneText;

    public Button tableAddedButton, StartBarButton, researchPlaneButton, auctionButton;
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
        auctionButton.onClick.AddListener(AuctionButton);
    }

    public void TextStart()
    {
        MoneySystem.Instance.MoneyTextRevork(0);
        MoneySystem.Instance.ResearchTextRevork(0);
        moneyPlaneText.text = ItemData.Instance.fieldPrice.moneyPlane.ToString();
        researchPlaneText.text = ItemData.Instance.fieldPrice.researchPlane.ToString();
        tableAddedText.text = ItemData.Instance.fieldPrice.tableCount.ToString();
        if (ItemData.Instance.field.tableCount % 6 == 0)
        {
            tableAddedText.text = "Full";
            tableAddedButton.enabled = false;
            BuyPlane.Instance.tableCountMaxBool = true;
        }
        bobinCountText.text = ItemData.Instance.fieldPrice.bobinCount.ToString();
        if (ItemData.Instance.field.bobinCount % MyDoPath.Instance.runnerCount == 0)
        {
            bobinCountText.text = "Full";
            bobinCountButton.enabled = false;
            BuyPlane.Instance.BobinCountMaxBool = true;
        }
        runnerAddedText.text = ItemData.Instance.fieldPrice.runnerCount.ToString();
        if (ItemData.Instance.field.bobinCount % MyDoPath.Instance.runnerCount == 0)
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
            MoneySystem.Instance.MoneyTextRevork((ItemData.Instance.fieldPrice.runnerCount * -1));
            RunnerManager.Instance.NewStartRunner();
        }
    }

    private void BobinCount()
    {
        if (GameManager.Instance.money >= ItemData.Instance.fieldPrice.bobinCount && ItemData.Instance.factor.bobinCount <= ItemData.Instance.maxFactor.bobinCount)
        {
            MoneySystem.Instance.MoneyTextRevork((ItemData.Instance.fieldPrice.bobinCount * -1));
            BuyPlane.Instance.MoneyPlanes[BuyPlane.Instance.MoneyPlanes.Count - 1].GetComponent<BobinManager>().BobinBuy();
        }
    }

    private void AddedTable()
    {
        if (GameManager.Instance.researchPoint >= ItemData.Instance.fieldPrice.tableCount && ItemData.Instance.factor.tableCount <= ItemData.Instance.maxFactor.tableCount)
        {
            MoneySystem.Instance.ResearchTextRevork((int)(ItemData.Instance.fieldPrice.tableCount * -1));
            BuyPlane.Instance.ResearchPlanes[BuyPlane.Instance.ResearchPlanes.Count - 1].GetComponent<TableBuy>().TableBuyWithButton();
        }
    }

    private void AuctionButton()
    {
        CounterSystem.Instance.CounterFinish();
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
        if (GameManager.Instance.money >= ItemData.Instance.fieldPrice.moneyPlane && ItemData.Instance.factor.moneyPlane <= ItemData.Instance.maxFactor.moneyPlane)
            BuyPlane.Instance.AddNewMoneyPlane();
    }

    private void ResearchPlaneButton()
    {
        if (GameManager.Instance.researchPoint >= ItemData.Instance.fieldPrice.researchPlane /*&& ItemData.Instance.field.researchPlane <= ItemData.Instance.maxFactor.researchPlane*/)
            BuyPlane.Instance.AddNewResearchPlane();
    }

    IEnumerator StartBarAyEnum()
    {
        int researchLimit = 0;

        if (PlaneHideSystem.Instance.researchHidePlaneCount > 0)
        {
            researchLimit = ItemData.Instance.field.researchPlane - PlaneHideSystem.Instance.planeLimit;
        }
        else
        {
            researchLimit = 0;
        }

        for (int i1 = researchLimit; i1 < ItemData.Instance.field.researchPlane; i1++)
        {
            if (i1 != ItemData.Instance.field.researchPlane - 1)
            {
                for (int i2 = 0; i2 < BuyPlane.Instance.ResearchPlanes[0].GetComponent<TableBuy>().TableTemplateCount; i2++)
                {
                    TableBuy tableBuy = BuyPlane.Instance.ResearchPlanes[i1].GetComponent<TableBuy>();
                    if (!tableBuy.ActiveTablesBool[i2])
                    {
                        StartCoroutine(tableBuy.ActiveTables[i2].GetComponent<TableWork>().StartBar(i2));
                        tableBuy.ActiveTablesBool[i2] = true;
                        yield return new WaitForSeconds(0.1f);
                    }
                }
            }
            else
            {
                int tableLimit = 0;

                if (ItemData.Instance.field.tableCount % BuyPlane.Instance.ResearchPlanes[i1].GetComponent<TableBuy>().TableTemplateCount != 0)
                {
                    tableLimit = ItemData.Instance.field.tableCount % BuyPlane.Instance.ResearchPlanes[i1].GetComponent<TableBuy>().TableTemplateCount;
                }
                else
                {
                    tableLimit = BuyPlane.Instance.ResearchPlanes[i1].GetComponent<TableBuy>().TableTemplateCount;
                }

                for (int i2 = 0; i2 < tableLimit; i2++)
                {
                    TableBuy tableBuy = BuyPlane.Instance.ResearchPlanes[i1].GetComponent<TableBuy>();
                    if (!tableBuy.ActiveTablesBool[i2])
                    {
                        tableBuy.ActiveTables[i2].GetComponent<TableWork>().hide = false;
                        StartCoroutine(tableBuy.ActiveTables[i2].GetComponent<TableWork>().StartBar(i2));
                        tableBuy.ActiveTablesBool[i2] = true;
                        yield return new WaitForSeconds(0.1f);
                    }
                }

            }
        }
    }
}

