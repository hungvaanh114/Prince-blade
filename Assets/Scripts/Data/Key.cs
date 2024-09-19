using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "Keys", menuName = "Keys/Key")]
public class Key : ScriptableObject
{
    [SerializeField] private KeyCode lookUpKey = KeyCode.UpArrow;
    [SerializeField] private KeyCode lookDownKey = KeyCode.DownArrow;
    [SerializeField] private KeyCode moveLeftKey = KeyCode.LeftArrow;
    [SerializeField] private KeyCode moveRightKey = KeyCode.RightArrow;
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode dashKey = KeyCode.LeftShift;
    [SerializeField] private KeyCode sitKey = KeyCode.C;
    [SerializeField] private KeyCode skill1Key = KeyCode.E;
    [SerializeField] private KeyCode attackKey = KeyCode.A;
    [SerializeField] private KeyCode usePotionBlueKey = KeyCode.G;
    [SerializeField] private KeyCode usePotionRedKey = KeyCode.F;


    public bool IsKeyAlreadyUsed(KeyCode key)
    {
        return lookUpKey == key || lookDownKey == key || moveLeftKey == key || moveRightKey == key ||
               jumpKey == key || dashKey == key || sitKey == key || skill1Key == key|| usePotionRedKey == key || usePotionBlueKey== key || attackKey == key;
    }

    // Hàm để lưu tùy chỉnh phím mới
    public bool SetKey(string action, KeyCode newKey)
    {
        if (IsKeyAlreadyUsed(newKey)) return false; // Phím đã được dùng cho kỹ năng khác
        
        switch (action)
        {
            case "LookUp":
                lookUpKey = newKey;
                break;
            case "LookDown":
                lookDownKey = newKey;
                break;
            case "MoveLeft":
                moveLeftKey = newKey;
                break;
            case "MoveRight":
                moveRightKey = newKey;
                break;
            case "Jump":
                jumpKey = newKey;
                break;
            case "Dash":
                dashKey = newKey;
                break;
            case "Sit":
                sitKey = newKey;
                break;
            case "Skill1":
                skill1Key = newKey;
                break;
            case "AttackKey":
                attackKey = newKey;
                break;
            case "UsePotionRedKey":
                usePotionRedKey = newKey;
                break;
            case "UsePotionBlueKey":
                usePotionBlueKey = newKey;
                break;
        }
        return true; // Thành công
    }
    public KeyCode LookUpKey
    {
        get => lookUpKey;
    }    
    public KeyCode UsePotionRedKey
    {
        get => usePotionRedKey;
    }    
    public KeyCode UsePotionBlueKey
    {
        get => usePotionBlueKey;
    }    
    public KeyCode AttackKey
    {
        get => attackKey;
    }    
    public KeyCode Skill1Key
    {
        get => skill1Key;
    }   
    public KeyCode SitKey
    {
        get => sitKey;
    }    
    public KeyCode DashKey
    {
        get => dashKey;
    }    
    public KeyCode JumpKey
    {
        get => jumpKey;
    }    
    public KeyCode MoveRightKey
    {
        get => moveRightKey;
    }
    public KeyCode MoveLeftKey
    {
        get => moveLeftKey;
    }
    public KeyCode LookDownKey
    {
        get => lookDownKey;
    }
    public void SaveToJson(string filePath)
    {
        string json = JsonUtility.ToJson(this, true);
        File.WriteAllText(filePath, json);
    }

    public void LoadFromJson(string filePath)
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            JsonUtility.FromJsonOverwrite(json, this);
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
        }
    }

}
