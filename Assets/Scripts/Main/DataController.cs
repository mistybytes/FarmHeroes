using Palmmedia.ReportGenerator.Core.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class DataController : MonoBehaviour
{
    public Inventory Inventory;
    private InventoryDTO InventoryDTO = new InventoryDTO();
    private StableItems stableItems = new StableItems();
    private string inventoryFile => "Inventory.txt";
    private string stableFile => "Stable.txt";


    void Start()
    {
        if (!File.Exists(GetFilePath(stableFile)))
        {
            InicialStableFile();
        }
        InicialInventoryObject();
        LoadInventoryData();
    }

    public void AddItemToStable(ItemDTO itemDTO)
    {
        stableItems.Items.Add(itemDTO);
    }

    public StableItems GetStableItems() 
    {
        if (stableItems == null)
        {
            foreach (ItemDTO item in InventoryDTO.Items)
            {
                stableItems.Items.Add(item);
            }
        }
        return stableItems;
    }

    public void AddItemToStable(string itemName, Rarity rarity, int value)
    {
        ItemDTO item = stableItems.Items.FirstOrDefault(item => item.Name.Equals(itemName));
        Dictionary<Rarity, int> quantity = new Dictionary<Rarity, int>();
        foreach (var pair in item.Quantity)
        {
            string[] row = pair.Split(":");
            string rarityString = row[0];
            int valueD = int.Parse(row[1]);
            Rarity rarityD = stringToRarity(rarityString);
            quantity.Add(rarityD, valueD);
        }
        quantity[rarity] += value;

        List<string> newQuantity = new List<string>();

        foreach (Rarity rarityD in (Rarity[])Enum.GetValues(typeof(Rarity)))
        {
            string record = $"{rarityD}:{quantity[rarityD]}";
            newQuantity.Add(record);
        }
        item.Quantity = newQuantity;
        SaveStableData();
        Item invItem = Inventory.Items.FirstOrDefault(invItem => invItem.Data.Name.Equals(item.Name));
        invItem.Quantity[rarity] -= value;

    }

    void InicialInventoryObject()
    {
        foreach(Item item in Inventory.Items)
        {
            foreach (Rarity rarity in (Rarity[])Enum.GetValues(typeof(Rarity)))
            {
                if (!item.Quantity.ContainsKey(rarity))
                {
                    item.Quantity.Add(rarity, 0);
                }
            }
        }
    }
    void InicialStableFile()
    {
        foreach (Item item in Inventory.Items)
        {
            List<string> quantity = new List<string>();
            foreach (Rarity rarity in (Rarity[])Enum.GetValues(typeof(Rarity)))
            {
                string record = $"{rarity}:0";
                quantity.Add(record);
            }
            ItemDTO itemDTO = new ItemDTO()
            {
                Name = item.Data.Name,
                Quantity = quantity
            };
            stableItems.Items.Add(itemDTO);
        }
        SaveStableData();
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



    public StableItems LoadStableItems()
    {
        string json = ReadFromFIle(stableFile);
        JsonUtility.FromJsonOverwrite(json, stableItems);
        return stableItems;
    }

    public void LoadInventoryData()
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

        foreach (AnimalClass animal in Inventory.Animals)
        {
            AnimalDTO animalDTO = InventoryDTO.Animals.FirstOrDefault(animalDTO => animal.Id.Equals(animalDTO.Id));
            if (animalDTO != null)
            {
                animal.Level = animalDTO.Level;
            }
        }
    }

    public Rarity stringToRarity(string sRarity)
    {

        switch (sRarity)
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
