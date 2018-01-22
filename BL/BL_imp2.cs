using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BE;
using GoogleMapsApi;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;

namespace BL
{
    partial class xmlInitilizer : Ibl
    {
        static long[] idMotherArray = new long[21];
        static long[] idNannyArray = new long[20];
        static long[] idChildArray = new long[30];
        string[] recomandactions = new string[]
        {
            "מטפלת מעולה",
            "אחת בדורה",
            "מאוד מרוצה ממנה",
            "עושה מעל ומעבר",

        };
        /// <summary>
        /// initilize 3 araays of id 
        /// </summary>
        void initilizeArray()
        {

            for (int i = 0; i < 30; i++)
                idChildArray[i] = IDCreator("child");
            for (int i = 0; i < 20; i++)
                idNannyArray[i] = IDCreator("nanny");
            for (int i = 0; i < 21; i++)
                idMotherArray[i] = IDCreator("mother");
        }
        /// <summary>
        /// create id for objects ranomaly, 
        /// TypeObject options: nanny,mother,child
        /// </summary>
        long IDCreator(string type)
        {
            long id = 0;
            switch (type)
            {
                case "nanny":
                    do
                    {
                        id = r.Next(100000000, 299999999);
                    } while (idNannyArray.Any(x => x == id));
                    break;
                case "mother":
                    do
                    {
                        id = r.Next(300000000, 599999999);
                    } while (idMotherArray.Any(x => x == id));
                    break;
                case "child":
                    do
                    {
                        id = r.Next(600000000, 999999999);
                    } while (idChildArray.Any(x => x == id));
                    break;
            }
            return id;
        }

        /// <summary>
        /// Initilize & addtion to list 20 nannies
        /// </summary>
        void NannyInitilize()
        {
            Nanny Ayala_Zehavi = new Nanny
            {

                nannyId = idNannyArray[0],
                firstNameNanny = "אילה",
                lastNameNanny = "זהבי",
                dateNanny = new DateTime(1980, 5, 19),
                addressNanny = "רחוב בית הדפוס 21, ירושלים",
                elevatorNanny = true,
                floorNanny = 2,
                experienceNanny = 3,
                phoneNanny = 0523433333,
                maxAgeChildNanny = 14,
                minAgeChildNanny = 3,
                maxChildNanny = 8,
                recommendationsNanny = recomandactions[0],
                isTamatNanny = false,
                isByHourNanny = true,
                rateHourNanny = 10,
                rateMonthNanny = 800,
                daysWorkNanny = new bool[6] { true, true, true, true, true, false },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 7, 15, 0),
                    new DateTime(01,01,1,7,45,0),
                    new DateTime(01,01,1,7,15,0),
                    new DateTime(01,01,1,8,30,0),
                    new DateTime(01,01,1,8,30,0),
                    new DateTime(01,01,1,0,0,0),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,16,20,0),
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(01,01,1,15,10,0),
                    new DateTime(01,01,1,14,30,0),
                    new DateTime(01,01,1,15,45,0),
                    new DateTime(01,01,1,0,0,0),
                },

            };
            Nanny Moria_schneider = new Nanny
            {
                nannyId = idNannyArray[1],
                firstNameNanny = "שניידר",
                lastNameNanny = "מוריה",
                dateNanny = new DateTime(1980, 5, 19),
                addressNanny = "רחוב שחל 15, ירושלים",
                elevatorNanny = true,
                floorNanny = 2,
                experienceNanny = 3,
                phoneNanny = 0523433333,
                maxAgeChildNanny = 14,
                minAgeChildNanny = 3,
                maxChildNanny = 8,
                isByHourNanny = true,
                rateHourNanny = 10,
                rateMonthNanny = 800,
                isTamatNanny = false,
                daysWorkNanny = new bool[6] { true, true, true, true, true, false },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 7, 0, 0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,17,30,0),
                    new DateTime(01,01,1,17,30,0),
                    new DateTime(01,01,1,17,45,0),
                    new DateTime(01,01,1,17,30,0),
                    new DateTime(01,01,1,17,30,0),
                    new DateTime(01,01,1,0,0,0),
                },
                recommendationsNanny = "",
            };
            Nanny malki_fishman = new Nanny
            {
                //v
                nannyId = idNannyArray[2],
                firstNameNanny = "מלכי",
                lastNameNanny = "פישמן",
                dateNanny = new DateTime(1992, 4, 9),
                addressNanny = "רחוב בר אילן 15, ירושלים",
                elevatorNanny = false,
                floorNanny = 1,
                experienceNanny = 5,
                phoneNanny = 0525633333,
                maxAgeChildNanny = 17,
                minAgeChildNanny = 1,
                maxChildNanny = 7,
                isByHourNanny = false,
                isTamatNanny = true,
                rateMonthNanny = 1200,
                daysWorkNanny = new bool[6] { true, true, true, true, true, true },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 8, 0, 0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,45,0),
                    new DateTime(01,01,1,7,30,0),
                    new DateTime(01,01,1,7,30,0),
                    new DateTime(01,01,1,8,0,0),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,16,45,0),
                    new DateTime(01,01,1,17,30,0),
                    new DateTime(01,01,1,16,15,0),
                    new DateTime(01,01,1,15,30,0),
                    new DateTime(01,01,1,15,45,0),
                    new DateTime(01,01,1,12,0,0),
                },
                recommendationsNanny = recomandactions[1],
            };
            Nanny Elisheva_Shaked = new Nanny
            {
                nannyId = idNannyArray[3],
                firstNameNanny = "אלישבע",
                lastNameNanny = "שקד",
                dateNanny = new DateTime(1990, 5, 29),
                addressNanny = "עמרם גאון 15, ירושלים",
                elevatorNanny = true,
                floorNanny = 2,
                experienceNanny = 3,
                phoneNanny = 0523433333,
                maxAgeChildNanny = 14,
                minAgeChildNanny = 3,
                maxChildNanny = 8,
                isByHourNanny = true,
                rateHourNanny = 10,
                isTamatNanny = false,
                rateMonthNanny = 800,
                daysWorkNanny = new bool[] { true, true, true, true, true, false },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 7, 30, 0),
                    new DateTime(01,01,1,7,20,0),
                    new DateTime(01,01,1,7,50,0),
                    new DateTime(01,01,1,7,40,0),
                    new DateTime(01,01,1,7,30,0),
                    new DateTime(),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,15,40,0),
                    new DateTime(01,01,1,15,30,0),
                    new DateTime(01,01,1,15,10,0),
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(01,01,1,15,35,0),
                    new DateTime(),
                },
                recommendationsNanny = recomandactions[0],
            };
            Nanny Yafi_Shtain = new Nanny
            {
                //v
                nannyId = idNannyArray[4],
                firstNameNanny = "יפי",
                lastNameNanny = "שטיין",
                dateNanny = new DateTime(1995, 1, 8),
                addressNanny = "הרב פנחס קהתי 5, ירושלים",
                elevatorNanny = true,
                floorNanny = 4,
                experienceNanny = 1,
                phoneNanny = 0526754123,
                maxAgeChildNanny = 18,
                minAgeChildNanny = 2,
                maxChildNanny = 6,
                isByHourNanny = true,
                rateHourNanny = 12,
                rateMonthNanny = 800,
                isTamatNanny = true,
                daysWorkNanny = new bool[6] { true, true, true, true, true, false },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 7, 15, 0),
                    new DateTime(01,01,1,7,30,0),
                    new DateTime(01,01,1,7,30,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,16,15,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(),
                },
                recommendationsNanny = recomandactions[3],
            };
            Nanny Hila_Sharabi = new Nanny
            {
                //v
                nannyId = idNannyArray[5],
                firstNameNanny = "הילה",
                lastNameNanny = "שרעבי",
                dateNanny = new DateTime(1990, 5, 19),
                addressNanny = "אליעזרוב 15, ירושלים",
                elevatorNanny = false,
                floorNanny = 0,
                experienceNanny = 6,
                phoneNanny = 0509856634,
                maxAgeChildNanny = 18,
                minAgeChildNanny = 3,
                maxChildNanny = 8,
                isByHourNanny = false,
                rateMonthNanny = 950,
                isTamatNanny = true,
                daysWorkNanny = new bool[6] { true, true, true, false, true, false },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 7, 30, 0),
                    new DateTime(01,01,1,7,30,0),
                    new DateTime(01,01,1,7,45,0),
                    new DateTime(),
                    new DateTime(01,01,1,7,30,0),
                    new DateTime(),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(1,1,1,16,30,0),
                    new DateTime(),
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(),
                },
                recommendationsNanny = recomandactions[2],
            };
            Nanny Adi_Shushan = new Nanny
            {
                //v
                nannyId = idNannyArray[6],
                firstNameNanny = "עדי",
                lastNameNanny = "שושן",
                dateNanny = new DateTime(1970, 5, 14),
                addressNanny = "רחוב היהודים 4, ירושלים",
                elevatorNanny = true,
                floorNanny = 2,
                experienceNanny = 30,
                phoneNanny = 0548435465,
                maxAgeChildNanny = 24,
                minAgeChildNanny = 1,
                maxChildNanny = 8,
                isByHourNanny = true,
                rateHourNanny = 10,
                isTamatNanny = true,
                rateMonthNanny = 800,
                daysWorkNanny = new bool[6] { true, true, true, true, false, true },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 7, 0, 0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(),
                    new DateTime(01,01,1,7,0,0),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(),
                    new DateTime(01,01,1,13,30,0),
                },
                recommendationsNanny = recomandactions[1],
            };
            Nanny Chavi_Horen = new Nanny
            {
                nannyId = idNannyArray[7],
                firstNameNanny = "חווי",
                lastNameNanny = "הורן",
                dateNanny = new DateTime(1994, 5, 9),
                addressNanny = "מאה שערים 8 ירושלים",
                elevatorNanny = false,
                floorNanny = 2,
                experienceNanny = 3,
                phoneNanny = 0573124354,
                maxAgeChildNanny = 12,
                minAgeChildNanny = 3,
                maxChildNanny = 8,
                isByHourNanny = true,
                rateHourNanny = 11,
                rateMonthNanny = 1100,
                isTamatNanny = false,
                daysWorkNanny = new bool[6] { false, true, true, true, true, true },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 0, 0, 0),
                    new DateTime(01,01,1,8,15,0),
                    new DateTime(01,01,1,7,30,0),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,0,0),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,0,0,0),
                    new DateTime(01,01,1,15,45,0),
                    new DateTime(01,01,1,17,30,0),
                    new DateTime(01,01,1,17,30,0),
                    new DateTime(01,01,1,17,30,0),
                    new DateTime(01,01,1,11,30,0),
                },
                recommendationsNanny = recomandactions[3],
            };
            Nanny Diti_Farkash = new Nanny
            {
                nannyId = idNannyArray[8],
                firstNameNanny = "דיטי",
                lastNameNanny = "פרקש",
                dateNanny = new DateTime(1987, 3, 19),
                addressNanny = "רחוב המחנכת 8, ירושלים",
                elevatorNanny = false,
                floorNanny = 2,
                experienceNanny = 8,
                phoneNanny = 0526785431,
                maxAgeChildNanny = 18,
                minAgeChildNanny = 3,
                maxChildNanny = 8,
                isByHourNanny = true,
                rateHourNanny = 8,
                rateMonthNanny = 800,
                isTamatNanny = true,
                daysWorkNanny = new bool[6] { true, true, true, true, true, true },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 7, 30, 0),
                    new DateTime(01,01,1,7,45,0),
                    new DateTime(01,01,1,8,30,0),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(01,01,1,7,0,0),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,17,0,0),
                    new DateTime(01,01,1,14,30,0),
                    new DateTime(01,01,1,17,0,0),
                    new DateTime(01,01,1,15,0,0),
                    new DateTime(01,01,1,17,0,0),
                    new DateTime(01,01,1,12,30,0),
                },
                recommendationsNanny = recomandactions[1],
            };
            Nanny noa_Karlibach = new Nanny
            {
                nannyId = idNannyArray[9],
                firstNameNanny = "נעה",
                lastNameNanny = "קרליבך",
                dateNanny = new DateTime(1984, 8, 19),
                addressNanny = "רחוב סולם יעקב 18, ירושלים",
                elevatorNanny = true,
                floorNanny = 2,
                experienceNanny = 10,
                phoneNanny = 0527612345,
                maxAgeChildNanny = 15,
                minAgeChildNanny = 3,
                maxChildNanny = 8,
                isByHourNanny = false,
                rateMonthNanny = 1000,
                isTamatNanny = true,
                daysWorkNanny = new bool[6] { false, true, false, true, true, true },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 0, 0, 0),
                    new DateTime(01,01,1,7,30,0),
                    new DateTime(01,01,1,0,0,0),
                    new DateTime(01,01,1,7,30,0),
                    new DateTime(01,01,1,7,30,0),
                    new DateTime(01,01,1,7,0,0),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,0,0,0),
                    new DateTime(01,01,1,15,45,0),
                    new DateTime(01,01,1,0,0,0),
                    new DateTime(01,01,1,15,45,0),
                    new DateTime(01,01,1,15,45,0),
                    new DateTime(01,01,1,12,30,0),
                },
                recommendationsNanny = recomandactions[1],

            };
            Nanny batSheva_Choen = new Nanny
            {
                //v
                nannyId = idNannyArray[10],
                firstNameNanny = "בתשבע",
                lastNameNanny = "כהן",
                dateNanny = new DateTime(1996, 5, 19),
                addressNanny = "רחוב יצחק מרסקי 8, ירושלים",
                elevatorNanny = true,
                floorNanny = 2,
                experienceNanny = 0,
                phoneNanny = 0526872034,
                maxAgeChildNanny = 18,
                minAgeChildNanny = 3,
                maxChildNanny = 8,
                isByHourNanny = true,
                rateHourNanny = 9,
                rateMonthNanny = 800,
                isTamatNanny = false,
                daysWorkNanny = new bool[6] { true, true, true, false, true, false },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 7, 30, 0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,30,0),
                    new DateTime(01,01,1,0,0,0),
                    new DateTime(01,01,1,7,30,0),
                    new DateTime(01,01,1,0,0,0),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,17,15,0),
                    new DateTime(01,01,1,0,0,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,0,0,0),
                },
                recommendationsNanny = "",
            };
            Nanny Mehira_Shulman = new Nanny
            {
                nannyId = idNannyArray[11],
                firstNameNanny = "מאירה",
                lastNameNanny = "שולמן",
                dateNanny = new DateTime(1990, 1, 1),
                addressNanny = "רחוב בר אילן 32, ירושלים",
                elevatorNanny = true,
                floorNanny = 1,
                experienceNanny = 3,
                phoneNanny = 0523421347,
                maxAgeChildNanny = 15,
                minAgeChildNanny = 3,
                maxChildNanny = 8,
                isByHourNanny = false,
                rateMonthNanny = 900,
                isTamatNanny = false,
                daysWorkNanny = new bool[6] { true, true, true, true, true, false },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 7, 30, 0),
                    new DateTime(01,01,1,7,15,0),
                    new DateTime(01,01,1,7,30,0),
                    new DateTime(01,01,1,7,15,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,0,0,0),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,17,0,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(01,01,1,0,0,0),
                },
                recommendationsNanny = recomandactions[1],
            };
            Nanny Avigail_Kuk = new Nanny
            {
                //v
                nannyId = idNannyArray[12],
                firstNameNanny = "אביגיל",
                lastNameNanny = "קוק",
                dateNanny = new DateTime(1990, 5, 12),
                addressNanny = "רחוב רבינו גרשום 32, ירושלים",
                elevatorNanny = true,
                floorNanny = 2,
                experienceNanny = 3,
                phoneNanny = 0523908761,
                maxAgeChildNanny = 18,
                minAgeChildNanny = 3,
                maxChildNanny = 8,
                isByHourNanny = true,
                rateHourNanny = 10,
                rateMonthNanny = 950,
                isTamatNanny = false,
                daysWorkNanny = new bool[6] { true, true, true, true, true, false },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 7, 30, 0),
                    new DateTime(01,01,1,7,15,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,0,0,0),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,16,45,0),
                    new DateTime(01,01,1,17,0,0),
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,15,30,0),
                    new DateTime(01,01,1,0,0,0),
                },
                recommendationsNanny = recomandactions[0],
            };
            Nanny Chani_Yosef = new Nanny
            {
                //v
                nannyId = idNannyArray[13],
                firstNameNanny = "חני",
                lastNameNanny = "יוסף",
                dateNanny = new DateTime(1994, 2, 19),
                addressNanny = "רחוב סולם יעקב 12, ירושלים",
                elevatorNanny = true,
                floorNanny = 2,
                experienceNanny = 3,
                phoneNanny = 0526545524,
                maxAgeChildNanny = 14,
                minAgeChildNanny = 3,
                maxChildNanny = 8,
                isByHourNanny = true,
                rateHourNanny = 10,
                rateMonthNanny = 800,
                isTamatNanny = true,
                daysWorkNanny = new bool[6] { true, true, true, true, true, true },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 8, 0, 0),
                    new DateTime(01,01,1,7,15,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(01,01,1,8,0,0),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,15,30,0),
                    new DateTime(01,01,1,12,30,0),
                },
                recommendationsNanny = recomandactions[3],
            };
            Nanny Batya_Adler = new Nanny
            {
                //v
                nannyId = idNannyArray[14],
                firstNameNanny = "בתיה",
                lastNameNanny = "אדלר",
                dateNanny = new DateTime(1990, 7, 13),
                addressNanny = "רחוב שחל 17, ירושלים",
                elevatorNanny = true,
                floorNanny = 2,
                experienceNanny = 3,
                phoneNanny = 0525476532,
                maxAgeChildNanny = 18,
                minAgeChildNanny = 3,
                maxChildNanny = 8,
                isByHourNanny = false,
                rateMonthNanny = 650,
                isTamatNanny = false,
                daysWorkNanny = new bool[6] { true, true, false, true, true, false },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 7, 30, 0),
                    new DateTime(01,01,1,7,15,0),
                    new DateTime(01,01,1,0,0,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,45,0),
                    new DateTime(01,01,1,0,0,0),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(01,01,1,0,0,0),
                    new DateTime(01,01,1,16,15,0),
                    new DateTime(01,01,1,15,30,0),
                    new DateTime(01,01,1,0,0,0),
                },

                recommendationsNanny = recomandactions[1],
            };
            Nanny lea_Gans = new Nanny
            {
                nannyId = idNannyArray[15],
                firstNameNanny = "לאה",
                lastNameNanny = "גנץ",
                dateNanny = new DateTime(1990, 9, 30),
                addressNanny = "רחוב רבינו גרשום 4, ירושלים",
                elevatorNanny = true,
                floorNanny = 2,
                experienceNanny = 3,
                phoneNanny = 0527832415,
                maxAgeChildNanny = 14,
                minAgeChildNanny = 3,
                maxChildNanny = 8,
                isByHourNanny = true,
                rateHourNanny = 10,
                rateMonthNanny = 1000,
                isTamatNanny = true,
                daysWorkNanny = new bool[6] { false, true, true, true, true, false },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 0, 0, 0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,0,0,0),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,0,0,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,15,30,0),
                    new DateTime(01,01,1,0,0,0),
                },

                recommendationsNanny = recomandactions[2],
            };
            Nanny Miryam_BenHamu = new Nanny
            {
                //v
                nannyId = idNannyArray[16],
                firstNameNanny = "מרים",
                lastNameNanny = "בן-חמו",
                dateNanny = new DateTime(1985, 5, 19),
                addressNanny = "רחוב שמואל הנביא 17, ירושלים  ",
                elevatorNanny = true,
                floorNanny = 2,
                experienceNanny = 8,
                phoneNanny = 0521234983,
                maxAgeChildNanny = 15,
                minAgeChildNanny = 3,
                maxChildNanny = 8,
                isByHourNanny = true,
                rateHourNanny = 12,
                rateMonthNanny = 900,
                isTamatNanny = false,
                daysWorkNanny = new bool[6] { true, true, true, true, true, false },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 7, 30, 0),
                    new DateTime(01,01,1,7,30,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,15,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,0,0,0),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,15,45,0),
                    new DateTime(01,01,1,0,0,0),
                },

                recommendationsNanny = recomandactions[0],
            };
            Nanny Gila_Elmagor = new Nanny
            {
                nannyId = idNannyArray[17],
                firstNameNanny = "גילה",
                lastNameNanny = "אלמגור",
                dateNanny = new DateTime(1977, 10, 16),
                addressNanny = "רחוב שמואל הנביא 5, ירושלים",
                elevatorNanny = true,
                floorNanny = 6,
                experienceNanny = 3,
                phoneNanny = 0529876543,
                maxAgeChildNanny = 12,
                minAgeChildNanny = 2,
                maxChildNanny = 8,
                isByHourNanny = false,
                rateHourNanny = 10,
                rateMonthNanny = 800,
                isTamatNanny = true,
                daysWorkNanny = new bool[6] { true, true, true, true, false, true },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 7, 30, 0),
                    new DateTime(01,01,1,7,30,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,0,0,0),
                    new DateTime(01,01,1,8,0,0),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,17,0,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,0,0,0),
                    new DateTime(01,01,1,13,0,0),
                },

                recommendationsNanny = recomandactions[1],
            };
            Nanny Tsipi_Hotoveli = new Nanny
            {
                //v
                nannyId = idNannyArray[18],
                firstNameNanny = "ציפי",
                lastNameNanny = "חוטובלי",
                dateNanny = new DateTime(1989, 3, 29),
                addressNanny = "רחוב הרב קוק 8, ירושלים",
                elevatorNanny = true,
                floorNanny = 2,
                experienceNanny = 3,
                phoneNanny = 0521001001,
                maxAgeChildNanny = 18,
                minAgeChildNanny = 3,
                maxChildNanny = 8,
                isByHourNanny = true,
                rateHourNanny = 10,
                rateMonthNanny = 900,
                isTamatNanny = true,
                daysWorkNanny = new bool[6] { true, true, true, true, true, false },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 7, 0, 0),
                    new DateTime(01,01,1,7,15,0),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(01,01,1,8,15,0),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(01,01,1,0,0,0),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,14,0,0),
                    new DateTime(01,01,1,14,30,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,0,0,0),
                },
                recommendationsNanny = recomandactions[2],

            };
            Nanny Shifi_Aizen = new Nanny
            {
                nannyId = idNannyArray[19],
                firstNameNanny = "שיפי",
                lastNameNanny = "אייזן",
                dateNanny = new DateTime(1980, 5, 19),
                addressNanny = "רחוב הרב שלום שבזי 12, ירושלים",
                elevatorNanny = true,
                floorNanny = 2,
                experienceNanny = 3,
                phoneNanny = 0529344513,
                maxAgeChildNanny = 15,
                minAgeChildNanny = 3,
                maxChildNanny = 8,
                isByHourNanny = false,
                rateMonthNanny = 900,
                isTamatNanny = false,
                daysWorkNanny = new bool[6] { true, true, true, true, true, false },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,7, 15, 0),
                    new DateTime(01,01,1,7,45,0),
                    new DateTime(01,01,1,7, 0,0),
                    new DateTime(01,01,1,7, 0,0),
                    new DateTime(01,01,1,7, 30,0),
                    new DateTime(01,01,1,0,0,0),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,15,45,0),
                    new DateTime(01,01,1,14, 0,0),
                    new DateTime(01,01,1,16, 0,0),
                    new DateTime(01,01,1,15, 30,0),
                    new DateTime(01,01,1,0,0,0),
                },
                recommendationsNanny = recomandactions[0],
            };
            try
            {
                dal.addNanny(malki_fishman);
                dal.addNanny(Moria_schneider);
                dal.addNanny(Ayala_Zehavi);
                dal.addNanny(Yafi_Shtain);
                dal.addNanny(Hila_Sharabi);
                dal.addNanny(Adi_Shushan);
                dal.addNanny(Chavi_Horen);
                dal.addNanny(Shifi_Aizen);
                dal.addNanny(Tsipi_Hotoveli);
                dal.addNanny(Gila_Elmagor);
                dal.addNanny(Miryam_BenHamu);
                dal.addNanny(lea_Gans);
                dal.addNanny(Batya_Adler);
                dal.addNanny(Chani_Yosef);
                dal.addNanny(Avigail_Kuk);
                dal.addNanny(Mehira_Shulman);
                dal.addNanny(batSheva_Choen);
                dal.addNanny(noa_Karlibach);
                dal.addNanny(Diti_Farkash);
                dal.addNanny(Elisheva_Shaked);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        /// <summary>
        /// Initilize & addtion to list 21 Mothers
        /// </summary>
        void MotherInitilize()
        {

            Mother Bracha_Polak = new Mother
            {
                IdMom = idMotherArray[0],
                FirstNameMom = "ברכה",
                LasNameMom = "פולק",
                AddressMom = "HaRav Herzog St 12, Jerusalem",
                PhoneMom = 0526874352,
                AddressForNanny = "Shakhal St 23,Jerusalem",
                DaysRequestMom = new bool[6] { true, false, true, false, true, false },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,8, 30, 0),
                    new DateTime(),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(),
                    new DateTime(01,01,1,12, 30,0),
                    new DateTime(),
                    new DateTime(01,01,1,13, 30,0),
                    new DateTime(),
                },
                nothMom = "",
            };
            Mother Oshrat_Levi = new Mother
            {
                IdMom = idMotherArray[1],
                FirstNameMom = "אושרת",
                LasNameMom = "לוי",
                AddressMom = "Ha-'va'ad haleumi St 21,Jerusalem",
                PhoneMom = 0526943451,
                AddressForNanny = "Shakhal St 23,Jerusalem",
                DaysRequestMom = new bool[6] { false, true, true, true, true, true },
                startHour = new DateTime[6]
                {
                    new DateTime(),
                    new DateTime(01,01,1,9,0,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8,0,0),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(),
                    new DateTime(01,01,1,17,30,0),
                    new DateTime(01,01,1,12, 30,0),
                    new DateTime(01,01,1,16, 30,0),
                    new DateTime(01,01,1,13, 30,0),
                    new DateTime(01,01,1,12,0,0),
                },
                nothMom = "",
            };
            Mother Ayelt_Shaked = new Mother
            {
                IdMom = idMotherArray[2],
                FirstNameMom = "איילת",
                LasNameMom = "שקד",
                AddressMom = "Shakhal St 23,Jerusalem",
                PhoneMom = 0521234566,
                AddressForNanny = "Shakhal St 23,Jerusalem",
                DaysRequestMom = new bool[6] { true, true, true, true, true, false },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,8, 15, 0),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,14,30,0),
                    new DateTime(01,01,1,13,30,0),
                    new DateTime(01,01,1,12, 30,0),
                    new DateTime(01,01,1,15, 30,0),
                    new DateTime(01,01,1,16, 30,0),
                    new DateTime(),
                },
                nothMom = "",
            };
            Mother Gilat_Benet = new Mother
            {
                IdMom = idMotherArray[3],
                FirstNameMom = "גילת",
                LasNameMom = "בנט",
                AddressMom = "HaMem Gimel St 4, Jerusalem",
                PhoneMom = 0527668451,
                AddressForNanny = "Shakhal St 23,Jerusalem",
                DaysRequestMom = new bool[6] { true, true, true, true, true, false },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,8, 15, 0),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,7, 45,0),
                    new DateTime(),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,15,45,0),
                    new DateTime(01,01,1,14, 0,0),
                    new DateTime(01,01,1,16, 0,0),
                    new DateTime(01,01,1,15, 30,0),
                    new DateTime(),
                },
                nothMom = "",
            };
            Mother Esti_Kopshitz = new Mother
            {
                IdMom = idMotherArray[4],
                FirstNameMom = "ברכה",
                LasNameMom = "קופביץ",
                AddressMom = "Haham Shmuel Bruchim St 5, Jerusalem",
                PhoneMom = 0523154634,
                AddressForNanny = "Shakhal St 23,Jerusalem",
                DaysRequestMom = new bool[6] { true, true, true, true, true, false },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,7, 45, 0),
                    new DateTime(01,01,1,7,45,0),
                    new DateTime(01,01,1,7, 45,0),
                    new DateTime(01,01,1,7, 45,0),
                    new DateTime(01,01,1,7, 45,0),
                    new DateTime(),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,15,45,0),
                    new DateTime(01,01,1,15,45,0),
                    new DateTime(01,01,1,15, 45,0),
                    new DateTime(01,01,1,15, 45,0),
                    new DateTime(01,01,1,15, 45,0),
                    new DateTime(),
                },
                nothMom = "",
            };
            Mother Irena_Gavrielov = new Mother
            {
                IdMom = idMotherArray[5],
                FirstNameMom = "אירנה",
                LasNameMom = "גבריאלוב",
                AddressMom = "Arzei ha-Bira St 6, Jerusalem",
                PhoneMom = 0523756345,
                AddressForNanny = "Shakhal St 23,Jerusalem",
                DaysRequestMom = new bool[6] { true, false, true, true, false, false },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,8, 15, 0),
                    new DateTime(),
                    new DateTime(01,01,1,8, 15,0),
                    new DateTime(01,01,1,8, 15,0),
                    new DateTime(),
                    new DateTime(01,01,1,8, 0,0),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,14,15,0),
                    new DateTime(),
                    new DateTime(01,01,1,14, 15,0),
                    new DateTime(01,01,1,14, 15,0),
                    new DateTime(),
                    new DateTime(01,01,1,12,0,0),
                },
                nothMom = "",
            };
            Mother Tovi_Shachak = new Mother
            {
                IdMom = idMotherArray[6],
                FirstNameMom = "טובי",
                LasNameMom = "שחק",
                AddressMom = "Kav Venaki St 6, Jerusalem",
                PhoneMom = 0527156743,
                AddressForNanny = "Shakhal St 23,Jerusalem",
                DaysRequestMom = new bool[6] { true, true, true, true, true, true },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,8, 0, 0),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(01,01,1,9, 0,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8,0,0),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,13,30,0),
                    new DateTime(01,01,1,15,30,0),
                    new DateTime(01,01,1,12, 30,0),
                    new DateTime(01,01,1,15, 30,0),
                    new DateTime(01,01,1,16, 0,0),
                    new DateTime(01,01,1,12,30,0),
                },
                nothMom = "",
            };
            Mother Sheindi_Lider = new Mother
            {
                IdMom = idMotherArray[7],
                FirstNameMom = "דקלה",
                LasNameMom = "שובי",
                AddressMom = "Yosef Ben Matityahu St 28, Jerusalem",
                PhoneMom = 0548456654,
                AddressForNanny = "Shakhal St 23,Jerusalem",
                DaysRequestMom = new bool[6] { true, true, true, true, false, false },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,8, 0, 0),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(01,01,1,7, 45,0),
                    new DateTime(01,01,1,8, 15,0),
                    new DateTime(),
                    new DateTime(),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,14,30,0),
                    new DateTime(01,01,1,15,30,0),
                    new DateTime(01,01,1,13, 30,0),
                    new DateTime(01,01,1,16, 30,0),
                    new DateTime(),
                    new DateTime(),
                },

                nothMom = "",
            };
            Mother Beili_Yudkevitz = new Mother
            {
                IdMom = idMotherArray[8],
                FirstNameMom = "שולה",
                LasNameMom = "יודקביץ",
                AddressMom = "HaRav Shalom Shabazi St 4, Jerusalem",
                PhoneMom = 0509998881,
                AddressForNanny = "Shakhal St 23,Jerusalem",
                DaysRequestMom = new bool[6] { true, false, true, true, true, false },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,7, 45, 0),
                    new DateTime(),
                    new DateTime(01,01,1,7, 45,0),
                    new DateTime(01,01,1,7, 45,0),
                    new DateTime(01,01,1,7, 45,0),
                    new DateTime(),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,14,30,0),
                    new DateTime(),
                    new DateTime(01,01,1,15, 30,0),
                    new DateTime(01,01,1,15, 30,0),
                    new DateTime(01,01,1,13, 30,0),
                    new DateTime(),
                },
                nothMom = "",
            };
            Mother Malki_Orbach = new Mother
            {
                IdMom = idMotherArray[9],
                FirstNameMom = "מלכי",
                LasNameMom = "אורבך",
                AddressMom = "HaRav Kuk St 12, Jerusalem",
                PhoneMom = 0571114444,
                AddressForNanny = "Shakhal St 23,Jerusalem",
                DaysRequestMom = new bool[6] { true, false, true, true, true, false },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,8, 0, 0),
                    new DateTime(),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8, 45,0),
                    new DateTime(01,01,1,8, 30,0),
                    new DateTime(),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,14,30,0),
                    new DateTime(),
                    new DateTime(01,01,1,12, 30,0),
                    new DateTime(01,01,1,16, 0,0),
                    new DateTime(01,01,1,13, 30,0),
                    new DateTime(),
                },
                nothMom = "",
            };
            Mother Yuti_Ashlag = new Mother
            {
                IdMom = idMotherArray[10],
                FirstNameMom = "יעל",
                LasNameMom = "קליין",
                AddressMom = "HaRav Reines St 5, Jerusalem",
                PhoneMom = 0528989897,
                AddressForNanny = "Shakhal St 23,Jerusalem",
                DaysRequestMom = new bool[6] { true, true, true, true, true, false },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,8, 0, 0),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8, 45,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,14,30,0),
                    new DateTime(01,01,1,15,30,0),
                    new DateTime(01,01,1,12, 30,0),
                    new DateTime(01,01,1,16, 0,0),
                    new DateTime(01,01,1,13, 30,0),
                    new DateTime(),
                },

                nothMom = "",
            };
            Mother Sara_Landau = new Mother
            {
                IdMom = idMotherArray[11],
                FirstNameMom = "שרה",
                LasNameMom = "לנדאו",
                AddressMom = "Sderot Sarei Israel St 2 Jerusalem",
                PhoneMom = 0527616509,
                AddressForNanny = "Shakhal St 23,Jerusalem",
                DaysRequestMom = new bool[6] { false, true, true, true, true, false },
                startHour = new DateTime[6]
                {
                    new DateTime(),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8, 45,0),
                    new DateTime(01,01,1,7, 30,0),
                    new DateTime(),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(),
                    new DateTime(01,01,1,15,30,0),
                    new DateTime(01,01,1,12, 30,0),
                    new DateTime(01,01,1,16, 0,0),
                    new DateTime(01,01,1,13, 30,0),
                    new DateTime(),
                },
                nothMom = "",
            };
            Mother Ruti_salomon = new Mother
            {
                IdMom = idMotherArray[12],
                FirstNameMom = "רותי",
                LasNameMom = "סלמון",
                AddressMom = "Jaffa St 8, Jerusalem",
                PhoneMom = 0543331234,
                AddressForNanny = "Shakhal St 23,Jerusalem",
                DaysRequestMom = new bool[6] { true, false, true, true, true, false },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,8, 0, 0),
                    new DateTime(),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8, 45,0),
                    new DateTime(01,01,1,7, 45,0),
                    new DateTime(),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,14,30,0),
                    new DateTime(),
                    new DateTime(01,01,1,12, 30,0),
                    new DateTime(01,01,1,16, 30,0),
                    new DateTime(01,01,1,13, 30,0),
                    new DateTime(),
                },
                nothMom = "",
            };
            Mother Chani_Stern = new Mother
            {
                IdMom = idMotherArray[13],
                FirstNameMom = "חני",
                LasNameMom = "שטרן",
                AddressMom = "Yafo St 222, Jerusalem",
                PhoneMom = 0525555111,
                AddressForNanny = "Shakhal St 23,Jerusalem",
                DaysRequestMom = new bool[6] { true, true, true, true, false, false },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,8, 0, 0),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8, 45,0),
                    new DateTime(),
                    new DateTime(),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,14,30,0),
                    new DateTime(01,01,1,15,30,0),
                    new DateTime(01,01,1,14, 30,0),
                    new DateTime(01,01,1,16, 0,0),
                    new DateTime(),
                    new DateTime(),
                },
                nothMom = "",
            };
            Mother Aliza_Sorotzkin = new Mother
            {
                IdMom = idMotherArray[14],
                FirstNameMom = "עליזה",
                LasNameMom = "סורוצקין",
                AddressMom = "Ha-Nevi'im St 4, Jerusalem",
                PhoneMom = 0526870003,
                AddressForNanny = "Shakhal St 23,Jerusalem",
                DaysRequestMom = new bool[6] { false, true, true, true, true, false },
                startHour = new DateTime[6]
                {
                    new DateTime(),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8, 45,0),
                    new DateTime(01,01,1,7, 45,0),
                    new DateTime(),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(),
                    new DateTime(01,01,1,15,30,0),
                    new DateTime(01,01,1,12, 30,0),
                    new DateTime(01,01,1,16, 30,0),
                    new DateTime(01,01,1,13, 30,0),
                    new DateTime(),
                },
                nothMom = "",
            };
            Mother Mina_Berkovitz = new Mother
            {
                IdMom = idMotherArray[15],
                FirstNameMom = "מרב",
                LasNameMom = "רייכנר",
                AddressMom = "Ha-Amarkalim St 4, Jerusalem",
                PhoneMom = 056754312,
                AddressForNanny = "Shakhal St 23,Jerusalem",
                DaysRequestMom = new bool[6] { true, false, true, true, true, false },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,8, 0, 0),
                    new DateTime(),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8, 15,0),
                    new DateTime(01,01,1,7, 30,0),
                    new DateTime(),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,14,30,0),
                    new DateTime(),
                    new DateTime(01,01,1,12, 30,0),
                    new DateTime(01,01,1,16, 0,0),
                    new DateTime(01,01,1,13, 30,0),
                    new DateTime(),
                },
                nothMom = "",
            };
            Mother Shani_Hovav = new Mother
            {
                IdMom = idMotherArray[16],
                FirstNameMom = "שני",
                LasNameMom = "חובב",
                AddressMom = "Sulam Ya'akov St 32, Jerusalem",
                PhoneMom = 0520909091,
                AddressForNanny = "Shakhal St 23,Jerusalem",
                DaysRequestMom = new bool[6] { false, true, false, true, true, true },
                startHour = new DateTime[6]
                {
                    new DateTime(),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(),
                    new DateTime(01,01,1,8, 45,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8,0,0),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(),
                    new DateTime(01,01,1,15,30,0),
                    new DateTime(),
                    new DateTime(01,01,1,16, 0,0),
                    new DateTime(01,01,1,14, 30,0),
                    new DateTime(01,01,1,12,0,0),
                },
                nothMom = "",
            };
            Mother Esti_Lerner = new Mother
            {
                IdMom = idMotherArray[17],
                FirstNameMom = "רחל",
                LasNameMom = "אלבז",
                AddressMom = "Binyamin Minz St 7, Jerusalem",
                PhoneMom = 0522020202,
                AddressForNanny = "Shakhal St 23,Jerusalem",
                DaysRequestMom = new bool[6] { true, false, true, true, true, false },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,8, 0, 0),
                    new DateTime(),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8, 45,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,14,30,0),
                    new DateTime(),
                    new DateTime(01,01,1,12, 30,0),
                    new DateTime(01,01,1,15, 0,0),
                    new DateTime(01,01,1,13, 30,0),
                    new DateTime(),
                },
                nothMom = "",
            };
            Mother Rochi_Zaltz = new Mother
            {
                IdMom = idMotherArray[18],
                FirstNameMom = "רחל",
                LasNameMom = "זקב",
                AddressMom = "Panim Meirot St 14, Jerusalem",
                PhoneMom = 0521313132,
                AddressForNanny = "Shakhal St 23,Jerusalem",
                DaysRequestMom = new bool[6] { true, true, false, true, true, false },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,8, 15, 0),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(),
                    new DateTime(01,01,1,8, 45,0),
                    new DateTime(01,01,1,7, 45,0),
                    new DateTime(),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,13,30,0),
                    new DateTime(01,01,1,15,30,0),
                    new DateTime(),
                    new DateTime(01,01,1,16, 0,0),
                    new DateTime(01,01,1,13, 30,0),
                    new DateTime(),
                },
                nothMom = "",
            };
            Mother Faigi_toyb = new Mother
            {
                IdMom = idMotherArray[19],
                FirstNameMom = "נינט",
                LasNameMom = "טייב",
                AddressMom = "Ha-Yehudim St 2, Jerusalem",
                PhoneMom = 0521001001,
                AddressForNanny = "Shakhal St 23,Jerusalem",
                DaysRequestMom = new bool[6] { true, true, true, false, true, false },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,8, 30, 0),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,13,30,0),
                    new DateTime(01,01,1,12,30,0),
                    new DateTime(01,01,1,12, 30,0),
                    new DateTime(),
                    new DateTime(01,01,1,13, 30,0),
                    new DateTime(),
                },
            };
            Mother Shiri_Hochman = new Mother
            {
                IdMom = idMotherArray[20],
                FirstNameMom = "שירי",
                LasNameMom = "הוכמן",
                AddressMom = "Me'a She'arim St 1, Jerusalem",
                PhoneMom = 0521818181,
                AddressForNanny = "Shakhal St 23,Jerusalem",
                DaysRequestMom = new bool[6] { true, true, true, true, false, false },
                startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,8, 0, 0),
                    new DateTime(01,01,1,8,30,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8, 30,0),
                    new DateTime(),
                    new DateTime(),
                },
                endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,14,30,0),
                    new DateTime(01,01,1,15,30,0),
                    new DateTime(01,01,1,12, 30,0),
                    new DateTime(01,01,1,16, 30,0),
                    new DateTime(),
                    new DateTime(),
                },
                nothMom = "",
            };
            try
            {
                dal.addMom(Bracha_Polak);
                dal.addMom(Shiri_Hochman);
                dal.addMom(Rochi_Zaltz);
                dal.addMom(Faigi_toyb);
                dal.addMom(Esti_Lerner);
                dal.addMom(Shani_Hovav);
                dal.addMom(Mina_Berkovitz);
                dal.addMom(Aliza_Sorotzkin);
                dal.addMom(Chani_Stern);
                dal.addMom(Ruti_salomon);
                dal.addMom(Sara_Landau);
                dal.addMom(Yuti_Ashlag);
                dal.addMom(Malki_Orbach);
                dal.addMom(Beili_Yudkevitz);
                dal.addMom(Bracha_Polak);
                dal.addMom(Ayelt_Shaked);
                dal.addMom(Oshrat_Levi);
                dal.addMom(Gilat_Benet);
                dal.addMom(Esti_Kopshitz);
                dal.addMom(Tovi_Shachak);
                dal.addMom(Irena_Gavrielov);
                dal.addMom(Sheindi_Lider);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


        }

        /// <summary>
        /// Initilize & addtion to list 30 Childs
        /// </summary>
        void ChildInitilize()
        {
            Child nadav = new Child
            {
                idChild = idChildArray[0],
                idMom = idMotherArray[0],
                firstName = "נדב",
                lastName = "פולק",
                birthdayKid = new DateTime(2017, 8, 26),
                isSpecialNeed = false,
            };
            Child moty = new Child
            {
                idChild = idChildArray[1],
                idMom = idMotherArray[1],
                firstName = "מוטי",
                lastName = "לוי",
                birthdayKid = new DateTime(2017, 9, 8),
                isSpecialNeed = false,
            };
            Child eti = new Child
            {
                idChild = idChildArray[2],
                idMom = idMotherArray[2],
                firstName = "אתי",
                lastName = "שקד",
                birthdayKid = new DateTime(2017, 5, 29),
                isSpecialNeed = false,
            };
            Child miri = new Child
            {
                idChild = idChildArray[3],
                idMom = idMotherArray[3],
                firstName = "הלל",
                lastName = "בנט",
                birthdayKid = new DateTime(2017, 1, 22),
                isSpecialNeed = false,
            };
            Child david = new Child
            {
                idChild = idChildArray[4],
                idMom = idMotherArray[4],
                firstName = "דוד",
                lastName = "קופביץ",
                birthdayKid = new DateTime(2017, 2, 9),
                isSpecialNeed = false,
            };
            Child yael = new Child
            {
                idChild = idChildArray[5],
                idMom = idMotherArray[4],
                firstName = "יעל",
                lastName = "קופביץ",
                birthdayKid = new DateTime(2017, 2, 24),
                isSpecialNeed = false,
            };
            Child naama = new Child
            {
                idChild = idChildArray[6],
                idMom = idMotherArray[5],
                firstName = "נעמה",
                lastName = "גבריאלוב",
                birthdayKid = new DateTime(2017, 3, 1),
                isSpecialNeed = false,
            };
            Child hila = new Child
            {
                idChild = idChildArray[7],
                idMom = idMotherArray[6],
                firstName = "הילה",
                lastName = "שחק",
                birthdayKid = new DateTime(2017, 2, 2),
                isSpecialNeed = false,
            };
            Child michal = new Child
            {
                idChild = idChildArray[8],
                idMom = idMotherArray[7],
                firstName = "מיכל",
                lastName = "שובי",
                birthdayKid = new DateTime(2017, 5, 29),
                isSpecialNeed = false,
            };
            Child adi = new Child
            {
                idChild = idChildArray[9],
                idMom = idMotherArray[7],
                firstName = "עדי ",
                lastName = "שובי",
                birthdayKid = new DateTime(2017, 1, 9),
                isSpecialNeed = false,
            };
            Child reut = new Child
            {
                idChild = idChildArray[10],
                idMom = idMotherArray[7],
                firstName = "רעות",
                lastName = "שובי",
                birthdayKid = new DateTime(2017, 4, 2),
                isSpecialNeed = false,
            };
            Child efrat = new Child
            {
                idChild = idChildArray[11],
                idMom = idMotherArray[8],
                firstName = "אפי",
                lastName = "יודקביץ",
                birthdayKid = new DateTime(2017, 4, 12),
                isSpecialNeed = false,
            };
            Child noa = new Child
            {
                idChild = idChildArray[12],
                idMom = idMotherArray[8],
                firstName = "נעה",
                lastName = "יודקביץ",
                birthdayKid = new DateTime(2017, 5, 1),
                isSpecialNeed = false,
            };
            Child shira = new Child
            {
                idChild = idChildArray[13],
                idMom = idMotherArray[9],
                firstName = "שירה",
                lastName = "אורבך",
                birthdayKid = new DateTime(2017, 5, 29),
                isSpecialNeed = false,
            };
            Child Moriya = new Child
            {
                idChild = idChildArray[14],
                idMom = idMotherArray[10],
                firstName = "מוריה",
                lastName = "קליין",
                birthdayKid = new DateTime(2017, 6, 2),
                isSpecialNeed = false,
            };
            Child sari = new Child
            {
                idChild = idChildArray[15],
                idMom = idMotherArray[10],
                firstName = "שרי",
                lastName = "קליין",
                birthdayKid = new DateTime(2017, 6, 9),
                isSpecialNeed = false,
            };
            Child yehuda = new Child
            {
                idChild = idChildArray[16],
                idMom = idMotherArray[11],
                firstName = "יהודה",
                lastName = "לנדאו",
                birthdayKid = new DateTime(2017, 6, 29),
                isSpecialNeed = false,
            };
            Child itsik = new Child
            {
                idChild = idChildArray[17],
                idMom = idMotherArray[12],
                firstName = "איציק",
                lastName = "סלמון",
                birthdayKid = new DateTime(2017, 8, 11),
                isSpecialNeed = false,
            };
            Child pinchas = new Child
            {
                idChild = idChildArray[18],
                idMom = idMotherArray[13],
                firstName = "פנחס",
                lastName = "שטרן",
                birthdayKid = new DateTime(2017, 7, 3),
                isSpecialNeed = false,
            };
            Child yanki = new Child
            {
                idChild = idChildArray[19],
                idMom = idMotherArray[14],
                firstName = "אורי",
                lastName = "סורוצקין",
                birthdayKid = new DateTime(2017, 6, 2),
                isSpecialNeed = false,
            };
            Child eliyau = new Child
            {
                idChild = idChildArray[20],
                idMom = idMotherArray[15],
                firstName = "אליהו",
                lastName = "רייכנר",
                birthdayKid = new DateTime(2017, 6, 2),
                isSpecialNeed = false,
            };
            Child eli = new Child
            {
                idChild = idChildArray[21],
                idMom = idMotherArray[15],
                firstName = "אלי",
                lastName = "רייכנר",
                birthdayKid = new DateTime(2017, 9, 9),
                isSpecialNeed = false,
            };
            Child yosef = new Child
            {
                idChild = idChildArray[22],
                idMom = idMotherArray[16],
                firstName = "יוסף",
                lastName = "חובב",
                birthdayKid = new DateTime(2017, 10, 22),
                isSpecialNeed = false,
            };
            Child ari = new Child
            {
                idChild = idChildArray[23],
                idMom = idMotherArray[17],
                firstName = "ארי",
                lastName = "אלבז",
                birthdayKid = new DateTime(2017, 11, 29),
                isSpecialNeed = false,
            };
            Child shuki = new Child
            {
                idChild = idChildArray[24],
                idMom = idMotherArray[17],
                firstName = "שוקי",
                lastName = "אלבז",
                birthdayKid = new DateTime(2017, 12, 2),
                isSpecialNeed = false,
            };
            Child itamar = new Child
            {
                idChild = idChildArray[25],
                idMom = idMotherArray[17],
                firstName = "איתמר",
                lastName = "אלבז",
                birthdayKid = new DateTime(2017, 5, 2),
                isSpecialNeed = false,
            };
            Child yoni = new Child
            {
                idChild = idChildArray[26],
                idMom = idMotherArray[18],
                firstName = "יוני",
                lastName = "זקב",
                birthdayKid = new DateTime(2017, 10, 14),
                isSpecialNeed = false,
            };
            Child moishi = new Child
            {
                idChild = idChildArray[27],
                idMom = idMotherArray[19],
                firstName = "מויישי",
                lastName = "טייב",
                birthdayKid = new DateTime(2017, 3, 19),
                isSpecialNeed = false,
            };
            Child avreimi = new Child
            {
                idChild = idChildArray[28],
                idMom = idMotherArray[19],
                firstName = "אבריימי",
                lastName = "טייב",
                birthdayKid = new DateTime(2017, 11, 9),
                isSpecialNeed = false,
            };
            Child yosi = new Child
            {
                idChild = idChildArray[29],
                idMom = idMotherArray[20],
                firstName = "יוסי",
                lastName = "הוכמן",
                birthdayKid = new DateTime(2017, 12, 2),
                isSpecialNeed = false,
            };
            try
            {
                dal.addChild(nadav);
                dal.addChild(moty);
                dal.addChild(eli);
                dal.addChild(yael);
                dal.addChild(yanki);
                dal.addChild(yehuda);
                dal.addChild(yoni);
                dal.addChild(yosef);
                dal.addChild(yosi);
                dal.addChild(michal);
                dal.addChild(miri);
                dal.addChild(moishi);
                dal.addChild(Moriya);
                dal.addChild(naama);
                dal.addChild(noa);
                dal.addChild(sari);
                dal.addChild(shira);
                dal.addChild(shuki);
                dal.addChild(efrat);
                dal.addChild(eliyau);
                dal.addChild(hila);
                dal.addChild(pinchas);
                dal.addChild(itsik);
                dal.addChild(itamar);
                dal.addChild(eti);
                dal.addChild(adi);
                dal.addChild(david);
                dal.addChild(ari);
                dal.addChild(avreimi);
                dal.addChild(reut);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
        }


        /// <summary>
        /// Initilize & addtion to list of Contracts, Note! there are children that have no nanny
        /// </summary>
        //void ContractInitilize()
        //{
        //    Contract con;
        //    for (int i = 0; i < 30; i++)
        //    {

        //        Mother m = dal.getMom().Find(x => x.ID == dal.getChild().Find(y => y.ID == idChildArray[i]).idMother);
        //        try
        //        {
        //            int Nannyid = FindNanny(m);
        //            con = new Contract
        //            {
        //                idChild = idChildArray[i],
        //                idNanny = Nannyid,
        //                NameNanny = dal.getNanny().Find(x => x.ID == Nannyid).name,
        //                IntroductoryMeeting = true,//if its not, addContract will change it
        //                signed = true,
        //                beginDeal = DateTime.Today,
        //                endDeal = new DateTime(2108, 6, 25),
        //            };
        //            if (dal.addContract(con))
        //            //throw the nanny that get a child to the end of list, to distribute evenly
        //            {
        //                Nanny n = dal.getNanny().Find(x => x.ID == con.idNanny);
        //                dal.removeNanny(con.idNanny);
        //                dal.addNanny(n);
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            //Console.WriteLine(dal.getMother().Find(x => x.ID == dal.getChild().Find(y => y.ID == idChildArray[i]).idMother).name);
        //            /* don't something*/
        //        }
        //    }
        //foreach (Nanny n in dal.getNanny())
        //    if (n.myChildren != null)
        //    {
        //        Console.WriteLine(n.name.ToString());
        //        Console.WriteLine(n.myChildren.Count);
        //    }
    }
}


