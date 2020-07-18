using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;
    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Keep> Get()
    {
      return _repo.Get();
    }

    internal IEnumerable<Keep> GetKeepsByUserId(string userId)
    {
      return _repo.GetKeepsByUserId(userId);
    }

    internal Keep GetKeepById(int id)
    {
      Keep foundKeep = _repo.GetKeepById(id);
      if (foundKeep == null)
      {
        throw new Exception("Invalid Id");
      }
      return foundKeep;
    }

    public Keep Create(Keep newKeep)
    {
      return _repo.Create(newKeep);
    }

    // KeepToUpdate (ktu) can be updated by clicking the Keep button
    // Count keeps++ when added to Vault
    // Count keeps-- when removed from Vault
    // Count view++ on router KeepsDetails
    internal Keep Edit(Keep ktu, string userId)
    {
      Keep original = GetKeepById(ktu.Id);
      if (ktu == null)
      {
        throw new Exception("Invalid Id");
      }
      // original.Name = ktu.Name == null ? original.Name : ktu.Name;
      // original.Description = ktu.Name == null ? original.Description : ktu.Description;
      // Author/userId is not to be changed. Ever.
      // original.Img = ktu.Img == null ? original.Img : ktu.Img;
      original.IsPrivate = ktu.IsPrivate == original.IsPrivate ? original.IsPrivate : ktu.IsPrivate;
      original.Views = ktu.Views != 0 ? ktu.Views : original.Views;
      // original.Shares = ktu.Shares != 0 ? ktu.Shares : original.Shares;
      original.Keeps = ktu.Keeps != 0 ? ktu.Keeps : original.Keeps;
      _repo.Edit(ktu);
      return original;
    }

    // Only user/author can delete, and only if isPrivate == true
    internal string Delete(int id, string userId)
    {
      Keep foundKeep = GetKeepById(id);
      if (foundKeep.UserId != userId)
      {
        throw new Exception("This is not your Keep!");
      }
      if (_repo.Delete(id, userId))
      {
        return "successfully deleted.";
      }
      throw new Exception("Public Keeps cannot be deleted!");
    }
  }
}