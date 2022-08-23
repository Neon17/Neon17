using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StudentTeacher;
using MarksGrade;

namespace SubjectChoice
{
    //Subject is called from class students or teacher
    public static class GlobalSubject {
        public static SortedList <int, string> globalSubject = new SortedList <int, string>();
        public static int TotalNumber = 0;
        static GlobalSubject() {
            Console.WriteLine("How many subjects are available altogether? ");
            TotalNumber = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i<TotalNumber; i++){
                int temp1; string temp2;
                Console.Write("Subject ID: ");
                temp1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Subject Name: ");
                temp2 = Console.ReadLine();
                globalSubject.Add(temp1,temp2);
            }
        }
        public static void CheckIfCall () {
            //"Checking whether this GlobalSubject is called or not by simply calling this function!"
            //Because static constructor is initialized before static members
        }
        public static void GlobalsetupAdd() {
            Console.WriteLine("I found that before calling this static function, static constructor is called automatically!");
        }
        public static void GlobalPrintInfo() {
            Console.WriteLine("ID\tName");
            foreach (var x in globalSubject.Keys){
                Console.WriteLine("{0}\t{1}",x,globalSubject[x]);
            }
        }
        
    }
    public class Subject {
        //I think we should call Marks from this class because in Marks there is no remove mechanisms or check duplicates
        //public static int TotalNumber = 0;
        private bool status = false;
        public int ID = 0;
        public int ChoiceNumber = 0;
        private static HashSet <int> IDs = new HashSet <int> ();
        //public static SortedList <int, string> globalSubject = new SortedList <int, string>();
        public SortedList <int, string> sl = new SortedList <int, string>();
        //private static HashSet <int> IDs = new HashSet <int> ();
        //We can make list of ID in static field listed here, so there cannot be duplicates
        //List allows duplicate values whereas HashSet doesn't. So, using HashSet can be wise decision
        public Subject(int ID) { //ID means Students, Teachers or Librarian ID
            Console.WriteLine("Constructor TSChoice called! and object of Subject initiated!");
            if (!IDs.Add(ID)){
                status = false;
                Console.WriteLine("Objects of this ID is already in use!");
            }
            else {
                this.ID = ID;
                status = true;
                //Subject.CheckStatus(*this);  If possible!
            }
        }
        /*static Subject () {
            Console.WriteLine("How many subjects are available altogether? ");
            Subject.TotalNumber = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i<Subject.TotalNumber; i++){
                int temp1; string temp2;
                Console.Write("Subject ID: ");
                temp1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Subject Name: ");
                temp2 = Console.ReadLine();
                Subject.globalSubject.Add(temp1,temp2);
            }
        }*/
        public static void CheckStatus (ref Subject s){ //We can also use bool return type
            if (!s.status){
                Console.WriteLine("Subject of this ID is already chosen!");
                s = null;
                return;
            }
            else {
                return;
            }
        }
        /*public static void GlobalsetupAdd() {
            Console.WriteLine("I found that before calling this static function, static constructor is called automatically!");
        }*/
        public void setupAdd() { //setupAdd setups the subjects chosen
            GlobalSubject.CheckIfCall();
            int n;
            do {
                Console.WriteLine("Enter the number of subjects you want to study or teach: ");
                n = Convert.ToInt32(Console.ReadLine());
            } while ((n>GlobalSubject.TotalNumber)&&(n<=0));
            this.ChoiceNumber = n;
            if (ID == 0) {
                Console.WriteLine("This ID is in Use. Please Delete this Objects!");
                return;
            }
            if (GlobalSubject.TotalNumber >= ChoiceNumber){
                int temp1;
                for (int i = 0; i<ChoiceNumber; i++){
                    int sCount = 0;
                    do {
                        sCount++;
                        if (sCount>2) {Console.WriteLine("Please Select the Available ID!");}
                        Console.Write("Subject ID: ");
                        temp1 = Convert.ToInt32(Console.ReadLine());
                    } while (!(check(temp1)));
                    string temp2 = GlobalSubject.globalSubject[temp1];
                    sl.Add(temp1,temp2);
                }
            }
            else {
                Console.WriteLine("Please Enter the number of chosen subjects less than or equal to available subjects!!");
            }
        }
        bool check(int temp){
            foreach (var item in GlobalSubject.globalSubject.Keys){
                if (item==temp){
                    return true;
                }
            }
            return false;
        }
        /*public static void GlobalPrintInfo() {
            foreach (var x in Subject.globalSubject.Keys){
                Console.WriteLine("ID:  {0}      Name:  {1}",x,Subject.globalSubject[x]);
            }
        }*/
        public void LocalPrintInfo() {
            if (sl!=null){
                Console.WriteLine("ID\t\tSubjectName");
                foreach (var x in sl.Keys){
                    Console.WriteLine("{0}\t{1}",x,sl[x]);
                }
                Console.WriteLine();
            }
            else {
                Console.WriteLine("Subjects are not setup!");
            }
        }
    }
    
    
        //Here we find number of classes teaching or
        //Class studying by students
}
