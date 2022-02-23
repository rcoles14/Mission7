﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public void AddItem (Book book, int qty)
        {
            BasketLineItem Line = Items
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (Line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = book,
                    Quantity = qty
                });
            }
            else
            {
                Line.Quantity += qty;
            }
        }    
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);

            return sum;
        }

    }


    public class BasketLineItem
    {
        public int LineID { get; set; }
        public Book Book { get; set; }

        public int Quantity { get; set; }
    }
}  
