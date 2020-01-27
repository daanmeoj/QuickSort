using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GFG
{

    class Program
    {
        /* This function takes last element as pivot, 
    places the pivot element at its correct 
    position in sorted array, and places all 
    smaller (smaller than pivot) to left of 
    pivot and all greater elements to right 
    of pivot */
        static int partitionFirst(int[] arr, int low,
                                       int high, int[] count)
        {
           
            int pivot = arr[low];
            count[0] +=high-low;
            // index of smaller element 
            int i = low +1;
            for (int j = low+1; j <=high; j++)
            {

                // If current element is smaller  
                // than or equal to pivot 
                if (arr[j] < pivot)
                {
                    
                    // swap arr[i] and arr[j] 
                    int temp = arr[j];
                    arr[j] = arr[i];
                    arr[i] = temp;
                    i++;
                }
            }

            // swap arr[i+1] and arr[high] (or pivot) 
            int temp1 = arr[low];
            arr[low] = arr[i-1];
            arr[i-1] = temp1;
            return i-1;
        }

        static int partitionLast(int[] arr, int low,
                                       int high, int[] count)
        {
            int temp0 = arr[high];
            arr[high] = arr[low];
            arr[low] = temp0;

            return partitionFirst(arr,low,high,count);

        }

        //static int partitionMedian(int[] arr, int low,
        //                               int high, int[] count)
        //{
        //    int median = MedianCalculation(arr, low, high);

        //}

        static int partitionMedian(int[] arr, int low,
                                       int high, int[] count)
        {
            int median = MedianCalculation(arr, low, high);
            int temp0 = arr[median];
            arr[median] = arr[low];
            arr[low] = temp0;

            return partitionFirst(arr, low, high, count);

        }



        static int MedianCalculation(int[] arr, int low,int high)
        {
            
            int Median=new int();
            int middle = low + (high - low) / 2;
          

            bool TheMedianIsMiddle = (arr[middle] > arr[low] && arr[middle] < arr[high]) 
                || (arr[middle] > arr[high] && arr[middle] < arr[low]);

            bool TheMedianIsHigh = (arr[high] > arr[middle] && arr[high] < arr[low]) 
                || (arr[high] > arr[low] && arr[high] < arr[middle]);

            bool TheMedianIsLow = (arr[low] < arr[high] && arr[low] > arr[middle]) 
                || (arr[low] < arr[middle] && arr[low] > arr[high]);

            if (TheMedianIsMiddle)
                Median=middle;
  
            else if (TheMedianIsHigh)
                Median = high;

            else if(TheMedianIsLow)
                Median = low;

            return Median;
        }


        /* The main function that implements QuickSort() 
        arr[] --> Array to be sorted, 
        low --> Starting index, 
        high --> Ending index */
        static void quickSort(int[] arr, int low, int high, int [] count)
        {
           
                /* pi is partitioning index, arr[pi] is  
                now at right place */

            if (low < high)
            {
                //use according a the pivot selection method you want to use(i.e. partitionFirst,partitionLast and partitionMedian)
                //int pi = partitionFirst(arr, low, high, count);
                //int pi = partitionLast(arr, low, high, count);
                int pi = partitionMedian(arr, low, high, count);
                quickSort(arr, low, pi - 1, count);
                quickSort(arr, pi+1, high,count);
            }
        }



        // A utility function to print array of size n 
        static void printArray(int[] arr, int n)
        {
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");

            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            var list = new List<int>();
            var fileStream = new FileStream(@"C:\Users\Administrador\Desktop\Cursos\Algorithms\3.QuickSort\array1.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    list.Add(Convert.ToInt32(line));
                }
            }



            var arr1 = new ComposedClass(list.Count);
            

            arr1.arr = list.ToArray();
            int n = arr1.arr.Length;
            quickSort(arr1.arr, 0, n-1, arr1.count);
            Console.WriteLine(arr1.count[0]);
            

        }
    }
}
