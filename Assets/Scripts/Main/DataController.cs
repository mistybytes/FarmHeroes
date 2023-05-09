using Palmmedia.ReportGenerator.Core.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class DataController : MonoBehaviour
{
    public Inventory Inventory;
    private InventoryDTO InventoryDTO;
    private List<ItemDTO> stableItems;
    private string inventoryFile => "Inventory.txt";
    private string stableFile => "Stable.txt";


    void Start()
    {
        InicialInventoryObject();

    }

    public void AddItemToStable(ItemDTO itemDTO)
    {
        stableItems.Add(itemDTO);
    }

    void InicialInventoryObject()
    {
        foreach(Item item in Inventory.Items)
        {
            foreach (Rarity rarity in (Rarity[])Enum.GetValues(typeof(Rarity)))
            {
                item.Quantity.Add(rarity, 0);
            }
        }
    }
    public List<ItemDTO> GetStableItems()
    {
        return stableItems;
    }

    private void OnDisable()
    {
        SaveInventoryData();
    }

    public void SaveStableData()
    {
        string json = JsonUtility.ToJson(stableItems);
        WriteToFile(stableFile, json);
    }

    public void SaveInventoryData()
    {
        string json = InventoryToJson();
        WriteToFile(inventoryFile, json);
    }

    public void LoadStableItems()
    {
        string json = ReadFromFIle(stableFile);
        JsonUtility.FromJsonOverwrite(json, stableItems);
    }

    void LoadInventoryData()
    {
        string json = ReadFromFIle(inventoryFile);
        JsonUtility.FromJsonOverwrite(json, InventoryDTO);
        LoadInventoryDTOToInventory();
        
    }
    private string InventoryToJson()
    {
        InventoryDTO = new InventoryDTO(Inventory);
        return JsonUtility.ToJson(InventoryDTO);
    }
    private void LoadInventoryDTOToInventory()
    {
        Inventory.Currency.Coin = InventoryDTO.Currency.Coin;
        Inventory.Currency.Diamond = InventoryDTO.Currency.Diamond;

        foreach(ItemDTO itemDTO in InventoryDTO.Items) 
        {
            foreach(string quantity in itemDTO.Quantity)
            {
                string[] strings = quantity.Split(':');
                Rarity rarity =  stringToRarity(strings[0]);
                int value = strings[1].ParseLargeInteger();
                Inventory.Items.FirstOrDefault(item => item.Data.Name == itemDTO.Name).Quantity[rarity] = value;
            }
        }

        Rarity stringToRarity(string sRarity) 
        {
            
            switch(sRarity) 
            {
                case "Common":
                    return Rarity.Common;
                case "Uncommon":
                    return Rarity.Uncommon;
                case "Rare":
                    return Rarity.Rare;
                case "Epic":
                    return Rarity.Epic;
                case "Legendary":
                    return Rarity.Legendary;
            }
            return Rarity.Common;
        }


        foreach (Item item in Inventory.Items)
        {
            ItemDTO itemDTO = InventoryDTO.Items.FirstOrDefault(itemDTO => item.name.Equals(itemDTO.Name));
            if (itemDTO != null)
            {
                foreach (Rarity rarity in (Rarity[])Enum.GetValues(typeof(Rarity)))
                {
                    item.Quantity[rarity] = itemDTO.Items[rarity];
                }
            }
        }
        foreach (Animal animal in Inventory.Animals)
        {
            AnimalDTO animalDTO = InventoryDTO.Animals.FirstOrDefault(animalDTO => animal.id.Equals(animalDTO.Id));
            if (animalDTO != null)
            {
                animal.Data.Level = animalDTO.Level;
            }
        }
    }

    private string ReadFromFIle(string fileName)
    {
        string path = GetFilePath(fileName);
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        }
        Debug.LogWarning("File not found");
        return "Error";
    }

    private void WriteToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }

    private string GetFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }
}
