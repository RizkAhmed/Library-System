﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EF4
{
    public class Wallet
    {
        public int Id { get; set; }
        public string Holder { get; set; }
        public decimal Balance { get; set; }

        public override string ToString() => $"[{Id}] {Holder} ({Balance})";
    }
}
