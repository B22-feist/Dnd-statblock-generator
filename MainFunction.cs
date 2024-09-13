using dbStuff;
using System;
using System.Dynamic;

namespace Display {
    class Program
    {
        static void Main()
        {
            dbConnection test = new();
            test.dboutput();
        }
    }
}