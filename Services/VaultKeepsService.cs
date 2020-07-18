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

    // public IEnumerable<DTOVaultKeep> GetDbs()
    // {
    //   return _repo.GetAll();
    // }

    public DTOVaultKeep Get(int Id)
    {
      DTOVaultKeep exists = _repo.GetById(Id);
      if (exists == null)
      {
        throw new System.Exception("Invalid VaultKeep buddy!");
      }
      return exists;
    }
    public IEnumerable<DTOVaultKeep> GetKeepsByVaultId(int id)
    {
      return _repo.GetKeepsByVaultId(id);
    }

    public DTOVaultKeep Create(DTOVaultKeep newVaultKeep)
    {
      _repo.Create(newVaultKeep);
      return newVaultKeep;
    }

    public DTOVaultKeep Delete(int id, string userId)
    {
      DTOVaultKeep exists = Get(id);
      _repo.Delete(id);
      return exists;
    }
  }
}