using CORE.Abstracts.IServices;
using CORE.Concretes.DTOs;
using CORE.Concretes.Entities.Store;
using CORE.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class ModelService : IModelService
    {
        private readonly IUnitOfWork unitOfWork;

        public ModelService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Reply> CreateModelAsync(string name)
        {
            var repo = unitOfWork.GetRepository<Model>();
            var model = new Model { Name = name };
            await repo.InsertOneAsync(model);
            return await unitOfWork.CommitAsync();
        }

        public IEnumerable<ModelDto> GetModels()
        {
            var repo = unitOfWork.GetRepository<Model>();
            var models = repo.Query();
            return models.Select(b => new ModelDto(b.Id, b.Name));
        }
    }
}
