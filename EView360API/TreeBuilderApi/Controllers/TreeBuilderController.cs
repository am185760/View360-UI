using EView360Models.Core;
using EView360Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace TreeBuilderApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TreeBuilderController : ControllerBase
    {
        private readonly CoreContext _context;

        public TreeBuilderController(CoreContext context)
        {
            _context = context;
        }
        [HttpGet("GetRegionAndAtmByUserId/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                TreeResponseViewModel treeResponse = new();

                List<Region> fetchRegion = (from r in _context.Regions
                                            where r.IsActive == true
                                            orderby r.RegionName
                                            select new Region { RegionName = r.RegionName, RegionId = r.RegionId, ParentRegionId = r.ParentRegionId }).ToList();

                List<AtmViewModel> fetchAtm = (from a in _context.Atms
                                               where a.IsActive == true && (from u in _context.UserAtms where u.UserId == id select u.AtmId).Contains(a.AtmId)
                                               orderby a.Title
                                               select new AtmViewModel { Title = a.Title, Ip = a.Ip, MinOperatingBalance = a.MinOperatingBalance, IsCdm = a.IsCdm, AtmId = a.AtmId, RegionId = a.RegionId, Location = a.Location, IsHealthy = a.IsHealthy, NoteSetTypeId = a.NoteSetTypeId }).ToList();

                //if (fetchRegion?.Count > 0 && fetchAtm?.Count > 0)
                //{
                treeResponse.AtmList = fetchAtm;
                treeResponse.RegionList = fetchRegion;

                return Ok(treeResponse);
                //}
            }
            catch (Exception)
            {
                throw;
            }
            return NoContent();
        }

        [HttpPost("CreateRegion")]
        public async Task<IActionResult> PostRegion(Region region)
        {
            try
            {
                _context.Regions.Add(region);
                await _context.SaveChangesAsync();
                return Ok(region.RegionId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("UpdateAtmTitle")]
        public async Task<IActionResult> UpdateAtmTitle(long atmId, string atmTitle)
        {
            try
            {
                Atm atm = await _context.Atms.FindAsync(atmId);
                if (atm is not null)
                {
                    atm.Title = atmTitle;
                    _context.Entry(atm).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok();
        }

        [HttpPut("UpdateRegionName")]
        public async Task<IActionResult> UpdateRegionName(long regionId, string regionName)
        {
            try
            {
                Region region = await _context.Regions.FindAsync(regionId);
                if (region is not null)
                {
                    region.RegionName = regionName;
                    _context.Entry(region).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok();
        }

        [HttpGet("IfAtmExistByTitle")]
        public async Task<IActionResult> IfAtmExistByTitle(string atmTitle)
        {
            try
            {
                bool atmExist = await _context.Atms.AnyAsync(x => x.Title == atmTitle);
                return Ok(atmExist);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("UpdateAtmRegionId")]
        public async Task<IActionResult> UpdateAtmRegionId(long atmId, long regionId)
        {
            try
            {
                Atm atm = await _context.Atms.FindAsync(atmId);
                if (atm is not null)
                {
                    atm.RegionId = regionId;
                    _context.Entry(atm).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok();
        }

        [HttpPut("UpdateRegionParentId")]
        public async Task<IActionResult> UpdateRegionParentId(long regionId, long parentRegionId)
        {
            try
            {
                Region region = await _context.Regions.FindAsync(regionId);
                if (region is not null)
                {
                    region.ParentRegionId = parentRegionId;
                    _context.Entry(region).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok();
        }

        [HttpDelete("DeleteRegion")]
        public async Task<IActionResult> DeleteRegion(long regionId)
        {
            try
            {
                Region region = await _context.Regions.FindAsync(regionId);
                if (region is not null)
                {
                    _context.Regions.Remove(region);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                return NotFound();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
