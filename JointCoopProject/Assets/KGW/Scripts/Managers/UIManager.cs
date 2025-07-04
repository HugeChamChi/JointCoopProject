using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ųʸ� Ű �Է¿� ���� ��Ÿ ������ enum ���
public enum UIKeyList
{
    // MainMenu UIKeyList
    mainOption, credit,
    // InGame UIKeyList
    playerHp, activeSkill, gold, bomb, inventory, confirmWindow, optionWindow, deathWindow, fortune, itemTitle, itemDescription
}

public class UIManager : MonoBehaviour
{
    static UIManager instance;
    Dictionary<UIKeyList, GameObject> _UiDictionary = new Dictionary<UIKeyList, GameObject>();

    [Header("InGame UI References")]
    [SerializeField] GameObject _playerHpUI;    // �÷��̾� ü�� UI
    [SerializeField] GameObject _activeSkillUI; // ��Ƽ�� ������ UI
    [SerializeField] GameObject _goldUI;        // ȹ���� ��� UI
    [SerializeField] GameObject _bombUI;        // ȹ���� ��ź UI
    [SerializeField] GameObject _inventoryUI;   // �κ��丮 UI
    [SerializeField] GameObject _confirmWindowUI;   // Ȯ��â UI
    [SerializeField] GameObject _optionWindowUI;   // �ɼ�â UI
    [SerializeField] GameObject _deathWindowUI;   // ĳ���� ����â UI
    [SerializeField] GameObject _fortuneUI;   // ������ �â UI
    [SerializeField] GameObject _itemTitleUI;   // ������ Ÿ��Ʋ UI
    [SerializeField] GameObject _itemDescriptionUI;   // ������ ���� UI

    [Header("MainMenu UI References")]
    [SerializeField] GameObject _mainOptionUI;    // ���� �ɼ� â UI
    [SerializeField] GameObject _creditUI;      // ���� ũ���� UI

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
        _UiDictionary[UIKeyList.playerHp] = _playerHpUI;
        _UiDictionary[UIKeyList.activeSkill] = _activeSkillUI;
        _UiDictionary[UIKeyList.gold] = _goldUI;
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

    // 
    public GameObject GetUI(UIKeyList uiName)
    {
        GameObject uiKeyName = _UiDictionary.ContainsKey(uiName) ? _UiDictionary[uiName] : null;
        if(uiKeyName == null)
        {
            Debug.Log($"��û�Ͻ� UI({uiName})�� �������� �ʽ��ϴ�.");
        }
        
        return uiKeyName;
    }
    

}
