using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Choose the task number (1 - 10, or 0 to exit).");
            int taskNumber;
            if (int.TryParse(Console.ReadLine(), out taskNumber))
            {
                switch (taskNumber)
                {
                    case 1:
                        Task1();
                        break;
                    case 2:
                        Task2();
                        break;
                    case 3:
                        Task3();
                        break;
                    case 4:
                        Task4();
                        break;
                    case 5:
                        Task5();
                        break;
                    case 6:
                        Task6();
                        break;
                    case 7:
                        Task7();
                        break;
                    case 8:
                        Task8();
                        break;
                    case 9:
                        Task9();
                        break;
                    case 10:
                        Task10();
                        break;
                    case 0:
                        Console.WriteLine("The program is exiting..");
                        return;
                    default:
                        Console.WriteLine("Incorrect task number. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Incorrect input format. Please enter an integer.");
            }
        }
        static void Task1()
        {
            Console.WriteLine("Task 1");
            Console.WriteLine("Enter the first array of words (space-separated):");
            string[] array1 = Console.ReadLine().Split();

            Console.WriteLine("Enter the second array of words (space-separated):");
            string[] array2 = Console.ReadLine().Split();

            int commonLength = FindCommonLength(array1, array2);

            Console.WriteLine($"The count of common words at the left and right is: {commonLength}");
        }

        static int FindCommonLength(string[] array1, string[] array2)
        {
            int minLength = Math.Min(array1.Length, array2.Length);
            int commonCount = 0;

            for (int i = 0; i < minLength; i++)
            {
                if (array1[i] == array2[i])
                {
                    commonCount++;
                }
                else
                {
                    break;
                }
            }

            return commonCount;
        }
    }
    static void Task2()
    {
        Console.WriteLine("Task 2");
        Console.WriteLine("Enter an array of integers (separated by spaces):");
        string[] inputArray = Console.ReadLine().Split();
        int[] numbers = new int[inputArray.Length];

        for (int i = 0; i < inputArray.Length; i++)
        {
            numbers[i] = int.Parse(inputArray[i]);
        }

        Console.WriteLine("Enter the number of rotations (k):");
        int k = int.Parse(Console.ReadLine());

        int n = numbers.Length;
        int[] sum = new int[n];

        for (int r = 0; r < k; r++)
        {
            int[] rotated = new int[n];

            for (int i = 0; i < n; i++)
            {
                int newPosition = (i + 1) % n;
                rotated[newPosition] = numbers[i];
            }

            Console.WriteLine($"Result after rotation {r + 1}: {string.Join(" ", rotated)}");

            numbers = rotated;
            for (int i = 0; i < n; i++)
            {
                sum[i] += numbers[i];
            }
        }

        Console.WriteLine("Sum after each rotation:");
        Console.WriteLine(string.Join(" ", sum));
    }
    static void Task3()
    {
        Console.WriteLine("Task 3");
        Console.WriteLine("Enter an array of integers (separated by spaces) where the number of elements is a multiple of 4:");
        int[] inputArr = Console.ReadLine()
            .Split() 
            .Select(int.Parse) 
            .ToArray(); 

        int k = inputArr.Length / 4; // arr.length = 4*k

        int[] upperRow = new int[2 * k]; 
        int[] lowerRow = new int[2 * k]; 

        for (int i = 0; i < k; i++) 
        {
            upperRow[i] = inputArr[k - 1 - i];
            upperRow[k + i] = inputArr[4 * k - i - 1];
        }
        for (int i = 0; i < 2 * k; i++) 
        {
            lowerRow[i] = inputArr[k + i];
        }
        int[] sumRow = new int[k * 2];
        for (int i = 0; i < k * 2; i++)
        {
            sumRow[i] = lowerRow[i] + upperRow[i];
        }
        Console.WriteLine(string.Join(" ", sumRow));

    }
    static void Task4()
    {
        Console.WriteLine("Task 4");

        {
            Console.WriteLine("Enter a positive integer (n) to find all prime numbers from 1 to n:");
            if (int.TryParse(Console.ReadLine(), out int n) && n >= 2)
            {
                bool[] primes = new bool[n + 1];
                for (int i = 2; i <= n; i++)
                {
                    primes[i] = true;
                }

                primes[0] = primes[1] = false;

                for (int p = 2; p <= n; p++)
                {
                    if (primes[p])
                    {
                        Console.Write(p + " ");

                        for (int i = 2 * p; i <= n; i += p)
                        {
                            primes[i] = false;
                        }
                    }
                }

                Console.WriteLine("\nPrime numbers from 1 to " + n + " have been printed.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a positive integer greater than or equal to 2.");
            }
        }
    }

    static void Task5()
    {
        Console.WriteLine("Task 5");

        Console.WriteLine("Enter the first string of characters:");
        string str1 = Console.ReadLine();

        Console.WriteLine("Enter the second string of characters:");
        string str2 = Console.ReadLine();

        int minLength = Math.Min(str1.Length, str2.Length);

        for (int i = 0; i < minLength; i++)
        {
            if (str1[i] < str2[i])
            {
                Console.WriteLine(str1);
                Console.WriteLine(str2);
                break;
            }
            else if (str1[i] > str2[i])
            {
                Console.WriteLine(str2);
                Console.WriteLine(str1);
                break;
            }
            else if (i == minLength - 1 && str1.Length != str2.Length)
            {
                Console.WriteLine(str1.Length < str2.Length ? str1 : str2);
                Console.WriteLine(str1.Length < str2.Length ? str2 : str1);
                break;
            }
        }

        if (str1 == str2)
        {
            Console.WriteLine(str1);
            Console.WriteLine(str2);
        }
    }
    static void Task6()
    {
        Console.WriteLine("Task 6");
        Console.WriteLine("Enter the array of integers (separated by spaces):");
        string[] inputArray = Console.ReadLine().Split();

        int[] numbers = new int[inputArray.Length];
        for (int i = 0; i < inputArray.Length; i++)
        {
            numbers[i] = int.Parse(inputArray[i]);
        }

        int start = 0;
        int len = 1;
        int bestStart = 0;
        int bestLen = 1;

        for (int pos = 1; pos < numbers.Length; pos++)
        {
            if (numbers[pos] == numbers[pos - 1])
            {
                len++;

                if (len > bestLen)
                {
                    bestStart = start;
                    bestLen = len;
                }
            }
            else
            {
                start = pos;
                len = 1;
            }
        }

        Console.WriteLine("Longest sequence of equal elements: ");
        for (int i = bestStart; i < bestStart + bestLen; i++)
        {
            Console.Write(numbers[i] + " ");
        }
    }
    static void Task7()
    {
        Console.WriteLine("Task 7");
        Console.WriteLine("Enter the array of integers (separated by spaces):");
        string[] inputArray = Console.ReadLine().Split();

        int[] numbers = new int[inputArray.Length];
        for (int i = 0; i < inputArray.Length; i++)
        {
            if (int.TryParse(inputArray[i], out int number))
            {
                numbers[i] = number;
            }
            else
            {
                Console.WriteLine($"Invalid input at index {i}: {inputArray[i]}");
                return;
            }
        }

        int maxLength = 1;
        int endIndex = 0;

        int currentLength = 1;
        int currentEndIndex = 0;

        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > numbers[i - 1])
            {
                currentLength++;

                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    endIndex = i;
                }
            }
            else
            {
                currentLength = 1;
            }
        }


        int[] longestIncreasingSubsequence = new int[maxLength];
        int currentIndex = endIndex - maxLength + 1;

        for (int i = 0; i < maxLength; i++)
        {
            longestIncreasingSubsequence[i] = numbers[currentIndex];
            currentIndex++;
        }

        Console.WriteLine("Longest increasing subsequence:");
        Console.WriteLine(string.Join(" ", longestIncreasingSubsequence));
    }

    public static void Task8()
    {
        Console.WriteLine("Task 8");
        Console.WriteLine("Enter a sequence of numbers separated by spaces:");
        string input = Console.ReadLine();
        string[] numberStrings = input.Split();

        int[] numbers = new int[numberStrings.Length];
        for (int i = 0; i < numberStrings.Length; i++)
        {
            if (int.TryParse(numberStrings[i], out int number))
            {
                numbers[i] = number;
            }
            else
            {
                Console.WriteLine($"Invalid input at index {i}: {numberStrings[i]}");
                return;
            }
        }

        Dictionary<int, int> numberCounts = new Dictionary<int, int>();

        foreach (int num in numbers)
        {
            if (numberCounts.ContainsKey(num))
            {
                numberCounts[num]++;
            }
            else
            {
                numberCounts[num] = 1;
            }
        }

        int mostFrequentNumber = numbers[0];
        int maxCount = numberCounts[numbers[0]];

        foreach (var kvp in numberCounts)
        {
            if (kvp.Value > maxCount)
            {
                mostFrequentNumber = kvp.Key;
                maxCount = kvp.Value;
            }
        }

        Console.WriteLine($"The most frequent number is {mostFrequentNumber}, which occurs {maxCount} times.");
    }
    public static void Task9()
    {
        {
            Console.WriteLine("Task 9");
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            Console.WriteLine("Enter a lowercase word:");
            string word = Console.ReadLine();

            Console.WriteLine("Indices of letters in the alphabet:");

            foreach (char letter in word)
            {
                int index = Array.IndexOf(alphabet, letter);
                if (index != -1)
                {
                    Console.WriteLine($"{letter}: {index}");
                }
                else
                {
                    Console.WriteLine($"{letter}: Not found in the alphabet.");
                }
            }
        }
    }
    public static void Task10()
    {
        Console.WriteLine("Task 10");

        Console.WriteLine("Enter the sequence of numbers (space-separated):");
        int[] inputArr = Console.ReadLine()
        .Split()
        .Select(int.Parse)
        .ToArray();

        Console.WriteLine("Enter the difference here: ");
        int n = int.Parse(Console.ReadLine());
        int counter = 0;
        string[] pairs = new string[inputArr.Length];

        for (int i = 0; i < inputArr.Length; i++)
        {
            for (int j = i + 1; j < inputArr.Length; j++)
            {
                if (inputArr[i] - inputArr[j] == n || inputArr[j] - inputArr[i] == n)
                {
                    pairs.SetValue(value: $"{inputArr[i]},{inputArr[j]}", counter);
                    counter++;
                }
            }
        }
        Console.WriteLine("The number of pairs: " + counter);
        Console.Write($"Pairs of elements with difference {n} -> ");
        foreach (string pair in pairs)
        {
            if (pair != null) Console.Write("{" + pair + "} ");
        }
    }
}

