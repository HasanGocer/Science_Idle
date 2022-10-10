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

    [SerializeField] private Button goLeftButton;
    [SerializeField] private Button goRightButton;
    [SerializeField] private GameObject leftSideObject;
    [SerializeField] private GameObject rightSideObject;

    [SerializeField] private Button _rewardButton;
    public GameObject mainChestGame, chestChoseGame, openChestGame;
    [SerializeField] private Button _chest1Button, _chest2Button, _chest3Button;
    [SerializeField] private Image _chestImage1, _chestImage2;
    [SerializeField] private Text _chestMoney;
    [SerializeField] private Button _rewardLastButton;

    [SerializeField] private Button runnerAddedButton, runnerSpeedButton, researchUpperButton, bobinCountButton, mergeButton;
    [SerializeField] private Text runnerAddedText, runnerSpeedText, researchUpperText, bobinCountText, mergeText;
    [SerializeField] private GameObject _runnerPos;
    [SerializeField] private GameObject _leftGame;

    [SerializeField] private GameObject _rightGame;
    [SerializeField] private Button tableAddedButton, barSpeedButton, moneyUpperButton, StartBarButton;
    [SerializeField] private Text tableAddedText, barSpeedText, moneyUpperText, StartBarText;




    private void Start()
    {
        //GameStart.Instance.money += 9999;
        TextStart();

        ButtonStart();


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

    private void ButtonStart()
    {
        _soundButton.onClick.AddListener(SoundButton);
        _vibrationButton.onClick.AddListener(VibrationButton);
        _settingButton.onClick.AddListener(SettingButton);
        _settingBackButton.onClick.AddListener(SettingBackButton);
        goLeftButton.onClick.AddListener(GoLeftSide);
        goRightButton.onClick.AddListener(GoRightSide);
        runnerAddedButton.onClick.AddListener(AddedRunner);
        runnerSpeedButton.onClick.AddListener(RunnerSpeed);
        researchUpperButton.onClick.AddListener(ResearchUpper);
        bobinCountButton.onClick.AddListener(BobinCount);
        mergeButton.onClick.AddListener(Merge);
        tableAddedButton.onClick.AddListener(AddedTable);
        //barSpeedButton.onClick.AddListener(BarSpeedUpdate);
        moneyUpperButton.onClick.AddListener(MoneyUpper);
        StartBarButton.onClick.AddListener(StartBar);

        /*_rewardButton.onClick.AddListener(RewardOpen);
        _chest1Button.onClick.AddListener(OpenChest);
        _chest2Button.onClick.AddListener(OpenChest);
        _chest3Button.onClick.AddListener(OpenChest);
        _rewardLastButton.onClick.AddListener(RewardLastButton);*/

    }

    private void TextStart()
    {
        moneyText.text = GameManager.Instance.money.ToString();
        ResearchPointText.text = GameManager.Instance.researchPoint.ToString();
        researchUpperText.text = ItemData.Instance.fieldPrice.addedResearchPoint.ToString();
        tableAddedText.text = ItemData.Instance.fieldPrice.tableCount.ToString();
        mergeText.text = ItemData.Instance.fieldPrice.merge.ToString();
        moneyUpperText.text = ItemData.Instance.fieldPrice.addedMoney.ToString();
        bobinCountText.text = ItemData.Instance.fieldPrice.bobinCount.ToString();
        runnerSpeedText.text = ItemData.Instance.fieldPrice.runnerSpeed.ToString();
        runnerAddedText.text = ItemData.Instance.fieldPrice.runnerCount.ToString();
        StartBarText.text = TableBuy.Instance.barPrice.ToString();
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

    private void GoLeftSide()
    {
        if (!MoveCamera.Instance.move)
        {
            StartCoroutine(MoveCamera.Instance.DoMoveCamera(rightSideObject));
            goLeftButton.gameObject.SetActive(false);
            goRightButton.gameObject.SetActive(true);
            _leftGame.SetActive(true);
            _rightGame.SetActive(false);
        }
    }

    private void GoRightSide()
    {
        if (!MoveCamera.Instance.move)
        {
            StartCoroutine(MoveCamera.Instance.DoMoveCamera(leftSideObject));
            goLeftButton.gameObject.SetActive(true);
            goRightButton.gameObject.SetActive(false);
            _leftGame.SetActive(false);
            _rightGame.SetActive(true);
        }
    }

    private void AddedRunner()
    {
        if (GameManager.Instance.money >= ItemData.Instance.fieldPrice.runnerCount && ItemData.Instance.factor.runnerCount <= ItemData.Instance.maxFactor.runnerCount)
        {
            GameManager.Instance.money -= ItemData.Instance.fieldPrice.runnerCount;
            GameManager.Instance.SetMoney();
            moneyText.text = GameManager.Instance.money.ToString();
            ItemData.Instance.factor.runnerCount++;
            GameManager.Instance.SetRunnerCount();
            ItemData.Instance.RunnerCount();
            runnerAddedText.text = ItemData.Instance.fieldPrice.runnerCount.ToString();
            RunnerManager.Instance.NewStartRunner();
        }
    }

    private void RunnerSpeed()
    {
        if (GameManager.Instance.money >= ItemData.Instance.fieldPrice.runnerSpeed && ItemData.Instance.factor.runnerSpeed <= ItemData.Instance.maxFactor.runnerSpeed)
        {
            GameManager.Instance.money -= (int)ItemData.Instance.fieldPrice.runnerSpeed;
            GameManager.Instance.SetMoney();
            moneyText.text = GameManager.Instance.money.ToString();
            ItemData.Instance.factor.runnerSpeed++;
            GameManager.Instance.SetRunnerSpeed();
            ItemData.Instance.RunnerSpeed();
            runnerSpeedText.text = ItemData.Instance.fieldPrice.runnerSpeed.ToString();
            RunnerManager.Instance.SpeedUp();
        }
    }

    private void BobinCount()
    {
        if (GameManager.Instance.money >= ItemData.Instance.fieldPrice.bobinCount && ItemData.Instance.factor.bobinCount <= ItemData.Instance.maxFactor.bobinCount)
        {
            GameManager.Instance.money -= (int)ItemData.Instance.fieldPrice.bobinCount;
            GameManager.Instance.SetMoney();
            moneyText.text = GameManager.Instance.money.ToString();
            ItemData.Instance.factor.bobinCount++;
            GameManager.Instance.SetBobinCount();
            ItemData.Instance.BobinCount();
            BobinManager.Instance.bobins[ItemData.Instance.factor.bobinCount].SetActive(true);
            bobinCountText.text = ItemData.Instance.fieldPrice.bobinCount.ToString();
        }
    }

    private void MoneyUpper()
    {
        if (GameManager.Instance.researchPoint >= ItemData.Instance.fieldPrice.addedResearchPoint && ItemData.Instance.factor.addedResearchPoint <= ItemData.Instance.maxFactor.addedResearchPoint)
        {
            GameManager.Instance.researchPoint -= (int)ItemData.Instance.fieldPrice.addedResearchPoint;
            GameManager.Instance.SetResearchPoint();
            ResearchPointText.text = GameManager.Instance.researchPoint.ToString();
            ItemData.Instance.factor.addedResearchPoint++;
            //texti deðiþtir
            GameManager.Instance.SetAddedResearchPoint();
            ItemData.Instance.AddedResearchPoint();
            moneyUpperText.text = ItemData.Instance.fieldPrice.addedMoney.ToString();
        }
    }

    private void Merge()
    {
        if (GameManager.Instance.money >= ItemData.Instance.fieldPrice.merge && ItemData.Instance.factor.merge <= ItemData.Instance.maxFactor.merge)
        {
            GameManager.Instance.money -= (int)ItemData.Instance.fieldPrice.merge;
            moneyText.text = GameManager.Instance.money.ToString();
            ItemData.Instance.factor.merge++;
            //merge aktifleþtir
            GameManager.Instance.SetMerge();
            ItemData.Instance.Merge();
            GameManager.Instance.SetMoney();
            mergeText.text = ItemData.Instance.fieldPrice.merge.ToString();
        }
    }

    private void AddedTable()
    {
        if (GameManager.Instance.researchPoint >= ItemData.Instance.fieldPrice.tableCount && ItemData.Instance.factor.tableCount < ItemData.Instance.maxFactor.tableCount - 1)
        {
            GameManager.Instance.researchPoint -= (int)ItemData.Instance.fieldPrice.tableCount;
            GameManager.Instance.SetResearchPoint();
            ResearchPointText.text = GameManager.Instance.researchPoint.ToString();
            ItemData.Instance.factor.tableCount++;
            GameManager.Instance.SetTableCount();
            tableAddedText.text = ItemData.Instance.fieldPrice.tableCount.ToString();
            TableBuy.Instance.TableBuyWithButton();
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

    private void ResearchUpper()
    {
        if (GameManager.Instance.money >= ItemData.Instance.fieldPrice.addedMoney && ItemData.Instance.factor.addedMoney <= ItemData.Instance.maxFactor.addedMoney && ItemData.Instance.field.addedMoney < ItemData.Instance.max.addedMoney)
        {
            GameManager.Instance.money -= (int)ItemData.Instance.fieldPrice.addedMoney;
            GameManager.Instance.SetMoney();
            moneyText.text = GameManager.Instance.money.ToString();

            ItemData.Instance.factor.addedMoney++;
            GameManager.Instance.SetAddedMoney();
            ItemData.Instance.AddedMoney();
            researchUpperText.text = ItemData.Instance.fieldPrice.addedResearchPoint.ToString();
        }
    }

    private void StartBar()
    {
        if (GameManager.Instance.researchPoint >= TableBuy.Instance.barPrice)
        {
            for (int i = 0; i < TableBuy.Instance.ActiveTablesBool.Count; i++)
            {
                if (!TableBuy.Instance.ActiveTablesBool[i])
                {
                    StartCoroutine(TableBuy.Instance.ActiveTables[i].GetComponent<TableWork>().StartBar(i));
                    TableBuy.Instance.ActiveTablesBool[i] = true;
                }
            }
        }

    }

    private void OpenChest()
    {
        int count = Random.Range(0, 10);

        if (count % 2 == 0)
        {
            chestChoseGame.SetActive(false);
            openChestGame.SetActive(true);
            _chestImage1.gameObject.SetActive(true);
            count = Random.Range(50, 100);
            _chestMoney.text = "+ " + count;
            GameManager.Instance.money += count;
            GameManager.Instance.SetMoney();
        }
        else
        {
            chestChoseGame.SetActive(false);
            openChestGame.SetActive(true);
            _chestImage2.gameObject.SetActive(true);
            count = Random.Range(30, 60);
            _chestMoney.text = "+ " + count;
            GameManager.Instance.money += count;
            GameManager.Instance.SetMoney();
        }
    }

    private void RewardOpen()
    {
        mainChestGame.SetActive(true);
        chestChoseGame.SetActive(true);
    }

    private void RewardLastButton()
    {
        mainChestGame.SetActive(false);
        openChestGame.SetActive(false);
        chestChoseGame.SetActive(true);
    }
}
