using CORE.Concretes.DTOs;
using CORE.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Abstracts.IServices
{
    public interface IModelService
    {
        IEnumerable<ModelDto> GetModels();
        Task<Reply> CreateModelAsync(string name);
    }
}
