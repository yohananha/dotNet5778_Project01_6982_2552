using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using BE;
using DS;


namespace DAL
{

    class Dal_XML_imp : Idal
    {
        public static int contract_Id = 1;

        private XElement nannysFile, motherFile, childFile, contractFile;
        string nannyPath = @"c:\xml\nanny.xml";
        string momPath = @"c:\xml\mother.xml";
        string kidPath = @"c:\xml\child.xml";
        string contractPath = @"c:\xml\contract.xml";


        public Dal_XML_imp()
        {
            new DataSource();
            if (!File.Exists(nannyPath))
                createFile(nannyPath, "Nannies");
            if (!File.Exists(momPath))
                createFile(momPath, "Mothers");
            if (!File.Exists(kidPath))
                createFile(kidPath, "Children");
            if (!File.Exists(contractPath))
                createFile(contractPath, "Contracts");

        }

        #region nannny funcs

        public void addNanny(Nanny nanny)
        {
            Nanny nannyCheck = getNanny(nanny.nannyId);
            if (nannyCheck != null)
                throw new Exception("Nanny is already exist in system");
            XElement id = new XElement("id", nanny.nannyId);
            XElement lastName = new XElement("lastName", nanny.lastNameNanny);
            XElement firstName = new XElement("firstName", nanny.firstNameNanny);
            XElement name = new XElement("name", firstName, lastName);
            XElement date = new XElement("date", nanny.dateNanny);
            XElement phone = new XElement("phone", nanny.phoneNanny);
            XElement address = new XElement("address", nanny.addressNanny);
            XElement elevatorNanny = new XElement("elevatorNanny", nanny.elevatorNanny);
            XElement floorNanny = new XElement("floorNanny", nanny.floorNanny);
            XElement experienceNanny = new XElement("experienceNanny", nanny.experienceNanny);
            XElement maxChildNanny = new XElement("maxChildNanny", nanny.maxChildNanny);
            XElement minAgeChildNanny = new XElement("minAgeChildNanny", nanny.minAgeChildNanny);
            XElement maxAgeChildNanny = new XElement("maxAgeChildNanny", nanny.maxAgeChildNanny);
            XElement isByHourNanny = new XElement("isByHourNanny", nanny.isByHourNanny);
            XElement rateHourNanny = new XElement("rateHourNanny", nanny.rateHourNanny);
            XElement rateMonthNanny = new XElement("rateMonthNanny", nanny.rateMonthNanny);
            XElement sunWork = new XElement("sunWork", nanny.daysWorkNanny[0]);
            XElement monWork = new XElement("monWork", nanny.daysWorkNanny[1]);
            XElement tueWork = new XElement("tueWork", nanny.daysWorkNanny[2]);
            XElement wedWork = new XElement("wedWork", nanny.daysWorkNanny[3]);
            XElement thuWork = new XElement("thuWork", nanny.daysWorkNanny[4]);
            XElement friWork = new XElement("friWork", nanny.daysWorkNanny[5]);
            XElement daysWork = new XElement("daysWorkNanny", sunWork, monWork, tueWork, wedWork, thuWork, friWork);
            XElement isTamatNanny = new XElement("isTamatNanny", nanny.isTamatNanny);
            XElement recommendationsNanny = new XElement("recommendationsNanny", nanny.recommendationsNanny);
            XElement currentChildren = new XElement("currentChildren", nanny.currentChildren);
            XElement sunStart = new XElement("sunStart", nanny.startHour[0]);
            XElement monStart = new XElement("monStart", nanny.startHour[1]);
            XElement tueStart = new XElement("tueStart", nanny.startHour[2]);
            XElement wedStart = new XElement("wedStart", nanny.startHour[3]);
            XElement thuStart = new XElement("thuStart", nanny.startHour[4]);
            XElement friStart = new XElement("friStart", nanny.startHour[5]);
            XElement startHour = new XElement("startHour", sunStart, monStart, tueStart, wedStart, thuStart, friStart);
            XElement sunEnd = new XElement("sunEnd", nanny.endHour[0]);
            XElement monEnd = new XElement("monEnd", nanny.endHour[1]);
            XElement tueEnd = new XElement("tueEnd", nanny.endHour[2]);
            XElement wedEnd = new XElement("wedEnd", nanny.endHour[3]);
            XElement thuEnd = new XElement("thuEnd", nanny.endHour[4]);
            XElement friEnd = new XElement("friEnd", nanny.endHour[5]);
            XElement endHour = new XElement("endHour", sunEnd, monEnd, tueEnd, wedEnd, thuEnd, friEnd);

            nannysFile.Add(new XElement("nanny", id, name, date, phone, address, elevatorNanny, floorNanny, experienceNanny,
                                        maxChildNanny, minAgeChildNanny, maxAgeChildNanny, isByHourNanny, rateHourNanny, rateMonthNanny,
                                        daysWork, isTamatNanny, recommendationsNanny, currentChildren, startHour, endHour));

            nannysFile.Save(nannyPath);
        }

        public void deleteNanny(long idNannyDel)
        {
            XElement nannyElement;

            nannyElement = (from nan in nannysFile.Elements()
                            where int.Parse(nan.Element("id").Value) == idNannyDel
                            select nan).FirstOrDefault();
            if (nannyElement == null)
                throw new Exception("Nanny is not exist in system");
            var contractList = getContracts(cl => cl.idNanny == idNannyDel);
            foreach (var contract in contractList)
            {
                deleteContract(contract.idChild);
            }
            nannyElement.Remove();
            nannysFile.Save(nannyPath);
        }

        public void updateNanny(Nanny nannye)
        {
            LoadData("nanny");

            XElement nannyElement = (from nan in nannysFile.Elements()
                                     where int.Parse(nan.Element("id").Value) == nannye.nannyId
                                     select nan).FirstOrDefault();
            if (nannyElement == null)
                throw new Exception("Nanny is not exist in system");

            nannyElement.Element("name").Element("lastName").Value = nannye.lastNameNanny;
            nannyElement.Element("name").Element("firstName").Value = nannye.firstNameNanny;
            nannyElement.Element("date").Value = nannye.dateNanny.ToString();
            nannyElement.Element("phone").Value = nannye.phoneNanny.ToString();
            nannyElement.Element("address").Value = nannye.addressNanny;
            nannyElement.Element("elevatorNanny").Value = nannye.elevatorNanny.ToString();
            nannyElement.Element("floorNanny").Value = nannye.floorNanny.ToString();
            nannyElement.Element("experienceNanny").Value = nannye.experienceNanny.ToString();
            nannyElement.Element("maxChildNanny").Value = nannye.maxChildNanny.ToString();
            nannyElement.Element("minAgeChildNanny").Value = nannye.minAgeChildNanny.ToString();
            nannyElement.Element("maxAgeChildNanny").Value = nannye.maxAgeChildNanny.ToString();
            nannyElement.Element("isByHourNanny").Value = nannye.isByHourNanny.ToString();
            nannyElement.Element("rateHourNanny").Value = nannye.rateHourNanny.ToString();
            nannyElement.Element("rateMonthNanny").Value = nannye.rateMonthNanny.ToString();
            nannyElement.Element("daysWorkNanny").Element("sunWork").Value = nannye.daysWorkNanny[0].ToString();
            nannyElement.Element("daysWorkNanny").Element("monWork").Value = nannye.daysWorkNanny[1].ToString();
            nannyElement.Element("daysWorkNanny").Element("tueWork").Value = nannye.daysWorkNanny[2].ToString();
            nannyElement.Element("daysWorkNanny").Element("wedWork").Value = nannye.daysWorkNanny[3].ToString();
            nannyElement.Element("daysWorkNanny").Element("thuWork").Value = nannye.daysWorkNanny[4].ToString();
            nannyElement.Element("daysWorkNanny").Element("friWork").Value = nannye.daysWorkNanny[5].ToString();

            nannyElement.Element("isTamatNanny").Value = nannye.isTamatNanny.ToString();
            nannyElement.Element("recommendationsNanny").Value = nannye.recommendationsNanny;
            nannyElement.Element("currentChildren").Value = nannye.currentChildren.ToString();

            nannyElement.Element("startHour").Element("sunStart").Value = nannye.daysWorkNanny[0].ToString();
            nannyElement.Element("startHour").Element("monStart").Value = nannye.daysWorkNanny[1].ToString();
            nannyElement.Element("startHour").Element("tueStart").Value = nannye.daysWorkNanny[2].ToString();
            nannyElement.Element("startHour").Element("wedStart").Value = nannye.daysWorkNanny[3].ToString();
            nannyElement.Element("startHour").Element("thuStart").Value = nannye.daysWorkNanny[4].ToString();
            nannyElement.Element("startHour").Element("friStart").Value = nannye.daysWorkNanny[5].ToString();

            nannyElement.Element("endHour").Element("sunEnd").Value = nannye.endHour[0].ToString();
            nannyElement.Element("endHour").Element("monEnd").Value = nannye.endHour[1].ToString();
            nannyElement.Element("endHour").Element("tueEnd").Value = nannye.endHour[2].ToString();
            nannyElement.Element("endHour").Element("wedEnd").Value = nannye.endHour[3].ToString();
            nannyElement.Element("endHour").Element("thuEnd").Value = nannye.endHour[4].ToString();
            nannyElement.Element("endHour").Element("friEnd").Value = nannye.endHour[5].ToString();

            nannysFile.Save(nannyPath);
        }

        public IEnumerable<Nanny> getAllNanny(Func<Nanny, bool> Predicate = null)
        {
            LoadData("nanny");
            List<Nanny> nannyList;
            try
            {
                nannyList = (from nan in nannysFile.Elements()
                             select new Nanny()
                             {
                                 nannyId = long.Parse(nan.Element("id").Value),
                                 lastNameNanny = nan.Element("name").Element("lastName").Value,
                                 firstNameNanny = nan.Element("name").Element("firstName").Value,
                                 dateNanny = DateTime.Parse(nan.Element("date").Value),
                                 phoneNanny = long.Parse(nan.Element("phone").Value),
                                 addressNanny = nan.Element("address").Value,
                                 elevatorNanny = bool.Parse(nan.Element("elevatorNanny").Value),
                                 floorNanny = int.Parse(nan.Element("floorNanny").Value),
                                 experienceNanny = int.Parse(nan.Element("experienceNanny").Value),
                                 maxChildNanny = int.Parse(nan.Element("maxChildNanny").Value),
                                 minAgeChildNanny = int.Parse(nan.Element("minAgeChildNanny").Value),
                                 maxAgeChildNanny = int.Parse(nan.Element("maxAgeChildNanny").Value),
                                 isByHourNanny = bool.Parse(nan.Element("isByHourNanny").Value),
                                 rateHourNanny = int.Parse(nan.Element("rateHourNanny").Value),
                                 rateMonthNanny = int.Parse(nan.Element("rateMonthNanny").Value),
                                 daysWorkNanny = new bool[6]{
                                        bool.Parse(nan.Element("daysWorkNanny").Element("sunWork").Value),
                                        bool.Parse(nan.Element("daysWorkNanny").Element("monWork").Value),
                                        bool.Parse(nan.Element("daysWorkNanny").Element("tueWork").Value),
                                        bool.Parse(nan.Element("daysWorkNanny").Element("wedWork").Value),
                                        bool.Parse(nan.Element("daysWorkNanny").Element("thuWork").Value),
                                        bool.Parse(nan.Element("daysWorkNanny").Element("friWork").Value)
                                },
                                 isTamatNanny = bool.Parse(nan.Element("isTamatNanny").Value),
                                 recommendationsNanny = nan.Element("recommendationsNanny").Value,
                                 currentChildren = int.Parse(nan.Element("currentChildren").Value),
                                 startHour = new DateTime[6]
                                    {
                                        DateTime.Parse(nan.Element("startHour").Element("sunStart").Value),
                                        DateTime.Parse(nan.Element("startHour").Element("monStart").Value),
                                        DateTime.Parse(nan.Element("startHour").Element("tueStart").Value),
                                        DateTime.Parse(nan.Element("startHour").Element("wedStart").Value),
                                        DateTime.Parse(nan.Element("startHour").Element("thuStart").Value),
                                        DateTime.Parse(nan.Element("startHour").Element("friStart").Value),
                                    },
                                 endHour = new DateTime[6]
                                    {
                                        DateTime.Parse(nan.Element("endHour").Element("sunEnd").Value),
                                        DateTime.Parse(nan.Element("endHour").Element("monEnd").Value),
                                        DateTime.Parse(nan.Element("endHour").Element("tueEnd").Value),
                                        DateTime.Parse(nan.Element("endHour").Element("wedEnd").Value),
                                        DateTime.Parse(nan.Element("endHour").Element("thuEnd").Value),
                                        DateTime.Parse(nan.Element("endHour").Element("friEnd").Value),
                                    }
                             }).ToList();
            }
            catch
            {
                nannyList = null;
            }
            if (Predicate == null)
                return nannyList;

            return nannyList.Where(Predicate);
        }

        public Nanny getNanny(long idNanny)
        {
            LoadData("nanny");
            Nanny nanny;

            nanny = (from nan in nannysFile.Elements()
                     where long.Parse(nan.Element("id").Value) == idNanny
                     select new Nanny()
                     {
                         nannyId = long.Parse(nan.Element("id").Value),
                         lastNameNanny = nan.Element("name").Element("lastName").Value,
                         firstNameNanny = nan.Element("name").Element("firstName").Value,
                         dateNanny = DateTime.Parse(nan.Element("date").Value),
                         phoneNanny = long.Parse(nan.Element("phone").Value),
                         addressNanny = nan.Element("address").Value,
                         elevatorNanny = bool.Parse(nan.Element("elevatorNanny").Value),
                         floorNanny = int.Parse(nan.Element("floorNanny").Value),
                         experienceNanny = int.Parse(nan.Element("experienceNanny").Value),
                         maxChildNanny = int.Parse(nan.Element("maxChildNanny").Value),
                         minAgeChildNanny = int.Parse(nan.Element("minAgeChildNanny").Value),
                         maxAgeChildNanny = int.Parse(nan.Element("maxAgeChildNanny").Value),
                         isByHourNanny = bool.Parse(nan.Element("isByHourNanny").Value),
                         rateHourNanny = int.Parse(nan.Element("rateHourNanny").Value),
                         rateMonthNanny = int.Parse(nan.Element("rateMonthNanny").Value),
                         daysWorkNanny = new bool[6]{
                                bool.Parse(nan.Element("daysWorkNanny").Element("sunWork").Value),
                                bool.Parse(nan.Element("daysWorkNanny").Element("monWork").Value),
                                bool.Parse(nan.Element("daysWorkNanny").Element("tueWork").Value),
                                bool.Parse(nan.Element("daysWorkNanny").Element("wedWork").Value),
                                bool.Parse(nan.Element("daysWorkNanny").Element("thuWork").Value),
                                bool.Parse(nan.Element("daysWorkNanny").Element("friWork").Value)
                                },
                         isTamatNanny = bool.Parse(nan.Element("isTamatNanny").Value),
                         recommendationsNanny = nan.Element("recommendationsNanny").Value,
                         currentChildren = int.Parse(nan.Element("currentChildren").Value),
                         startHour = new DateTime[6]
                            {
                                DateTime.Parse(nan.Element("startHour").Element("sunStart").Value),
                                DateTime.Parse(nan.Element("startHour").Element("monStart").Value),
                                DateTime.Parse(nan.Element("startHour").Element("tueStart").Value),
                                DateTime.Parse(nan.Element("startHour").Element("wedStart").Value),
                                DateTime.Parse(nan.Element("startHour").Element("thuStart").Value),
                                DateTime.Parse(nan.Element("startHour").Element("friStart").Value),
                                },
                         endHour = new DateTime[6]
                            {
                                DateTime.Parse(nan.Element("endHour").Element("sunEnd").Value),
                                DateTime.Parse(nan.Element("endHour").Element("monEnd").Value),
                                DateTime.Parse(nan.Element("endHour").Element("tueEnd").Value),
                                DateTime.Parse(nan.Element("endHour").Element("wedEnd").Value),
                                DateTime.Parse(nan.Element("endHour").Element("thuEnd").Value),
                                DateTime.Parse(nan.Element("endHour").Element("friEnd").Value),
                            }
                     }).FirstOrDefault();
            //if (nanny == null)
            //    throw new Exception("id doesn't exist");

            return nanny;
        }

        #endregion

        #region mom funcs

        public void addMom(Mother mother)
        {

            Mother momCheck = getMom(mother.IdMom);
            if (momCheck != null)
                throw new Exception("Mother is already exist in system");
            XElement id = new XElement("id", mother.IdMom);
            XElement firstName = new XElement("firstName", mother.FirstNameMom);
            XElement lastName = new XElement("lastName", mother.LasNameMom);
            XElement name = new XElement("name", firstName, lastName);
            XElement phone = new XElement("phone", mother.PhoneMom);
            XElement address = new XElement("address", mother.AddressMom);
            XElement addressForNanny = new XElement("addressForNanny", mother.AddressForNanny);
            XElement sunReq = new XElement("sunReq", mother.DaysRequestMom[0]);
            XElement monReq = new XElement("monReq", mother.DaysRequestMom[1]);
            XElement tueReq = new XElement("tueReq", mother.DaysRequestMom[2]);
            XElement wedReq = new XElement("wedReq", mother.DaysRequestMom[3]);
            XElement thuReq = new XElement("thuReq", mother.DaysRequestMom[4]);
            XElement friReq = new XElement("friReq", mother.DaysRequestMom[5]);
            XElement daysRequest = new XElement("daysRequest", sunReq, monReq, tueReq, wedReq, thuReq, friReq);
            XElement sunStart = new XElement("sunStart", mother.startHour[0]);
            XElement monStart = new XElement("monStart", mother.startHour[1]);
            XElement tueStart = new XElement("tueStart", mother.startHour[2]);
            XElement wedStart = new XElement("wedStart", mother.startHour[3]);
            XElement thuStart = new XElement("thuStart", mother.startHour[4]);
            XElement friStart = new XElement("friStart", mother.startHour[5]);
            XElement startHour = new XElement("startHour", sunStart, monStart, tueStart, wedStart, thuStart, friStart);
            XElement sunEnd = new XElement("sunEnd", mother.endHour[0]);
            XElement monEnd = new XElement("monEnd", mother.endHour[1]);
            XElement tueEnd = new XElement("tueEnd", mother.endHour[2]);
            XElement wedEnd = new XElement("wedEnd", mother.endHour[3]);
            XElement thuEnd = new XElement("thuEnd", mother.endHour[4]);
            XElement friEnd = new XElement("friEnd", mother.endHour[5]);
            XElement endHour = new XElement("endHour", sunEnd, monEnd, tueEnd, wedEnd, thuEnd, friEnd);
            XElement note = new XElement("note", mother.nothMom);

            motherFile.Add(new XElement("mother", id, name, phone, address, addressForNanny, daysRequest, startHour, endHour, note));

            motherFile.Save(momPath);


        }

        public void deleteMother(long idMotherDel)
        {

            XElement motherElement;

            motherElement = (from nan in motherFile.Elements()
                             where int.Parse(nan.Element("id").Value) == idMotherDel
                             select nan).FirstOrDefault();
            if (motherElement == null)
                throw new Exception("Mother is not exist in system");
            var idMom = Convert.ToInt64(motherElement.Element("id").Value);
            deleteAllChildtMother(idMom);

            motherElement.Remove();

            motherFile.Save(momPath);

        }

        private void deleteAllChildtMother(long idMotherDel)
        {
            var listChildToDelete = (from item in childFile.Elements()
                                     where int.Parse(item.Element("idMom").Value) == idMotherDel
                                     select item).ToList();

            //the metod deleteChild delete also the contract child
            foreach (XElement item in listChildToDelete)
                deleteChild(Convert.ToInt64(item.Element("idChild").Value));
        }

        public void updateMother(Mother mother)
        {
            LoadData("mother");

            XElement motherElement = (from mom in motherFile.Elements()
                                      where int.Parse(mom.Element("id").Value) == mother.IdMom
                                      select mom).FirstOrDefault();
            if (motherElement == null)
                throw new Exception("Nanny is not exist in system");

            motherElement.Element("name").Element("firstName").Value = mother.FirstNameMom;
            motherElement.Element("name").Element("lastName").Value = mother.LasNameMom;
            motherElement.Element("phone").Value = mother.PhoneMom.ToString();
            motherElement.Element("address").Value = mother.AddressMom;
            motherElement.Element("addressForNanny").Value = mother.AddressForNanny;
            motherElement.Element("daysRequest").Element("sunReq").Value = mother.DaysRequestMom[0].ToString();
            motherElement.Element("daysRequest").Element("monReq").Value = mother.DaysRequestMom[1].ToString();
            motherElement.Element("daysRequest").Element("tueReq").Value = mother.DaysRequestMom[2].ToString();
            motherElement.Element("daysRequest").Element("wedReq").Value = mother.DaysRequestMom[3].ToString();
            motherElement.Element("daysRequest").Element("thuReq").Value = mother.DaysRequestMom[4].ToString();
            motherElement.Element("daysRequest").Element("friReq").Value = mother.DaysRequestMom[5].ToString();
            motherElement.Element("startHour").Element("sunStart").Value = mother.startHour[0].ToString();
            motherElement.Element("startHour").Element("monStart").Value = mother.startHour[1].ToString();
            motherElement.Element("startHour").Element("tueStart").Value = mother.startHour[2].ToString();
            motherElement.Element("startHour").Element("wedStart").Value = mother.startHour[3].ToString();
            motherElement.Element("startHour").Element("thuStart").Value = mother.startHour[4].ToString();
            motherElement.Element("startHour").Element("friStart").Value = mother.startHour[5].ToString();

            motherElement.Element("endHour").Element("sunEnd").Value = mother.endHour[0].ToString();
            motherElement.Element("endHour").Element("monEnd").Value = mother.endHour[1].ToString();
            motherElement.Element("endHour").Element("tueEnd").Value = mother.endHour[2].ToString();
            motherElement.Element("endHour").Element("wedEnd").Value = mother.endHour[3].ToString();
            motherElement.Element("endHour").Element("thuEnd").Value = mother.endHour[4].ToString();
            motherElement.Element("endHour").Element("friEnd").Value = mother.endHour[5].ToString();

            motherElement.Element("note").Value = mother.nothMom;

            motherFile.Save(momPath);
        }

        public IEnumerable<Mother> getAllMothers(Func<Mother, bool> Predicate = null)
        {
            LoadData("mother");
            List<Mother> motherList;
            try
            {
                motherList = (from mom in motherFile.Elements()
                              select new Mother()
                              {
                                  IdMom = long.Parse(mom.Element("id").Value),
                                  FirstNameMom = mom.Element("name").Element("firstName").Value,
                                  LasNameMom = mom.Element("name").Element("lastName").Value,
                                  PhoneMom = long.Parse(mom.Element("phone").Value),
                                  AddressMom = mom.Element("address").Value,
                                  AddressForNanny = mom.Element("addressForNanny").Value,
                                  DaysRequestMom = new bool[6]
                                  {
                                    bool.Parse(mom.Element("daysRequest").Element("sunReq").Value),
                                    bool.Parse(mom.Element("daysRequest").Element("monReq").Value),
                                    bool.Parse(mom.Element("daysRequest").Element("tueReq").Value),
                                    bool.Parse(mom.Element("daysRequest").Element("wedReq").Value),
                                    bool.Parse(mom.Element("daysRequest").Element("thuReq").Value),
                                    bool.Parse(mom.Element("daysRequest").Element("friReq").Value)
                                  },
                                  startHour = new DateTime[6]
                                  {
                                    DateTime.Parse(mom.Element("startHour").Element("sunStart").Value),
                                    DateTime.Parse(mom.Element("startHour").Element("monStart").Value),
                                    DateTime.Parse(mom.Element("startHour").Element("tueStart").Value),
                                    DateTime.Parse(mom.Element("startHour").Element("wedStart").Value),
                                    DateTime.Parse(mom.Element("startHour").Element("thuStart").Value),
                                    DateTime.Parse(mom.Element("startHour").Element("friStart").Value)
                                  },
                                  endHour = new DateTime[6]
                                  {
                                    DateTime.Parse(mom.Element("endHour").Element("sunEnd").Value),
                                    DateTime.Parse(mom.Element("endHour").Element("monEnd").Value),
                                    DateTime.Parse(mom.Element("endHour").Element("tueEnd").Value),
                                    DateTime.Parse(mom.Element("endHour").Element("wedEnd").Value),
                                    DateTime.Parse(mom.Element("endHour").Element("thuEnd").Value),
                                    DateTime.Parse(mom.Element("endHour").Element("friEnd").Value)
                                  },
                                  nothMom = mom.Element("note").Value
                              }).ToList();
            }
            catch
            {
                motherList = null;
            }

            if (Predicate == null)
                return motherList;

            return motherList.Where(Predicate);
        }

        public Mother getMom(long idMom)
        {
            LoadData("mother");
            Mother mother;

            mother = (from mom in motherFile.Elements()
                      where long.Parse(mom.Element("id").Value) == idMom

                      select new Mother()
                      {
                          IdMom = long.Parse(mom.Element("id").Value),
                          FirstNameMom = mom.Element("name").Element("firstName").Value,
                          LasNameMom = mom.Element("name").Element("lastName").Value,
                          PhoneMom = long.Parse(mom.Element("phone").Value),
                          AddressMom = mom.Element("address").Value,
                          AddressForNanny = mom.Element("addressForNanny").Value,
                          DaysRequestMom = new bool[6]
                          {
                                  bool.Parse(mom.Element("daysRequest").Element("sunReq").Value),
                                  bool.Parse(mom.Element("daysRequest").Element("monReq").Value),
                                  bool.Parse(mom.Element("daysRequest").Element("tueReq").Value),
                                  bool.Parse(mom.Element("daysRequest").Element("wedReq").Value),
                                  bool.Parse(mom.Element("daysRequest").Element("thuReq").Value),
                                  bool.Parse(mom.Element("daysRequest").Element("friReq").Value)
                          },
                          startHour = new DateTime[6]
                          {
                                  DateTime.Parse(mom.Element("startHour").Element("sunStart").Value),
                                  DateTime.Parse(mom.Element("startHour").Element("monStart").Value),
                                  DateTime.Parse(mom.Element("startHour").Element("tueStart").Value),
                                  DateTime.Parse(mom.Element("startHour").Element("wedStart").Value),
                                  DateTime.Parse(mom.Element("startHour").Element("thuStart").Value),
                                  DateTime.Parse(mom.Element("startHour").Element("friStart").Value),
                          },
                          endHour = new DateTime[6]
                          {
                                  DateTime.Parse(mom.Element("endHour").Element("sunEnd").Value),
                                  DateTime.Parse(mom.Element("endHour").Element("monEnd").Value),
                                  DateTime.Parse(mom.Element("endHour").Element("tueEnd").Value),
                                  DateTime.Parse(mom.Element("endHour").Element("wedEnd").Value),
                                  DateTime.Parse(mom.Element("endHour").Element("thuEnd").Value),
                                  DateTime.Parse(mom.Element("endHour").Element("friEnd").Value),
                          },
                          nothMom = mom.Element("note").Value
                      }).FirstOrDefault();

            //if (mother == null)
            //    throw new Exception("id doesn't exist");
            return mother;

        }

        #endregion

        #region child funcs

        public void addChild(Child child)
        {
            Child childCheck = getChild(child.idChild);
            if (childCheck != null)
                throw new Exception("Child is already exist in system");

            XElement idMom = new XElement("idMom", child.idMom);
            XElement idChild = new XElement("idChild", child.idChild);
            XElement firstName = new XElement("firstName", child.firstName);
            XElement lastName = new XElement("lastName", child.lastName);
            XElement name = new XElement("name", firstName, lastName);
            XElement birthday = new XElement("birthday", child.birthdayKid);
            XElement isSpeacial = new XElement("isSpecial", child.isSpecialNeed);
            XElement needs = new XElement("needs", child.specialNeeds);
            childFile.Add(new XElement("child", idMom, idChild, name, birthday, isSpeacial, needs));

            childFile.Save(kidPath);
        }

        public void deleteChild(long idChildDel)
        {
            LoadData("child");

            XElement childElement;

            childElement = (from kid in childFile.Elements()
                            where long.Parse(kid.Element("idChild").Value) == idChildDel
                            select kid).FirstOrDefault();
            if (childElement == null)
                throw new Exception("Child is not appear in system");
            deleteContract(long.Parse(childElement.Element("idChild").Value));
            childElement.Remove();
            childFile.Save(kidPath);
        }

        public void updateChild(Child kid)
        {
            LoadData("child");

            XElement childElement = (from child in childFile.Elements()
                                     where int.Parse(child.Element("idChild").Value) == kid.idChild
                                     select child).FirstOrDefault();
            if (childElement == null)
                throw new Exception("Child is not appear in system");

            childElement.Element("name").Element("firstName").Value = kid.firstName;
            childElement.Element("name").Element("lastName").Value = kid.lastName;
            childElement.Element("birthday").Value = kid.birthdayKid.ToString();
            childElement.Element("isSpecial").Value = kid.isSpecialNeed.ToString();
            childElement.Element("needs").Value = kid.specialNeeds;

            childFile.Save(kidPath);

        }

        public IEnumerable<Child> getKids(Func<Child, bool> Predicate = null)
        {
            LoadData("child");
            List<Child> kidsList;
            try
            {
                 kidsList = (from child in childFile.Elements()
                    select new Child()
                    {
                        idMom = long.Parse(child.Element("idMom").Value),
                        idChild = long.Parse(child.Element("idChild").Value),
                        firstName = child.Element("name").Element("firstName").Value,
                        lastName = child.Element("name").Element("lastName").Value,
                        birthdayKid = DateTime.Parse(child.Element("birthday").Value),
                        isSpecialNeed = bool.Parse(child.Element("isSpecial").Value),
                        specialNeeds = child.Element("needs").Value,
                    }).ToList();

            }
            catch 
            {
                kidsList = null;
            }
            if (Predicate == null)
                return kidsList;
            return kidsList.Where(Predicate);
        }


        public Child getChild(long idChild)
        {
            LoadData("child");
            Child getChild;
            //var childList = getKids();

            //var child = childList.FirstOrDefault(_child => _child.idChild == idChild);
            //if (child == null)
            //    throw new Exception("id doesn't exist");

            getChild = (from kid in childFile.Elements()
                     where long.Parse(kid.Element("idChild").Value) == idChild

                     select new Child()
                     {
                         idMom = long.Parse(kid.Element("idMom").Value),
                         idChild = long.Parse(kid.Element("idChild").Value),
                         firstName = kid.Element("name").Element("firstName").Value,
                         lastName = kid.Element("name").Element("lastName").Value,
                         birthdayKid = DateTime.Parse(kid.Element("birthday").Value),
                         isSpecialNeed = bool.Parse(kid.Element("isSpecial").Value),
                         specialNeeds = kid.Element("needs").Value
                     }).FirstOrDefault();

            return getChild;

        }

        #endregion

        #region contract funcs

        public void addContract(Contract contract)
        {
            var contractList = getContracts().ToList();
            if (contractList.Exists(c => c.idChild == contract.idChild && c.idNanny == contract.idNanny))
                throw new Exception("Contract already exist in system, please update the contract");
            Child contractchild = getChild(contract.idChild);
            Mother contractMother = getMom(contractchild.idMom);
            if (contractMother == null)
                throw new Exception("Mother is not appear in the system");
            Nanny contractNanny = getNanny(contract.idNanny);
            if (contractNanny == null)
                throw new Exception("Nanny is not appear in system");
            contract.idContract = ++contract_Id;

            XElement idContract = new XElement("idContract", contract.idContract);
            XElement nameChild = new XElement("name", contract.nameChild);
            XElement idChild = new XElement("idChild", contract.idChild);
            XElement Child = new XElement("Child", nameChild, idChild);
            XElement nameNanny = new XElement("name", contract.nameNanny);
            XElement idNanny = new XElement("idNanny", contract.idNanny);
            XElement Nanny = new XElement("Nanny", nameNanny, idNanny);
            XElement isMet = new XElement("isMet", contract.isMet);
            XElement isContract = new XElement("isContract", contract.isContract);
            XElement salaryPerHour = new XElement("salaryPerHour", contract.salaryPerHour);
            XElement salaryPerMonth = new XElement("salaryPerMonth", contract.salaryPerMonth);
            XElement salaryAgreed = new XElement("salaryAgreed", contract.salaryAgreed);
            XElement isHour = new XElement("isHour", contract.isHour);
            XElement workBegin = new XElement("workBegin", contract.workBegin);
            XElement workEnd = new XElement("workEnd", contract.workEnd);

            contractFile.Add(new XElement("contract", idContract, Child, Nanny, isMet, isContract, salaryPerHour,
                                                       salaryPerMonth, salaryAgreed, isHour, workBegin, workEnd));
            contractFile.Save(contractPath);
        }

        public void deleteContract(long idChildContractDel)
        {

            LoadData("contract");

            XElement contractElement;

            contractElement = (from contr in contractFile.Elements()
                               where int.Parse(contr.Element("Child").Element("idChild").Value) == idChildContractDel
                               select contr).FirstOrDefault();
         if (contractElement == null)
               return;
            Nanny contracctNanny = getNanny(long.Parse(contractElement.Element("Nanny").Element("idNanny").Value));
            contracctNanny.currentChildren--;
            updateNanny(contracctNanny);
            contractElement.Remove();
            contractFile.Save(contractPath);

        }

        public void updateContract(Contract contract)
        {
            LoadData("contract");

            XElement contractElement = (from contr in contractFile.Elements()
                                        where int.Parse(contr.Element("idContract").Value) == contract.idContract
                                        select contr).FirstOrDefault();
            if (contractElement == null)
                throw new Exception("Contract is not exist in system");

            contractElement.Element("Child").Element("name").Value = contract.nameChild;
            contractElement.Element("Child").Element("idChild").Value = contract.idChild.ToString();
            contractElement.Element("Nanny").Element("name").Value = contract.nameNanny;
            contractElement.Element("Nanny").Element("idNanny").Value = contract.idNanny.ToString();
            contractElement.Element("isMet").Value = contract.isMet.ToString();
            contractElement.Element("isContract").Value = contract.isContract.ToString();
            contractElement.Element("salaryPerHour").Value = contract.salaryPerHour.ToString();
            contractElement.Element("salaryPerMonth").Value = contract.salaryPerMonth.ToString();
            contractElement.Element("salaryAgreed").Value = contract.salaryAgreed.ToString();
            contractElement.Element("isHour").Value = contract.isHour.ToString();
            contractElement.Element("workBegin").Value = contract.workBegin.ToString();
            contractElement.Element("workEnd").Value = contract.workEnd.ToString();

            contractFile.Save(contractPath);
        }

        public IEnumerable<Contract> getContracts(Func<Contract, bool> Predicate = null)
        {
            LoadData("contract");
            List<Contract> contracts;
            try
            {
                contracts = (from contr in contractFile.Elements()
                             select new Contract()
                             {
                                 idContract = int.Parse(contr.Element("idContract").Value),
                                 nameChild = contr.Element("Child").Element("name").Value,
                                 idChild = long.Parse(contr.Element("Child").Element("idChild").Value),
                                 nameNanny = contr.Element("Nanny").Element("name").Value,
                                 idNanny = long.Parse(contr.Element("Nanny").Element("idNanny").Value),
                                 isMet = bool.Parse(contr.Element("isMet").Value),
                                 isContract = bool.Parse(contr.Element("isContract").Value),
                                 salaryPerHour = double.Parse(contr.Element("salaryPerHour").Value),
                                 salaryPerMonth = double.Parse(contr.Element("salaryPerMonth").Value),
                                 salaryAgreed = double.Parse(contr.Element("salaryAgreed").Value),
                                 isHour = bool.Parse(contr.Element("isHour").Value),
                                 workBegin = DateTime.Parse(contr.Element("workBegin").Value),
                                 workEnd = DateTime.Parse(contr.Element("workEnd").Value)
                             }).ToList();
            }
            catch
            {
                contracts = null;
            }
            if (Predicate == null)
                return contracts;

            return contracts.Where(Predicate);
        }

        public Contract getContract(long idChildContract)
        {
            LoadData("contract");
            Contract contract;

            contract = (from contr in contractFile.Elements()
                        where long.Parse(contr.Element("Child").Element("idChild").Value) == idChildContract

                        select new Contract()
                        {
                            idContract = int.Parse(contr.Element("idContract").Value),
                            nameChild = contr.Element("Child").Element("name").Value,
                            idChild = long.Parse(contr.Element("Child").Element("idChild").Value),
                            nameNanny = contr.Element("Nanny").Element("name").Value,
                            idNanny = long.Parse(contr.Element("Nanny").Element("idNanny").Value),
                            isMet = bool.Parse(contr.Element("isMet").Value),
                            isContract = bool.Parse(contr.Element("isContract").Value),
                            salaryPerHour = double.Parse(contr.Element("salaryPerHour").Value),
                            salaryPerMonth = double.Parse(contr.Element("salaryPerMonth").Value),
                            salaryAgreed = double.Parse(contr.Element("salaryAgreed").Value),
                            isHour = bool.Parse(contr.Element("isHour").Value),
                            workBegin = DateTime.Parse(contr.Element("workBegin").Value),
                            workEnd = DateTime.Parse(contr.Element("workEnd").Value)
                        }).FirstOrDefault();
            if (contract == null)
                throw new Exception("id doesn't exist");
            return contract;
        }

        #endregion

        #region other funcs

        public void createFile(string path, string elementName)
        {
            var fileToCreate = new XElement(elementName);
            fileToCreate.Save(path);
        }

        //public static void SaveToXML<T>(T source, string path)
        //{
        //    FileStream file = new FileStream(path, FileMode.Create);
        //    XmlSerializer xmlSerializer = new XmlSerializer(source.GetType());
        //    xmlSerializer.Serialize(file, source);
        //    file.Close();
        //}

        //public static T LoadFromXML<T>(string path)
        //{
        //    FileStream file = new FileStream(path, FileMode.Open);
        //    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        //    T result = (T)xmlSerializer.Deserialize(file);
        //    file.Close();
        //    return result;
        //}

        private void LoadData(string person)
        {
            try
            {
                switch (person)
                {
                    case "mother":
                        motherFile = XElement.Load(momPath);
                        break;
                    case "child":
                        childFile = XElement.Load(kidPath);
                        break;
                    case "nanny":
                        nannysFile = XElement.Load(nannyPath);
                        break;
                    case "contract":
                        contractFile = XElement.Load(contractPath);
                        break;
                    default:
                        throw new Exception("File upload problem");
                }
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }

        public void SaveChildListLinq(List<Child> childList)
        {
            childFile = new XElement("Childern",
                from p in DS.DataSource.childList
                select new XElement("Child",
                    new XElement("id", p.idChild),
                    new XElement("name",
                        new XElement("firstName", p.firstName),
                        new XElement("lastName", p.lastName)),
                    new XElement("birthday", p.birthdayKid),
                    new XElement("momID", p.idMom),
                    new XElement("specialNeeds",
                        new XElement("isNeed", p.isSpecialNeed),
                        new XElement("needs", p.specialNeeds))
                    )
                );
            childFile.Save(kidPath);
        }

        public List<Child> GetChildList()
        {
            LoadData("child");
            List<Child> children;
            try
            {
                children = (from kid in childFile.Elements()
                            select new Child()
                            {
                                idChild = int.Parse(kid.Element("id").Value),
                                firstName = kid.Element("name").Element("firstName").Value,
                                lastName = kid.Element("name").Element("lastName").Value,
                                birthdayKid = DateTime.Parse(kid.Element("birthday").Value),
                                idMom = int.Parse(kid.Element("momID").Value),
                                isSpecialNeed = bool.Parse(kid.Element("specialNeeds").Element("isNeed").Value),
                                specialNeeds = kid.Element("specialNeeds").Element("needs").Value
                            }).ToList();
            }
            catch
            {
                children = null;
            }
            return children;
        }
        #endregion
    }
}
