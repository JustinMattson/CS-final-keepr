using System;
using System.Collections.Generic;
using System.Security.Claims;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  [Authorize]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vks;
    public VaultKeepsController(VaultKeepsService vks)
    {
      _vks = vks;
    }

    [HttpGet("user")]
    public ActionResult<IEnumerable<DTOVaultKeep>> GetDTOvkByUser()
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_vks.GetDTOvkByUser(userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // Get User DTOVaultKeeps by keepId
    [HttpGet("{id}" + "/keeps")]
    public ActionResult<IEnumerable<DTOVaultKeep>> GetDTOkByUser(int id)
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        int keepId = id;
        return Ok(_vks.GetDTOkByUser(keepId, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    // Get User DTOVaultKeeps by vaultId
    [HttpGet("{id}" + "/vaults")]
    public ActionResult<IEnumerable<DTOVaultKeep>> GetDTOvByUser(int id)
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        int vaultId = id;
        return Ok(_vks.GetDTOvByUser(vaultId, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<DTOVaultKeep> Post([FromBody] DTOVaultKeep newDTOVaultKeep)
    {
      try
      {
        newDTOVaultKeep.userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_vks.Create(newDTOVaultKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpDelete("{id}")]
    public ActionResult<DTOVaultKeep> Delete(int id)
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_vks.Delete(id, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}