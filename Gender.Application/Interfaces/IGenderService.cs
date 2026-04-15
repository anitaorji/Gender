using Gender.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gender.Application.Interfaces
{
    public interface IGenderService
    {
        Task<ServiceResult> GetGenderAsync(string name);
    }
}
