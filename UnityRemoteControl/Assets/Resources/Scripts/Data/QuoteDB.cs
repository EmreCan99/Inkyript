﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuoteDB
{
    public int id;
    public string quote;
    public string author;
    public string category;
    public string book;

   public QuoteDB(int id, string quote, string author, string book, string category)
    {
        this.id = id;
        this.quote = quote;
        this.author = author;
        this.category = category;
        this.book = book;
    }
}
