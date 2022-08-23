using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    //All class should be made in such a way that all can be accessed independently
    //TotalClass Object should be somewhere
    public class TotalClass {
        //It makes array of classes
        //Function that access class objects by name
        /*
        c[0], c[1], c[2],.....c[n] are the arrays of object class
        int TotalClassNumber;
        Class AccessitByName (string n){
            for (int i = 0; i<TotalClassNumber; i++){
                if (c[i].name==n){
                    return c[i];
                }
            }
        }
        */
    }
    public class Class {
        //There should be no repetition of ClassName or ID
        /*int AvailableSeats;
        TotalSubject ts;
        TotalStudent tc;*/
    }
    public class ChosenClass {
        //It checks whether Students calling selected class is occupied with seats or not
        //It should get students select from available classes
        //Subject s;
        //There should be functions that return TotalSubject of that class
        //This class should also be such that teachers can also use it
    }
    public class setup {
        //It initializes TotalClass, returns object of TotalClass
    }
    public class AllObjectController {
        //It makes array of TotalClass if necessary
        //Subject can be accessed from class in these
        //It returns the objects to be accessed
    }
}