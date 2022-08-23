using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SubjectChoice;
using StudentTeacher;
using MarksGrade;

class Program {
    static void Main(string[] args)
    {
        /*Subject.GlobalsetupAdd();
        Console.WriteLine("Printing All Available Subjects!!");
        Subject.GlobalPrintInfo();
        Console.WriteLine("Filling the Data of Students!");
        Student stud = new Student();
        stud.LocalPrintInfo();
        Console.WriteLine("Now Choosing Subject by this Student!");
        Subject s = new Subject(stud.ID);
        Subject.CheckStatus(ref s);
        try {
            s.setupAdd();
            Console.WriteLine("Printing All The Chosen Subjects!");
            s.LocalPrintInfo();
        }
        catch (NullReferenceException NRE){
            Console.WriteLine("No Objects of type Students!");
        }
        stud.setupAdd(s);
        Console.WriteLine("Printing All the Details of That Student: ");
        stud.GlobalPrintInfo();*/
        
        GlobalStudent.setupAdd();
        GlobalStudent.fullsetupAdd();
        GlobalStudent.FullMSetup();
        GlobalStudent.GlobalPrintInfo();

        Student s = new Student ();
        s.setupAdd();
        s.MarksSetup();
        s.LocalPrintInfo();
        
        /*for (int i = 0; i < TotalS.Length; i++){
            TotalS[i].setupAdd(); //why not using indexer in total students
        }
        Console.WriteLine("Printing All!");
        for (int i = 0; i < TotalS.Length; i++){
            TotalS[i].GlobalPrintInfo();
        }*/

        /*Console.WriteLine("Now Making all Array of Objects in type Students!!");
        Student[] student = TotalStudent.setupAdd();
        TotalStudent.LocalPrintInfo();
        Marks m = new Marks();
        Marks result = new Marks();
        result = m.setupAdd(StudSub);*/
        var a = Console.ReadLine();
    }
}