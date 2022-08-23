using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SubjectChoice;
using MarksGrade;

namespace StudentTeacher
{
   static class GlobalStudent {
      public static int TotalNumber;
      public static Student[] s;
      public static void setupAdd () {
         Console.Write("Enter the total number of students: ");
         TotalNumber = Convert.ToInt32(Console.ReadLine());
         int n = TotalNumber;
         StartArray Sa = new StartArray();
         s = Sa.InitializeArray <Student> (n);
      }
      public static void fullsetupAdd() {
         for (int i = 0; i<s.Length; i++)
            s[i].setupAdd();
      }
      public static void LocalPrintthis(int ID){
         ID -= 1000;
         s[ID].LocalPrintInfo();
      }
      public static void GlobalPrintthis(int ID){
         ID -= 1000;
         s[ID].GlobalPrintInfo();
      }
      public static void LocalPrintInfo(){
         for (int i = 0; i<TotalNumber; i++){
            s[i].LocalPrintInfo();
         }
      }
      public static void ChosenSub () {
         for (int i = 0; i<TotalNumber; i++)
            s[i].ChosenSub();
      }
      public static void ObtainedMarks() {
         for (int i = 0; i<TotalNumber; i++){
            s[i].ObtainedMarks();
         }
      }
       public static void GlobalPrintInfo() {
         LocalPrintInfo();
         ChosenSub();
         ObtainedMarks();
      }
      public static void FullMSetup() {
         for (int i = 0; i<TotalNumber; i++){
            s[i].MarksSetup();
         }
      }
      /*public void setupAdd (){
         int n;
         n = Convert.ToInt32(Console.ReadLine());
         TotalStudent.TotalNumber = n;
         Student[] s = new Student[n];
         for (int i = 0; i<n; i++){
            s[i] = new Student();
         }
      }*/
   }
   class TotalStudent {
      //This is the collection of student of same class

   }
   class Student {
      //ChosenClass c;
      public string Name; 
      public int Class, Roll;
      static int StudID = 1000;
      public int ID;
      private static HashSet <int> IDs = new HashSet <int> (); //Still in Progress
      Subject sub; //Same variable of type Subject for all students
      Marks mark;
      //We can access it directly by calling Student s[0].s;
      public  Student () {
         Console.Write("Enter your name: ");
         Name = Console.ReadLine();
         Console.Write("Enter your class: ");
         Class = Convert.ToInt32(Console.ReadLine());
         Console.Write("Enter your roll: ");
         Roll = Convert.ToInt32(Console.ReadLine());
         ID = StudID;
         StudID++;
      }
      public void setupAdd() {
         //In this method, full setup of Students are done
         //Like Choosing Subjects
         if (sub==null){
            sub = new Subject (ID);
            sub.setupAdd();
         }
      }
      public void MarksSetup () {
         //This should be done after subject setup
         if (sub != null)
            mark = new Marks(sub);
         else 
            Console.WriteLine("Subject is not setup!");
      }
      public void LocalPrintInfo () {
         Console.WriteLine("ID\tName\tClass\tRoll");
         Console.Write("{0}\t", ID);
         Console.Write("{0}\t", Name);
         Console.Write("{0}\t", Class);
         Console.WriteLine("{0}\t", Roll);
      }
      public void ChosenSub() {
         if (sub != null)
            sub.LocalPrintInfo();
         else 
            Console.WriteLine("Subject is not setup!");
      }
      public void ObtainedMarks() {
          if (mark != null)
            mark.LocalPrintInfo();
         else 
            Console.WriteLine("Marks is not setup!");
      }
      public void GlobalPrintInfo () {
         LocalPrintInfo();
         Console.WriteLine("All Chosen Subjects are listen below!");
         if (sub != null)
            sub.LocalPrintInfo();
         else 
            Console.WriteLine("Subject is not setup!");
         if (mark != null)
            mark.LocalPrintInfo();
         else 
            Console.WriteLine("Marks is not setup!");
      }
   }
   //Now Making Generic Classes to make array of objects
   public class StartArray {
      public T[] InitializeArray <T>(int length) where T: new(){ //T[] return an array and new tells that it is parameterless constructor
         T[] array = new T[length];
         for (int i = 0; i < length; ++i){
            array[i] = new T();
         }
         return array;
      }
   }
}
