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
        //constractor 
        public DAL_imp()
        {
          new DataSource();
        }


        #region child funcs

        public Child getChild(long idChild)
        {
            return DataSource.childList.FirstOrDefault(_child => _child.idChild == idChild);
        }

        public void addChild(Child child)
        {
            Child _child = getChild(child.idChild);
            if (child != null)//child found
                throw new Exception("Child is already exist in system");
            DataSource.childList.Add(child);
        }

        public void deleteChild(long idChildDel)
        {
            Child _child = getChild(idChildDel);
            if (_child==null)//no child found
                throw  new Exception("Child is not appear in system");
            DataSource.contractList.RemoveAll(c => c.idChild == idChildDel);//delete all contract regarding the child
            DataSource.childList.Remove(_child);
        }

        public void updateChild(Child child)
        {
            int index = DataSource.childList.FindIndex(c => c.idChild == child.idChild);
            if (index == -1)//no child found
                throw new Exception("Child is not appear in system");
            DataSource.childList[index] = child;
        }

        public IEnumerable<Child> getKidsByMoms(Func<Child, bool> Predicate = null)
        {
            if (Predicate == null)
                throw new Exception("get mom");

            return DataSource.childList.Where(Predicate);
        }

        #endregion

        #region contract funcs

        public Contract getContract(int idContract)
        {
            return DataSource.contractList.FirstOrDefault(cl => cl.idContract == idContract);
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

            DataSource.contractList.Add(contract);
            }

        public void deleteContract(int idContractDel)
        {
            Contract _contract = getContract(idContractDel);
            if (_contract == null)
                throw new Exception("Contract is not exist in system");
            //update the current number of chidren 
            Nanny contracctNanny = getNanny(_contract.idNanny);
            contracctNanny.currentChildren--;
            updateNanny(contracctNanny);

            DataSource.contractList.Remove(_contract);
        }

        public void updateContract(Contract contract)
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
            return DataSource.motherList.FirstOrDefault(ml => ml.idMom == idMom);
        }

        public void addMom(Mother mother)
        {
            Mother _mother = getMom(mother.idMom);
            if (mother!=null)
                throw new Exception("Mother already exist in system");
            DataSource.motherList.Add(mother);
        }

        public void deleteMother(long idMotherDel)
        {
            Mother _mother = getMom(idMotherDel);
            if (_mother==null)
                throw new Exception("Mother is not exist in system");
            deleteAllContrctMother(idMotherDel);
            DataSource.motherList.Remove(_mother);
        }

        //metod 
        private void deleteAllContrctMother(long idMotherDel)
        {
            var listChild = DataSource.childList.Where(t => t.idMom == idMotherDel);
            //if we need to delete only the contract
            foreach (var item in listChild)
            {
              DataSource.contractList.RemoveAll(c => c.idChild == item.idChild);
            }

            //if we need delete all child mother
            //the metod deleteChild delete also the contract child
            foreach (var item in listChild)
            {
                deleteChild(item.idChild);
            }

        }

        public void updateMother(Mother mother)
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
            return DataSource.nannyList.FirstOrDefault(nl=>nl.nannyId==idNanny);
        }

        public void addNanny(Nanny nanny)
        {
            throw new NotImplementedException();
        }

        public void updateNanny(Nanny nanny)
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
