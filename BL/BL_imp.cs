﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    class BL_imp : Ibl
    {
        DAL.Idal dal;
        //CTOR creating factory
        public BL_imp()
        {
            dal = DAL.factoryDal.getDal();
        }
        #region child metod

        public void addChild(Child child)
        {
            dal.addChild(child);
        }

        public void deleteChild(long idChildDel)
        {
            dal.deleteChild(idChildDel);
        }

        public IEnumerable<Child> getKidsByMoms(Func<Child, bool> Predicate = null)
        {
            if (Predicate == null)
                return dal.getKidsByMoms();
            return dal.getKidsByMoms(Predicate);
        }

        public void updateChild(Child child)
        {
            dal.updateChild(child);
        }

        #endregion

        #region contract metod
        public void addContract(Contract contract)
        {
            Child contracctChild = dal.getChild(contract.idChild);
            DateTime today = DateTime.Today;
            if (today.Year - contracctChild.birthdayKid.Year < 1 && today.Month - contracctChild.birthdayKid.Month < 3)
                throw new Exception("Child is too small");
            Nanny contractNanny = dal.getNanny(contract.idNanny);
            if (contractNanny.maxChildNanny == contractNanny.currentChildren)
                throw new Exception("This nanny has reached the limit of children");
            /*
             * 
             * 
             * need to add salary check. maybe different function
             * 
             * 
             */
            dal.addContract(contract);
        }

        public void deleteContract(int idContractDel)
        {
            dal.deleteContract(idContractDel);
        }

        public IEnumerable<Contract> getContracts(Func<Contract, bool> Predicate = null)
        {
            if (Predicate == null)
                return dal.getContracts();
            return dal.getContracts(Predicate);
        }


        public void updateContract(Contract contract)
        {
            dal.updateContract(contract);
        }
        #endregion

        #region mom methods
        public void addMom(Mother mother)
        {
            dal.addMom(mother);
        }


        public void deleteMother(long idMotherDel)
        {
            dal.deleteMother(idMotherDel);
        }

        public IEnumerable<Mother> getAllMothers(Func<Mother, bool> Predicate = null)
        {
            if (Predicate == null)
                return dal.getAllMothers();
            return dal.getAllMothers(Predicate);
        }

        public void updateMother(Mother mother)
        {
            dal.updateMother(mother);
        }
        #endregion

        #region nanny metod
        public void addNanny(Nanny nanny)
        {
            DateTime today = DateTime.Today;
            if (today.Year - 18 < nanny.dateNanny.Year)
                throw new Exception("Nanny is too young");
            dal.addNanny(nanny);
        }

        public void deleteNanny(long idNannyDel)
        {
            dal.deleteNanny(idNannyDel);
        }

        public IEnumerable<Nanny> getAllNanny(Func<Nanny, bool> Predicate = null)
        {
            if (Predicate == null)
                return dal.getAllNanny();
            return dal.getAllNanny(Predicate);
        }

        public void updateNanny(Nanny nanny)
        {
            dal.updateNanny(nanny);
        }

        #endregion
    }
}
