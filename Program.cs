﻿using System;
using System.Collections;
using System.Collections.Generic;
using Lucene.Net.Util;
using System.Text;
using System.Linq;

namespace Assignment2_CT_Spring2020
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Question 1");
            //int[] l1 = new int[] { 5, 6, 6, 9, 9, 12 };
            //int target = 9;
            //int[] r = TargetRange(l1, target);
            // Write your code to print range r here
            //foreach (int n in r)
            //{
            //    Console.Write("[{0}]",string.Join(", ",r));
            //    //Console.Write(n);
            //}
            //DisplayArray(r);

            //Console.WriteLine("Question 3");
            //int[] l2 = new int[] { 40, 40 };
            //int sum = MinimumSum(l2);
            //Console.WriteLine(sum);

            //Console.WriteLine("Question 4");
            //string s2 = "Dell";
            //string sortedString = FreqSort(s2);
            //Console.WriteLine(sortedString);

            Console.WriteLine("Question 5-Part 1");
            int[] nums1 = { 3, 6, 2 };
            int[] nums2 = { 6, 3, 6, 7, 3 };
            int[] intersect1 = Intersect1(nums1, nums2);
            //Console.WriteLine("Part 1- Intersection of two arrays is: ");
            //DisplayArray(intersect1);
            //Console.WriteLine("\n");

            //Console.WriteLine("Question 5-Part 2");
            //int[] intersect2 = Intersect2(nums1, nums2);
            //Console.WriteLine("Part 2- Intersection of two arrays is: ");
            //DisplayArray(intersect2);
            //Console.WriteLine("\n");

            Console.WriteLine("Question 7");
            int rodLength = 15;
            int priceProduct = GoldRod(rodLength);
            Console.WriteLine(priceProduct);

            //Console.WriteLine("Question 8");
            //string[] userDict = new string[] { "rocky", "usf", "hello", "apple" };
            //string keyword = "hhllo";

            //Console.WriteLine(DictSearch(userDict, keyword));
        }

            

        public static void DisplayArray(int[] a)
        {
            foreach (int n in a)
            {
                Console.Write(n + " ");
            }
        }

        public static int[] TargetRange(int[] l1, int t)
        {
            int[] res = { -1, 1 };
            if (l1 == null | l1.Length == 0)
                return res;
            try
            {
                res[0] = firstPos(l1, t);
                res[1] = lastPos(l1,t);
               
                

            }
            catch (Exception)
            {
                Console.WriteLine("Exception Occured"); ;
            }
            return res;
        }


        public static int MinimumSum(int[] l2)
        {
            try
            {
                //Write your code here;
                int res = l2[0];
                int n = l2.Length;
                for (int i = 1; i < n; i++)
                {
                    if (l2[i] == l2[i - 1]) // comparing current element with previous
                    {

                        int j = i;
                        while (j < n && l2[j] <= l2[j - 1])
                        {
                            l2[j] = l2[j] + 1;
                            j++;
                        } // removing same number in array and adding 1 to that.
                    }
                    res = res + l2[i]; // producing sum
                }
                return res;

            }
            catch (Exception)
            {
                throw;
            }
            return 0;
        }


        public static int[] Intersect1(int[] nums1, int[] nums2)
        {
            try
            {
                // Write your code here
                Array.Sort(nums1);
                Array.Sort(nums2);
                // Sorted both the array
                int m = nums1.Length;
                int n = nums2.Length;
                int i = 0, j = 0;
                ArrayList myAL = new ArrayList();


                while (i < m && j < n)
                {
                    if (nums1[i] < nums2[j])
                        i++;
                    else if (nums2[j] < nums1[i])
                        j++; // comparing elements in both the array with each other to find intersection
                    else
                    {

                        myAL.Add(nums2[j++]);
                        i++;
                    }

                }
                object[] obj1 = myAL.ToArray();
                int[] a = new int[obj1.Length];
                int x = 0;
                foreach (int st in obj1)
                {

                    a[x++] = st;
                }
                return a;
            }

            catch
            {
                throw;
            }
            return new int[] { };
        }

        public static int[] Intersect2(int[] nums1, int[] nums2)
        {
            try
            {
                var Countnum = new Dictionary<int, int>(); // creating a dictionary

                foreach (var num in nums1)
                {
                    if (!Countnum.ContainsKey(num))
                        Countnum[num] = 0;
                    Countnum[num]++;
                }

                var Intersection = new List<int>();

                foreach (var num in nums2)
                {
                    if (Countnum.ContainsKey(num) && Countnum[num] > 0)
                    {
                        Intersection.Add(num);

                        Countnum[num]--;
                    }

                }
                return Intersection.ToArray();
            }

            catch
            {
                throw;
            }
            return new int[] { };
        }
        public static int firstPos(int[] l1, int t)
        {
            int start = 0;
            int last = l1.Length - 1;
            
            int index = -1;

            while (start <= last)
            {
                int mid = start + (last - start) / 2;
                if (l1[mid] == t)
                {
                    index = mid;
                    last = mid - 1;
                }
                else if (l1[mid] > t)
                    last = mid - 1;
                else
                    start = mid + 1;
            }
            return index;
        }

        public static int lastPos(int[] l1, int t)
        {
            int start = 0;
            int last = l1.Length - 1;

            int index = -1;

            while (start <= last)
            {
                int mid = start + (last - start) / 2;
                if (l1[mid] == t)
                {
                    index = mid;
                    start = mid + 1;
                }
                else if (l1[mid] > t)
                    last = mid - 1;
                else
                    start = mid + 1;
            }
            return index;
        }


        //public static string FreqSort(string s)
        //{
        //    if (string.IsNullOrEmpty(s))
        //        return s;

        //    Dictionary<char, int> dict = new Dictionary<char, int>();
        //    //calculate frequencies by character
        //    foreach (var c in s)
        //    {
        //        if (!dict.ContainsKey(c))
        //        {   
        //            dict.Add(c, 0);
        //        }
        //        dict[c]++;
        //    }

        //    PriorityQueue<Char> maxHeap = new PriorityQueue<>();

        //}



        public static string FreqSort(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            Dictionary<char, int> cache = new Dictionary<char, int>();
            Dictionary<int, List<char>> rcache = new Dictionary<int, List<char>>();

            //calculate frequencies by char
            foreach (var c in s)
            {
                if (!cache.ContainsKey(c))
                {
                    cache.Add(c, 0);
                }

                cache[c]++;
            }

            //reverse cache:chars by frequency
            foreach (var k in cache.Keys)
            {
                if (!rcache.ContainsKey(cache[k]))
                    rcache.Add(cache[k], new List<char>());

                rcache[cache[k]].Add(k);
            }


            StringBuilder sb = new StringBuilder();
            var l = rcache.Keys.ToList();
            l.Sort();
            l.Reverse();

            foreach (var f in l)
            {
                foreach (var c in rcache[f])
                    for (int i = 0; i < f; i++)
                        sb.Append(c);
            }


            return sb.ToString();

        }

        //Question 7
        public static int GoldRod(int rodLength)
        {
            try
            {
                if (rodLength == 2)
                    return 1;
                else if (rodLength == 3)
                    return 2;
                else if (rodLength == 4)
                    return 4;
                else if (rodLength == 5)
                    return 6;
                else if (rodLength == 6)
                    return 9;
                else
                    return 3 * GoldRod(rodLength - 3); // Recursion used

            }
            catch (Exception)
            {
                throw;
            }
            return 0;
        }

        //Question 8
        public static bool DictSearch(string[] userDict, string keyword)
        {

            //for(int i = 0; i < keyword.Length; i++)
            //{
            //    if (keyword == userDict[i])
            //        return false;
            //}
            int same = 0;
            //for (int i = 0; i < userDict.Length; i++)
            //{
            //    if (userDict[i].Length != keyword.Length)
            //        return false;
            //}
            for (int i = 0; i < userDict.Length; i++)
            {
                    same = 0;
                    for (int j = 0; j < userDict[i].Length; j++)
                    {
                       // Console.Write(userDict[i][j]);
                        if (userDict[i][j] == keyword[j])
                        {
                            same = same + 1;
                            Console.WriteLine(same);                           
                        }
                    
                }
                if (same == keyword.Length-1)
                    return true;

            }

            return false; 

        }



    }
}
