using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class PreProcess : MonoBehaviour
{
    public  QuoteDB[] quotedb;

    public List<QuoteDB> loveDb = new List<QuoteDB>();
    public List<QuoteDB> lifeDb = new List<QuoteDB>();
    public List<QuoteDB> philosophyDb = new List<QuoteDB>();
    public List<QuoteDB> educationDb = new List<QuoteDB>();
    public List<QuoteDB> inspirationalDb = new List<QuoteDB>();
    public List<QuoteDB> artDb = new List<QuoteDB>();

    void Start()
    {
            Init();

            Debug.Log("Db.Inıt");

    }

    void Init()
    {
        TextAsset quoteData = Resources.Load<TextAsset>("Database/MainDb");
        string[] data = quoteData.text.Split(new char[] { '\n' });

        quotedb = new QuoteDB[data.Length - 2];

        for (int i = 1; i < data.Length - 1; i++)
        {
            string[] row = data[i].Split(new char[] { ';' });
            quotedb[i - 1] = new QuoteDB(row[0], row[1], row[2], row[3], row[4]);
        }

        Debug.Log("Preprocess sorun çözüldü");
        Categorize();
    }

    public void Categorize()
    {

        loveDb = (from item in quotedb
                  where item.category.ToString() == "love\r"
                  select item).ToList();

        lifeDb = (from item in quotedb
                  where item.category.ToString() == "life\r"
                  select item).ToList();

        philosophyDb = (from item in quotedb
                        where item.category.ToString() == "philosophy\r"
                        select item).ToList();

        educationDb = (from item in quotedb
                       where item.category.ToString() == "education\r"
                       select item).ToList();

        inspirationalDb = (from item in quotedb
                           where item.category.ToString() == "inspirational\r"
                           select item).ToList();

        artDb = (from item in quotedb
                  where item.category.ToString() == "art\r"
                  select item).ToList();

    }
}
