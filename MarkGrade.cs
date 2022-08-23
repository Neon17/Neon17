using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SubjectChoice;
using StudentTeacher;

namespace MarksGrade
{
    //We can create Global things like GlobalSubMarks and like others as separate class
    //And we can inherit them
    public static class GlobalMarks {
        static int WhilePrinting;
        public static int TotalSubMarks = 0;
        public static int[,] GlobalSubMarks = new int[GlobalSubject.TotalNumber,4];
        static GlobalMarks () {
            int count = 0;
            foreach (var item in GlobalSubject.globalSubject.Keys){
                GlobalSubMarks[count,0] = item;
                Console.WriteLine("{0}: ",GlobalSubject.globalSubject[item]);
                Console.Write("Total Marks in Theory: ");
                GlobalSubMarks[count,1] = Convert.ToInt32(Console.ReadLine());
                Console.Write("Total Marks in Practical: ");
                GlobalSubMarks[count,2] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Processing Total Marks! Wait...");
                GlobalSubMarks[count,3] = GlobalSubMarks[count,1] + GlobalSubMarks[count,2];
                count++;
                TotalSubMarks++;
            }
        }
        public static void CheckIfCall () {
            //"Checking whether this GlobalMarks is called or not by simply calling this function!"
            //Because static constructor is initialized before static members
        }
        public static void GlobalsetupAdd () {
                Console.WriteLine("Total Marks is setup for all available subjects!");
        }
        public static void GlobalPrintInfo() {
            WhilePrinting = 0;
            Console.WriteLine("Subject ID\t\tSubject Name\t\tTheory\t\tPractical\t\tTotal Marks");
            for (int i = 0; i<GlobalSubject.TotalNumber; i++){
                Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}",GlobalSubMarks[i,0],GlobalSubject.globalSubject[GlobalSubMarks[i,0]],GlobalSubMarks[i,1],GlobalSubMarks[i,2],GlobalSubMarks[i,3]);
                WhilePrinting++;
            }
            WhilePrinting = 0;
        }
    }
    class Marks { //Marks should inherit Subject
            //GlobalSubMarks are made in ascending order of Subject ID number
            //public static int[,] GlobalSubMarks = new int[Subject.TotalNumber,4];
            //Subject.TotalNumber cannot be zero
            //4 is for Theory Practical and Total Marks  
            public int[,] SubMarks; //This is for chosen subjects in students  
            Subject s1;
            //public SortedList <int, int> mark = new SortedList <int, int>();
            //Id and marks are stored
            //Confusion: Whether to control it by Subject or StudentID (which ultimately controls subject)
            public Marks (Subject s1) {
                GlobalMarks.CheckIfCall();
                this.s1 = s1;
                SubMarks = new int[s1.ChoiceNumber,4];
                int count = 0;
                //Here should be checking of whether given marks exceeded the total marks criteria TheoryCheck PracticalCheck
                foreach (var item in s1.sl.Keys){
                    SubMarks[count,0] = item;
                    Console.WriteLine("{0}: ",s1.sl[item]);
                    //In TheoryCheck or PracticalCheck if possible, make pass marks and also prints some status like PASSED FAILED
                        //Also criteria
                    bool status = false;
                    do{
                        Console.Write("Obtained Marks in Theory: ");
                        SubMarks[count,1] = Convert.ToInt32(Console.ReadLine());
                        if (!TheoryCheck(SubMarks[count,1],count)){
                            SubMarks[count,1] = 0;
                            Console.WriteLine("Invalid Marks! Please fill again!");
                            status = false;
                        }
                        else {status = true;}
                    }while (!status);
                    do {
                        Console.Write("Obtained Marks in Practical: ");
                        SubMarks[count,2] = Convert.ToInt32(Console.ReadLine());
                        if (!PracticalCheck(SubMarks[count,2],count)){
                            SubMarks[count,2] = 0;
                            Console.WriteLine("Invalid Marks! Please fill again!");
                            status = false;
                        }
                        else {status = true;}
                    }while (!status);

                    Console.WriteLine("Processing Total Marks! Wait...");
                    SubMarks[count,3] = SubMarks[count,1] + SubMarks[count,2];
                    count++;
                }
            }
            bool TheoryCheck(int h, int count){
                int gCount = -1; //gCount = GlobalCount
                int x = SubMarks[count,0];
                for (int i = 0; i<GlobalMarks.TotalSubMarks; i++){
                    if (x == GlobalMarks.GlobalSubMarks[i,0]){
                        gCount = i;
                        break;
                    } 
                }
                if (gCount>=0){
                    if ((h<=GlobalMarks.GlobalSubMarks[gCount,1])&&(h>=0)){ return true;}
                }
                return false;
            }
            bool PracticalCheck(int h, int count) {
                int gCount = -1; //gCount = GlobalCount
                int x = SubMarks[count,0];
                for (int i = 0; i<GlobalMarks.TotalSubMarks; i++){
                    if (SubMarks[count,0] == GlobalMarks.GlobalSubMarks[i,0]){
                        gCount = i;
                    } 
                }
                if (gCount>=0){
                    if ((h<=GlobalMarks.GlobalSubMarks[gCount,2])&&(h>=0)){ return true;}
                }
                return false;
            }
            public void LocalPrintInfo() {
                Console.WriteLine("Subject ID\t\tSubject Name\t\tTheory\t\tPractical\t\tTotal Marks");
                for (int i = 0; i<s1.ChoiceNumber; i++){
                    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}",SubMarks[i,0],s1.sl[SubMarks[i,0]],SubMarks[i,1],SubMarks[i,2],SubMarks[i,3]);
                }
            }
            /*static Marks () {
                int count = 0;
                foreach (var item in Subject.globalSubject.Keys){
                    GlobalSubMarks[count,0] = item;
                    Console.WriteLine("{0}: ",Subject.globalSubject[item]);
                    Console.Write("Total Marks in Theory: ");
                    GlobalSubMarks[count,1] = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Total Marks in Practical: ");
                    GlobalSubMarks[count,2] = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Processing Total Marks! Wait...");
                    GlobalSubMarks[count,3] = GlobalSubMarks[count,1] + GlobalSubMarks[count,2];
                    count++;
                }
            }
            public static void GlobalsetupAdd () {
                Console.WriteLine("Total Marks is setup for all available subjects!");
            }*/
            /*public bool check (){}
            public Marks setupAdd (Subject s3) {
                    Marks m1 = new Marks();
                    s1 = s3;
                    foreach (var x in s1.sl.Keys){
                        int temp1; int temp2;
                        Console.Write("Subject ID: {0}", x);
                        Console.Write("Subject Name: {0}", s1.sl[x]);
                        Console.Write("Marks in that Subject: ");
                        temp2 = Convert.ToInt32(Console.ReadLine());
                        m1.sl.Add(temp1,temp2);
                    }
                    return m1;
                }*/
        }
}
