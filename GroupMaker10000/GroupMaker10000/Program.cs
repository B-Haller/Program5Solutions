using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Brandon Haller

namespace GroupMaker10000
{
    class Program
    {
        static void Main(string[] args)
        {
            GroupMaker10000(4, 20);
            Console.ReadKey();
        }
        /// <summary>
        /// makes a group maker that assigns people randomly to groups according
        /// to group size and class size
        /// </summary>
        /// <param name="groupSize">how many people in each group</param>
        /// <param name="classSize">how many people in each class</param>
        static void GroupMaker10000(int groupSize, int classSize)
        {
            //new random number generate, and two lists to maniuplate groups
            Random rng = new Random();
            List<int> groupList = new List<int>();
            List<int> classList = new List<int>();
            int groupCounter = 1;
            
            //populate class list
            for (int i = 1; i <= classSize; i++)
            {
                classList.Add(i);
                
            }
            //using random index, add students to group
            //while removing them from list until list is empty
            while (classList.Count() > 0)
            {
                int randomNum = rng.Next(0, classList.Count());
                int aStudent = classList[randomNum];
                groupList.Add(aStudent);
                classList.Remove(aStudent);
                
                //if group list meets params, or classlist is empty,
                //write to console the group and the elemnets in group
                if(groupList.Count() == groupSize || classList.Count() == 0)
                {
                    Console.WriteLine("Group {0}", groupCounter);
                    //write to console using foreach element in group
                    foreach (int element in groupList)
                    {
                        Console.WriteLine(element);
                    }
                    groupCounter++;
                    //clear grouplist and begin loop again
                    groupList.Clear();
                    
                }
            }
        }
    }
}
