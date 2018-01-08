/*Written by Matanya Glik && Nachum Shtauber
I.d: 305498594   && 311604854*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;

namespace DAL
{
   public static class  Tools
    {
        public static Mother Clone(this Mother mother)
        {
            Mother clone = new Mother
            {
                ID = mother.ID,
                FirstName = mother.FirstName,
                LastName = mother.LastName,
                Schedule = mother.Schedule.ToArray(),
                SearchArea = mother.SearchArea,
                Telephone = mother.Telephone,
                Address = mother.Address,
                MonthlyOrHourly = mother.MonthlyOrHourly,
                Budget=mother.Budget,
                KosherFood = mother.KosherFood,
                MaxDistance = mother.MaxDistance,
                WantsElevator=mother.WantsElevator,
                WantedExperience=mother.WantedExperience,
                Vacation =mother.Vacation,
                Recommendation=mother.Recommendation
               
           };

            return clone;
        }
        public static Nanny Clone(this Nanny nanny)
        {
            Nanny clone = new Nanny
            {
                ID = nanny.ID,
                FirstName = nanny.FirstName,
                LastName = nanny.LastName,
                Address = nanny.Address,
                Birthday=nanny.Birthday,
                Experience = nanny.Experience,
                Floor = nanny.Floor,
                HourlyWage = nanny.HourlyWage,
                MonthlyWage = nanny.MonthlyWage,
                IsElevator = nanny.IsElevator,
                KidsCapacity = nanny.KidsCapacity,
                MinimumAge = nanny.MinimumAge,
                MaximumAge = nanny.MaximumAge,
                Telephone = nanny.Telephone,
                Schedule = nanny.Schedule.ToArray(),
                Recommendation = nanny.Recommendation,
                Vacation = nanny.Vacation,
                KosherFood = nanny.KosherFood

                 
            };

            return clone;
        }
        public static Child Clone(this Child child)
        {
            Child clone = new Child
            {
                ID = child.ID,
                MotherID = child.MotherID,
                Name = child.Name,
                Birthday = child.Birthday,
                SpecialNeeds = child.SpecialNeeds,
                Needs=child.Needs

            };

            return clone;
        }

        public static Contract Clone(this Contract contract)
        {
            Contract clone = new Contract
            {
                ChildId = contract.ChildId,
                MotherId = contract.MotherId,
                ContractNumber = contract.ContractNumber,
                EndDate = contract.EndDate,
                HourlyWage = contract.HourlyWage,
                Interview = contract.Interview,
                MonthlyWage = contract.MonthlyWage,
                NannyId = contract.NannyId,
                Rate = contract.Rate,
                Signed = contract.Signed,
                StartDate = contract.StartDate,
                Salary=contract.Salary 
            };
            return clone;
        }

        
       

        public static Child ToChild(this XElement childXml)
        {
            Child result = null;
            if (childXml == null)
            {
                return result;
            }
            else
            {
                result=new Child
                {
                    Name = childXml.Element("Name").Value,
                    Birthday = Convert.ToDateTime(childXml.Element("Birthday")),
                    ID = int.Parse(childXml.Element("ID").Value),
                    MotherID = int.Parse(childXml.Element("MotherID").Value),
                    Needs = childXml.Element("Needs").Value,
                    SpecialNeeds = bool.Parse(childXml.Element("SpecialNeeds").Value)
                };
                return result;
            }
        }
        public static Nanny ToNanny(this XElement nannyXml)
        {
            Nanny result = null;
            if (nannyXml == null)
            {
                return result;
            }
            else
            {
                result = new Nanny
                {
                    ID = int.Parse(nannyXml.Element("ID").Value),
                    FirstName = nannyXml.Element("FirstName").Value,
                    LastName = nannyXml.Element("LastName").Value,
                    Address = nannyXml.Element("Address").Value,
                    Birthday = Convert.ToDateTime(nannyXml.Element("Birthday")),
                    Floor = Convert.ToInt32(nannyXml.Element("Floor")),
                    Schedule = (from d in nannyXml.Element("Schedule").Elements("Day")
                        from t in d.Elements("Time")
                        select new Schedule
                        {
                            StartTime = new Time(
                                int.Parse(t.Element("Hour").Value),
                                int.Parse(t.Element("Minute").Value)),
                            EndTime = new Time(
                                int.Parse(t.Element("Hour").Value),
                                int.Parse(t.Element("Minute").Value)),
                            IsWorking = Convert.ToBoolean(t.Element("IsWorking").Value)
                        }).ToArray(),
                    Recommendation = nannyXml.Element("Recommendation").Value,
                    Vacation = bool.Parse(nannyXml.Element("Vacation").Value),
                    KosherFood = bool.Parse(nannyXml.Element("KosherFood").Value),
                    Telephone = nannyXml.Element("Telephone").Value,
                    MonthlyWage = double.Parse(nannyXml.Element("MonthlyWage").Value),
                    HourlyWage = double.Parse(nannyXml.Element("HourlyWage").Value),
                    Experience = int.Parse(nannyXml.Element("Experience").Value),
                    IsElevator = bool.Parse(nannyXml.Element("IsElevator").Value),
                    KidsCapacity = int.Parse(nannyXml.Element("KidsCapacity").Value),
                    MaximumAge = int.Parse(nannyXml.Element("MaximumAge").Value),
                    MinimumAge = int.Parse(nannyXml.Element("MinimumAge").Value)
                };
                return result;
            }
        }
        public static Mother toMother(this XElement motherXml)
        {
            Mother result = null;
            if (motherXml == null)
            {
                return result;
            }
            else
            {
                result = new Mother
                {
                    ID = int.Parse(motherXml.Element("ID").Value),
                    FirstName = motherXml.Element("FirstName").Value,
                    LastName = motherXml.Element("LastName").Value,
                    SearchArea = motherXml.Element("SearchArea").Value,
                    Address = motherXml.Element("Address").Value,
                    Telephone = motherXml.Element("Telephone").Value,
                    Schedule = (from d in motherXml.Element("Schedule").Elements("Day")
                        from t in d.Elements("Time")
                        select new Schedule
                        {
                            StartTime = new Time(
                                int.Parse(t.Element("Hour")?.Value),
                                int.Parse(t.Element("Minute")?.Value)),
                            EndTime = new Time(
                                int.Parse(t.Element("Hour")?.Value),
                                int.Parse(t.Element("Minute")?.Value)),
                            IsWorking = Convert.ToBoolean(t.Element("IsWorking")?.Value)
                        }).ToArray(),
                    MonthlyOrHourly = motherXml.Element("Rate").Value.toMonthlyOrHourly(),
                    Recommendation =
                        Convert.ToBoolean(motherXml.Element("Recommendation")?.Value),
                    Vacation = Convert.ToBoolean(motherXml.Element("Vacation")),
                    KosherFood = Convert.ToBoolean(motherXml.Element("KosherFood")),
                    WantsElevator = Convert.ToBoolean(motherXml.Element("WantsElevator")),
                    Budget = Convert.ToInt32(motherXml.Element("Budget")),
                    MaxDistance = Convert.ToInt32(motherXml.Element("MaxDistance")),
                    WantedExperience = Convert.ToInt32(motherXml.Element("WantedExperience"))
                };
                return result;
            }
        }
    }
}
