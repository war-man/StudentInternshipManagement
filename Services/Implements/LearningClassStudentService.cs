﻿using System;
using System.Linq;
using Models;
using Models.Entities;
using Repositories;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implements
{
    public class LearningClassStudentService : GenericService<LearningClassStudent>, ILearningClassStudentService
    {
        private readonly IGroupService _groupService;
        public LearningClassStudentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public LearningClassStudentService(IUnitOfWork unitOfWork, IGroupService groupService) : base(unitOfWork)
        {
            _groupService = groupService;
        }

        public LearningClassStudent GetById(int classId, int studentId)
        {
            return UnitOfWork.Repository<LearningClassStudent>().TableNoTracking.FirstOrDefault(s => s.ClassId == classId && s.StudentId == studentId);
        }

        public IQueryable<LearningClassStudent> GetByClass(int classId)
        {
            return UnitOfWork.Repository<LearningClassStudent>().TableNoTracking.Where(s => s.ClassId == classId);
        }

        public IQueryable<LearningClassStudent> GetByStudent(int studentId)
        {
            return UnitOfWork.Repository<LearningClassStudent>().TableNoTracking.Where(s => s.StudentId == studentId);
        }

        public IQueryable<LearningClassStudent> GetByTeacher(int teacherId)
        {
            var groups = _groupService.GetByTeacher(teacherId);
            var students = groups.SelectMany(g => g.Members).Select(s => s.Id);
            return GetAll().Where(l => students.Contains(l.StudentId));
        }
    }
}
