using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Xml.Linq;
using DS;
using static DS.DSxml;

namespace DAL
{
    internal class Dal_XML_imp : IDal
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
            var temp = (from x in Mothers.Elements()
                where Convert.ToInt32(x.Element("ID").Value) == mother.ID
                select x).FirstOrDefault();
            if(temp!=null)
            {
                Mothers.Add(mother.toXML());
                SaveMothers();
                
            }
            else throw new Exception("Mother with the same ID already exists...");
                
           
           
        }

         public bool RemoveMother(int m)
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

         public void AddContract(Contract c)
        {
            //ContractNannyChild contract = c.clone();
            //contract.ContractId = MaxContractID() + 1;
            //DS.DSxml.Contracts.Add(contract.toXML());

            XElement contract = c.toXML();
            contract.Element("ContractID").Value = (MaxContractID() + 1).ToString();
            DS.DSxml.Contracts.Add(contract);
            DS.DSxml.SaveContracts();

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
        //matanya
         

        private int MaxContractID()
        {
            int result;
            var kayam = DS.DSxml.Contracts.Elements("Contract").Any();

            if (!kayam)
            {
                result = 100000;
            }
            else
            {
                result = (from c in DS.DSxml.Contracts.Elements("Contract")
                          select Int32.Parse(c.Element("ContractID").Value)).Max();
            }

            return result;

        }
       
        public IEnumerable<Mother> getAllMothers()
        {
            XElement root = DS.DSxml.Mothers;
            List<Mother> result = new List<Mother>();
            foreach (var m in root.Elements("Mother"))
            {
                result.Add(m.toMother());
            }
            return result.AsEnumerable();
        }

        public IEnumerable<Contract> getAllContracts()
        {
            XElement root = DS.DSxml.Contracts;
            List<Contract> result = new List<Contract>();
            foreach (var c in root.Elements("Contract"))
            {
                result.Add(c.ToContract());
            }
            return result.AsEnumerable();
        }

      

        public bool RemoveContract(Contract c)
        {
            throw new NotImplementedException();
        }

        public bool idCheck(int id)
        {
           var check1=(from mother in Mothers.Elements()
                       where Convert.ToInt32(mother.Element("ID").Value) == id
               select mother).Any();
            
            var check2 = (from nanny in Nannies.Elements()
                where Convert.ToInt32(nanny.Element("ID").Value) == id
                select nanny).Any();
            var check3 = (from child in Children.Elements()
                where Convert.ToInt32(child.Element("ID").Value) == id
                select child).Any();
            return check3 && check2 && check1;
        }
    }
}
