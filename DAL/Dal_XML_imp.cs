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
        private XElement nannysFile, motherFile, childFile, contractFile;
        string nannyPath = "nanny.xml";
        string momPath = "mother.xml";
        string kidPath = "child.xml";
        string contractPath = "contract.xml";


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
                if (DataSource.nannyList.Exists(nl => nl.nannyId == nanny.nannyId))
                throw new Exception("Nanny is already exist in system");
            DataSource.nannyList.Add(nanny.duplicate());
        }

        public void deleteNanny(long idNannyDel)
        {
            throw new NotImplementedException();
        }

        public void updateNanny(Nanny nannye)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Nanny> getAllNanny(Func<Nanny, bool> Predicate = null)
        {
            throw new NotImplementedException();
        }

        public Nanny getNanny(long idNanny)
        {
            
        //public string lastNameNanny { get; set; }
        //public string firstNameNanny { get; set; }
        //public DateTime dateNanny { get; set; }
        //public long phoneNanny { get; set; }
        //public string addressNanny { get; set; }

        ////work conditions
        //public bool elevatorNanny { get; set; }
        //public int floorNanny { get; set; }
        //public int experienceNanny { get; set; }
        //public int maxChildNanny { get; set; }
        //public int minAgeChildNanny { get; set; }
        //public int maxAgeChildNanny { get; set; }

        ////contract data
        //public bool isByHourNanny { get; set; }
        //public int rateHourNanny { get; set; }
        //public int rateMonthNanny { get; set; }
        //public bool[] daysWorkNanny { get; set; }
        //public bool isTamatNanny { get; set; }
        //public string recommendationsNanny { get; set; }
        //public int currentChildren { get; set; }
        //public DateTime[] startHour { get; set; }
        //public DateTime[] endHour { get; set; }

            LoadData("nanny");
            Nanny nanny;
            try
            {
                nanny = (from a in nannysFile.Elements()
                           where int.Parse(a.Element("id").Value) == idNanny
                           select new Nanny()
                           {
            nannyId = long.Parse(a.Element("nannyId").Value),
                               lastNameNanny = a.Element("lastNameNanny").Value,
                               firstNameNanny = a.Element("firstNameNanny").Value,
                               dateNanny = DateTime.Parse(a.Element("dateNanny").Value),
                               phoneNanny = long.Parse(a.Element("phoneNanny").Value),
                               addressNanny = a.Element("addressNanny").Value,
                               elevatorNanny = bool.Parse(a.Element("elevatorNanny").Value),
                               floorNanny = int.Parse(a.Element("floorNanny").Value),
                               experienceNanny = int.Parse(a.Element("experienceNanny").Value),
                               maxChildNanny = int.Parse(a.Element("maxChildNanny").Value),
                               minAgeChildNanny = int.Parse(a.Element("minAgeChildNanny").Value),
                               maxAgeChildNanny = int.Parse(a.Element("maxAgeChildNanny").Value),
                               isByHourNanny = bool.Parse(a.Element("isByHourNanny").Value),
                               rateHourNanny = int.Parse(a.Element("rateHourNanny").Value),
                               rateMonthNanny = int.Parse(a.Element("rateMonthNanny").Value),
                               daysWorkNanny = new [] bool {bool.Parse(a.Element("daysWorkNanny").Element("sunwork")) }
                                            firstNameNanny = a.Element("firstNameNanny").Value,
                                             firstNameNanny = a.Element("firstNameNanny").Value,
                                              firstNameNanny = a.Element("firstNameNanny").Value
                           }).FirstOrDefault();
            }
            catch
            {
                nanny = null;
            }
            return nanny;
        }

        #endregion

        #region mom funcs

        public void addMom(Mother mother)
        {

            //public long IdMom { get; set; }
            //public string LasNameMom { get; set; }
            //public string FirstNameMom { get; set; }
            //public long PhoneMom { get; set; }
            //public string AddressMom { get; set; }
            //public string AddressForNanny { get; set; }
            //public bool[] DaysRequestMom { get; set; }
            //public DateTime[] startHour { get; set; }
            //public DateTime[] endHour { get; set; }
            //public string nothMom { get; set; }

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



            motherFile.Add(new XElement("mother", id, name, phone, address,addressForNanny, daysRequest,startHour,endHour,note));
            motherFile.Save(momPath); 
        }

        public void deleteMother(long idMotherDel)
        {
            throw new NotImplementedException();
        }

        public void updateMother(Mother mother)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Mother> getAllMothers(Func<Mother, bool> Predicate = null)
        {
            throw new NotImplementedException();
        }

        public Mother getMom(long idMom)
        {
            LoadData("mother");
            Mother mother = null;
            mother.DaysRequestMom = new bool[6];
            mother.startHour = new DateTime[6];
            mother.endHour = new DateTime[6];
            try
            {
                mother = (from mom in motherFile.Elements()
                          where long.Parse(mom.Element("id").Value) == idMom

                          select new Mother()
                          {
                              IdMom = long.Parse(mom.Element("IdMom").Value),
                              FirstNameMom = mom.Element("name").Element("FirstNameMom").Value,
                              LasNameMom = mom.Element("name").Element("LasNameMom").Value,
                              PhoneMom = long.Parse(mom.Element("PhoneMom").Value),
                              AddressMom = mom.Element("AddressMom").Value,
                              AddressForNanny = mom.Element("AddressForNanny").Value,
                              DaysRequestMom = new bool[6] { bool.Parse(mom.Element("DaysRequestMom").Element()) }

                          }).FirstOrDefault();
            }
            catch
            {
                mother = null;
            }
            return mother;

        }

        #endregion

        #region child funcs

        public void addChild(Child child)
        {
            throw new NotImplementedException();
        }

        public void deleteChild(long idChildDel)
        {
            throw new NotImplementedException();
        }

        public void updateChild(Child child)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Child> getKids(Func<Child, bool> Predicate = null)
        {
            throw new NotImplementedException();
        }

        public Child getChild(long idChild)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region contract funcs

        public void addContract(Contract contract)
        {
            throw new NotImplementedException();
        }

        public void deleteContract(long idChildContractDel)
        {
            throw new NotImplementedException();
        }

        public void updateContract(Contract contract)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contract> getContracts(Func<Contract, bool> Predicate = null)
        {
            throw new NotImplementedException();
        }

        public Contract getContract(long idChildContract)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region other funcs

        public void createFile(string path, string elementName)
        {
            var fileToCreate = new XElement(elementName);
            fileToCreate.Save(path);
        }

        public static void SaveToXML<T>(T source, string path)
        {
            FileStream file = new FileStream(path, FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(source.GetType());
            xmlSerializer.Serialize(file, source);
            file.Close();
        }

        public static T LoadFromXML<T>(string path)
        {
            FileStream file = new FileStream(path, FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            T result = (T)xmlSerializer.Deserialize(file);
            file.Close();
            return result;
        }

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
