using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL
{
    class DAL_imp : Idal
    {
        private DataSource ds = new DataSource();

        public static List<Nanny> nannyList = new List<Nanny>();
        public static List<Mother> motherList = new List<Mother>();
        public static List<Child> childList = new List<Child>();
        public static List<Contract> contractList = new List<Contract>();

        #region child funcs

        public Child getChild(long idChild)
        {
            return childList.FirstOrDefault(_child => _child.idChild == idChild);
        }

        public void addChild(Child child)
        {
            Child _child = getChild(child.idChild);
            if (child != null)//child found
                throw new Exception("Child is already exist in system");
            childList.Add(child);
        }

        public void deleteChild(long idChildDel)
        {
            Child _child = getChild(idChildDel);
            if (_child==null)//no child found
                throw  new Exception("Child is not appear in system");
            contractList.RemoveAll(c => c.idChild == idChildDel);//delete all contract regarding the child
            childList.Remove(_child);
        }

        public void updateChild(long idChildUpdate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Child> getKidsByMoms(Func<Child, bool> Predicate = )
        {
            throw new NotImplementedException();
        }

        #endregion

        #region contract funcs

        public Contract getContract(int idContract)
        {
            return contractList.FirstOrDefault(cl => cl.idContract == idContract);
        }
        
        [SuppressMessage("ReSharper", "HeuristicUnreachableCode")]
        public void addContract(Contract contract)
        {
            Contract _contract = getContract(contract.idContract);
            if (contract!=null)
                throw new Exception("Contract already exist in system");
            Child contractchild = getChild(contract.idChild);
            Mother contractMother = getMom(contractchild.idMom);
            if (contractMother==null)
                throw new Exception("Mother is not appear in the system");
            Nanny contractNanny = getNanny(contract.idNanny);
            if (contractNanny==null)
                throw new Exception("Nanny is not appear in system");

            contractList.Add(contract);
            }

        public void deleteContract(int idContractDel)
        {
            Contract _contract = getContract(idContractDel);
            if (_contract == null)
                throw new Exception("Contract is not exist in system");
            //update the current number of chidren 
            Nanny contracctNanny = getNanny(_contract.idNanny);
            contracctNanny.currentChildren--;
            updateNanny(contracctNanny.nannyId);

            contractList.Remove(_contract);
        }

        public void updateContract(int idContractUpdate)
        {

        }

        public IEnumerable<Contract> getContracts(Func<Contract, bool> Predicate = null)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region  mother funcs

        public Mother getMom(long idMom)
        {
            return motherList.FirstOrDefault(ml => ml.idMom == idMom);
        }

        public void addMom(Mother mother)
        {
            Mother _mother = getMom(mother.idMom);
            if (mother!=null)
                throw new Exception("Mother already exist in system");
            motherList.Add(mother);
        }

        public void deleteMother(long idMotherDel)
        {
            Mother _mother = getMom(idMotherDel);
            if (_mother==null)
                throw new Exception("Mother is not exist in system");
          
        }

        public void updateMother(long idMotherUpdate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Mother> getAllMothers(Func<Mother, bool> Predicate = null)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region nanny funcs

        public Nanny getNanny(long idNanny)
        {
            return nannyList.FirstOrDefault(nl=>nl.nannyId==idNanny);
        }

        public void addNanny(Nanny nanny)
        {
            throw new NotImplementedException();
        }

        public void updateNanny(long idNannyUpdate)
        {
            throw new NotImplementedException();
        }

      

        public void deleteNanny(long idNannyDel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Nanny> getAllNanny(Func<Nanny, bool> Predicate = null)
        {
            throw new NotImplementedException();
        }

        #endregion

     }
}
