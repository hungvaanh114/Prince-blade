using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KeyManager : MonoBehaviour
{
    public Text lookUpKey;
    public Text lookDownKey;
    public Text moveLeftKey;
    public Text moveRightKey;
    public Text jumpKey;
    public Text dashKey;
    public Text sitKey;
    public Text skill1Key;
    public Text attackKey;
    public Text usePotionRedKey;
    public Text usePotionBlueKey;

    private Key key;

    public Button lookUpButton;
    public Button lookDownButton;
    public Button moveLeftButton;
    public Button moveRightButton;
    public Button jumpButton;
    public Button dashButton;
    public Button sitButton;
    public Button skill1Button;
    public Button attackButton;
    public Button usePotionRedButton;
    public Button usePotionBlueButton;

    private string actionToBind;
    public GameObject keyInputPanel;
    // Start is called before the first frame update
    void Start()
    {
        key = Resources.Load<Key>("GameData/Keys");
        lookUpButton.onClick.AddListener(() => StartChangingKey("LookUp"));
        lookDownButton.onClick.AddListener(() => StartChangingKey("LookDown"));
        moveLeftButton.onClick.AddListener(() => StartChangingKey("MoveLeft"));
        moveRightButton.onClick.AddListener(() => StartChangingKey("MoveRight"));
        jumpButton.onClick.AddListener(() => StartChangingKey("Jump"));
        dashButton.onClick.AddListener(() => StartChangingKey("Dash"));
        sitButton.onClick.AddListener(() => StartChangingKey("Sit"));
        skill1Button.onClick.AddListener(() => StartChangingKey("Skill1"));
        attackButton.onClick.AddListener(() => StartChangingKey("AttackKey"));
        usePotionRedButton.onClick.AddListener(() => StartChangingKey("UsePotionRedKey"));
        usePotionBlueButton.onClick.AddListener(() => StartChangingKey("UsePotionBlueKey"));

    }
    void StartChangingKey(string action)
    {
        actionToBind = action;
        keyInputPanel.SetActive(true);

    }
    // Update is called once per frame
    void Update()
    {
        if (key != null)
        {
            UpdateKeyDisplay();
            if (keyInputPanel.activeSelf)
            {
                foreach (KeyCode code in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(code))
                    {
                        if (key.SetKey(actionToBind, code))
                        {
                            keyInputPanel.SetActive(false);
                        }
                        else
                        {
                            keyInputPanel.GetComponentInChildren<Text>().text = "Phím đã được thiết lập, vui lòng chọn phím khác";
                        }
                        break;
                    }
                }
            }
            else
            {
                keyInputPanel.GetComponentInChildren<Text>().text = "Nhấn phím bất kì";
            }
        }
        


    }
    private void UpdateKeyDisplay()
    {
        lookUpKey.text = "" + key.LookUpKey;
        lookDownKey.text = "" + key.LookDownKey;
        moveLeftKey.text = "" + key.MoveLeftKey;
        moveRightKey.text = "" + key.MoveRightKey;
        jumpKey.text = "" + key.JumpKey;
        dashKey.text = "" + key.DashKey;
        sitKey.text = "" + key.SitKey;
        skill1Key.text = "" + key.Skill1Key;
        attackKey.text = "" + key.AttackKey;
        usePotionRedKey.text = "" + key.UsePotionRedKey;
        usePotionBlueKey.text = "" + key.UsePotionBlueKey;
    }

}
