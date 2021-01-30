using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuoteDB
{
    public string quote;
    public string author;
    public string category;
    public string book;

   public QuoteDB(string quote, string author, string category, string book)
    {
        this.quote = quote;
        this.author = author;
        this.category = category;
        this.book = book;
    }
}
