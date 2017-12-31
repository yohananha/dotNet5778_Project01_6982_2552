using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    public interface Ibl
    {

        void addNanny(Nanny nanny);
        void deleteNanny(long idNannyDel);
        void updateNanny(Nanny nannye);
        Nanny getNanny(long idNanny);

        void addMom(Mother mother);
        void deleteMother(long idMotherDel);
        void updateMother(Mother mother);
        Mother getMother(long idMom);

        void addChild(Child child);
        void deleteChild(long idChildDel);
        void updateChild(Child child);
        Child getChild(long idChild);

        void addContract(Contract contract);
        void deleteContract(int idContractDel);
        void updateContract(Contract contract);
        Contract getContract(int idContract);

        IEnumerable<Nanny> getAllNanny(Func<Nanny, bool> Predicate = null);
        IEnumerable<Mother> getAllMothers(Func<Mother, bool> Predicate = null);
        IEnumerable<Child> getKidsByMoms(Func<Child, bool> Predicate = null);
        IEnumerable<Contract> getContracts(Func<Contract, bool> Predicate = null);
        
    }
}
