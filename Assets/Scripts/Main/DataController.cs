using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class DataController : MonoBehaviour
{
    public Inventory Inventory;
    private InventoryDTO InventoryDTO;
    private List<ItemDTO> stableItems;
    private string inventoryFile => "Inventory.txt";
    private string stableFile => "Stable.txt";


    void Start()
    {

        InventoryDTO = new InventoryDTO(Inventory);
        LoadInventoryData();

    }

    public void AddItemToStable(ItemDTO itemDTO)
    {
        stableItems.Add(itemDTO);
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

    void SaveInventoryData()
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
        return JsonUtility.ToJson(InventoryDTO);
    }
    private void LoadInventoryDTOToInventory()
    {
        Inventory.Currency.Coin = InventoryDTO.Currency.Coin;
        Inventory.Currency.Diamond = InventoryDTO.Currency.Diamond;

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
