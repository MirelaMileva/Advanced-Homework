using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLigth = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            var cars = new Queue<string>();

            string input = Console.ReadLine();
            bool crash = false;
            string crashedCar = string.Empty;
            int hitIndex = -1;
            int count = 0;

            while (input != "END")
            {
                if (input == "green")
                {
                    int currentGreenLigth = greenLigth;
                    while (currentGreenLigth > 0 && cars.Any())
                    {
                        string currentCar = cars.Peek();
                        int carLength = currentCar.Length;

                        if (carLength <= currentGreenLigth)
                        {
                            currentGreenLigth -= carLength;
                            cars.Dequeue();
                            count++;
                        }
                        else
                        {
                            carLength -= currentGreenLigth;

                            if (carLength <= freeWindow)
                            {
                                cars.Dequeue();
                                count++;
                            }
                            else
                            {
                                crash = true;
                                crashedCar = currentCar;
                                hitIndex = currentGreenLigth + freeWindow;
                                
                            }
                            break;
                        }

                    }
                }
                else
                {
                    cars.Enqueue(input);
                }

                if (crash)
                {
                    break;
                }

                input = Console.ReadLine();
            }

            if (crash)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{crashedCar} was hit at {crashedCar[hitIndex]}.");
            }
            else
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{count} total cars passed the crossroads.");
            }
        }                                                                                                                                                                                                                                                     
    }
}
