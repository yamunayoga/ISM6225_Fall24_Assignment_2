using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            // No edge cases identified as the problem statement guarantee that there will not be negative numbers or empty arrays.

            try
            {

                List<int> missingNumbers = new List<int>();

                // Get the minimum and maximum values from the array to define the range
                int min = nums.Min();
                int max = nums.Max();
                bool[] present = new bool[max + 1];

                // Marking the numbers present in the original array
                foreach (int num in nums)
                {
                    present[num] = true;
                }

                // Checking for missing numbers within the range and adding them to the result list
                for (int i = min; i <= max; i++)
                {
                    if (!present[i])
                    {
                        missingNumbers.Add(i);
                    }
                }

                return missingNumbers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            // Edge Case: If the array is empty, this loop won’t run, and the function will return an empty array.
            // Edge Case: If the array has only one element (either even or odd), it gets added to the respective list and returned without issue.
            // Edge Case: If all elements are even or all are odd, one of the lists (evens or odds) will be empty, and the function will still return a valid result.

            try
            {
                List<int> evens = new List<int>(nums.Length);
                List<int> odds = new List<int>(nums.Length);

                // Loop through the input array and separate numbers into evens and odds
                foreach (int num in nums)
                {
                    if (num % 2 == 0)
                        evens.Add(num);
                    else
                        odds.Add(num);
                }

                // Combining the evens list with the odds list and returns the result as an array
                evens.AddRange(odds);
                return evens.ToArray();
            }
            catch (Exception)
            {
                throw;
            }
        }
        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            // Edge Case: If the array has only one element, the inner loop won’t run,
            // and it will correctly return {-1, -1} as no pair can be formed.

            try
            {
                // Outer loop to iterate through the array
                for (int firstIndex = 0; firstIndex < nums.Length; firstIndex++)
                {
                    // Inner loop to find the second number that completes the pair
                    for (int secondIndex = firstIndex + 1; secondIndex < nums.Length; secondIndex++)
                    {
                        // Checking if the sum of the two numbers equals the target
                        if (nums[firstIndex] + nums[secondIndex] == target)
                            return new int[] { firstIndex, secondIndex };
                    }
                }

                return new int[] { -1, -1 }; // No solution found
            }
            catch (Exception)
            {
                throw;
            }
        }
        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                // Edge Case: If array has fewer than 3 elements, product can't be calculated
                if (nums.Length < 3)
                {
                    throw new ArgumentException("Input array must contain at least three elements.");
                }
                // Initializing the three largest and two smallest values
                int max1 = int.MinValue, max2 = int.MinValue, max3 = int.MinValue;
                int min1 = int.MaxValue, min2 = int.MaxValue;


                // Loop through the array to update the largest and smallest values
                foreach (int num in nums)
                {
                    // Updating the three largest values
                    if (num > max1)
                    {
                        max3 = max2;
                        max2 = max1;
                        max1 = num;
                    }
                    else if (num > max2)
                    {
                        max3 = max2;
                        max2 = num;
                    }
                    else if (num > max3)
                    {
                        max3 = num;
                    }

                    // Updating the two smallest values
                    if (num < min1)
                    {
                        min2 = min1;
                        min1 = num;
                    }
                    else if (num < min2)
                    {
                        min2 = num;
                    }
                }

                // Calculating the maximum product of three numbers
                return Math.Max(max1 * max2 * max3, min1 * min2 * max1);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)


        {
            try
            {
                // Edge Case: Handle input 0 explicitly – binary of 0 is "0"
                if (decimalNumber == 0)
                    return "0";
                // Edge Case: Handle negative numbers
                if (decimalNumber < 0)
                    throw new ArgumentException("Negative numbers are not supported.");

                return ConvertToBinary(decimalNumber);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string ConvertToBinary(int n)
        {
            if (n == 0)
                return "";
            // Recursive Case: Calling the method recursively to build the binary string
            // Added the remainder (0 or 1) after dividing by 2 to the binary result
            return ConvertToBinary(n / 2) + (n % 2).ToString();
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                // Edge Case: Handle empty array input
                if (nums == null || nums.Length == 0)
                    throw new ArgumentException("Input array cannot be null or empty.");

                // Edge Case: If the array contains only one element, return it directly
                if (nums.Length == 1)
                    return nums[0];

                int low = 0;
                int high = nums.Length - 1;

                while (low < high)
                {
                    int middle = low + (high - low) / 2;

                    // If mid element is greater than the rightmost element, the minimum is in the right half
                    if (nums[middle] > nums[high])
                        low = middle + 1;
                    else
                        high = middle; // Mid element could be the minimum, so including it
                }

                return nums[low];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Edge Case: Negative numbers are not palindromes by definition

                if (x < 0)
                    return false;

                int originalNumber = x;
                int reversedNumber = 0;

                // Edge Case: Single-digit numbers (e.g., 0-9) are palindromes
                // This is automatically handled by the logic since reversedNumber will equal originalNumber


                while (x > 0)
                {
                    int lastDigit = x % 10;
                    // Added this digit to the reversed number
                    reversedNumber = reversedNumber * 10 + lastDigit;
                    x /= 10;
                }

                // Checking if the original number and the reversed number are equal
                // If they are equal, the number is a palindrome
                return originalNumber == reversedNumber;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Edge Case: If n is 0, the Fibonacci value is 0
                if (n == 0) return 0;
                // Edge Case: If n is 1, the Fibonacci value is 1
                if (n == 1) return 1;

                int previous = 0, current = 1;

                // Loop starts from 2 since the first two Fibonacci numbers (0 and 1) are already defined
                for (int i = 2; i <= n; i++)
                {
                    int next = previous + current;
                    // Move the 'previous' pointer to the current number
                    previous = current;

                    // Move the 'current' pointer to the newly calculated Fibonacci number
                    current = next;
                }

                return current;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}