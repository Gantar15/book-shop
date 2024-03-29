﻿using BookShop.Models.Base;

namespace BookShop.Models
{
    public class BasketModel : Model
    {
        private int _count;
        private decimal _price;

        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
                OnPropertyChanged();
            }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged();
            }
        }
    }
}
