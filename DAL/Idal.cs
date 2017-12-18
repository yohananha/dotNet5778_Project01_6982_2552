using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using BE;


namespace DAL
{
    public interface IDAL
    {
        void addNanny(Nanny nanny);
        void deleteNanny(long idNannyDel);
        void updateNanny(long idNannyUpdate);

        void addMom(Mother mother);
        void deleteMother(long idMotherDel);
        void updateMother(long idMotherUpdate);

        void addChild(Child child);
        void deleteChild(long idChildDel);
        void updateChild(long idChildUpdate);

        void addContract(Contract contract);
        void deleteContract(int idContractDel);
        void updateContract(int idContractUpdate);

        IEnumerable<Nanny> getAllNanny(Func<Nanny, bool> Predicate=null);
        IEnumerable<Mother> getAllMothers(Func<Mother, bool> Predicate = null);
        IEnumerable<Child> getKidsByMoms(Func<Child, bool> Predicate = null);
        IEnumerable<Contract> getContracts(Func<Contract, bool> Predicate = null);

        //getters by id
        void getNanny(long idNanny);
        void getMom(long idMom);
        void getChild(long idChild);
        void getContract(int idContract);
    }
}