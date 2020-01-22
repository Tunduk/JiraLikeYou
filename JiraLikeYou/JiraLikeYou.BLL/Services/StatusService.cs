using System;
using System.Collections.Generic;
using System.Linq;
using JiraLikeYou.BLL.Mappers;
using JiraLikeYou.BLL.Models.Status;
using JiraLikeYou.BLL.Validators;
using JiraLikeYou.BLL.Validators.Common;
using JiraLikeYou.DAL;
using JiraLikeYou.DAL.Repositories;

namespace JiraLikeYou.BLL.Services
{
    public interface IStatusService
    {
        void Create(StatusCreateModel createModel);
        void Update(StatusUpdateModel statusUpdateModel);
        void Delete(int statusId);
        StatusModel GetById(int id);
        IEnumerable<StatusModel> GetAll();
    }

    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;
        private readonly IStatusMapper _statusMapper;
        private readonly IStatusValidator _statusValidator;
        private readonly IUnitOfWork _unitOfWork;

        public StatusService(IStatusRepository statusRepository, IStatusMapper statusMapper, IStatusValidator statusValidator, IUnitOfWork unitOfWork)
        {
            _statusRepository = statusRepository;
            _statusMapper = statusMapper;
            _statusValidator = statusValidator;
            _unitOfWork = unitOfWork;
        }


        public StatusModel GetById(int id)
        {
            return _statusMapper.MapFromEntity(_statusRepository.GetById(id));
        }

        public IEnumerable<StatusModel> GetAll()
        {
            return _statusRepository.GetAll().AsEnumerable().Select(_statusMapper.MapFromEntity);
        }

        public void Create(StatusCreateModel createModel)
        {
            EnsureValid(_statusValidator.ValidateCreate(createModel));
            _statusRepository.Add(_statusMapper.MapFromCreateModel(createModel));
            _unitOfWork.Commit();
        }

        public void Delete(int statusId)
        {
            _statusRepository.Delete(statusId);
            _unitOfWork.Commit();
        }

        public void Update(StatusUpdateModel statusUpdateModel)
        {
            EnsureValid(_statusValidator.ValidateUpdate(statusUpdateModel));
            _statusRepository.Update(_statusMapper.MapFromUpdateModel(statusUpdateModel));
            _unitOfWork.Commit();
        }


        private void EnsureValid(ValidateResult validateResult)
        {
            if (validateResult.IsValid)
                return;
            throw new Exception(CreateErrorMesssage(validateResult));
        }

        private string CreateErrorMesssage(ValidateResult validationResult)
        {
            return string.Join(";", validationResult.Errors);
        }
    }
}