﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using BE;


namespace DAL
{
    public interface Idal
    {
        void addNanny(Nanny nanny);
        void deleteNanny(long idNannyDel);
        void updateNanny(Nanny nannye);

        void addMom(Mother mother);
        void deleteMother(long idMotherDel);
        void updateMother(Mother mother);

        void addChild(Child child);
        void deleteChild(long idChildDel);
        void updateChild(Child child);
        

        void addContract(Contract contract);
        void deleteContract(long idChildContractDel);
        void updateContract(Contract contract);

        IEnumerable<Nanny> getAllNanny(Func<Nanny, bool> Predicate=null);
        IEnumerable<Mother> getAllMothers(Func<Mother, bool> Predicate = null);
        IEnumerable<Child> getKids(Func<Child, bool> Predicate = null);
        IEnumerable<Contract> getContracts(Func<Contract, bool> Predicate = null);

        //getters by id
        Nanny getNanny(long idNanny);
        Mother getMom(long idMom);
        Child getChild(long idChild);
        Contract getContract(long idChildContract);
    }
}