using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;


namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;
    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<DTOVaultKeep> GetDTOvkByUser(string userId)
    {
      return _repo.GetDTOvkByUser(userId);
    }

    // Get User DTOVaultKeeps by keepId
    internal IEnumerable<DTOVaultKeep> GetDTOkByUser(int keepId, string userId)
    {
      return _repo.GetDTOkByUser(keepId, userId);
    }

    // Get User DTOVaultKeeps by vaultId
    internal IEnumerable<DTOVaultKeep> GetDTOvByUser(int vaultId, string userId)
    {
      return _repo.GetDTOvByUser(vaultId, userId);
    }

    public DTOVaultKeep Get(int id, string userId)
    {
      DTOVaultKeep exists = _repo.GetById(id);
      if (exists == null)
      {
        throw new System.Exception("VaultKeep does not exist!");
      }
      if (exists.userId != userId)
      {
        throw new System.Exception("VaultKeep does not belong to you.");
      }
      return exists;
    }

    // public IEnumerable<DTOVaultKeep> GetKeepsByVaultId(int id)
    // {
    //   return _repo.GetKeepsByVaultId(id);
    // }

    public DTOVaultKeep Create(DTOVaultKeep newVaultKeep)
    {
      _repo.Create(newVaultKeep);
      return newVaultKeep;
    }

    public string Delete(int id, string userId)
    {
      DTOVaultKeep exists = Get(id, userId);
      _repo.Delete(id);
      return "VaultKeep successfully deleted.";
    }
  }
}