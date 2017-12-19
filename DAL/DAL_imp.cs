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
            return DataSource.childList.FirstOrDefault(_child => _child.idChild == idChild);
        }

        public void addChild(Child child)
        {
            int index = DataSource.childList.FindIndex(c => c.idChild == child.idChild);
            if (index == -1)//no child found
                throw new Exception("Child is already exist in system");
            DataSource.childList.Add(child);
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
            DataSource.childList[index] = child;
        }

        public IEnumerable<Child> getKidsByMoms(Func<Child, bool> Predicate = null)
        {
            if (Predicate == null)
                throw new Exception("Please send mother ID");
            return DataSource.childList.Where(Predicate);
        }

        #endregion

        #region contract funcs

        public Contract getContract(int idContract)
        {
            return DataSource.contractList.FirstOrDefault(cl => cl.idContract == idContract);
        }

        public void addContract(Contract contract)
        {
            int contractIndex = DataSource.contractList.FindIndex(c => c.idChild == contract.idChild && c.idNanny == contract.idNanny);
            if (contractIndex != -1)
                throw new Exception("Contract already exist in system, please update the contract");
            Child contractchild = getChild(contract.idChild);
            Mother contractMother = getMom(contractchild.idMom);
            if (contractMother == null)
                throw new Exception("Mother is not appear in the system");
            Nanny contractNanny = getNanny(contract.idNanny);
            if (contractNanny == null)
                throw new Exception("Nanny is not appear in system");
            contract.idContract = ++contract_Id;
            DataSource.contractList.Add(contract);

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
            DataSource.contractList[index] = contract;
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
            return DataSource.motherList.FirstOrDefault(ml => ml.idMom == idMom);
        }

        public void addMom(Mother mother)
        {
            int indexMom = DataSource.motherList.FindIndex(ml => ml.idMom == mother.idMom);
            if (indexMom!=-1)
                throw new Exception("Mother already exist in system");
            DataSource.motherList[indexMom]=mother;
        }

        public void deleteMother(long idMotherDel)
        {
            int index = DataSource.motherList.FindIndex(m => m.idMom == idMotherDel);
            if (index == -1)
                throw new Exception("Mother is not exist in system");

            deleteAllChildtMother(idMotherDel);

            DataSource.motherList.RemoveAt(index);
        }

        //metod 
        private void deleteAllChildtMother(long idMotherDel)
        {
            var listChildToDelete = DataSource.childList.Where(t => t.idMom == idMotherDel);
            //the metod deleteChild delete also the contract child
            foreach (var item in listChildToDelete)
                deleteChild(item.idChild);
        }

        public void updateMother(Mother mother)
        {
            int indexMom=DataSource.motherList.FindIndex(ml=>ml.idMom==mother.idMom);
            if (indexMom==-1)
                throw new Exception("Mother is not appear in the system");
            DataSource.motherList[indexMom] = mother;
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
            return DataSource.nannyList.FirstOrDefault(nl => nl.nannyId == idNanny);
        }

        public void addNanny(Nanny nanny)
        {
            int nanIndex = DataSource.nannyList.FindIndex(nl => nl.nannyId == nanny.nannyId);
            if (nanIndex != -1)
                throw new Exception("Nanny is already exist in system");
            DataSource.nannyList.Add(nanny);
        }

        public void updateNanny(Nanny nanny)
        {
            int nanindex = DataSource.nannyList.FindIndex(nl => nl.nannyId == nanny.nannyId);
            if (nanindex == -1)
                throw new Exception("Nanny is not exist in system");
            DataSource.nannyList[nanindex] = nanny;
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
