using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using BE;

namespace ConsoleApplication1
{
    class Program
    {
        static BL.Ibl bl;

        static void Main(string[] args)
        {
            int choice;
            bl = BL.factoryBL.getBL();

            Console.WriteLine("Hello");
            Console.WriteLine("Mom- enter 1 \nNanny- enter 2 /nExit- enter 0");

            do
            {
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        break;
                    case 1:
                        MomFun();
                        break;
                    case 2:
                        NannyFun();
                        break;
                    default:
                        Console.WriteLine("please enter only 1/2");
                        break;
                }
            }
            while (choice != 0);
        }

        #region mainFun

        private static void NannyFun()
        {
            int choice;
            Console.WriteLine("add Nanny-1 /n delete Nanny-2 /nupdate Nanny-3 /nExit-0");
            do
            {
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        addNannyFunc();
                        break;
                    case 2:
                        Console.WriteLine("enter your Id to delete yourself");
                        try
                        {
                            bl.deleteNanny(Convert.ToInt32(Console.ReadLine()));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 3:
                        UpdateNannyFunc();
                        break;
                    default:
                        Console.WriteLine("please enter in range 0-3");
                        break;
                }

            } while (choice != 0);

        }

        private static void MomFun()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region NannyFun
        private static void addNannyFunc()
        {
            Nanny nanny = new Nanny();

            Console.WriteLine("enter id");
            nanny.nannyId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter last name");
            nanny.lastNameNanny = Console.ReadLine();

            Console.WriteLine("enter first name");
            nanny.firstNameNanny = Console.ReadLine();

            Console.WriteLine("enter your date");
            nanny.dateNanny = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("enter your phone");
            nanny.phoneNanny = int.Parse(Console.ReadLine());

        Console.WriteLine("enter your address with ',' between city, street");
            nanny.addressNanny = Console.ReadLine();

        Console.WriteLine("you have elevator? true/false");
            nanny.elevatorNanny = bool.Parse(Console.ReadLine());

        Console.WriteLine("enter your floor");
            nanny.floorNanny = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("how math experience");
            nanny.experienceNanny = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter max child to take");
            nanny.maxChildNanny = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter min age to take in month");
            nanny.minAgeChildNanny = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter max age to take in month");
            nanny.maxAgeChildNanny = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("you want work by hour? true/false");
            nanny.isByHourNanny = bool.Parse(Console.ReadLine());


            Console.WriteLine("enter payment per hour");
            nanny.rateHourNanny = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter payment per month");
            nanny.rateMonthNanny = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What days do you work? Please enter the order of the week true/false");
            nanny.daysWorkNanny = new bool[6];
            for (int i = 0; i < 6; i++)
            {
                nanny.daysWorkNanny[i] = bool.Parse(Console.ReadLine());
            }

        Console.WriteLine("Do you work by TAMAT? true/false");
        nanny.isTamatNanny = bool.Parse(Console.ReadLine());


        Console.WriteLine("enter your recommendation");
            nanny.recommendationsNanny = Console.ReadLine();
            nanny.currentChildren = 0;

            Console.WriteLine("enter start time and end time for each day /n(Seperate the hour and minute by Enter ");
            nanny.ScheduleNanny = new Schedule[6];
            for (int i = 0; i < 6; i++)
            {
                int hourStart = Convert.ToInt32(Console.ReadLine());
                int minStart = Convert.ToInt32(Console.ReadLine());
                int hourEnd = Convert.ToInt32(Console.ReadLine());
                int minEnd = Convert.ToInt32(Console.ReadLine());
                nanny.ScheduleNanny[i].startHour = new DateTime(1, 1, 1, hourStart, minStart,0);
                    nanny.ScheduleNanny[i].endHour= new DateTime(1, 1, 1, hourEnd, minEnd, 0);
            }
            nanny.diff = 0;
            nanny.Distance = 0;
            try
            {
                bl.addNanny(nanny);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
    }

    private static void UpdateNannyFunc()
    {
        throw new NotImplementedException();
    }

    #endregion
}
}
