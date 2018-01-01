using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BE;
using DS;

namespace DAL
{
    class DAL_imp : Idal
    {
        public static int contract_Id = 1;

        //constractor 
        public DAL_imp()
        {
            new DataSource();
        }


        #region child funcs

        public Child getChild(long idChild)
        {
            var child = DataSource.childList.FirstOrDefault(_child => _child.idChild == idChild);
            if (child == null)
                throw new Exception("id doesn't exist");
            return child;
        }

        public void addChild(Child child)
        {
            if (DataSource.childList.Exists(c => c.idChild == child.idChild))//no child found
                throw new Exception("Child is already exist in system");
            DataSource.childList.Add(child.duplication());
        }

        public void deleteChild(long idChildDel)
        {
            int index = DataSource.childList.FindIndex(c => c.idChild == idChildDel);
            if (index == -1)//no child found
                throw new Exception("Child is not appear in system");
            DataSource.contractList.RemoveAll(c => c.idChild == idChildDel);//delete all contract regarding the child
            DataSource.childList.RemoveAt(index);
        }

        public void updateChild(Child child)
        {
            int index = DataSource.childList.FindIndex(c => c.idChild == child.idChild);
            if (index == -1)//no child found
                throw new Exception("Child is not appear in system");
            DataSource.childList[index] = child.duplication();
        }

        public IEnumerable<Child> getKidsByMoms(Func<Child, bool> Predicate = null)
        {
            if (Predicate == null)
                return DataSource.childList.AsEnumerable();
            return DataSource.childList.Where(Predicate);
        }

        #endregion

        #region contract funcs

        public Contract getContract(int idContract)
        {
            var contract = DataSource.contractList.FirstOrDefault(cl => cl.idContract == idContract);
            if (contract == null)
                throw new Exception("id doesn't exist");
            return contract;
        }

        public void addContract(Contract contract)
        {
            if (DataSource.contractList.Exists(c => c.idChild == contract.idChild && c.idNanny == contract.idNanny))
                throw new Exception("Contract already exist in system, please update the contract");
            Child contractchild = getChild(contract.idChild);
            Mother contractMother = getMom(contractchild.idMom);
            if (contractMother == null)
                throw new Exception("Mother is not appear in the system");
            Nanny contractNanny = getNanny(contract.idNanny);
            if (contractNanny == null)
                throw new Exception("Nanny is not appear in system");
            contract.idContract = ++contract_Id;
            DataSource.contractList.Add(contract.duplication());

        }

        public void deleteContract(int idContractDel)
        {
            int index = DataSource.contractList.FindIndex(cl => cl.idContract == idContractDel);
            if (index == -1)
                throw new Exception("Contract is not exist in system");
            //update the current number of chidren 
            Nanny contracctNanny = getNanny(idContractDel);
            contracctNanny.currentChildren--;
            updateNanny(contracctNanny);
            DataSource.contractList.RemoveAt(index);
        }

        public void updateContract(Contract contract)
        {
            int index = DataSource.contractList.FindIndex(cl => cl.idContract == contract.idContract);
            if (index == -1)
                throw new Exception("Contract is not appear in system");
            DataSource.contractList[index] = contract.duplication();
        }

        public IEnumerable<Contract> getContracts(Func<Contract, bool> Predicate = null)
        {
            if (Predicate == null)
                return DataSource.contractList.AsEnumerable();

            return DataSource.contractList.Where(Predicate);
        }

        #endregion

        #region  mother funcs



        public Mother getMom(long idMom)
        {
            var mom = DataSource.motherList.FirstOrDefault(ml => ml.IdMom == idMom);
            if (mom == null)
                throw new Exception("id doesn't exist");
            return mom;
        }

        public void addMom(Mother mother)
        {
             if (DataSource.motherList.Exists(ml => ml.IdMom == mother.IdMom))
                throw new Exception("Mother already exist in system");
            DataSource.motherList.Add(mother.duplication());
        }

        public void deleteMother(long idMotherDel)
        {
            int index = DataSource.motherList.FindIndex(m => m.IdMom == idMotherDel);
            if (index == -1)
                throw new Exception("Mother is not exist in system");

            deleteAllChildtMother(idMotherDel);

            DataSource.motherList.RemoveAt(index);
        }

        //metod 
        private void deleteAllChildtMother(long idMotherDel)
        {
            var listChildToDelete = from item in DataSource.childList
                                    where item.idMom == idMotherDel
                                    select item;
     
            //the metod deleteChild delete also the contract child
            foreach (var item in listChildToDelete)
                deleteChild(item.idChild);
        }

        public void updateMother(Mother mother)
        {
            int indexMom = DataSource.motherList.FindIndex(ml => ml.IdMom == mother.IdMom);
            if (indexMom == -1)
                throw new Exception("Mother is not appear in the system");
            DataSource.motherList[indexMom] = mother.duplication();
        }

        public IEnumerable<Mother> getAllMothers(Func<Mother, bool> Predicate = null)
        {
            if (Predicate == null)
                return DataSource.motherList.AsEnumerable();

            return DataSource.motherList.Where(Predicate);
        }

        #endregion

        #region nanny funcs

        public Nanny getNanny(long idNanny)
        {
            var nanny = DataSource.nannyList.FirstOrDefault(nl => nl.nannyId == idNanny);
            if (nanny == null)
                throw new Exception("id doesn't exist");
            return nanny;
        }

        public void addNanny(Nanny nanny)
        {
            if (DataSource.nannyList.Exists(nl => nl.nannyId == nanny.nannyId))
                throw new Exception("Nanny is already exist in system");
            DataSource.nannyList.Add(nanny.duplication());
        }

        public void updateNanny(Nanny nanny)
        {
            int nanindex = DataSource.nannyList.FindIndex(nl => nl.nannyId == nanny.nannyId);
            if (nanindex == -1)
                throw new Exception("Nanny is not exist in system");
            DataSource.nannyList[nanindex] = nanny.duplication();
        }



        public void deleteNanny(long idNannyDel)
        {
            int nanindex = DataSource.nannyList.FindIndex(nl => nl.nannyId == idNannyDel);
            if (nanindex == -1)
                throw new Exception("Nanny is not exist in system");
            DataSource.contractList.RemoveAll(cl => cl.idNanny == idNannyDel);
            DataSource.nannyList.RemoveAt(nanindex);
        }

        public IEnumerable<Nanny> getAllNanny(Func<Nanny, bool> Predicate = null)
        {
            if (Predicate == null)
                return DataSource.nannyList.AsEnumerable();

            return DataSource.nannyList.Where(Predicate);
        }

        #endregion

    }
}
