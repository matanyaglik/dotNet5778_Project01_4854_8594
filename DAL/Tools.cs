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
    }
}
