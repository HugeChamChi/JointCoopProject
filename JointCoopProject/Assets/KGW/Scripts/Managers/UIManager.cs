using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

// ��ųʸ� Ű �Է¿� ���� ��Ÿ ������ enum ���
public enum UIKeyList
{
    // MainMenu UIKeyList
    mainOption, credit,
    // InGame UIKeyList
    miniMap, playerHp, activeItem, activeItemGuage, Chip, bomb, inventory, confirmWindow, optionWindow, deathWindow, fortune, itemTitle, itemDescription
}

public class UIManager : MonoBehaviour
{
    static UIManager instance;
    Dictionary<UIKeyList, GameObject> _UiDictionary = new Dictionary<UIKeyList, GameObject>();

    [Header("InGame UI References")]
    [SerializeField] GameObject _miniMapUI;   // �̴ϸ� UI
    [SerializeField] GameObject _playerHpUI;    // �÷��̾� ü�� UI
    [SerializeField] GameObject _activeItemUI; // ��Ƽ�� ������ UI
    [SerializeField] GameObject _activeItemGuageUI; // ��Ƽ�� ������ UI
    [SerializeField] GameObject _ChipUI;        // ȹ���� ��� UI
    [SerializeField] GameObject _bombUI;        // ȹ���� ��ź UI
    [SerializeField] GameObject _inventoryUI;   // �κ��丮 UI
    [SerializeField] GameObject _confirmWindowUI;   // Ȯ�� â UI
    [SerializeField] GameObject _optionWindowUI;   // �ɼ� â UI
    [SerializeField] GameObject _deathWindowUI;   // ĳ���� ���� â UI
    [SerializeField] GameObject _fortuneUI;   // ������ � â UI
    [SerializeField] GameObject _itemTitleUI;   // ������ Ÿ��Ʋ UI
    [SerializeField] GameObject _itemDescriptionUI;   // ������ ���� UI

    [Header("MainMenu UI References")]
    [SerializeField] GameObject _mainOptionUI;    // ���� �ɼ� â UI
    [SerializeField] GameObject _creditUI;      // ���� ũ���� UI

    [Header("Button UI Reference")]
    [SerializeField] Button _optionWindowButton;    // �ɼ� â ���� ��ư
    [SerializeField] Button _mainMenuButton;    // ���� ȭ�� �̵� ��ư
    [SerializeField] Button _inventoryCloseButton;    // �κ��丮 �ݱ� ��ư
    [SerializeField] Button _yesButton;    // Yes ��ư
    [SerializeField] Button _noButton;    // No ��ư
    [SerializeField] Button _optionCloseButton;    // �ɼ� �ݱ� ��ư

    [Header("Player Heart Controll")]
    [SerializeField] PlayerHeartController _playerHeartController;  // �÷��̾� ��Ʈ ��Ʈ�� ��ũ��Ʈ

    // �ʱ� UIManager ����
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject gameObject = new GameObject("UIManager");
                instance = gameObject.AddComponent<UIManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        CreateUIManager();
        Init();
    }

    private void Update()
    {
        OnInventoryOpen();
        HeartUpdateUI(PlayerStatManager.Instance._playerHp, PlayerStatManager.Instance._playerMaxHp);
    }

    private void CreateUIManager()
    {
        if(instance == null)    // ������ �Ǿ� ������ �� ������ �ʰ� ���
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else    // �ߺ� ����
        {
            Destroy(gameObject);
        }
    }

    // ��ųʸ��� UI �߰� (��Ÿ ������ Ű == enum UIKeyList)
    private void Init()
    {
        // InGame UI �߰�
        _UiDictionary[UIKeyList.miniMap] = _miniMapUI;
        _UiDictionary[UIKeyList.playerHp] = _playerHpUI;
        _UiDictionary[UIKeyList.activeItem] = _activeItemUI;
        _UiDictionary[UIKeyList.activeItemGuage] = _activeItemGuageUI;
        _UiDictionary[UIKeyList.Chip] = _ChipUI;
        _UiDictionary[UIKeyList.bomb] = _bombUI;
        _UiDictionary[UIKeyList.inventory] = _inventoryUI;
        _UiDictionary[UIKeyList.confirmWindow] = _confirmWindowUI;
        _UiDictionary[UIKeyList.optionWindow] = _optionWindowUI;
        _UiDictionary[UIKeyList.deathWindow] = _deathWindowUI;
        _UiDictionary[UIKeyList.fortune] = _fortuneUI;
        _UiDictionary[UIKeyList.itemTitle] = _itemTitleUI;
        _UiDictionary[UIKeyList.itemDescription] = _itemDescriptionUI;

        // Main Menu UI �߰�
        _UiDictionary[UIKeyList.mainOption] = _mainOptionUI;
        _UiDictionary[UIKeyList.credit] = _creditUI;

    }

    // UI��������
    public GameObject GetUI(UIKeyList uiName)
    {
        GameObject uiKeyName = _UiDictionary.ContainsKey(uiName) ? _UiDictionary[uiName] : null;
        if (uiKeyName == null)
        {
            Debug.Log($"��û�Ͻ� UI({uiName})�� �������� �ʽ��ϴ�.");
        }

        return uiKeyName;
    }

    // �κ��丮 â ����
    public void OnInventoryOpen()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameSceneManager.Instance != null)
            {
                GameSceneManager.Instance.OpenUi(UIKeyList.inventory);
                // �κ��丮 â
                _inventoryCloseButton.onClick.AddListener(() => GameSceneManager.Instance.CloseUi());   // �κ��丮 â ����
                _optionWindowButton.onClick.AddListener(() => GameSceneManager.Instance.OpenUi(UIKeyList.optionWindow));    // �ɼ� â ����
                _mainMenuButton.onClick.AddListener(() => GameSceneManager.Instance.OpenUi(UIKeyList.confirmWindow));   // Ȯ�� â ����

                // Ȯ�� â
                _yesButton.onClick.AddListener(() => GameSceneManager.Instance.LoadMainScene());    // Yes ��ư : ���� â ��ȯ
                _noButton.onClick.AddListener(() => GameSceneManager.Instance.CloseUi()); // No ��ư : �κ��丮 â ��ȯ

                // �ɼ� â
                _optionCloseButton.onClick.AddListener(() => GameSceneManager.Instance.CloseUi());  // �ɼ� â ���� : �κ��丮 â ��ȯ
            }
            else
            {
                Debug.LogWarning("GameSceneManager�� �ʱ�ȭ���� �ʾҽ��ϴ�.");
                return;
            }
        }
    }

    public void HeartUpdateUI(float playerCurrentHp, float playerMaxHp)
    {
        _playerHeartController.HeartsUpdate(playerCurrentHp, playerMaxHp);
    }
}
