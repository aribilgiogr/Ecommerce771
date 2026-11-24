using AutoMapper;
using CORE.Abstracts.IServices;
using CORE.Concretes.DTOs;
using CORE.Concretes.Entities.Store;
using CORE.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace BLL.Services
{
    public class ModelService : IModelService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public ModelService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Reply> CreateModelAsync(ModelDto model)
        {
            var repo = unitOfWork.GetRepository<Model>();
            await repo.InsertOneAsync(mapper.Map<Model>(model));
            return await unitOfWork.CommitAsync();
        }

        public async Task<Reply> DeleteModelAsync(int id)
        {
            var repo = unitOfWork.GetRepository<Model>();
            var model = await repo.Query().FirstOrDefaultAsync(x => x.Id == id);
            if (model != null)
            {
                repo.DeleteOne(model);
                return await unitOfWork.CommitAsync();
            }
            return Reply.Fail("Model bulunamadı!");
        }

        public ModelDto? GetModel(int id)
        {
            var repo = unitOfWork.GetRepository<Model>();
            var model = repo.Query().FirstOrDefault(x => x.Id == id);
            return mapper.Map<ModelDto>(model);
        }

        public IEnumerable<ModelDto> GetModels()
        {
            var repo = unitOfWork.GetRepository<Model>();
            var models = repo.Query().ToList();
            return mapper.Map<IEnumerable<ModelDto>>(models);
        }

        public async Task<Reply> UpdateModelAsync(ModelDto model)
        {
            var repo = unitOfWork.GetRepository<Model>();
            var item = await repo.Query().FirstOrDefaultAsync(x => x.Id == model.Id);
            if (item != null)
            {
                item.Name = model.Name;
                repo.UpdateOne(item);
                return await unitOfWork.CommitAsync();
            }
            return Reply.Fail("Model bulunamadı!");
        }
    }
}
