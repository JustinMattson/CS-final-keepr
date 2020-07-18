using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;
    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Vault> Get(string userId)
    {
      return _repo.Get(userId);
    }

    internal Vault GetVaultById(int id, string userId)
    {
      Vault foundVault = _repo.GetVaultById(id);
      if (foundVault == null || foundVault.UserId != userId)
      {
        throw new Exception("This vault does not belong to you.");
      }
      return foundVault;
    }

    public Vault Create(Vault newVault)
    {
      return _repo.Create(newVault);
    }

    // VaultToUpdate (vtu)
    internal Vault Edit(Vault vtu)
    {
      Vault original = GetVaultById(vtu.Id, vtu.UserId);
      if (vtu == null || original.UserId != vtu.UserId)
      {
        throw new Exception("Invalid Id");
      }
      original.Name = vtu.Name == null ? original.Name : vtu.Name;
      original.Description = vtu.Name == null ? original.Description : vtu.Description;
      // Author/userId is not to be changed. Ever.
      // original.Img = vtu.Img == null ? original.Img : vtu.Img;
      // original.IsPrivate = vtu.IsPrivate == original.IsPrivate ? original.IsPrivate : vtu.IsPrivate;
      // original.Views = vtu.Views != 0 ? vtu.Views : original.Views;
      // original.Shares = vtu.Shares != 0 ? vtu.Shares : original.Shares;
      // original.Vaults = vtu.Vaults != 0 ? vtu.Vaults : original.Vaults;
      _repo.Edit(vtu);
      return original;
    }

    // Only user/author can delete
    // Probably easier to handle validation in Repository
    // Leaving similar to Keep.Delete for now...since it appears the keepr-testing-tool needs confimation.
    internal string Delete(int id, string userId)
    {
      Vault foundVault = GetVaultById(id, userId);
      if (foundVault.UserId != userId)
      {
        throw new Exception("This is not your Vault!");
      }
      if (_repo.Delete(id, userId))
      {
        return "successfully deleted.";
      }
      throw new Exception("Something unexpected happened?");
    }
  }
}