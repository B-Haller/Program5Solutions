using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Course course1 = new Course();
            Course course2 = new Course("SeedPaths", "a");

            //.DisplayCourseInfo();
            //course2.DisplayCourseInfo();

            Student Pat = new Student("Pat", "McClary");
            Pat.CoursesTaken.Add(new Course("Professional Development", "B"));
            Pat.CoursesTaken.Add(new Course("Programming", "D"));
            Pat.CoursesTaken.Add(new Course("Being Rad", "A"));

            Student Kyle = new Student("Kyle", "Wood");
            Kyle.CoursesTaken.Add(new Course("Whoculture", "A"));
            Kyle.CoursesTaken.Add(new Course("History of the Doctor", "B"));

            Pat.PrintAllStudentInfo();
            Kyle.PrintAllStudentInfo();
            Console.ReadKey();
        }
    }

    public class Course
    {
        //1. Define its properties
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        //creating a read-only property (no set)
        private int _gradePoints;

        public int GradePoints
        {
            get
            {
                return _gradePoints;
            }
        }

        private string _letterGrade;

        public string LetterGrade
        {
            get
            {
                return _letterGrade;
            }
            set
            {
                _letterGrade = value.ToUpper();
                //also change the value of the
                //grade points
                switch (_letterGrade)
                {
                    case "A":
                        _gradePoints = 4;
                        break;
                    case "B":
                        _gradePoints = 3;
                        break;
                    case "C":
                        _gradePoints = 2;
                        break;
                    case "D":
                        _gradePoints = 1;
                        break;
                    case "F":
                        _gradePoints = 0;
                        break;
                    default:
                        _gradePoints = 0;
                        break;
                }
            }
        }

        //step 2: constructors
        public Course()
        {
            //paramerterless constructor
            this.Name = "Undefined";
            this.LetterGrade = "F";

        }

        //overload
        public Course(string courseName, string letterGrade)
        {
            this.Name = courseName;
            this.LetterGrade = letterGrade;
        }

        //step 3: create its methods
        public void DisplayCourseInfo()
        {
            Console.WriteLine("{0}, {1}", this.Name, this.GradePoints);
        }
    }

    public class Student
    {
        //step 1: define properties for a student
        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }

        }
        
        private string _lastName;
        public string LastName
        {
            get{return _lastName;}
            set{_lastName = value;}

        }

        private List<Course> _coursesTaken;
        public List<Course> CoursesTaken
        {
            get{ return _coursesTaken;}
            set{ _coursesTaken = value;}

        }
        //read only
        public double GPA
        {
            get
            {
                if (this.CoursesTaken.Any())
                {                
                     return this.CoursesTaken.Average(x => x.GradePoints);
                }
                else
                {
                    return -1;
                }
            }
        }

        //Step 2: constructors

        public Student()
        {
            this.FirstName = "Undefined";
            this.LastName = "Undefined";
            this.CoursesTaken = new List<Course>();

        }
        //colon this() calls the parameterless constructor above
        public Student(string firstName, string lastName) : this()
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.CoursesTaken = new List<Course>();
        }

        //step 3: methods
        public void PrintAllStudentInfo()
        {
            Console.WriteLine("Student: {0}, {1}", this.FirstName, this.LastName);
            this.CoursesTaken.ForEach(x => x.DisplayCourseInfo());
            Console.WriteLine("GPA: {0}", this.GPA);

        }
    }
}
