using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;
using DS;


namespace DAL
{
    class Dal_XML_imp : Idal
    {
        XElement nannysFile;
        string nannyPath = @"C:\files\nanny.xml";


        public Dal_XML_imp()
        {
            new DataSource();


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
            throw new NotImplementedException();
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

        public void SaveNannyListLinq(List<Nanny> studentList)
        {
            nannysFile = new XElement("Nannies",
                from p in DS.DataSource.nannyList
                select new XElement("Nanny",
                    new XElement("id", p.nannyId),
                    new XElement("name",
                        new XElement("firstName", p.firstNameNanny),
                        new XElement("lastName", p.lastNameNanny)
                    )
                )
            );
            nannysFile.Save(nannyPath);
        }

        #endregion
    }
}
