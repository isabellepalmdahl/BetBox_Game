using System;
using System.Collections.Generic;
using System.Text;

namespace supX.ViewModels
{
    public class Player : MainViewModel
    {
        public double MyBalance { get; set; }
        public string MyName { get; set; }

        public Player()
        {
            MyBalance = 100;
            MyName = "Madde";

        }
        //public override string ToString()
        //{
        //    return $"{MyBalance}";
        //}
    }
}
