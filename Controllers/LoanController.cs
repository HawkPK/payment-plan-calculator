using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using payment_plan_calculator.Controllers.Resources;
using payment_plan_calculator.Mapping.Interface;
using payment_plan_calculator.Model;
using payment_plan_calculator.Service.DataAccess;
using payment_plan_calculator.Service.Domain.Interface;

namespace payment_plan_calculator.Controllers
{
    [Route("api/[controller]")]
    public class LoanController
    {
        private ILoanPlannerBuilder _loanPlannerBuilder;
        private readonly IResourceMapper _resourceMapper;
        public LoanController(ILoanPlannerBuilder loanPlannerBuilder, IResourceMapper resourceMapper)
        {
            _loanPlannerBuilder = loanPlannerBuilder;
            _resourceMapper = resourceMapper;
        }
        [HttpGet("[action]")]
        public IEnumerable<InstallmentResource> Detail([FromQuery]int value, [FromQuery]int repaymentPeriod, 
            [FromQuery]int loanTypeId)
        {
            Console.WriteLine(loanTypeId);
            IList<InstallmentResource> installmentResources = new List<InstallmentResource>();
            var installments = _loanPlannerBuilder.GetInstallmentPlan(loanTypeId, value, repaymentPeriod);
            foreach(var installment in installments)
            {          
                var installmentResource = _resourceMapper.MapToInstallmentResource(installment);
                installmentResources.Add(installmentResource);
            }
            return (IEnumerable<InstallmentResource>)installmentResources;
        }
        [HttpGet("[action]")]
        public IEnumerable<OfferResource> Offer()
        {
            LoanDao loanDao = new LoanDao();
            var offerts = loanDao.GetAllOferts();
            var offerResources = _resourceMapper.MapToOfferResource(offerts);
            return offerResources;
        }
    }
}
