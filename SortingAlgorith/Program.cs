using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorith
{
    class SortingAlgorithms
    {
        static int arraysize = 50000;
        static void Main(string[] args)
        {
            
            int[] randomUnsortedArray = populateUnsortedList();
            int[] heapSortedArray = (int[])randomUnsortedArray.Clone();
            int[] insertionSortedArray = (int[])randomUnsortedArray.Clone();
            int[] bubbleSortedArray = (int[])randomUnsortedArray.Clone();
            int[] mergeSortedArray = (int[])randomUnsortedArray.Clone();
            int[] quickSortedArray = (int[])randomUnsortedArray.Clone();


            for (int counter = 0; counter < 5; counter++)
            { 
                System.Diagnostics.Stopwatch clock = new System.Diagnostics.Stopwatch();
                clock.Start();
                switch(counter)
                {
                    case 0:
                        heapSortedArray = HeapSort(heapSortedArray);
                        Console.Write("Heap");
                        break;
                    case 1:
                        insertionSortedArray = InsertionSort(insertionSortedArray);
                        Console.Write("Insertion");
                        break;
                    case 2:
                        bubbleSortedArray = Bubblesort(bubbleSortedArray);
                        Console.Write("Bubble");
                        break;
                    case 3:
                        mergeSortedArray = Mergesort(mergeSortedArray, 0, mergeSortedArray.Length - 1);
                        Console.Write("Merge");
                        break;
                    case 4:
                        quickSortedArray = Quicksort(quickSortedArray, 0, quickSortedArray.Length - 1);
                        Console.Write("Quick");
                        break;
                }
                clock.Stop();
                Console.WriteLine(" took: " + clock.Elapsed.TotalMilliseconds + " ms. to sort list of  "+arraysize+" numbers.");
            }
            Console.WriteLine("Press enter to close");
            Console.ReadLine();
           
        }

        /**Merge sort
         * 
         * Best - n log n
         * Average - n log n
         * Worst - n log n
         * Memory Required - n
         */
        private static int[] Mergesort(int[] unsortedArray, int left, int right)
        {
            int mid;

            if (right>left)
            {
                mid = (right + left) / 2;
                Mergesort(unsortedArray,left,mid);
                Mergesort(unsortedArray,mid+1,right);
                Mergesort_Recursion(unsortedArray, left, mid+1, right);
            }
            return unsortedArray;
        }

        private static void Mergesort_Recursion(int[] unsortedArray, int left, int mid, int right)
        {
            int[] temp = new int[unsortedArray.Length];
            int i, left_end, num_elements, tmp_pos;
            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);
            while ((left <= left_end) && (mid <= right))
            {
                if (unsortedArray[left] <= unsortedArray[mid])
                    temp[tmp_pos++] = unsortedArray[left++];
                else
                    temp[tmp_pos++] = unsortedArray[mid++];
            }
            while (left <= left_end)
                temp[tmp_pos++] = unsortedArray[left++];
            while (mid <= right)
                temp[tmp_pos++] = unsortedArray[mid++];
            for (i = 0; i < num_elements; i++)
            {
                unsortedArray[right] = temp[right];
                right--;
            }
        }

        /**Heapsort
         * 
         * Best - n log n
         * Average - n log n
         * Worst - n log n
         * Memory Required - 1
         */
        private static int[] HeapSort(int[] unsortedArray)
        {
            for (int counter = 0; counter < unsortedArray.Length - 1; counter++)
            {
                int key = unsortedArray[counter];
                int temp = counter;
                for (int counter2 = counter + 1; counter2 < unsortedArray.Length; counter2++)
                {
                    if (unsortedArray[counter2] < key)
                    {
                        key = unsortedArray[counter2];
                        temp = counter2;
                    }
                }
                unsortedArray[temp] = unsortedArray[counter];
                unsortedArray[counter] = key;
            }
            return unsortedArray;
        }
        
        /**Insertion sort
         * 
         * Best - n
         * Average - n^2
         * Worst - n^2
         * Memory Required - 1
         */
        private static int[] InsertionSort(int[] unsortedArray)
        {
            for (int counter = 0; counter < unsortedArray.Length-1; counter++)
            {
                int key = unsortedArray[counter];
                int temp = counter - 1;
                while (temp >= 0 && unsortedArray[temp] > key)
                {
                    unsortedArray[temp + 1] = unsortedArray[temp];
                    temp = temp - 1;
                }
                unsortedArray[temp + 1] = key;
            }
            return unsortedArray;
        }

        /**Quicksort
         * 
         * Best - n log n
         * Average - n log n
         * Worst - n^2
         * Memory Required - n (worst case) 
         */
        private static int[] Quicksort(int[] unsortedArray, int low, int high)
        {
            if (low < high)
            {
                int pivot = QuicksortPartition(unsortedArray, low, high);
                Quicksort(unsortedArray, low, pivot-1);
                Quicksort(unsortedArray, pivot+1, high);
            }
            return unsortedArray;
        }

        private static int QuicksortPartition(int[] unsortedArray, int low, int high)
        {
            int pivot = unsortedArray[high];
            int left = low;
            int temp;
            for (int counter = low; counter < high; counter++)
            {
                if (unsortedArray[counter] <= pivot) 
                {
                    temp = unsortedArray[counter];
                    unsortedArray[counter] = unsortedArray[left];
                    unsortedArray[left] = temp;
                    left++;
                }
            }
            unsortedArray[high] = unsortedArray[left];
            unsortedArray[left] = pivot;

            return left;
        }

        /**Bubble sort (NEVER USE!)
         * 
         * Best - n
         * Average - n^2
         * Worst - n^2
         * Memory Required - 1
         */
        private static int[] Bubblesort(int[] unsortedArray)
        {
            int temp = 0;
            for (int counter = 0; counter < unsortedArray.Length; counter++)
            {
                for (int sort = 0; sort < unsortedArray.Length -1; sort++)
                {
                    if (unsortedArray[sort] > unsortedArray[sort + 1])
                    {
                        temp = unsortedArray[sort + 1];
                        unsortedArray[sort + 1] = unsortedArray[sort];
                        unsortedArray[sort] = temp;
                    }
                }
            }
            return unsortedArray;
        }

        /*Populates the list
         */
        private static int[] populateUnsortedList()
        {
            string line;
            string basedir = System.AppDomain.CurrentDomain.BaseDirectory;
            int[] readinArray = new int[arraysize];
            System.IO.StreamReader file = new System.IO.StreamReader(basedir + "\\numberlist" + arraysize + ".txt");
            for (int counter = 0; (line = file.ReadLine()) != null; counter++ )
            {
                    readinArray[counter]=(Convert.ToInt32(line));
            }
            file.Close();
            return readinArray;
        }

    }
}
