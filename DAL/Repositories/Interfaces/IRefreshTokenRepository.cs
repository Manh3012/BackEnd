﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task<bool> Add(RefreshToken refreshToken);
        Task<RefreshToken> FindToken(string refreshToken);
        Task<bool> ChangeStatus(RefreshToken refreshToken);
        Task DeleteAll(long userId);
    }
}
