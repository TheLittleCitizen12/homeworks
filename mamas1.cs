using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstcsharp
{
    enum Season
    {
        Summer,
        Winter,
        Spring,
        Fall
    }

    class Delivery
    {
        
        private int quantity;
        private double price;

        public Delivery(int quantity, double price)
        {
            this.quantity = quantity;
            this.price = price;
        }

        public double GetPrice()
        {
            return this.price;
        }

        public int Quantity
        {
            get { return this.quantity; }
            set { this.quantity = value; }
        }

        public override string ToString()
        {
            string Squantity = Convert.ToString(this.quantity);
            string Sprice = Convert.ToString(this.price);
            return ("quantity: " + Squantity + " price: " + Sprice);
        }
    }

    class Stock
    {
        private Queue<Delivery> deliveries;
        private int numOfSold = 0;
        

        public Stock()
        {
            this.deliveries=new Queue<Delivery>();
        }

        public void Buy(int quantity, double price)
        {
            Delivery delivery = new Delivery(quantity, price);
            this.deliveries.Enqueue(delivery);
            
        }

        public double Sell(int quantity, double price)
        {
            this.numOfSold += quantity;
            double profit=0;
            while(quantity > 0)
            {
                if (this.deliveries.Peek().Quantity > quantity)
                {
                    this.deliveries.Peek().Quantity -= quantity;
                    profit += quantity * (price - this.deliveries.Peek().GetPrice());
                    quantity = 0;
                }
                else if(this.deliveries.Peek().Quantity <= quantity)
                {
                    profit += this.deliveries.Peek().Quantity* (price - this.deliveries.Peek().GetPrice());
                    quantity -= this.deliveries.Peek().Quantity;
                    this.deliveries.Dequeue();
                }
                
            }
            return profit;
            
        }

        public int NumOfSold()
        {
            return this.numOfSold;
        }

        public override string ToString()
        {
            string endString = "";
            Delivery[] arr = this.deliveries.ToArray();

            for (int i =0; i < this.deliveries.Count; i++)
            {
                endString += Convert.ToString(arr[i]);
                endString += "\n";
            }
            return endString;
        }


    }


    class Program
    {
        static void Main(string[] args)
        {
            
            string str1 = "the sun is shining and so are you";
            string letter = "s";
            Console.WriteLine(NumOfCharInStr(str1, letter));
            Console.ReadLine();

            int[] my_arr = { 8, 2, 5, 17, 2 };
            Console.WriteLine("the biggest number in the array is: " + MaxNun(my_arr));
            Console.ReadLine();


            int num = 3897637;
            Console.Write("is the num " + num + " has even digit?\n");
            Console.WriteLine(EvenDigit(num));
            Console.ReadLine();


            int num1 = 123456;
            Console.WriteLine(TurnNumber(num1));
            Console.ReadLine();
            

            Console.Write("Write a numer: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("f(" + num2 +")=2*f(n-1)+3 = " + Rec1(num2)+"\n f(0)=2");
            Console.ReadLine();

            bool key = true;
            string word1 = "abba";
            string word2 = "abbc";
            Console.Write("Check if the word " + word1 +" is a polindrom: ");
            Console.WriteLine(Polindrom(word1,key));
            Console.ReadLine();
            Console.Write("Check if the word " + word2 + " is a polindrom: ");
            Console.WriteLine(Polindrom(word2, key));
            Console.ReadLine();

            Console.WriteLine("Enter two numbers to check what their gcd");
            Console.Write("Enter a number: ");
            int number1 = Convert.ToInt32( Console.ReadLine());
            Console.Write("Enter another number: ");
            int number2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("The gcd of "+number1+" and "+number2 +" is: "+Gcd(number1, number2));
            Console.ReadLine();
            
            
            ListStack();
            
            
            List<int> list1 = new List<int>()
            { 1,2,3,4,5,6};
            
            List<int> list2 = new List<int>();
            ListRec(list1 , list2);
            
            
            List<string> list = new List<string>()
            { "summer", "summer", "fall", "spring" };
            DictionStr(list);
            
            
            
            Console.WriteLine("0. Summer");
            Console.WriteLine("1. Winter");
            Console.WriteLine("2. Spring");
            Console.WriteLine("3. Fall");
            int val = Convert.ToInt32(Console.ReadLine());
            SeasonQoute(val);
            Console.ReadLine();
            

            RemainderEven();
            Console.ReadLine();
            
            
            string str = "sdfyesfhhhjj yesuy yeshhh";
            string tat = "yes";
            Console.WriteLine("The tat string: " + tat +" showed in str: " + str +" "+ Convert.ToString(CountTatStr(str, tat))+" times");
            Console.ReadLine();
            

            int[,] arr2d = new int[2, 4]
            {
                {1,2,3,4 },
                {2,1,3,4 }
            };
            int row1 = 1;
            int row2 = 2;
            int col = 4;
            Console.WriteLine("if the sum of numbers in the first line equal to the second line the code will return 1, else 0:");
            Console.WriteLine(Convert.ToString (SumOfRowEven(arr2d, row1, row2,col)));
            Console.ReadLine();
            
            
            Console.Write("Enter a number of intigers you want to be in the array: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            RandomArr(arr, n);
            Console.ReadLine();
            

            string[] str3 = { "love", "code", "food", "dog" };
            int num3 = 4;
            Console.WriteLine("the number of string that thier lenght equal to str = "+Convert.ToString(LengthOfArrEqualToNum(str3, num3)));
            Console.ReadLine();

            
        }
        //2.1.1
        static string NumOfCharInStr(string str1, string letter)
        {
            int i = 0, counter = 0;
            for (i = 0; i < str1.Length; i++)
            {
                if (str1[i] == letter[0])
                {
                    counter++;
                }
            }
            return ("The letter " + letter + " showed " + counter + " times in the string");

        }
        //2.1.2
        static Int32 MaxNun(int[] my_arr)
        {
            int j = 0, max_num = Int32.MinValue;
            for (j = 0; j < 5; j++)
            {
                if (max_num < my_arr[j])
                    max_num = my_arr[j];
            }
            return (max_num);

        }
        //2.1.3
        static string EvenDigit(int num)
        {

            int even_number = 0;
            while (num != 0)
            {
                if ((num % 10) % 2 == 0)
                {
                    even_number = 1;
                    return ("true");
                }
                num = num / 10;
            }
            return ("false");
        }
        //2.1.4
        static int TurnNumber(int num1)
        {
            int new_num = 0;
            if (num1 < 10)
            {
                return (num1);
            }
            while (num1 > 0)
            {
                new_num = new_num * 10;
                new_num = new_num + (num1 % 10);
                num1 = num1 / 10;
            }
            return (new_num);
        }
        //2.2.1
        static int Rec1(int num2) // f(n)= 2*f(n-1)+3   f(0)= 2
        {
            if (num2 == 0)
                return 2;
            else
            {
                return (2 * Rec1(num2 - 1)) + 3;
            }


        }
        //2.2.2
        static bool Polindrom(string word, bool key)
        {
            int x = word.Length;
            if (word.Length == 1)
                return key;
            else
            {

                return (word[0] == word[x - 1] ? Polindrom(word.Remove(0, x - 1), key) : key = false);
            }
        }
        //2.2.3
        static int Gcd(int number1, int number2)
        {
            return (number2 == 0 ? number1 : Gcd(number2, number1 % number2));
        }
        //4.1
        static void ListStack()
        {
            List<int> list1 = new List<int>()
            { 1,2,3,4,5,6};

            List<int> list2 = new List<int>();
            int i, n = list1.Count;
            Stack myStack = new Stack();


            for (i = 0; i < n; i++)
            {
                myStack.Push(list1[i]);
            }
            for(i=0;i<n;i++)
            {
                list2.Add(Convert.ToInt32(myStack.Pop()));
            }
            Console.WriteLine(String.Join("; ", list2));
            Console.ReadLine();


        }
        //4.2
        static void ListRec(List<int> list1, List<int> list2)
        {
            if(list1.Count == 0)
            {
                 return;
            }
            list2.Add(list1[list1.Count - 1]);
            list1.RemoveAt(list1.Count-1);
            ListRec(list1,list2);
        }
        //5
        static Dictionary<string, int> DictionStr(List<string> list)
        {
            Dictionary<string, int> myDict =
            new Dictionary<string, int>();
            int i, count=1;
            for(i=0;i<list.Count;i++)
            {
                if(myDict.ContainsKey(list[i])== false)// the string is not in the dictionary
                {
                    count = 1;
                    myDict.Add(list[i], count);
                }
                else
                {
                    myDict.Remove(list[i]);
                    count++;
                    myDict.Add(list[i], count);
                }
            }
            return myDict;  
        }
        //6
        static void SeasonQoute(int val)
        {
            if (val == (int)Season.Summer)
                Console.WriteLine("LIFE IS A BEACH, ENJOY THE WAVES.");
            else if (val == (int)Season.Winter)
                Console.WriteLine("WINTER IS COMING");
            else if (val == (int)Season.Spring)
            {
                Console.WriteLine("DEAR WINTER, I'M BREAKING UP WITH YOU. IT'S TIME I START SEEING OTHER SEASON.");
                Console.WriteLine("LIKE SPRING HE GIVES ME FLOWERS");
            }
            else
                Console.WriteLine("'TIS THE SEASON TO BE FALL-Y");




        }
        //7
        static void RemainderEven()
        {
            int[] Arr = new int[25] { 5, 9, 7, 11, 8, 12, 10, 33, 1, 4, 5,6,7,8,9,2,3,1,4,5,6,7,8,8,9};
            int i, num=0, middle = 25/2;
            

            for(i = 0; i < 25; i= i+2)
            {
                num = Arr[middle] - Arr[i];
                if(num<0)
                {
                    num = num * -1;
                }
                Console.WriteLine(Convert.ToString(num));
                Console.ReadLine();

            }
        }
        //8
        static int CountTatStr(string str, string tat)
        {
            int i,j,key=0,count=0;
            for(i=0; i< str.Length; i++)
            {
                key = 0;
                if (str[i]== tat[0])
                {
                    for(j=0; j< tat.Length; j++)
                    {
                        if (str[i] != tat[j])
                        {
                            i++;
                            key = 1;
                        }
                        
                    }
                    if (key == 1)
                        count++;
                }
            }
            return count;
        }
        //9
        static int SumOfRowEven(int [,] arr2d, int row1, int row2,int col)
        {
            int i, j, sum1 = 0, sum2 = 0;
            for(i=0; i<row2; i++)
            {
                for(j=0; j<col; j++)
                {
                    sum1 = sum1 + arr2d[i, j];
                }
                if(i == 0)
                {
                    sum2 = sum1;
                }
                else
                {
                    if (sum1 == sum2)
                        return 1;
                    else
                        return 0;
                }
                sum1 = 0;
                
            }
            return 0;
        }
        //10
        static void RandomArr(int [] arr, int n)
        {
            var rand = new Random();
            int rand_num;
            int i=0;
            while(i<n)
            {
                if(i == 0)
                {
                    rand_num = rand.Next(10,100);
                    if(rand_num%2 == 0)
                    {
                        arr[i] = rand_num;
                        i++;
                    }
                }
                else if(i%2 == 0)
                {
                    rand_num = rand.Next(10,100);
                    if(rand_num%2 == 0)
                    {
                        arr[i] = rand_num;
                        i++;
                    }
                }
                else //i%2 != 0
                {
                    rand_num = rand.Next(10,100);
                    if(rand_num%2 != 0)
                    {
                        arr[i] = rand_num;
                        i++;
                    }
                }
            }
            foreach (var item in arr)
            {
                Console.WriteLine(item);

            }
        }
        //1
        static int LengthOfArrEqualToNum(string [] str, int num)
        {
            int i,count=0;
            for(i=0; i< str.Length; i++)
            {
                if(str[i].Length == num)
                {
                    count++;
                }
            }
            return count;

        }


    }
    }
