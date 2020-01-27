using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFG
{
    public  class ComposedClass
    {
        public int [] arr { get; set; }

        public int[] count { get; set; }



        public ComposedClass(int ArrSize)
        {
                this.arr=new int[ArrSize];
                this.count= new int[1];
        }
    }
}
