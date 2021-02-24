using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastQuote
{

    public QuoteDB love;
    public QuoteDB life;
    public QuoteDB philosophy;
    public QuoteDB education;
    public QuoteDB inspirational;
    public QuoteDB art;

    public LastQuote(QuoteDB love = null, QuoteDB life = null, QuoteDB philosophy = null, QuoteDB education = null, QuoteDB inspirational = null, QuoteDB art = null)
    {
        this.love = love;
        this.life = life;
        this.philosophy = philosophy;
        this.education = education;
        this.inspirational = inspirational;
        this.art = art;
    }
}
