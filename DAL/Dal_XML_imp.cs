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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        #endregion

        #region mom funcs

        public void addMom(Mother mother)
        {

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
            LoadData("mother");

            XElement motherElement;
            try
            {
                motherElement = (from mom in motherFile.Elements()
                                 where int.Parse(mom.Element("id").Value) == idMotherDel
                                 select mom).FirstOrDefault();
                motherElement.Remove();
                motherFile.Save(momPath);
            }
            catch
            {
                throw new Exception("Delete mothe problem");
            }
        }

        public void updateMother(Mother mother)
        {
            LoadData("mother");

            XElement motherElement = (from mom in motherFile.Elements()
                                      where int.Parse(mom.Element("id").Value) == mother.IdMom
                                      select mom).FirstOrDefault();

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

            motherElement.Element("sunEnd").Element("sunEnd").Value = mother.endHour[0].ToString();
            motherElement.Element("sunEnd").Element("monEnd").Value = mother.endHour[1].ToString();
            motherElement.Element("sunEnd").Element("tueEnd").Value = mother.endHour[2].ToString();
            motherElement.Element("sunEnd").Element("wedEnd").Value = mother.endHour[3].ToString();
            motherElement.Element("sunEnd").Element("thuEnd").Value = mother.endHour[4].ToString();
            motherElement.Element("sunEnd").Element("friEnd").Value = mother.endHour[5].ToString();

            motherElement.Element("note").Value = mother.nothMom;

            motherFile.Save(momPath);
        }

        public IEnumerable<Mother> getAllMothers(Func<Mother, bool> Predicate = null)
        {
            LoadData("mother");
            List<Mother> mothers;
            try
            {
                mothers = (from mom in motherFile.Elements()
                           select new Mother()
                           {
                               IdMom = long.Parse(mom.Element("IdMom").Value),
                               FirstNameMom = mom.Element("name").Element("FirstNameMom").Value,
                               LasNameMom = mom.Element("name").Element("LasNameMom").Value,
                               PhoneMom = long.Parse(mom.Element("PhoneMom").Value),
                               AddressMom = mom.Element("AddressMom").Value,
                               AddressForNanny = mom.Element("AddressForNanny").Value,
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
                           }).ToList();
            }
            catch
            {
                mothers = null;
            }
            return mothers;
        }

        public Mother getMom(long idMom)
        {
            LoadData("mother");
            Mother mother;

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
            XElement idMom = new XElement("idMom", child.idMom);
            XElement idChild = new XElement("idChild", child.idChild);
            XElement firstName = new XElement("firstName", child.firstName);
            XElement lastName = new XElement("lastName", child.lastName);
            XElement name = new XElement("name", firstName, lastName);
            XElement birthday = new XElement("birthday", child.birthdayKid);
            XElement isSpeacial = new XElement("isSpecial", child.isSpecialNeed);
            XElement needs = new XElement("needs", child.specialNeeds);
            childFile.Add(new XElement("mother", idMom, idChild, name, birthday, isSpeacial, needs));

            childFile.Save(momPath);
        }

        public void deleteChild(long idChildDel)
        {
            LoadData("child");

            XElement childElement;
            try
            {
                childElement = (from kid in childFile.Elements()
                                where int.Parse(kid.Element("id").Value) == idChildDel
                                select kid).FirstOrDefault();
                childElement.Remove();
                motherFile.Save(momPath);
            }
            catch
            {
                throw new Exception("Delete mothe problem");
            }
        }

        public void updateChild(Child child)
        {
            LoadData("child");

            XElement childElement = (from kid in childFile.Elements()
                                     where int.Parse(kid.Element("id").Value) == child.idChild
                                     select kid).FirstOrDefault();

            childElement.Element("name").Element("firstName").Value = child.firstName;
            childElement.Element("name").Element("lastName").Value = child.lastName;
            childElement.Element("birthday").Value = child.birthdayKid.ToString();
            childElement.Element("isSpecial").Value = child.isSpecialNeed.ToString();
            childElement.Element("needs").Value = child.specialNeeds;

            childFile.Save(momPath);

        }

        public IEnumerable<Child> getKids(Func<Child, bool> Predicate = null)
        {
            LoadData("child");
            List<Child> kids;
            try
            {
                kids = (from kid in childFile.Elements()
                        select new Child()
                        {
                            idMom = long.Parse(kid.Element("IdMom").Value),
                            idChild = long.Parse(kid.Element("idChild").Value),
                            firstName = kid.Element("name").Element("firstName").Value,
                            lastName = kid.Element("name").Element("lastName").Value,
                            birthdayKid = DateTime.Parse(kid.Element("birthday").Value),
                            isSpecialNeed = Convert.ToBoolean(kid.Element("isSpecial").Value),
                            specialNeeds = kid.Element("needs").Value,
                        }).ToList();
            }
            catch
            {
                kids = null;
            }
            return kids;
        }

        public Child getChild(long idChild)
        {
            LoadData("child");
            Child child;

            try
            {
                child = (from kid in childFile.Elements()
                    where long.Parse(kid.Element("id").Value) == idChild

                    select new Child()
                    {
                        idMom = long.Parse(kid.Element("IdMom").Value),
                        idChild = long.Parse(kid.Element("idChild").Value),
                        firstName = kid.Element("name").Element("firstName").Value,
                        lastName = kid.Element("name").Element("lastName").Value,
                        birthdayKid = DateTime.Parse(kid.Element("birthday").Value),
                        isSpecialNeed = Convert.ToBoolean(kid.Element("isSpecial").Value),
                        specialNeeds = kid.Element("needs").Value,
                    }).FirstOrDefault();
            }
            catch
            {
                child = null;
            }
            return child;

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
