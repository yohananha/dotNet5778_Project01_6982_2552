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
        void deleteContract(int idChildContractDel);
        void updateContract(Contract contract);
        double getSalary(long idChild, long idNanny, bool isHour);
        Contract getContract(int idChildContract);

        IEnumerable<Nanny> getAllNanny(Func<Nanny, bool> Predicate = null);
        IEnumerable<Mother> getAllMothers(Func<Mother, bool> Predicate = null);
        IEnumerable<Child> getKidsByMoms(Func<Child, bool> Predicate = null);
        IEnumerable<Contract> getContracts(Func<Contract, bool> Predicate = null);

        //other metod
        int CalculateDistance(string source/*mother*/, string dest/*nanny*/);
        IEnumerable<Nanny> getAllCompatibleNanny(Mother mom);
        IEnumerable<Child> getAllChildWithoutNanny();
        IEnumerable<Nanny> getTamatNanny();
        IEnumerable<Contract> contractByTerm(Func<Contract, bool> Predicate = null);
        int numContractByTerm(Func<Contract, bool> Predicate = null);
        IEnumerable<Nanny> getNannyByDistance(Mother mom, double distance);
        IEnumerable<IGrouping<int, Nanny>> getNannyByDistance(string addressMom, bool isSort);
        IEnumerable<IGrouping<int, Nanny>> getChildByAgeRange(bool minAge, bool isSort);
        bool checkSchedule(Nanny nanny, Mother mom);
    }
}
