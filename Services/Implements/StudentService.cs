﻿using System;
using System.Linq;
using Models;
using Models.Entities;
using Repositories;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implements
{
    public class StudentService : GenericService<Student>, IStudentService
    {
        private readonly ILearningClassStudentService _learningClassStudentService;
        private readonly ISemesterService _semesterService;
        public StudentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public StudentService(IUnitOfWork unitOfWork, ILearningClassStudentService learningClassStudentService, ISemesterService semesterService) : base(unitOfWork)
        {
            _learningClassStudentService = learningClassStudentService;
            _semesterService = semesterService;
        }

        public IQueryable<Student> GetByStudentClass(int classId)
        {
            return UnitOfWork.Repository<Student>().TableNoTracking.Where(s => s.ClassId == classId);
        }


        public IQueryable<LearningClass> GetLearningClassList(int studentId)
        {
            return _learningClassStudentService.GetByStudent(studentId).Select(x => x.Class);
        }

        public IQueryable<LearningClass> GetLearningClassBySemesterList(int studentId)
        {
            var semesterId = _semesterService.GetLatest().Id;
            return GetLearningClassList(studentId).Where(c => c.SemesterId == semesterId);
        }
    }
}