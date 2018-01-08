using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    class DAL_XML_imp:IDal
    {
        public void AddNanny(Nanny nanny)
        {
            throw new NotImplementedException();
        }

        public bool RemoveNanny(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateNanny(Nanny nanny)
        {
            throw new NotImplementedException();
        }

        public Nanny GetNanny(int id)
        {
            throw new NotImplementedException();
        }

        public void AddMother(Mother mother)
        {
            throw new NotImplementedException();
        }

        public bool RemoveMother(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateMother(Mother mother)
        {
            throw new NotImplementedException();
        }

        public Mother GetMother(int id)
        {
            throw new NotImplementedException();
        }

        public void AddChild(Child child)
        {
            throw new NotImplementedException();
        }

        public bool RemoveChild(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateChild(Child child)
        {
            throw new NotImplementedException();
        }

        public Child GetChild(int id)
        {
            throw new NotImplementedException();
        }

        public void AddContract(Contract contract)
        {
            throw new NotImplementedException();
        }

        public bool RemoveContract(int contractNumber)
        {
            throw new NotImplementedException();
        }

        public void UpdateContract(Contract contract)
        {
            throw new NotImplementedException();
        }

        public Contract GetContract(int contractNumber)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Nanny> GetNannies(Func<Nanny, bool> predicate = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Mother> GetMothers(Func<Mother, bool> predicate = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Child> GetChildrenByMother(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contract> GetContracts(Func<Contract, bool> predicate = null)
        {
            throw new NotImplementedException();
        }
    }
}
