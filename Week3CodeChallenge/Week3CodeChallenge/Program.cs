using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3CodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            FindNPrime(10001);
            EvenFibonacciSequencer(10001);
            LongestCollatzSequence();

            Console.ReadKey();
        }

        static void FindNPrime(int nthPrime)
        {
            //new var for number of primes
            int numberOfPrimes = 0;
            //long to hold number
            long number = 1;
            //while the number of primes to find doesnt equal number of primes found
            while (nthPrime != numberOfPrimes)
            {
                //if number is even
                if (number % 2 == 0)
                {
                    //increment number and continue
                    number++;
                    continue;
                }
                else
                {
                    //set bool to is prime is true
                    bool isPrime = true;
                    //loop through, starting at 2 and continuing untl you reach the number
                    for (int i = 2; i < number; i++)
                    {
                        //if number can be divided by any of these numbers
                        if (number % i == 0)
                        {
                            //it is not a prime
                            isPrime = false;
                        }

                    }
                    //if it isn't
                    if (isPrime == false)
                    {
                        //increment number and continue
                        number++;
                        continue;
                    }
                        //if it is
                    else
                    {
                        //increment number of primes found
                        numberOfPrimes++;
                        //increment number
                        number++;
                    }
                }
                
            }
            

            //write number, subtracting one to account for the final incrament of the loop
            Console.WriteLine(number-1);
    
        }

        static void EvenFibonacciSequencer(int maxValue)
        {
            //set int for first
            int current = 1;
            //set int for second
            int next = 2;
            //set int for temp
            int temp = 0;
            //set int for sum
            int sum = 0;

            //while the next number is less than maxValue
            while (next < maxValue)
            {
                //if it is even
                if (next % 2 == 0)
                
                    //add even fib number to sum
                    sum += next;
                    //set temp to equal current number and next number
                    temp = current + next;
                    //current number becomes next number
                    current = next;
                    //next number becomes temp number
                    next = temp;
                
            }

            Console.WriteLine(sum);
            
        }

        static void LongestCollatzSequence()
        {
            //set vars, longest sequence number is 0
            //longest sequence number starts at 0
            long longestStepNumber = 0;
            long longestStepLength = 0;

            //loops through, starting at 2 and going till it is less than a mil
            for (int i = 2; i < 1000000; i++)
            {
                //new var to hold i
                long num = i;
                //temp length of steps
                long tempStepLength = 1;
                //while num does not equal 1
                while (num != 1)
                {
                    //if divisible by 2
                    if (num % 2 == 0)
                    {
                        //set num equal to itseld divided by 2
                        num = num / 2;
                    }
                    else
                    {
                        //if not, set it equal to itself times 3 plus 1
                        num = ((3 * num) + 1);
                    }
                    //increase the length counter after each loop
                    tempStepLength++;
                }
                //if temp step length is greater than previous longest step length
                if (tempStepLength > longestStepLength)
                {
                    //replace longest with temp
                    longestStepLength = tempStepLength;
                    //set that number to longest step
                    longestStepNumber = i;
                }
            }

            Console.WriteLine(longestStepNumber);
            
        }
    }
}
