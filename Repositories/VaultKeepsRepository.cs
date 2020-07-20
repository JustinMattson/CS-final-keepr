using System.Data;
using System.Collections.Generic;
using Dapper;
using Keepr.Models;
using System;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<VaultKeep> GetDTOvkByUser(string userId)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE userId = @userId;";
      return _db.Query<VaultKeep>(sql, new { userId });
    }

    // Get User DTO Keeps by vaultId
    internal IEnumerable<VaultKeep> GetDTOKeepsByVaultId(int vaultId, string userId)
    {
      string sql = @"
        SELECT * FROM vaultkeeps WHERE vaultId = @vaultId && userId = @userId;
      ";
      return _db.Query<VaultKeep>(sql, new { vaultId, userId });
    }

    // Get User VaultKeeps by vaultId
    internal IEnumerable<VaultKeep> GetDTOvByUser(int id, string userId)
    {
      string sql = @"
        SELECT * FROM vaultkeeps WHERE vaultId = @id && userId = @userId;
      ";
      return _db.Query<VaultKeep>(sql, new { id, userId });
    }

    internal VaultKeep GetById(int id)
    {
      string sql = "SELECT * FROM vaultkeeps where id = @Id";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id });
    }


    public VaultKeep Create(VaultKeep newVaultKeep)
    {
      string sql = @"
      INSERT INTO vaultkeeps
        (vaultId, keepId, userId)
      VALUES
        (@vaultId, @KeepId, @UserId);
      SELECT LAST_INSERT_ID();";
      newVaultKeep.id = _db.ExecuteScalar<int>(sql, newVaultKeep);
      return newVaultKeep;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM VaultKeeps WHERE id = @Id";
      _db.Execute(sql, new { id });
      // FIXME this should probably return something!
    }

    // public IEnumerable<VaultKeep> GetKeepsByVaultId(int id)
    // {
    //   string sql = @"
    // SELECT
    //   k.*,
    //   vk.id as vaultKeepId
    // FROM vaultkeeps vk
    //   INNER JOIN keeps k on k.id = vk.keepId
    //   WHERE kv.vaultId = @id";
    //   return _db.Query<VaultKeep>(sql, new { id });
    // }
  }
}