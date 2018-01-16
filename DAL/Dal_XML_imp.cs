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
            throw new NotImplementedException();
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
