﻿using Extensibility;
using System;
using System.Collections.Generic;
using Domain;
using System.IO;
using System.Linq;
using System.Text;
using Domain;

namespace Service
{
    public class HRLogic : IHRLogic
    {
        IUnitOfWork UoW;

        public HRLogic(IUnitOfWork uoW)
        {
            this.UoW = uoW;
        }

        public IEnumerable<Specialization> GetSpecializationList()
        {            
            return UoW.Specializations.GetAll();            
        }

        public bool DeleteSpecialization (int id)
        {
            if (UoW.Specializations.Find(id) != null)
            {
                UoW.Specializations.Delete(UoW.Specializations.Find(id));
                return UoW.Commit();
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Skill> GetSkillList()
        {
            return UoW.Skills.GetAll();

        }

        public bool DeleteSkill(int SkillId)
        {
            UoW.Skills.Delete(UoW.Skills.Find(SkillId));
            var isOk = UoW.Commit();
            if (isOk)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CreateSkill(Skill skill)
        {
            try
            {
                UoW.Skills.Create(skill);                
                return UoW.Commit();                
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Skill GetSkill(int id)
        {
            return UoW.Skills.Find(id);
        }

        public bool EditSkill(Skill skill)
        {

            UoW.Skills.Update(skill.SkillId, skill.Name);

            List<SkillLevel> OldSkillLevels = UoW.Skills.Find(skill.SkillId).SkillLevels.ToList<SkillLevel>();
            List<SkillLevel> NewSkillLevels = skill.SkillLevels.ToList<SkillLevel>();

            foreach (SkillLevel OldSkillLevel in OldSkillLevels)
            {
                bool exist = false;

                foreach (SkillLevel newSkillLevel in NewSkillLevels)
                {
                    if (OldSkillLevel.SkillLevelId == newSkillLevel.SkillLevelId)
                    {
                        UoW.SkillLevels.Update(newSkillLevel.SkillLevelId, newSkillLevel.Name, newSkillLevel.Description, newSkillLevel.SkillId, newSkillLevel.Level);
                        exist = true;
                    }
                }

                if (exist == false)
                {
                    UoW.SkillLevels.Delete(OldSkillLevel);
                }
            }
            foreach (SkillLevel newSkillLevel in NewSkillLevels)
            {
                if (newSkillLevel.SkillLevelId == 0)
                {
                    newSkillLevel.SkillId = skill.SkillId;
                    UoW.SkillLevels.Create(newSkillLevel);
                }
            }
            
            return UoW.Commit();
        }
    }
}