using System;
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
            throw new NotImplementedException();
        }

        public void deleteContract(int idContractDel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contract> getContracts(Func<Contract, bool> Predicate = null)
        {
            throw new NotImplementedException();
        }


        public void updateContract(Contract contract)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region mom metod
        public void addMom(Mother mother)
        {
            throw new NotImplementedException();
        }


        public void deleteMother(long idMotherDel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Mother> getAllMothers(Func<Mother, bool> Predicate = null)
        {
            throw new NotImplementedException();
        }

        public void updateMother(Mother mother)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region nanny metod
        public void addNanny(Nanny nanny)
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

        public void updateNanny(Nanny nannye)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
