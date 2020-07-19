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

    internal IEnumerable<DTOVaultKeep> GetDTOvkByUser(string userId)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE userId = @userId;";
      return _db.Query<DTOVaultKeep>(sql, new { userId });
    }

    // Get User VaultKeeps by keepId
    internal IEnumerable<DTOVaultKeep> GetDTOkByUser(int id, string userId)
    {
      string sql = @"
        SELECT * FROM vaultkeeps WHERE keepId = @id && userId = @userId;
      ";
      return _db.Query<DTOVaultKeep>(sql, new { id, userId });
    }

    // Get User VaultKeeps by vaultId
    internal IEnumerable<DTOVaultKeep> GetDTOvByUser(int id, string userId)
    {
      string sql = @"
        SELECT * FROM vaultkeeps WHERE vaultId = @id && userId = @userId;
      ";
      return _db.Query<DTOVaultKeep>(sql, new { id, userId });
    }

    internal DTOVaultKeep GetById(int id)
    {
      string sql = "SELECT * FROM vaultkeeps where id = @Id";
      return _db.QueryFirstOrDefault<DTOVaultKeep>(sql, new { id });
    }


    public int Create(DTOVaultKeep newDTOVaultKeep)
    {
      string sql = @"
    INSERT INTO vaultkeeps
      (vaultId, keepId, userId)
    VALUES
      (@vaultId, @KeepId, @UserId);
    SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newDTOVaultKeep);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM VaultKeeps WHERE id = @Id";
      _db.Execute(sql, new { id });
    }

    // public IEnumerable<DTOVaultKeep> GetKeepsByVaultId(int id)
    // {
    //   string sql = @"
    // SELECT
    //   k.*,
    //   vk.id as vaultKeepId
    // FROM vaultkeeps vk
    //   INNER JOIN keeps k on k.id = vk.keepId
    //   WHERE kv.vaultId = @id";
    //   return _db.Query<DTOVaultKeep>(sql, new { id });
    // }
  }
}