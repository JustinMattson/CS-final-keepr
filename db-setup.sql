USE keepr252;
-- NOTE all tables can have duplicate rows as there is only one primary key on id which does not guarantee uniqueness other columns...

-- CREATE TABLE vaults (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     userId VARCHAR(255),
--     INDEX userId (userId),  
--     PRIMARY KEY (id)
-- );

-- CREATE TABLE keeps (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     userId VARCHAR(255),
--     img VARCHAR(255),
--     isPrivate TINYINT,
--     views INT DEFAULT 0,
--     shares INT DEFAULT 0,
--     keeps INT DEFAULT 0,
--     INDEX userId (userId),
--     PRIMARY KEY (id)
-- );

-- CREATE TABLE vaultkeeps (
--     id int NOT NULL AUTO_INCREMENT,
--     vaultId int NOT NULL,
--     keepId int NOT NULL,
--     userId VARCHAR(255) NOT NULL,

--     PRIMARY KEY (id),
--     INDEX (vaultId, keepId),
--     INDEX (userId),

--     FOREIGN KEY (vaultId)
--         REFERENCES vaults(id)
--         ON DELETE CASCADE,

--     FOREIGN KEY (keepId)
--         REFERENCES keeps(id)
--         ON DELETE CASCADE
-- )

-- -- USE THIS LINE FOR GET KEEPS BY VAULTID
-- SELECT 
-- k.*,
-- vk.id as vaultKeepId
-- FROM vaultkeeps vk
-- INNER JOIN keeps k ON k.id = vk.keepId 
-- WHERE (vaultId = @vaultId AND vk.userId = @userId) 



-- -- USE THIS TO CLEAN OUT YOUR DATABASE
-- DROP TABLE IF EXISTS vaultkeeps;
-- DROP TABLE IF EXISTS vaults;
-- DROP TABLE IF EXISTS keeps;
-- DROP TABLE IF EXISTS users;


-- Keeps:
-- SELECT * FROM `keepr252`.`keeps` LIMIT 100;
-- DELETE FROM keeps WHERE name LIKE 'TEST%';
-- UPDATE keeps SET userId="vraY84SbrIwTT3dUevCymVza5Xl47kLc@clients" WHERE id = 10;
-- {
--     "name": "Cookie Monster",
--     "description": "Lovable Cookie Dude!",
--     "img": "https://cnet3.cbsistatic.com/img/YuLvQxpo04T02vD5Zp-Cogdim2g=/1200x675/center/top/2019/07/26/26589aa5-6aee-48be-bb2a-2505e411d834/cookie.jpg",
--     "isPrivate": true,
--     "views": 0,
--     "shares": 0,
--     "keeps": 0
-- }
-- {
--     "name": "Somewhere Over the Rainbow",
--     "description": "You're not in Kansas anymore!",
--     "img": "https://images.unsplash.com/photo-1565073182887-6bcefbe225b1?ixlib=rb-1.2.1&w=1000&q=80",
--     "isPrivate": false,
--     "views": 0,
--     "shares": 0,
--     "keeps": 0
-- }
-- {
--     "name": "Please don't delete me!",
--     "description": "Pretty pretty please?",
--     "img": "https://rlv.zcache.co.uk/unhappy_face_6_cm_round_badge-r43e2fbd4603f4c2c9ba5a71cc74b300b_k94rf_540.jpg?rlvnet=1",
--     "isPrivate": true,
--     "views": 0,
--     "shares": 0,
--     "keeps": 0
-- }

-- Vaults:
SELECT * FROM `keepr252`.`vaults` LIMIT 100;
-- UPDATE vaults SET userId="vraY84SbrI@clients" WHERE id = 22;
-- {
--     "id": 9,
--     "userId": "vraY84SbrIwTT3dUevCymVza5Xl47kLc@clients",
--     "name": "Super Funny Stuff",
--     "description": "These things make me laugh out loud!"
-- },
-- {
--     "id": 11,
--     "userId": "vraY84SbrIwTT3dUevCymVza5Xl47kLc@clients",
--     "name": "Stuff to delete!",
--     "description": "Please delete this stuff."
-- },
-- {
--     "id": 23,
--     "userId": "vraY84SbrIwTT3dUevCymVza5Xl47kLc@clients",
--     "name": "More stuff to delete!",
--     "description": "Please delete this stuff."
-- },
-- {
--     "id": 28,
--     "userId": "vraY84SbrIwTT3dUevCymVza5Xl47kLc@clients",
--     "name": "Funny Stuff",
--     "description": "These things make me smile!"
-- }

-- VaultKeeps:
-- SELECT * FROM `keepr252`.`vaultkeeps` LIMIT 100;


-- CleanUp:
-- DELETE FROM keeps WHERE name LIKE '%KEEP%';
-- DELETE FROM vaults where name LIKE '%VAULT';
