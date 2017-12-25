﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BE;
using GoogleMapsApi;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;

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

        public int MomsKidsByNanny(Child child, Nanny nanny)
        {
            var kidsMom = dal.getKidsByMoms(a => a.idMom == child.idMom);
            var nannycontract = dal.getContracts(a => a.idNanny == nanny.nannyId);

            var finalList = from a in kidsMom
                            from b in nannycontract
                            where b.idChild == a.idChild
                            select b;
            return finalList.Count();
        }
        public void addContract(Contract contract)
        {
            Child contractChild = dal.getChild(contract.idChild);
            Nanny contractNanny = dal.getNanny(contract.idNanny);
            Mother contractMother = dal.getMom(contractChild.idMom);
            double discountRate = MomsKidsByNanny(contractChild, contractNanny) * 0.02 * contractNanny.rateMonthNanny;
            DateTime today = DateTime.Today;
            if (today.Year - contractChild.birthdayKid.Year < 1 && today.Month - contractChild.birthdayKid.Month < 3)
                throw new Exception("Child is too small");

            if (contractNanny.maxChildNanny == contractNanny.currentChildren)
                throw new Exception("This nanny has reached the limit of children");
            if (contract.isHour == false)
                contract.salaryPerMonth = contractNanny.rateMonthNanny - contractNanny.rateMonthNanny * discountRate;
            else
            {
                contract.salaryPerMonth =
                    getMomHours(contractMother) * 4 - getMomHours(contractMother) * 4 * discountRate;
            }
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

        public double getMomHours(Mother mother)
        {
            TimeSpan sum = new TimeSpan();
            for (var i = 0; i < 6; i++)
            {
                sum += mother.ScheduleMom[i].endHour - mother.ScheduleMom[i].startHour;
            }
            return ((sum.Days - 1) * 24 + sum.Hours + sum.Minutes / 60.0);
        }

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

        #region other functions
        //google directions
        public static int CalculateDistance(string source/*mother*/, string dest/*nanny*/)
        {
            var drivingDirectionRequest = new DirectionsRequest
            {
                TravelMode = TravelMode.Walking,
                Origin = source,
                Destination = dest,
            };
            DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
            Route route = drivingDirections.Routes.First();
            Leg leg = route.Legs.First();
            return leg.Distance.Value;
        }

        /// <summary>
        /// get all the nannies into a list, and then check each one for compitabillity
        /// </summary>
        /// <param name="mom"></param>
        /// <returns></returns> Nanny list compatible to mother
        public IEnumerable<Nanny> getAllCompatibleNanny(Mother mom)
        {
            var nannyList = dal.getAllNanny();

            var compatibleNanny = from a in nannyList
                                  where checkSchedule(a, mom)
                                  select a;
            if (!compatibleNanny.Any())
            {
                return fiveNearestNanny(mom);
            }
            else return compatibleNanny;
        }

        private IEnumerable<Nanny> fiveNearestNanny(Mother mom)
        {
            // copy the list into new one
            var nannyList = from a in dal.getAllNanny()
                            select a.duplication();

            foreach (var a in nannyList)
            {
                schduleDifference(a, mom);
            }

            return nannyList.OrderBy(a => a.diff).Take(5);


        }


        /// <summary>
        /// calculates the difference between moms request hours and the nanny scheduele
        /// </summary>
        /// <param name="nanny"></param>
        /// <param name="mom"></param>
        /// <returns></returns>
        public void schduleDifference(Nanny nanny, Mother mom)
        {
            nanny.diff = 0;
            for (int i = 0; i < 6; i++)
            {
                if (nanny.ScheduleNanny[i].startHour > mom.ScheduleMom[i].startHour)
                {
                    TimeSpan sum = new TimeSpan();
                    sum = nanny.ScheduleNanny[i].startHour - mom.ScheduleMom[i].startHour;
                    nanny.diff += ((sum.Days - 1) * 24 + sum.Hours + sum.Minutes / 60.0);
                }
                if (nanny.ScheduleNanny[i].endHour < mom.ScheduleMom[i].endHour)
                {
                    TimeSpan sum = new TimeSpan();
                    sum = mom.ScheduleMom[i].endHour - nanny.ScheduleNanny[i].endHour;
                    nanny.diff += ((sum.Days - 1) * 24 + sum.Hours + sum.Minutes / 60.0);
                }
            }
        }

        public bool checkSchedule(Nanny nanny, Mother mom)
        {
            for (int i = 0; i < 6; i++)
            {
                if (nanny.ScheduleNanny[i].startHour > mom.ScheduleMom[i].startHour ||
                    nanny.ScheduleNanny[i].endHour < mom.ScheduleMom[i].endHour)
                    return false;
            }
            return true;
        }

        public IEnumerable<Child> getAllChildWithoutNanny()
        {
            return from a in dal.getKidsByMoms()
                   let idChild = a.idChild
                   from b in dal.getContracts()
                   where idChild != b.idChild
                   select a;
        }

        public IEnumerable<Nanny> getTamatNanny()
        {
            return dal.getAllNanny(a => a.isTamatNanny);
        }

        public IEnumerable<Contract> contractByTerm(Func<Contract, bool> Predicate = null)
        {
            return dal.getContracts(Predicate);
        }

        public int numContractByTerm(Func<Contract, bool> Predicate = null)
        {
            return contractByTerm(Predicate).Count();
        }

        public IEnumerable<Nanny> getNannyByDistance(Mother mom, double distance)
        {
            int distanceMeter = (int)(distance * 1000);

            // copy the list into new one
            var nannyList = from a in dal.getAllNanny()
                            select a.duplication();

            foreach (var a in nannyList)
            {
                a.Distance = CalculateDistance(mom.AddressMom, a.addressNanny);
            }

            return from a in nannyList
                   where a.Distance < distanceMeter
                   select a;
        }

        public IEnumerable<IGrouping<bool, Nanny>> getNannyByDistance(string addressMom, string addressNanny, double rangeM, bool isSort)
        {
            //if (isSort)
            //    return from a in dal.getAllNanny()
            //           group a by CalculateDistance(a.addressNanny, addressMom) < rangeM*1000;
        }


        //public IEnumerable<IGrouping<int, Nanny>> getNannyByDistance(string addressMom, bool isSort)
        //{
        //    //if no sort return by grouping
        //    if(!isSort)
        //    return from a in dal.getAllNanny()
        //           group a by CalculateDistance(addressMom, a.addressNanny) / 5000;

        //    //if is sort first get all nanny and clac the distance and after return by grouping with order
        //    var nannyList = from a in dal.getAllNanny()
        //                    select a.duplication();

        //    foreach (var a in nannyList)
        //    {
        //        a.Distance = CalculateDistance(addressMom, a.addressNanny);
        //    }

        //    return from a in dal.getAllNanny()
        //           orderby a.Distance
        //           group a by a.Distance / 5000;
        //}

        public IEnumerable<IGrouping<int, Nanny>> getChildByAgeRange(bool minAge, bool isSort)
        {
            if (isSort)
                if (minAge)
                    return from a in dal.getAllNanny()
                           orderby a.minAgeChildNanny
                           group a by a.minAgeChildNanny / 3;
                else
                    return from a in dal.getAllNanny()
                           orderby a.maxAgeChildNanny
                           group a by a.minAgeChildNanny / 3;
            else
                    if (minAge)
                        return from a in dal.getAllNanny()
                               group a by a.minAgeChildNanny / 3;
                    else
                        return from a in dal.getAllNanny()
                               group a by a.minAgeChildNanny / 3;
        }
        #endregion
    }
}
