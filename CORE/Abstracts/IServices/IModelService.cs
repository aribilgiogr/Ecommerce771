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
        ModelDto? GetModel(int id);
        Task<Reply> CreateModelAsync(ModelDto model);
        Task<Reply> UpdateModelAsync(ModelDto model);
        Task<Reply> DeleteModelAsync(int id);
    }
}
