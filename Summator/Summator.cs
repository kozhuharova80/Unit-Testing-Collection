using System;
using System.Collections.Generic;
using System.Text;

namespace Summator
{
    public  class Summator
    {
        public  int Sum(int[] arr)
        {
            checked
            {
        
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];

            }
            return sum;
            }
        }
    }  
}
