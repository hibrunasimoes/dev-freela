﻿using System;
using DevFreela.Domain.Entities;

namespace DevFreela.Domain.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync(); 
    }
}