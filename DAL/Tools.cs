/*Written by Matanya Glik && Nachum Shtauber
I.d: 305498594   && 311604854*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;
using Microsoft.Win32.SafeHandles;

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
        public static XElement toXML(this Time time, string attribute = "undefined")
        {
            return new XElement("Time", new XAttribute("type", attribute),
                new XElement("Hour", time.Hour),
                new XElement("Minutes", time.Minute));

        }

        public static XElement toXML(this Mother mother)
        {
            return new XElement("Mother",
                new XElement("ID", mother.ID),
                new XElement("FirstName", mother.FirstName),
                new XElement("LastName", mother.LastName),
               
                new XElement("Address", mother.Address),
                new XElement("SearchArea", mother.SearchArea),
                new XElement("MaxDistance",mother.MaxDistance),
                new XElement("Schedule",
                    (from d in mother.Schedule
                     select new XElement($"Day",new XElement("isWorking",d.IsWorking),
                         new XElement(d.StartTime.toXML("Start")),
                         new XElement(d.EndTime.toXML("End"))
                     )
                    )
                ),
                new XElement("Telephone", mother.Telephone),
                new XElement("Rate",mother.MonthlyOrHourly),
                new XElement("Budget",mother.Budget),
                new XElement("KosherFood",mother.KosherFood),
                new XElement("WantsExperience",mother.WantedExperience),
                new XElement("WantsElevator",mother.WantsElevator),
                new XElement("Vacation",mother.Vacation),
                new XElement("Recommendation",mother.Recommendation)
            );
        }
        public static XElement toXML(this Contract contract)
        {
            return new XElement("Contract",
                new XElement("ContractNumber", contract.ContractNumber),
                new XElement("MotherId", contract.MotherId),
                new XElement("NannyId", contract.NannyId),
                new XElement("ChildId", contract.ChildId),
                new XElement("Interview",contract.Interview),
                new XElement("HourlyWage",contract.HourlyWage),
                new XElement("MonthlyWage",contract.MonthlyWage),
                new XElement("Salary",contract.Salary),
                new XElement("Rate",contract.Rate),
                new XElement("StartDate",contract.StartDate.ToShortDateString()),
                new XElement("EndDate",contract.EndDate.ToShortDateString()),
                new XElement("Signed",contract.Signed)

          );
        }

        public static XElement toXML(this Nanny nanny)
        {
            return new XElement("Nanny",
                new XElement("ID",nanny.ID),
                new XElement("FirstName",nanny.FirstName),
                new XElement("LastName",nanny.LastName),
                new XElement("Birthday",nanny.Birthday),
                new XElement("Telephone", nanny.Telephone),
                new XElement("Address",nanny.Address),
                new XElement("Floor",nanny.Floor),
                new XElement("IsElevator",nanny.IsElevator),
                new XElement("Experience",nanny.Experience),
                new XElement("KidsCapacity",nanny.KidsCapacity),
                new XElement("MinimumAge",nanny.MinimumAge),
                new XElement("MaximumAge",nanny.MaximumAge),
                new XElement("HourlyWage",nanny.HourlyWage),
                new XElement("MonthyWage",nanny.MonthlyWage),
                new XElement("Vacation",nanny.Vacation),
                new XElement("Recommendation",nanny.Recommendation),
                new XElement("KosherFood",nanny.KosherFood),
                new XElement("Schedule",
                    (from d in nanny.Schedule
                        select new XElement($"Day", new XElement("isWorking", d.IsWorking),
                            new XElement(d.StartTime.toXML("Start")),
                            new XElement(d.EndTime.toXML("End"))
                         )
                        )
                     )
                );
        }

        public static XElement toXML(this Child child)
        {
            return new XElement("Child",
                new XElement("ID",child.ID),
                new XElement("Name",child.Name),
                new XElement("MotherID",child.MotherID),
                new XElement("Birthday",child.Birthday.ToShortDateString()),
                new XElement("SpecialNeeds",child.SpecialNeeds),
                (child.SpecialNeeds)? new XElement("Needs",child.Needs) : new XElement("Needs", "")
                );
        }
        public static Contract toContract(this XElement contractrXml)
        {
            Contract result = null;
            if (contractrXml == null)
            {
                return result;
            }
            else
            {
                //TO DO
            }
            return result;
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
                    ID = Int32.Parse(motherXml.Element("ID").Value),
                    FirstName = motherXml.Element("FirstName").Value,
                    LastName = motherXml.Element("LastName").Value,
                    Location = motherXml.Element("Location").Value,
                    Address = motherXml.Element("Address").Value,
                    CellPhone = motherXml.Element("CellPhone").Value,
                    WantedDays = (from e in motherXml.Element("WantedDaysArray").Elements("DayBool")
                                  select Boolean.Parse(e.Value)).ToArray(),
                    Days = (from d in motherXml.Element("DaysArray").Elements("Day")
                            from t in d.Elements("Time")
                            select new Day
                            {
                                Start = new Time(
                                    Int32.Parse(t.Element("Hour").Value),
                                    Int32.Parse(t.Element("Minutes").Value),
                                    Int32.Parse(t.Element("Seconds").Value)),
                                End = new Time(
                                    Int32.Parse(t.Element("Hour").Value),
                                    Int32.Parse(t.Element("Minutes").Value),
                                    Int32.Parse(t.Element("Seconds").Value)),
                            }).ToList()
                };
                return result;
            }
        }

        public static Contract ToContract(this XElement contractXml)
        {
            Contract result=new Contract
            {
                ContractNumber = Int32.Parse(contractXml.Element("ContractNumber").Value),
                ChildId=Int32.Parse(contractXml.Element("childId").Value),
                MotherId = Int32.Parse(contractXml.Element("MotherId").Value),
                NannyId = Int32.Parse(contractXml.Element("NannyId").Value),
                StartDate = Convert.ToDateTime(contractXml.Element("StartDate").Value),
                EndDate = Convert.ToDateTime(contractXml.Element("EndDate").Value), Rate = 
                
            };
        }

    }
}
