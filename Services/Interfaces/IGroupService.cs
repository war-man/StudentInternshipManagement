﻿using System.Linq;
using System.Threading.Tasks;
using Models;
using Models.Entities;

namespace Services.Interfaces
{
    public interface IGroupService:IGenericService<Group>
    {
        Group GetByInternship(Internship internship);
        Task<Group> GetByInternshipAsync(Internship internship);
        IQueryable<Group> GetByStudent(int studentId);
        IQueryable<Group> GetByTeacher(int teacherId);
        IQueryable<Group> GetBySemester(int semesterId);
    }
}