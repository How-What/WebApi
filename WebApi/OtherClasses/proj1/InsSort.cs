using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.OtherClasses.proj1
{
    public class InsSort
    {
        public static int[] InsertionSort(int[] A)
        {
            //Ripped from https://codereview.stackexchange.com/questions/59968/performing-insertion-sort-in-c
            for (int i = 0; i < A.Length - 1; i++)
            {
                int j = i + 1;

                while (j > 0)
                {
                    if (A[j - 1] > A[j])
                    {
                        int temp = A[j - 1];
                        A[j - 1] = A[j];
                        A[j] = temp;
                    }
                    j--;
                }
            }
            return A;
        }
    }
}