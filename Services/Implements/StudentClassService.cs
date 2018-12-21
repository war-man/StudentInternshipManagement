﻿using Models.Entities;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implements
{
    public class StudentClassService : GenericService<StudentClass>, IStudentClassService
    {
        public StudentClassService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}