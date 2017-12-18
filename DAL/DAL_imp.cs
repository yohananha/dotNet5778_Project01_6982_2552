using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL
{
    class DAL_imp : IDAL
    {
        private DataSource ds = new DataSource();
        
        public void addChild(Child child)
        {
            Child _child=
        }

        public void addContract(Contract contract)
        {
            throw new NotImplementedException();
        }

        public void addMom(Mother mother)
        {
            throw new NotImplementedException();
        }

        public void addNanny(Nanny nanny)
        {
            throw new NotImplementedException();
        }

        public void deleteChild(long idChildDel)
        {
            throw new NotImplementedException();
        }

        public void deleteContract(int idContractDel)
        {
            throw new NotImplementedException();
        }

        public void deleteMother(long idMotherDel)
        {
            throw new NotImplementedException();
        }

        public void deleteNanny(long idNannyDel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Mother> getAllMothers(Func<Mother, bool> Predicate = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Nanny> getAllNanny(Func<Nanny, bool> Predicate = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contract> getContracts(Func<Contract, bool> Predicate = null)
        {
            throw new NotImplementedException();
        }

        public void getNanny(long idNanny)
        {
            throw new NotImplementedException();
        }

        public void getMom(long idMom)
        {
            throw new NotImplementedException();
        }

        public void getChild(long idChild)
        {
            throw new NotImplementedException();
        }

        public void getContract(int idContract)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Child> getKidsByMoms(Func<Child, bool> Predicate = null)
        {
            throw new NotImplementedException();
        }

        public void updateChild(long idChildUpdate)
        {
            throw new NotImplementedException();
        }

        public void updateContract(int idContractUpdate)
        {
            throw new NotImplementedException();
        }

        public void updateMother(long idMotherUpdate)
        {
            throw new NotImplementedException();
        }

        public void updateNanny(long idNannyUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
