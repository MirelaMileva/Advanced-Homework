using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Tuple
{
    public class Tuple<T1, T2>
    {
        public Tuple(T1 item1, T2 item2)
        {
            this.ItemOne = item1;
            this.ItemTwo = item2;
        }
        public T1 ItemOne { get; set; }
        public T2 ItemTwo { get; set; }

        public override string ToString()
        {
            return $"{this.ItemOne} -> {this.ItemTwo}";
        }
    }
}
