using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
//created by Andrew Perkins, October 3, 2017
namespace DataStructures2
{
    class Program
    {
        static void Main(string[] args)
        {
            //declare objects for use in this assignment
            Stack<string> sStack = new Stack<string>();
            Queue<string> sQueue = new Queue<string>();
            Dictionary<string, int> SIdictionary = new Dictionary<string, int>();
            Stopwatch stopwatch = new Stopwatch();
            TimeSpan timespan;
            //main menu 
            void MainMenu()
            {
                int input = 0;
                Console.WriteLine("\n1. Stack\n2. Queue\n3. Dictionary\n4. Exit\n");
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    switch(input)
                    {
                        case 1: stackMenu();
                            break;
                        case 2: queueMenu();
                            break;
                        case 3: dictionaryMenu();
                            break;
                        default: break;
                    }
                }
                catch
                {
                    Console.Write("\nEnter a menu choice 1 - 4: ");
                    MainMenu();
                }
            }
            //menu for the stack structure
            void stackMenu()
            {
                int input = 0;
                string sinput;
                Console.WriteLine("\n1. Add one time to Stack\n2. Add Huge List of Items to Stack\n3. Display Stack\n4. Delete from Stack\n5. Clear Stack\n6. Search Stack\n7. Return to Main Menu\n");
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.Write("\nEnter a menu choice 1 - 7: ");
                    stackMenu();
                }
                switch (input)
                {
                    case 1: //add to stack
                        Console.Write("What string would you like to add?: ");
                        sinput = Console.ReadLine();
                        sStack.Push(sinput);
                        stackMenu();
                        break;
                    case 2: //clear stack
                        sStack.Clear();
                        for(int i=0; i<2000; i++)
                        {
                            sStack.Push("New Entry " + (i + 1));
                        }
                        stackMenu();

                        break;
                    case 3: //display stack
                        Console.Write("displaying stack: \n");
                        try
                        {
                            foreach (string foosball in sStack)
                            {
                                Console.Write(foosball);
                            }
                        }
                        catch(Exception e)
                        {
                            Console.Write("error displaying structure", e);
                            stackMenu();
                        }
                        stackMenu();

                        break;
                    case 4: //delete from stack
                        Console.Write("Which Item should be deleted? \n");
                        sinput = Console.ReadLine();
                        if (sStack.Contains(sinput))
                        {
                            List<string> list = new List<string>();

                            string temp;
                            while (sStack.Count > 0)
                            {
                                temp = sStack.Pop();
                                //put in the list if it's not the inputed string

                                if (sinput != temp)
                                {
                                    list.Add(temp);
                                }
                            }                    
                            for (int i = list.Count - 1; i >= 0; i--)
                            {
                                sStack.Push(list[i]);
                            }
                            Console.WriteLine("\n'{0}' was removed from the stack.", sinput);
                        }
                        else { Console.WriteLine("\n'{0}' is not in the stack.", sinput); }
                        stackMenu();

                        break;
                    case 5:
                        sStack.Clear();
                        Console.Write("stack cleared");
                        stackMenu();

                        break;
                    case 6:
                        Console.Write("What would you like to search for?: ");
                        sinput = Console.ReadLine();
                        //reset and start the stopwatch
                        stopwatch.Reset();
                        stopwatch.Start();
                        //check if the input is in the stack
                        if (sStack.Contains(sinput))
                        {
                            Console.WriteLine("\n'{0}' is in the stack!", sinput);
                        }
                        else
                        {
                            Console.WriteLine("\nSorry, '{0}' is not in the stack.", sinput);
                            Console.ReadKey();
                        }
                        //stop stopwatch
                        stopwatch.Stop();
                        //show elapsed time
                        timespan = stopwatch.Elapsed;
                        getElapTime(timespan);
                        stackMenu();
                        break;

                    default:
                        MainMenu();
                        break;
                }
            }
            //menu for the queue structure
            void queueMenu()
            {
                int input = 0;
                string sinput;
                Console.WriteLine("\n1. Add one time to Queue\n2. Add Huge List of Items to Queue\n3. Display Queue\n4. Delete from Queue\n5. Clear Queue\n6. Search Queue\n7. Return to Main Menu\n");
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.Write("\nEnter a menu choice 1 - 7: ");
                    queueMenu();
                }
                switch (input)                {
                    case 1:
                        Console.Write("What would you like to add?: ");
                        sinput = Console.ReadLine();
                        sQueue.Enqueue(sinput);
                        queueMenu();
                        break;
                    //clear queue then add 2000 "new entries"
                    case 2:
                        sQueue.Clear();
                        for (int i = 1; i < 2001; i++)
                        {
                            sQueue.Enqueue("New Entry " + i);
                        }
                        Console.WriteLine("Huge list has been added to the queue");
                        queueMenu();
                        break;
                    //print out the queue
                    case 3:
                        if (sQueue.Count > 0)
                        {
                            foreach (string shoe in sQueue)

                            {
                                Console.WriteLine(shoe);
                            }
                        }
                        else
                        {
                            Console.WriteLine("The queue is empty.");
                        }
                        queueMenu();
                        break;
                    //delete element from queue
                    case 4:
                        Console.Write("What would you like to delete?: ");
                        sinput = Console.ReadLine();
                        //do only if in queue
                        if (sQueue.Contains(sinput))
                        {
                            //list holds pop'ed elements
                            List<string> list = new List<string>();
                            string temp;
                            while (sQueue.Count > 0)
                            {
                                //dequeue into temp
                                temp = sQueue.Dequeue();
                                //if its not the input, put in list

                                if (sinput != temp)
                                {
                                    list.Add(temp);
                                }
                            }
                            //but pack in queue FIFO order
                            for (int i = 0; i < list.Count; i++)
                            {
                                sQueue.Enqueue(list[i]);
                            }
                            Console.WriteLine("\n'{0}' was removed from the queue.", sinput);
                        }
                        else
                        {
                            Console.WriteLine("\n'{0}' is not in the queue.", sinput);
                        }
                        queueMenu();
                        break;
                    //clear the queue
                    case 5:
                        sQueue.Clear();
                        Console.WriteLine("\nThe queue has been cleared.");
                        queueMenu();
                        break;
                    //search queue
                    case 6:
                        Console.Write("What would you like to search for?: ");
                        sinput = Console.ReadLine();
                        //reset and start watch
                        stopwatch.Reset();
                        stopwatch.Start();
                        //check if it's in the queue
                        if (sQueue.Contains(sinput))
                        {
                            Console.WriteLine("\n'{0}' is in the queue!", sinput);
                        }
                        else
                        {
                            Console.WriteLine("\nSorry, '{0}' is not in the queue.", sinput);
                        }
                        //stop time
                        stopwatch.Stop();
                        //show elapsed time
                        timespan = stopwatch.Elapsed;
                        getElapTime(timespan);
                        queueMenu();
                        break;
                    //exit to main menu
                    default:
                        MainMenu();
                        break;
                }
            }
            //menu for the dictionary structure
            void dictionaryMenu()
            {
                int input = 0;
                string sinput;
                Console.WriteLine("\n1. Add one item to Dictionary\n2. Add Huge List of Items to Dictionary\n3. Display Dictionary\n4. Delete from Dictionary\n5. Clear Dictionary\n6. Search Dictionary\n7. Return to Main Menu\n");
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.Write("\nEnter a menu choice 1 - 7: ");
                    dictionaryMenu();
                }
                switch (input)
                {
                    case 1:
                        Console.Write("What Key string would you like to add?: ");
                        sinput  = Console.ReadLine();
                        int key = SIdictionary.Count();
                        //Console.Write("\nWhat Value would you like to add for {0}?: ", input);
                        ////make sure value is int
                        
                        //    try
                        //    {
                        //        key = Convert.ToInt32(Console.ReadLine());
                        //    }

                        //    catch
                        //    {
                        //        Console.Write("Enter an integer for the value: ");
                                
                        //    }

                        SIdictionary.Add(sinput, key);
                        dictionaryMenu();
                        break;
                    //clear dict and add 2000 new entries

                    case 2:

                        SIdictionary.Clear();
                        for (int i = 1; i < 2001; i++)

                        {
                            SIdictionary.Add("New Entry " + i, i);
                        }
                        Console.WriteLine("Huge list has been added to the dictionary");
                        dictionaryMenu();
                        break;
                    //print out dict

                    case 3:

                        if (SIdictionary.Count > 0)

                        {
                            foreach (KeyValuePair<string, int> kvp in SIdictionary)

                            {
                                Console.WriteLine("{0}\t{1}", kvp.Key, kvp.Value);
                            }
                        }
                        else
                        {
                            Console.WriteLine("The dictionary is empty.");

                        }
                        dictionaryMenu();
                        break;
                    //delete from dict
                    case 4:
                        Console.Write("What would you like to delete?: ");
                        sinput = Console.ReadLine();
                        //if in dict, use remove methid

                        if (SIdictionary.ContainsKey(sinput))
                        {
                            SIdictionary.Remove(sinput);

                            Console.WriteLine("\n'{0}' was removed from the dictionary.", sinput);
                        }
                        else

                        {
                            Console.WriteLine("\n'{0}' is not in the dictionary.", sinput);
                        }
                        dictionaryMenu();
                        break;
                    //clear dict

                    case 5:
                        SIdictionary.Clear();
                        Console.WriteLine("\nThe dictionary has been cleared.");
                        dictionaryMenu();

                        break;



                    //search dict

                    case 6:

                        Console.Write("What would you like to search for?: ");

                        sinput = Console.ReadLine();



                        //reset and start sw

                        stopwatch.Reset();
                        stopwatch.Start();
                        //check if in dict or not
                        if (SIdictionary.ContainsKey(sinput))

                        {

                            Console.WriteLine("\n'{0}' is in the dictionary!", sinput);
                        }
                        else
                        {
                            Console.WriteLine("\nSorry, '{0}' is not in the dictionary.", sinput);
                        }
                        //stop sw
                        stopwatch.Stop();
                        //print out elapTime
                        timespan = stopwatch.Elapsed;
                        getElapTime(timespan);
                        dictionaryMenu();
                        break;
                    //menu choice 7
                    default:
                        MainMenu();
                        break;
                }
            }
            
            MainMenu();
        }
        public static void getElapTime(TimeSpan ts)
        {
            //format time string then print out
            //            string et = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //                ts.Hours, ts.Minutes, ts.Seconds,
            //                ts.Milliseconds / 10);
            //            Console.WriteLine("Elapsed time: {0}", et);
            Console.WriteLine("\nElaspsed time: {0} milliseconds", ts.TotalMilliseconds.ToString());
        }
    }
}
