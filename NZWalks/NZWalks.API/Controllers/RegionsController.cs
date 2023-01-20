﻿using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionRepository;

        public RegionsController(IRegionRepository regionRepository)
        {
            this.regionRepository = regionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            /* var regions = new List<Region>()
             {
                 new Region
                 {
                     Id = Guid.NewGuid(),
                     Name = "Wellington",
                     Code = "WLG",
                     Area = 227755,
                     Lat = 1.8822,
                     Long = 399.88,
                     Population = 500000
                 },
                 new Region {
                     Id = Guid.NewGuid(),
                     Name = "Auckland",
                     Code = "AUCk",
                     Area = 227755,
                     Lat = 1.8822,
                     Long = 399.88,
                     Population = 500000
                 }

             };*/
            /*var regions = regionRepository.GetAll();
             return Ok(regions);*/
            var regions = await regionRepository.GetAllAsync();

            var regionsDTO = new List<Models.DTO.Region>();
            regions.ToList().ForEach(region =>
            {
                var regionDTO = new Models.DTO.Region()
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    Area = region.Area,
                    Lat= region.Lat,   
                    Long= region.Long,
                    Population= region.Population,
                };
                regionsDTO.Add(regionDTO);
            });
            return Ok(regionsDTO);
        }

       
    }
}
